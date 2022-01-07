using System;
using Abp.Application.Services.Dto;
using System.ComponentModel.DataAnnotations;

namespace SBCRM.Crm.Dtos
{
    /// <summary>
    /// A Customer attachment data transfer model for creating and editing attachment.
    /// </summary>
    public class CreateOrEditCustomerAttachmentDto : EntityDto<int?>
    {
        /// <summary>
        /// An attachment given name
        /// </summary>
        [Required]
        [StringLength(CustomerAttachmentConsts.MaxNameLength, MinimumLength = CustomerAttachmentConsts.MinNameLength)]
        public string Name { get; set; }

        /// <summary>
        /// An attachment file path
        /// </summary>
        [Required]
        [StringLength(CustomerAttachmentConsts.MaxFilePathLength, MinimumLength = CustomerAttachmentConsts.MinFilePathLength)]
        public string FilePath { get; set; }

        /// <summary>
        /// A customer Id to whom this attachment belongs to.
        /// </summary>
        public string CustomerNumber { get; set; }
    }
}