using System;
using Abp.Application.Services.Dto;
using System.ComponentModel.DataAnnotations;

namespace SBCRM.Crm.Dtos
{
    public class GetIndustryForEditOutput
    {
        public CreateOrEditIndustryDto Industry { get; set; }

    }
}