using System;
using Abp.Application.Services.Dto;
using System.ComponentModel.DataAnnotations;

namespace SBCRM.Crm.Dtos
{
    public class CreateOrEditAccountUserDto : EntityDto<int?>
    {

        public long UserId { get; set; }

        public string CustomerNumber { get; set; }

    }
}