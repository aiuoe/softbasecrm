﻿using System;
using Abp.Application.Services.Dto;
using System.ComponentModel.DataAnnotations;

namespace SBCRM.Crm.Dtos
{
    public class GetAccountTypeForEditOutput
    {
        public CreateOrEditAccountTypeDto AccountType { get; set; }

    }
}