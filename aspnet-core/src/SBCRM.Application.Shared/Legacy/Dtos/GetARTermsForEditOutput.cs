using System;
using Abp.Application.Services.Dto;
using System.ComponentModel.DataAnnotations;

namespace SBCRM.Legacy.Dtos
{
    public class GetARTermsForEditOutput
    {
        public CreateOrEditARTermsDto ARTerms { get; set; }

    }
}