using System;
using Abp.Application.Services.Dto;
using System.ComponentModel.DataAnnotations;

namespace SBCRM.Crm.Dtos
{
    /// <summary>
    /// Activity Status Dto for edit output
    /// </summary>
    public class GetActivityStatusForEditOutput
    {
        public CreateOrEditActivityStatusDto ActivityStatus { get; set; }

    }
}