using System;
using Abp.Application.Services.Dto;

namespace SBCRM.Crm.Dtos
{
    /// <summary>
    /// Dto for the Activity Source Type entity
    /// </summary>
    public class ActivitySourceTypeDto : EntityDto
    {
        public string Description { get; set; }

    }
}