using System;
using Abp.Application.Services.Dto;
using System.ComponentModel.DataAnnotations;

namespace SBCRM.Crm.Dtos
{
    /// <summary>
    /// OpportunityUser dto used by the ui to create or edit a opportunity user
    /// </summary>
    public class CreateOrEditOpportunityUserDto : EntityDto<int?>
    {

        public long UserId { get; set; }

        public int OpportunityId { get; set; }

    }
}