using Abp.Application.Services.Dto;
using System;

namespace SBCRM.Crm.Dtos
{
    public class GetAllCustomerAttachmentsForExcelInput
    {
        public string Filter { get; set; }

        public string NameFilter { get; set; }

        public string FilePathFilter { get; set; }

    }
}