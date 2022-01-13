using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Abp.Domain.Repositories;
using Abp.EntityHistory;
using Abp.Runtime.Validation;
using Abp.UI;
using Bogus;
using Castle.MicroKernel.Registration;
using NSubstitute;
using NSubstitute.ReturnsExtensions;
using SBCRM.Crm;
using SBCRM.Crm.Dtos;
using SBCRM.Legacy;
using SBCRM.Legacy.Dtos;
using SBCRM.Test.Base.Configuration;
using Xunit;

namespace SBCRM.Tests.Crm
{
    /// <summary>
    /// Tests suite for Customers(Accounts) Service
    /// </summary>
    public class CustomerAppServiceTests : AppTestBase
    {
        [Fact]
        [Trait("Category", "UnitTest")]
        public async Task CreateCustomer_WithNameAlreadyExist_ReturnsError()
        {
            // Arrange
            var existingCustomer = new Faker<Customer>()
                .RuleFor(u => u.Name, (f) => f.Company.CompanyName())
                .RuleFor(u => u.Phone, (f) => f.Phone.PhoneNumber())
                .Generate(20);

            var customer = new CreateOrEditCustomerDto { Name = existingCustomer.First().Name, Phone = existingCustomer.First().Phone };

            var fakeCustomerRepository = Substitute.For<IRepository<Customer>>();
            fakeCustomerRepository.GetAll().Returns(_ => existingCustomer.AsAsyncQueryable());

            Register(Component.For<IRepository<Customer>>().Instance(fakeCustomerRepository).IsDefault());

            // Act
            async Task CustomerCreationDelegate() => await Resolve<ICustomerAppService>().CreateOrEdit(customer);

            // Assert
            var userFriendlyException = await Assert.ThrowsAsync<UserFriendlyException>(CustomerCreationDelegate);
            Assert.Equal(L("CustomerNameAlreadyExist"),userFriendlyException.Message);
        }

        [Fact]
        [Trait("Category", "UnitTest")]
        public async Task CreateCustomer_WithInvalidFields_ReturnsError()
        {
            // Arrange
            var customer = new CreateOrEditCustomerDto { Name = string.Empty, Phone = string.Empty };

            var fakeCustomerRepository = Substitute.For<IRepository<Customer>>();
            fakeCustomerRepository.GetAll().Returns(_ => new List<Customer>().AsAsyncQueryable());

            Register(Component.For<IRepository<Customer>>().Instance(fakeCustomerRepository).IsDefault());

            // Act
            async Task CustomerCreationDelegate() => await Resolve<ICustomerAppService>().CreateOrEdit(customer);

            // Assert
            var validationException = await Assert.ThrowsAsync<AbpValidationException>(CustomerCreationDelegate);
            Assert.NotNull(validationException);
            Assert.NotEmpty(validationException.ValidationErrors);
        }


        [Fact]
        [Trait("Category", "UnitTest")]
        public async Task CreateCustomer_WithValidFields_ButDefaultAccountTypeIsNotDefined_ReturnsError()
        {
            // Arrange
            var customer = new Faker<CreateOrEditCustomerDto>()
                .RuleFor(u => u.Name, (f) => f.Company.CompanyName())
                .RuleFor(u => u.Phone, (f) => f.Phone.PhoneNumber())
                .Generate(1)
                .First();
            
            var fakeCustomerRepository = Substitute.For<IRepository<Customer>>();
            fakeCustomerRepository.GetAll().Returns(_ => new List<Customer>().AsAsyncQueryable());

            var fakeAccountTypeRepository = Substitute.For<IRepository<AccountType>>();
            (fakeAccountTypeRepository.FirstOrDefaultAsync(Arg.Any<Expression<Func<AccountType, bool>>>())).ReturnsNull();

            Register(Component.For<IRepository<Customer>>().Instance(fakeCustomerRepository).IsDefault());
            Register(Component.For<IRepository<AccountType>>().Instance(fakeAccountTypeRepository).IsDefault());            

            // Act
            async Task CustomerCreationDelegate() => await Resolve<ICustomerAppService>().CreateOrEdit(customer);

            // Assert
            var userFriendlyException = await Assert.ThrowsAsync<UserFriendlyException>(CustomerCreationDelegate);
            Assert.Equal(L("DefaultAccountTypeNotExist"), userFriendlyException.Message);
        }


