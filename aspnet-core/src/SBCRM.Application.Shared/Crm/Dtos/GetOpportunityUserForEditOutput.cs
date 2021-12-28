using System;
using Abp.Application.Services.Dto;
using System.ComponentModel.DataAnnotations;

namespace SBCRM.Crm.Dtos
{
    public class GetOpportunityUserForEditOutput
    {
        public CreateOrEditOpportunityUserDto OpportunityUser { get; set; }

        public string UserName { get; set; }

        public string OpportunityName { get; set; }

    }
}