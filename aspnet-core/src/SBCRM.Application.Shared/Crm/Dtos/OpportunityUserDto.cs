using System;
using Abp.Application.Services.Dto;

namespace SBCRM.Crm.Dtos
{
    public class OpportunityUserDto : EntityDto
    {

        public long UserId { get; set; }

        public int OpportunityId { get; set; }

        public UserAssignedDto UserFk { get; set; }

    }
}