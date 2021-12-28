using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Abp.EntityHistory;
using Abp.Localization;
using Abp.UI;
using Castle.MicroKernel.Registration;
using NSubstitute;
using NSubstitute.ReturnsExtensions;
using SBCRM.Base;
using SBCRM.Crm;
using SBCRM.Legacy;
using SBCRM.Legacy.Dtos;
using SBCRM.Test.Base.Configuration;
using Xunit;

namespace SBCRM.Tests.Crm
{
    /// <summary>
    /// Unit test for Customers Service
    /// </summary>
    public class CustomerAppServiceTests : AppTestBase
    {
        private readonly ILocalizationManager _localization;

        public CustomerAppServiceTests()
        {
            _localization = Resolve<ILocalizationManager>();
        }
        
        [Fact]
        [Trait("Category", "UnitTest")]
        public async Task CreateCustomer_WithNameAlreadyExist_ReturnsError()
        {
            var customerName = "Softbase Systems";

            // Arrange
            var existingCustomer = new List<Customer>
            {
                new()
                {
                    Id = 1,
                    Name = customerName
                }
            };

            var fakeCustomerRepository = Substitute.For<Abp.Domain.Repositories.IRepository<Customer>>();
            (fakeCustomerRepository.GetAll()).Returns(x => existingCustomer.AsAsyncQueryable());

            LocalIocManager.IocContainer.Register(Component.For<Abp.Domain.Repositories.IRepository<Customer>>().Instance(fakeCustomerRepository).IsDefault());

            // Act
            async Task CustomerCreationDelegate() => await Resolve<ICustomerAppService>()
                .CreateOrEdit(new CreateOrEditCustomerDto {Name = customerName, Phone = "1234856"});

            // Assert
            var userFriendlyException = await Assert.ThrowsAsync<UserFriendlyException>(CustomerCreationDelegate);
            Assert.Equal(_localization.GetString(SBCRMConsts.LocalizationSourceName, "CustomerNameAlreadyExist"),
                userFriendlyException.Message);
        }

        [Fact]
        [Trait("Category", "UnitTest")]
        public async Task CreateCustomer_WithValidFields_ButDefaultAccountTypeIsNotDefined_ReturnsError()
        {
            var customerName = "Softbase Systems";

            // Arrange
            var fakeCustomerRepository = Substitute.For<Abp.Domain.Repositories.IRepository<Customer>>();
            (fakeCustomerRepository.GetAll()).Returns(x => new List<Customer>().AsAsyncQueryable());

            var fakeAccountTypeRepository = Substitute.For<Abp.Domain.Repositories.IRepository<AccountType>>();
            (fakeAccountTypeRepository.FirstOrDefaultAsync(Arg.Any<Expression<Func<AccountType, bool>>>())).ReturnsNull();

            LocalIocManager.IocContainer.Register(Component.For<Abp.Domain.Repositories.IRepository<Customer>>().Instance(fakeCustomerRepository).IsDefault());
            LocalIocManager.IocContainer.Register(Component.For<Abp.Domain.Repositories.IRepository<AccountType>>().Instance(fakeAccountTypeRepository).IsDefault());
            

            // Act
            async Task CustomerCreationDelegate() => await Resolve<ICustomerAppService>()
                .CreateOrEdit(new CreateOrEditCustomerDto { Name = customerName, Phone = "1234856" });

            // Assert
            var userFriendlyException = await Assert.ThrowsAsync<UserFriendlyException>(CustomerCreationDelegate);
            Assert.Equal(_localization.GetString(SBCRMConsts.LocalizationSourceName, "DefaultAccountTypeNotExist"),
                userFriendlyException.Message);
        }


        [Fact]
        [Trait("Category", "UnitTest")]
        public async Task CreateCustomer_WithValidFields_ReturnsSuccess()
        {
            var customerName = "Softbase Systems";

            // Arrange
            var fakeCustomerRepository = Substitute.For<Abp.Domain.Repositories.IRepository<Customer>>();
            (fakeCustomerRepository.GetAll()).Returns(x => new List<Customer>().AsAsyncQueryable());
            (fakeCustomerRepository.InsertAsync(Arg.Any<Customer>())).Returns(x => Task.FromResult(new Customer()));

            var fakeAccountTypeRepository = Substitute.For<Abp.Domain.Repositories.IRepository<AccountType>>();
            (fakeAccountTypeRepository.FirstOrDefaultAsync(Arg.Any<Expression<Func<AccountType, bool>>>())).Returns(new AccountType()
            {
                Id = 1,
                Description = "Prospect"
            });
            var fakeEntityChangeReasonProvider = Substitute.For<IEntityChangeSetReasonProvider>();
            fakeEntityChangeReasonProvider.Use(Arg.Any<string>()).ReturnsNull();

            var fakeCustomerSequenceRepository = Substitute.For<ISoftBaseCustomerSequenceRepository>();
            (fakeCustomerSequenceRepository.GetNextSequence()).Returns(x => 123456);

            LocalIocManager.IocContainer.Register(Component.For<Abp.Domain.Repositories.IRepository<Customer>>().Instance(fakeCustomerRepository).IsDefault());
            LocalIocManager.IocContainer.Register(Component.For<Abp.Domain.Repositories.IRepository<AccountType>>().Instance(fakeAccountTypeRepository).IsDefault());
            LocalIocManager.IocContainer.Register(Component.For<IEntityChangeSetReasonProvider>().Instance(fakeEntityChangeReasonProvider).IsDefault());
            LocalIocManager.IocContainer.Register(Component.For<ISoftBaseCustomerSequenceRepository>().Instance(fakeCustomerSequenceRepository).IsDefault());


            // Act
            async Task CustomerCreationDelegate() => await Resolve<ICustomerAppService>()
                .CreateOrEdit(new CreateOrEditCustomerDto { Name = customerName, Phone = "1234856" });

            // Assert
            var exception = await Record.ExceptionAsync(CustomerCreationDelegate);
            Assert.Null(exception);
        }
    }
}