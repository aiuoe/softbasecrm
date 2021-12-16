using System;
using Abp.Application.Services.Dto;
using System.ComponentModel.DataAnnotations;

namespace SBCRM.Legacy.Dtos
{
    /// <summary>
    /// Gets a secure instance to create or edit
    /// </summary>
    public class GetSecureForEditOutput
    {
        public CreateOrEditSecureDto Secure { get; set; }

    }
}