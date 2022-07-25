using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp;
using Abp.EntityHistory;
using Abp.Timing;
using Bogus;
using Castle.MicroKernel.Registration;
using NSubstitute;
using NSubstitute.ReturnsExtensions;
using NUglify.Helpers;
using SBCRM.Common;
using SBCRM.Crm;
using SBCRM.Crm.Dtos;
using SBCRM.Legacy;
using SBCRM.Legacy.Dtos;
using Xunit;

namespace SBCRM.Tests.Crm
{
    /// <summary>
    /// Tests suite for Opportunities Service
    /// </summary>
    public class OpportunitiesAppServiceTests : AppTestBase
    {
        [Theory]
        [InlineData(500)]
        [Trait("Category", "IntegrationTest")]
        public async Task CreateOpportunity_WithDifferentDate_WithDifferentAmounts(int quantityRecords)
        {
            // Arrange
            var allContacts =
                await Resolve<IContactsAppService>().GetAllWithoutPaging(new GetAllNoPagedContactsInput());
            var stages = await Resolve<IOpportunitiesAppService>().GetAllOpportunityStageForTableDropdown();
            var departments = await Resolve<IOpportunitiesAppService>().GetAllDepartmentsForTableDropdown();
            var leadSources = await Resolve<IOpportunitiesAppService>().GetAllLeadSourceForTableDropdown();

            GuardHelper.ThrowIf(allContacts == null || !allContacts.Any(), new AbpException("Contacts not found"));
            GuardHelper.ThrowIf(stages == null || !stages.Any(), new AbpException("Stages not found"));
            GuardHelper.ThrowIf(departments == null || !departments.Any(), new AbpException("Departments not found"));
            GuardHelper.ThrowIf(leadSources == null || !leadSources.Any(), new AbpException("Lead Sources not found"));

            List<CreateOrEditOpportunityDto> opportunities = new List<CreateOrEditOpportunityDto>();

            Enumerable.Range(1, quantityRecords).ForEach(_ =>
            {
                var randomContact = allContacts[GetRandom(allContacts.Count)].Contact;
                var randomDepartment = departments[GetRandom(departments.Count)];

                var opportunityFake = new Faker<CreateOrEditOpportunityDto>()
                    .RuleFor(u => u.Name, (f) => f.Commerce.ProductName())
                    .RuleFor(u => u.CloseDate,
                        (f) => f.Date.Between(Clock.Now.AddDays(-30), Clock.Now.AddDays(30)))
                    .RuleFor(u => u.Amount, (f) => f.Random.Decimal(10000, 999999))
                    .RuleFor(u => u.CustomerNumber, (f) => randomContact.CustomerNo)
                    .RuleFor(u => u.ContactId, (f) => randomContact.Id)
                    .RuleFor(u => u.Probability, (f) => f.Random.Decimal(10, 100))
                    .RuleFor(u => u.Description, (f) => f.Finance.AccountName())
                    .RuleFor(u => u.OpportunityStageId, (f) => f.PickRandom(stages).Id)
                    .RuleFor(u => u.LeadSourceId, (f) => f.PickRandom(leadSources).Id)
                    .RuleFor(u => u.Branch, (f) => randomDepartment.Branch)
                    .RuleFor(u => u.Dept, (f) => randomDepartment.Dept)
                    .Generate(1)
                    .FirstOrDefault();

                opportunities.Add(opportunityFake);
            });

            var fakeEntityChangeReasonProvider = Substitute.For<IEntityChangeSetReasonProvider>();
            fakeEntityChangeReasonProvider.Use(Arg.Any<string>()).ReturnsNull();
            Register(Component.For<IEntityChangeSetReasonProvider>().Instance(fakeEntityChangeReasonProvider)
                .IsDefault());


            // Act
            List<Exception> exceptions = new List<Exception>();
            foreach (CreateOrEditOpportunityDto opportunity in opportunities)
            {
                try
                {
                    await Resolve<IOpportunitiesAppService>().CreateOrEdit(opportunity);
                }
                catch (Exception exception)
                {
                    exceptions.Add(exception);
                }
            }

            // Assert
            Assert.Empty(exceptions);
        }
    }
}