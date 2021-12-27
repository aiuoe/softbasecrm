using Abp.Application.Services.Dto;
using System;

namespace SBCRM.Crm.Dtos
{
    /// <summary>
    /// Activity Priorities Dto for Excel Input
    /// </summary>
 
    public class GetAllActivityPrioritiesForExcelInput
    {
        public string Filter { get; set; }

        public string DescriptionFilter { get; set; }

    }
}