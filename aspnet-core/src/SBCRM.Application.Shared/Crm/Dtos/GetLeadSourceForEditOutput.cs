using System;
using Abp.Application.Services.Dto;
using System.ComponentModel.DataAnnotations;

namespace SBCRM.Crm.Dtos
{
    /// <summary>
    /// DTO to manage the object lead source for edit purposes
    /// </summary>
    public class GetLeadSourceForEditOutput
    {
        public CreateOrEditLeadSourceDto LeadSource { get; set; }

    }
}