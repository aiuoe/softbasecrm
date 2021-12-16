using System;
using Abp.Application.Services.Dto;
using System.ComponentModel.DataAnnotations;

namespace SBCRM.Crm.Dtos
{
    public class GetAccountUserForEditOutput
    {
        public CreateOrEditAccountUserDto AccountUser { get; set; }

        public string UserName { get; set; }

    }
}