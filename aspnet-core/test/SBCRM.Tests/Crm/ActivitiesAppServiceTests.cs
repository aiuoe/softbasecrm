using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.Domain.Entities;
using Abp.Domain.Repositories;
using Abp.Runtime.Validation;
using Bogus;
using Castle.MicroKernel.Registration;
using NSubstitute;
using SBCRM.Crm;
using SBCRM.Crm.Dtos;
using SBCRM.Test.Base.Configuration;
using Xunit;

namespace SBCRM.Tests.Crm
{
    /// <summary>
    /// Unit tests for the Activities App Service
    /// </summary>
    public class ActivitiesAppServiceTests : AppTestBase
    {

        private void RegisterFakeActivityRepository(List<Activity> activities)
        {
            var fakeRepository = Substitute.For<IRepository<Activity, long>>();
            fakeRepository.GetAll().Returns(_ => activities.AsAsyncQueryable());

            Register(Component.For<IRepository<Activity, long>>().Instance(fakeRepository).IsDefault());
        }

        [Fact]
        [Trait("Category", "UnitTest")]
        public async Task GetActivityForEdit_ButActivityDoesNotExist_ReturnsError()
        {
            // Arrange
            LoginAsHostAdmin();

            var nonExistingEntity = new EntityDto<long>() { Id = 0 };

            var records = new Faker<Activity>()
                .RuleFor(u => u.Id, (f) => 1)
                .RuleFor(u => u.Description, (f) => f.Lorem.Sentence())
                .Generate(1);

            RegisterFakeActivityRepository(records);

            // Act
            async Task TargetMethodDelegate() => await Resolve<IActivitiesAppService>().GetActivityForEdit(nonExistingEntity);

            // Assert
            var result = await Assert.ThrowsAsync<EntityNotFoundException>(TargetMethodDelegate);
            Assert.Equal(L("ActivityNotExist"), result.Message);
        }

        [Fact]
        [Trait("Category", "UnitTest")]
        public async Task CreateOrEdit_ButActivityDoesNotExist_ReturnsError()
        {
            // Arrange
            LoginAsHostAdmin();

            var nonExistingEntity = new CreateOrEditActivityDto()
            {
                Id = 0,
                TaskName = new Faker().Lorem.Sentence(),
            };

            var records = new Faker<Activity>()
                .RuleFor(u => u.Id, (f) => 1)
                .RuleFor(u => u.Description, (f) => f.Lorem.Sentence())
                .Generate(1);

            RegisterFakeActivityRepository(records);

            // Act
            async Task TargetMethodDelegate() => await Resolve<IActivitiesAppService>().CreateOrEdit(nonExistingEntity);

            // Assert
            var result = await Assert.ThrowsAsync<EntityNotFoundException>(TargetMethodDelegate);
            Assert.Equal(L("ActivityNotExist"), result.Message);
        }

        [Fact]
        [Trait("Category", "UnitTest")]
        public async Task CreateOrEdit_ButFieldsAreEmpty_ReturnsError()
        {
            // Arrange
            LoginAsHostAdmin();

            var newEntity = new CreateOrEditActivityDto() { TaskName = string.Empty };

            RegisterFakeActivityRepository(new List<Activity>());

            // Act
            async Task TargetMethodDelegate() => await Resolve<IActivitiesAppService>().CreateOrEdit(newEntity);

            // Assert
            var result = await Assert.ThrowsAsync<AbpValidationException>(TargetMethodDelegate);
            Assert.NotNull(result);
            Assert.NotEmpty(result.ValidationErrors);
        }
    }
}
