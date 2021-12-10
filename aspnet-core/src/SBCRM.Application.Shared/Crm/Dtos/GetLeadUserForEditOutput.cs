using System;
using Abp.Application.Services.Dto;
using System.ComponentModel.DataAnnotations;

namespace SBCRM.Crm.Dtos
{
    public class GetLeadUserForEditOutput
    {
        public CreateOrEditLeadUserDto LeadUser { get; set; }

        public string LeadCompanyName { get; set; }

        public string UserName { get; set; }

    }
}