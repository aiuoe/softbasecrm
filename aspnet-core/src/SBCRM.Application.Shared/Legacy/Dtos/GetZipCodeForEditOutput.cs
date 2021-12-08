using System;
using Abp.Application.Services.Dto;
using System.ComponentModel.DataAnnotations;

namespace SBCRM.Legacy.Dtos
{
    public class GetZipCodeForEditOutput
    {
        public CreateOrEditZipCodeDto ZipCode { get; set; }

    }
}