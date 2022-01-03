using System.Threading.Tasks;
using SBCRM.Crm;
using Xunit;

namespace SBCRM.Tests.Crm
{
    /// <summary>
    /// Tests suite for Customers(Accounts) Service
    /// </summary>
    public class AccountUsersAppServiceTests : AppTestBase
    {
        [Theory]
        [InlineData("7000", "0249")]
        [Trait("Category", "IntegrationTest")]
        public async Task GetCanViewAssignedUsersWidget(string username, string customerNumber)
        {
            // Arrange
            LoginAsTenant("Default", username);

            // Act
            var userCanViewWidget = await Resolve<IAccountUsersAppService>().GetCanViewAssignedUsersWidget(customerNumber);

            // Assert
            Assert.NotNull(userCanViewWidget);
        }
    }
}
