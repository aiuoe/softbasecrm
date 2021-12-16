using System.Linq;
using System.Threading.Tasks;
using SBCRM.Authorization.Accounts.Dto;
using SBCRM.Legacy;
using SBCRM.Legacy.Dtos;
using Shouldly;
using Xunit;

namespace SBCRM.Tests.Crm
{
    public class CustomerAppServiceTests : AppTestBase
    {
        private readonly ICustomerAppService _customerAppService;

        public CustomerAppServiceTests()
        {
            _customerAppService = Resolve<ICustomerAppService>();
        }

        [Fact]
        public async Task Should_Register()
        {
            //Act
            await _customerAppService.CreateOrEdit(new CreateOrEditCustomerDto
            {
                Name = null,
            });

            //Assert
        }
    }
}
