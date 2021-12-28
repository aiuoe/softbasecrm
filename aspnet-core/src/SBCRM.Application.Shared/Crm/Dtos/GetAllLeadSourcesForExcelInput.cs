using Abp.Application.Services.Dto;
using System;

namespace SBCRM.Crm.Dtos
{
    public class GetAllLeadSourcesForExcelInput
    {
        public string Filter { get; set; }

        public string DescriptionFilter { get; set; }

    }
}