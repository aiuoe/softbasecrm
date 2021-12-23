using System;
using Abp.Application.Services.Dto;
using System.ComponentModel.DataAnnotations;

namespace SBCRM.Crm.Dtos
{
    /// <summary>
    /// DTO to manage the object priority for edit purposes
    /// </summary>
    public class GetPriorityForEditOutput
    {
        public CreateOrEditPriorityDto Priority { get; set; }

    }
}