using System;
using Abp.Application.Services.Dto;
using System.ComponentModel.DataAnnotations;

namespace SBCRM.Crm.Dtos
{
    /// <summary>
    /// Activity Source Type Dto for edit output
    /// </summary>
    public class GetActivitySourceTypeForEditOutput
    {
        public CreateOrEditActivitySourceTypeDto ActivitySourceType { get; set; }

    }
}