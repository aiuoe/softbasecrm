using System;
using Abp.Application.Services.Dto;
using System.ComponentModel.DataAnnotations;

namespace SBCRM.Crm.Dtos
{
    public class CreateOrEditLeadUserDto : EntityDto<int?>
    {

        public int? LeadId { get; set; }

        public long? UserId { get; set; }

    }
}