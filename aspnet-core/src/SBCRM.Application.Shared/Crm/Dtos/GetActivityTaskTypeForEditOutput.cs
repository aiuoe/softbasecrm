using System;
using Abp.Application.Services.Dto;
using System.ComponentModel.DataAnnotations;

namespace SBCRM.Crm.Dtos
{
    /// <summary>
    /// Activity Task Type Dto for edit output
    /// </summary>
    public class GetActivityTaskTypeForEditOutput
    {
        public CreateOrEditActivityTaskTypeDto ActivityTaskType { get; set; }

    }
}