using System;
using Abp.Application.Services.Dto;
using System.ComponentModel.DataAnnotations;

namespace SBCRM.Crm.Dtos
{
    public class CreateOrEditCustomerAttachmentDto : EntityDto<int?>
    {

        [Required]
        [StringLength(CustomerAttachmentConsts.MaxNameLength, MinimumLength = CustomerAttachmentConsts.MinNameLength)]
        public string Name { get; set; }

        [Required]
        [StringLength(CustomerAttachmentConsts.MaxFilePathLength, MinimumLength = CustomerAttachmentConsts.MinFilePathLength)]
        public string FilePath { get; set; }

        public string CustomerNumber { get; set; }
    }
}