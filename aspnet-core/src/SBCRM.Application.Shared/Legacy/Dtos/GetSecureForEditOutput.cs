using System;
using Abp.Application.Services.Dto;
using System.ComponentModel.DataAnnotations;

namespace SBCRM.Legacy.Dtos
{
    public class GetSecureForEditOutput
    {
        public CreateOrEditSecureDto Secure { get; set; }

    }
}