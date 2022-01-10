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
using Microsoft.EntityFrameworkCore;
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
    /// Tests suite for Opportunties Service
    /// </summary>
    public class OpportunitiesAppServiceTests : AppTestBase
    {
        [Fact]
        [Trait("Category", "UnitTest")]
        public async Task CreateOpportunity_WithDifferentDate_WithDifferentAmounts()
        {
            var customers = await Resolve<IOpportunitiesAppService>().GetAllCustomerForTableDropdown();

            var customerWithContacts = customers.FirstOrDefault(x => x.Name == "Sabina Valley Dental Surgery");

            var contacts = await Resolve<IOpportunitiesAppService>().GetAllContactsForTableDropdownCustomerSpecific(customerWithContacts.Number);

            var stages = await Resolve<IOpportunitiesAppService>().GetAllOpportunityStageForTableDropdown();

            var branches = await Resolve<IOpportunitiesAppService>().GetAllBranchesForTableDropdown();

            var branchWithDepartments = branches.FirstOrDefault(x => x.Name == "Houston");

            var departments = await Resolve<IOpportunitiesAppService>().GetAllDepartmentsForTableDropdownBranchSpecific(branchWithDepartments.Number);

            // Arrange
            var opportunities = new Faker<CreateOrEditOpportunityDto>()
                .RuleFor(u => u.Name, (f) => f.Commerce.ProductName())
                .RuleFor(u => u.CloseDate, (f) => f.Date.Recent())
                .RuleFor(u => u.Amount, (f) => Convert.ToDecimal(f.Commerce.Price(1000, 10000)))
                .RuleFor(u => u.CustomerNumber, (f) => customerWithContacts.Number)
                .RuleFor(u => u.ContactId, (f) => contacts[0].Id)
                .RuleFor(u => u.OpportunityStageId, (f) => stages[0].Id)
                .RuleFor(u => u.Branch, (f) => branchWithDepartments.Number)
                .RuleFor(u => u.Dept, (f) => departments[0].Dept)
                .Generate(200);

            // Arrange
            var fakeOpportunityRepository = Substitute.For<IRepository<Opportunity>>();
            fakeOpportunityRepository.GetAll().Returns(_ => new List<Opportunity>().AsAsyncQueryable());
            fakeOpportunityRepository.InsertAsync(Arg.Any<Opportunity>()).Returns(_ => Task.FromResult(new Opportunity()));

            var fakeEntityChangeReasonProvider = Substitute.For<IEntityChangeSetReasonProvider>();
            fakeEntityChangeReasonProvider.Use(Arg.Any<string>()).ReturnsNull();

            Register(Component.For<IRepository<Opportunity>>().Instance(fakeOpportunityRepository).IsDefault());
            Register(Component.For<IEntityChangeSetReasonProvider>().Instance(fakeEntityChangeReasonProvider).IsDefault());


            // Act
            List<Exception> exceptions = new List<Exception>();
            foreach (CreateOrEditOpportunityDto opportunity in opportunities)
                try
                {
                    async Task OpportunityCreationDelegate() => await Resolve<IOpportunitiesAppService>().CreateOrEdit(opportunity);
                    await Task.Run(OpportunityCreationDelegate);
                }
                catch (Exception exception)
                {
                    exceptions.Add(exception);
                }

            // Assert
            Assert.Empty(exceptions);
        }
    }
        //private static int nextRandom(int value, int max, int min)
        //{
        //    return (value > min) ? min : value : (value > max) ? max : value;
        //}


 
        //[Fact]
        //[Trait("Category", "UnitTest")]
        //public async Task CreateCustomer_WithValidFields_ReturnsSuccess()
        //{
        //    // Arrange
        //    var customer = new Faker<CreateOrEditCustomerDto>()
        //        .RuleFor(u => u.Name, (f) => f.Company.CompanyName())
        //        .RuleFor(u => u.Phone, (f) => f.Phone.PhoneNumber())
        //        .Generate(1)
        //        .First();

        //    // Arrange
        //    var fakeCustomerRepository = Substitute.For<IRepository<Customer>>();
        //    fakeCustomerRepository.GetAll().Returns(_ => new List<Customer>().AsAsyncQueryable());
        //    fakeCustomerRepository.InsertAsync(Arg.Any<Customer>()).Returns(_ => Task.FromResult(new Customer()));

        //    var fakeAccountTypeRepository = Substitute.For<IRepository<AccountType>>();
        //    (fakeAccountTypeRepository.FirstOrDefaultAsync(Arg.Any<Expression<Func<AccountType, bool>>>())).Returns(new AccountType()
        //    {
        //        Id = 1,
        //        Description = "Prospect"
        //    });
        //    var fakeEntityChangeReasonProvider = Substitute.For<IEntityChangeSetReasonProvider>();
        //    fakeEntityChangeReasonProvider.Use(Arg.Any<string>()).ReturnsNull();

        //    var fakeCustomerSequenceRepository = Substitute.For<Base.ISoftBaseCustomerSequenceRepository>();
        //    fakeCustomerSequenceRepository.GetNextSequence().Returns(_ => new Random().Next(10000, 50000));

        //    Register(Component.For<IRepository<Customer>>().Instance(fakeCustomerRepository).IsDefault());
        //    Register(Component.For<IRepository<AccountType>>().Instance(fakeAccountTypeRepository).IsDefault());
        //    Register(Component.For<IEntityChangeSetReasonProvider>().Instance(fakeEntityChangeReasonProvider).IsDefault());
        //    Register(Component.For<Base.ISoftBaseCustomerSequenceRepository>().Instance(fakeCustomerSequenceRepository).IsDefault());

        //    // ActSequenceRepository
        //    async Task CustomerCreationDelegate() => await Resolve<ICustomerAppService>().CreateOrEdit(customer);


        //    // Assert
        //    var exception = await Record.ExceptionAsync(CustomerCreationDelegate);
        //    Assert.Null(exception);
        //}

   
}