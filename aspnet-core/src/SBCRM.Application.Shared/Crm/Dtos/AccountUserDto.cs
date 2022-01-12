using Abp.Application.Services.Dto;

namespace SBCRM.Crm.Dtos
{
    public class AccountUserDto : EntityDto
    {
        public string CustomerNumber { get; set; }

        public long? UserId { get; set; }

        public UserAssignedDto UserFk { get; set; }

    }
}