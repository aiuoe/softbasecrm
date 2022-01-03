using System;
using Abp.Application.Services.Dto;
using System.ComponentModel.DataAnnotations;

namespace SBCRM.Crm.Dtos
{
    public class GetCustomerAttachmentForEditOutput
    {
        public CreateOrEditCustomerAttachmentDto CustomerAttachment { get; set; }

    }
}