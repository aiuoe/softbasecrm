using System;
using Abp.Application.Services.Dto;
using System.ComponentModel.DataAnnotations;

namespace SBCRM.Crm.Dtos
{
    public class GetLeadForEditOutput
    {
        public CreateOrEditLeadDto Lead { get; set; }

        public string LeadSourceDescription { get; set; }

        public string LeadStatusDescription { get; set; }

        public string PriorityDescription { get; set; }

    }
}