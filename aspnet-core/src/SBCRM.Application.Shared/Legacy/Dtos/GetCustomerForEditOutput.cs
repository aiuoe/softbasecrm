using System;
using Abp.Application.Services.Dto;
using System.ComponentModel.DataAnnotations;

namespace SBCRM.Legacy.Dtos
{
    public class GetCustomerForEditOutput
    {
        public CreateOrEditCustomerDto Customer { get; set; }

        public string AccountTypeDescription { get; set; }

    }
}