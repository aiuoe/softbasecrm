using Abp.Application.Services.Dto;
using System;

namespace SBCRM.Crm.Dtos
{
    /// <summary>
    /// A Lead attachment excel filter model.
    /// </summary>
    public class GetAllLeadAttachmentsForExcelInput
    {
        public string Filter { get; set; }

        public string NameFilter { get; set; }

        public string FilePathFilter { get; set; }

        public string LeadCompanyNameFilter { get; set; }

    }
}