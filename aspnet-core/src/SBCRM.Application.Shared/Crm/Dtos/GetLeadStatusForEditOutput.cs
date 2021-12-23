using System;
using Abp.Application.Services.Dto;
using System.ComponentModel.DataAnnotations;

namespace SBCRM.Crm.Dtos
{
    /// <summary>
    /// DTO to manage the object lead status for edit purposes
    /// </summary>
    public class GetLeadStatusForEditOutput
    {
        public CreateOrEditLeadStatusDto LeadStatus { get; set; }

    }
}