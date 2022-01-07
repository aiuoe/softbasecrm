using Abp.Application.Services.Dto;
using System;

namespace SBCRM.Crm.Dtos
{
    /// <summary>
    /// A Customer attachment excel filter model.
    /// </summary>
    public class GetAllCustomerAttachmentsForExcelInput
    {
        /// <summary>
        /// A generic filter
        /// </summary>
        public string Filter { get; set; }

        /// <summary>
        /// Filter by name
        /// </summary>
        public string NameFilter { get; set; }

        /// <summary>
        /// Filter by file path
        /// </summary>
        public string FilePathFilter { get; set; }

    }
}