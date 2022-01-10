using System;
using Abp.Application.Services.Dto;

namespace SBCRM.Crm.Dtos
{
    /// <summary>
    /// A Customer attachment data transfer model.
    /// </summary>
    public class CustomerAttachmentDto : EntityDto<int?>
    {
        /// <summary>
        /// An attachment given name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// An attachment file path
        /// </summary>
        public string FilePath { get; set; }

        /// <summary>
        /// A customer Id to whom this attachment belongs to.
        /// </summary>
        public string CustomerNumber { get; set; }
    }
}