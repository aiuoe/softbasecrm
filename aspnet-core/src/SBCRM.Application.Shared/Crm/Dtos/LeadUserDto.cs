using System;
using Abp.Application.Services.Dto;

namespace SBCRM.Crm.Dtos
{
    /// <summary>
    /// DTO to manage the object lead user
    /// </summary>
    public class LeadUserDto : EntityDto
    {

        public int? LeadId { get; set; }

        public long? UserId { get; set; }
               

    }
}