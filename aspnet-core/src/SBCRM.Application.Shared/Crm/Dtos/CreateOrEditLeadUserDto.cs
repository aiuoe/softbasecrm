using System;
using Abp.Application.Services.Dto;
using System.ComponentModel.DataAnnotations;

namespace SBCRM.Crm.Dtos
{
    /// <summary>
    /// DTO to manage the object lead user for create or edit purposes
    /// </summary>
    public class CreateOrEditLeadUserDto : EntityDto<int?>
    {

        public int? LeadId { get; set; }

        public long? UserId { get; set; }

    }
}