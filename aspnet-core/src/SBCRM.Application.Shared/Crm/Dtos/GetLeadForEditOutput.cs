using System;
using Abp.Application.Services.Dto;
using System.ComponentModel.DataAnnotations;

namespace SBCRM.Crm.Dtos
{
    /// <summary>
    /// DTO to manage the object lead for edit purposes
    /// </summary>
    public class GetLeadForEditOutput
    {
        public CreateOrEditLeadDto Lead { get; set; }

        public string LeadSourceDescription { get; set; }

        public string LeadStatusDescription { get; set; }

        public string PriorityDescription { get; set; }

        public bool CanViewActivityWidget { get; set; }
        public bool CanCreateActivity { get; set; }
        public bool CanViewScheduleMeetingOption { get; set; }
        public bool CanViewScheduleCallOption { get; set; }
        public bool CanViewEmailReminderOption { get; set; }
        public bool CanViewToDoReminderOption { get; set; }
        public bool CanEditActivity { get; set; }
        public bool CanAssignAnyUserInActivity { get; set; }

    }
}