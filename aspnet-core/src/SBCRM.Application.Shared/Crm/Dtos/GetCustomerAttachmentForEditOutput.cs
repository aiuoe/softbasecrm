using System;
using Abp.Application.Services.Dto;
using System.ComponentModel.DataAnnotations;

namespace SBCRM.Crm.Dtos
{
    /// <summary>
    /// A customer attachment model for editing purposes.
    /// </summary>
    public class GetCustomerAttachmentForEditOutput
    {
        public CreateOrEditCustomerAttachmentDto CustomerAttachment { get; set; }

    }
}