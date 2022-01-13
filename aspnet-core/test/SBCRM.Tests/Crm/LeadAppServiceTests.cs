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
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Xunit;

namespace SBCRM.Tests.Crm
{
    public class LeadAppServiceTests : AppTestBase
    {
        private readonly string _convertedStatusCode = "CONVERTED";

        [Fact]
        [Trait("Category", "UnitTest")]
        public async Task CreateLead_WithCompanyAndContactNameAlreadyExist_ReturnsError()
        {
            // Arrange
            var existingLead = new Faker<Lead>()
                .RuleFor(u => u.CompanyName, (f) => f.Company.CompanyName())
                .RuleFor(u => u.ContactName, (f) => f.Name.FullName())
                .RuleFor(u => u.CompanyEmail, (f) => f.Person.Email)
                .RuleFor(u => u.CompanyPhone, (f) => f.Person.Phone)
                .Generate(20);

            var lead = new CreateOrEditLeadDto { 
                CompanyName = existingLead.First().CompanyName, 
                ContactName = existingLead.First().ContactName,
                CompanyEmail = existingLead.First().CompanyEmail,
                CompanyPhone = existingLead.First().CompanyPhone};

            var fakeLeadRepository = Substitute.For<IRepository<Lead>>();
            (fakeLeadRepository.FirstOrDefaultAsync(Arg.Any<Expression<Func<Lead, bool>>>())).Returns(existingLead.FirstOrDefault());

            Register(Component.For<IRepository<Lead>>().Instance(fakeLeadRepository).IsDefault());

            // Act
            async Task LeadCreationDelegate() => await Resolve<ILeadsAppService>().CreateOrEdit(lead);

            // Assert
            var userFriendlyException = await Assert.ThrowsAsync<UserFriendlyException>(LeadCreationDelegate);
            Assert.Equal(L("DuplicatedLead"), userFriendlyException.Message);
        }


        [Fact]
        [Trait("Category", "UnitTest")]
        public async Task ConvertToAccount_ButCustomerNameAlreadyExist_ReturnsError()
        {
            // Arrange
            var existingLead = new Faker<Lead>()
                .RuleFor(u => u.CompanyName, (f) => f.Company.CompanyName())
                .RuleFor(u => u.ContactName, (f) => f.Name.FullName())
                .RuleFor(u => u.CompanyEmail, (f) => f.Person.Email)
                .RuleFor(u => u.CompanyPhone, (f) => f.Person.Phone)
                .RuleFor(u => u.Id, (f) => 1)
                .Generate(1);

            var existingCustomer = new Faker<Customer>()
                .RuleFor(u => u.Name, (f) => existingLead.First().CompanyName)
                .RuleFor(u => u.Id, (f) => 1)
                .Generate(1);

            var existingLeadStatus = new Faker<LeadStatus>()
                .RuleFor(u => u.Code, (f) => _convertedStatusCode)
                .RuleFor(u => u.Description, (f) => _convertedStatusCode)
                .RuleFor(u => u.Id, (f) => 1)
                .RuleFor(u => u.Id, (f) => 1)
                .Generate(1);

            var leadToConvert = new ConvertLeadToAccountRequestDto()
            {
                LeadId = existingLead.First().Id
            };

            var fakeLeadRepository = Substitute.For<IRepository<Lead>>();
            fakeLeadRepository.GetAll().Returns(existingLead.AsAsyncQueryable());

            var fakeLeadStatusRepository = Substitute.For<IRepository<LeadStatus>>();
            fakeLeadStatusRepository.GetAll().Returns(existingLeadStatus.AsAsyncQueryable());

            Register(Component.For<IRepository<Lead>>().Instance(fakeLeadRepository).IsDefault());
            Register(Component.For<IRepository<LeadStatus>>().Instance(fakeLeadStatusRepository).IsDefault());


            // Act
            async Task LeadCreationDelegate() => await Resolve<ILeadsAppService>().ConvertToAccount(leadToConvert);

            // Assert
            var userFriendlyException = await Assert.ThrowsAsync<UserFriendlyException>(LeadCreationDelegate);
            Assert.Equal(L("CustomerWithSameNameAlreadyExists"), userFriendlyException.Message);
        }

    }
}
