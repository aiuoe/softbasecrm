using System;
using Abp.Application.Services.Dto;
using System.ComponentModel.DataAnnotations;

namespace SBCRM.Crm.Dtos
{
    public class CreateOrEditOpportunityUserDto : EntityDto<int?>
    {

        public long UserId { get; set; }

        public int OpportunityId { get; set; }

    }
}