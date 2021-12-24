using System;
using Abp.Application.Services.Dto;
using System.ComponentModel.DataAnnotations;

namespace SBCRM.Crm.Dtos
{
    public class GetActivityForEditOutput
    {
        public CreateOrEditActivityDto Activity { get; set; }

        public string OpportunityName { get; set; }

        public string LeadCompanyName { get; set; }

        public string UserName { get; set; }

        public string ActivitySourceTypeDescription { get; set; }

        public string ActivityTaskTypeDescription { get; set; }

        public string ActivityStatusDescription { get; set; }

        public string ActivityPriorityDescription { get; set; }

        public string CustomerName { get; set; }
    }
}