        [Fact]
        [Trait("Category", "UnitTest")]
        public async Task CreateCustomer_WithValidFields_ReturnsSuccess()
        {
            // Arrange
            var customer = new Faker<CreateOrEditCustomerDto>()
                .RuleFor(u => u.Name, (f) => f.Company.CompanyName())
                .RuleFor(u => u.Phone, (f) => f.Phone.PhoneNumber())
                .Generate(1)
                .First();
            
            var fakeCustomerRepository = Substitute.For<IRepository<Customer>>();
            fakeCustomerRepository.GetAll().Returns(_ => new List<Customer>().AsAsyncQueryable());
            fakeCustomerRepository.InsertAsync(Arg.Any<Customer>()).Returns(_ => Task.FromResult(new Customer()));

            var fakeAccountTypeRepository = Substitute.For<IRepository<AccountType>>();
            (fakeAccountTypeRepository.FirstOrDefaultAsync(Arg.Any<Expression<Func<AccountType, bool>>>())).Returns(new AccountType()
            {
                Id = 1,
                Description = "Prospect"
            });
            var fakeEntityChangeReasonProvider = Substitute.For<IEntityChangeSetReasonProvider>();
            fakeEntityChangeReasonProvider.Use(Arg.Any<string>()).ReturnsNull();

            var fakeCustomerSequenceRepository = Substitute.For<Base.ISoftBaseCustomerSequenceRepository>();
            fakeCustomerSequenceRepository.GetNextSequence().Returns(_ => new Random().Next(10000, 50000));

            var fakeAccountAutomateAssignmentService = Substitute.For<IAccountAutomateAssignmentService>();
            fakeAccountAutomateAssignmentService.AssignAccountUsersAsync(Arg.Any<List<CreateOrEditAccountUserDto>>()).Returns(Task.CompletedTask);

            Register(Component.For<IRepository<Customer>>().Instance(fakeCustomerRepository).IsDefault());
            Register(Component.For<IRepository<AccountType>>().Instance(fakeAccountTypeRepository).IsDefault());
            Register(Component.For<IEntityChangeSetReasonProvider>().Instance(fakeEntityChangeReasonProvider).IsDefault());
            Register(Component.For<Base.ISoftBaseCustomerSequenceRepository>().Instance(fakeCustomerSequenceRepository).IsDefault());
            Register(Component.For<IAccountAutomateAssignmentService>().Instance(fakeAccountAutomateAssignmentService).IsDefault());

            // Act
            async Task CustomerCreationDelegate() => await Resolve<ICustomerAppService>().CreateOrEdit(customer);

            // Assert
            var exception = await Record.ExceptionAsync(CustomerCreationDelegate);
            Assert.Null(exception);
        }


        [Fact]
        [Trait("Category", "UnitTest")]
        public async Task EditCustomer_WithValidFields_ButCustomerDoesNotExist_ReturnsError()
        {
            // Arrange
            var customer = new Faker<CreateOrEditCustomerDto>()
                .RuleFor(u => u.Number, (f) => f.Random.Number(1, 5).ToString())
                .RuleFor(u => u.Name, (f) => f.Company.CompanyName())
                .RuleFor(u => u.Phone, (f) => f.Phone.PhoneNumber())
                .Generate(1)
                .First();
            
            var fakeCustomerRepository = Substitute.For<IRepository<Customer>>();
            fakeCustomerRepository.FirstOrDefaultAsync(Arg.Any<Expression<Func<Customer, bool>>>()).Returns(_ => (Customer)null);

            Register(Component.For<IRepository<Customer>>().Instance(fakeCustomerRepository).IsDefault());

            // Act
            async Task CustomerEditionDelegate() => await Resolve<ICustomerAppService>().CreateOrEdit(customer);

            // Assert
            var userFriendlyException = await Assert.ThrowsAsync<UserFriendlyException>(CustomerEditionDelegate);
            Assert.Equal(L("AccountNotExist"), userFriendlyException.Message);
        }
    }
}