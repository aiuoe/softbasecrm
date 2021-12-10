using System;
using Abp.Application.Services.Dto;

namespace SBCRM.Crm.Dtos
{
    public class LeadUserDto : EntityDto
    {

        public int? LeadId { get; set; }

        public long? UserId { get; set; }

    }
}