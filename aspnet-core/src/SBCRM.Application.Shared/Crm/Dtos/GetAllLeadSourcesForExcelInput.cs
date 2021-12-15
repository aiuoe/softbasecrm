﻿using Abp.Application.Services.Dto;
using System;

namespace SBCRM.Crm.Dtos
{
    /// <summary>
    /// DTO used as input for the get excel report method that includes filters
    /// </summary>
    public class GetAllLeadSourcesForExcelInput
    {
        public string Filter { get; set; }

        public string DescriptionFilter { get; set; }

        public int? IsDefaultFilter { get; set; }

    }
}