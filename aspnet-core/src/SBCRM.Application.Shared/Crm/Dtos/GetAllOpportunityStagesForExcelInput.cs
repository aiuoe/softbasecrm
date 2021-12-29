using Abp.Application.Services.Dto;
using System;

namespace SBCRM.Crm.Dtos
{
    public class GetAllOpportunityStagesForExcelInput
    {
        public string Filter { get; set; }

        public string DescriptionFilter { get; set; }

        public string ColorFilter { get; set; }

    }
}