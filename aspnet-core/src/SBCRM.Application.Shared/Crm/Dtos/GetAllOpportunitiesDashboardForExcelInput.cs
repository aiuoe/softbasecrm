using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;

namespace SBCRM.Crm.Dtos
{
    /// <summary>
    /// DTO to manage the object filters to export excel
    /// </summary>
    public class GetAllOpportunitiesDashboardForExcelInput
    {
        public List<int> OpportunityIds { get; set; } = new List<int>();
    }
}