using System;
using Abp.Application.Services.Dto;
using System.ComponentModel.DataAnnotations;

namespace SBCRM.Crm.Dtos
{
    /// <summary>
    /// Activity Priority Dto for edit output
    /// </summary>
    public class GetActivityPriorityForEditOutput
    {
        public CreateOrEditActivityPriorityDto ActivityPriority { get; set; }

    }
}