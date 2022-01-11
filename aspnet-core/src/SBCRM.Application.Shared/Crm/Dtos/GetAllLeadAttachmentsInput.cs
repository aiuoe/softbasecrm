using Abp.Application.Services.Dto;
using System;

namespace SBCRM.Crm.Dtos
{

    /// <summary>
    /// Lead attachment filter model.
    /// </summary>
    public class GetAllLeadAttachmentsInput : PagedAndSortedResultRequestDto
    {
        public string Filter { get; set; }

        public string NameFilter { get; set; }

        public string FilePathFilter { get; set; }

        public string LeadCompanyNameFilter { get; set; }

        public int LeadIdFilter { get; set; }

    }
}