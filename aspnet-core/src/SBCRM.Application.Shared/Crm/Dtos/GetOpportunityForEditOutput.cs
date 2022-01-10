namespace SBCRM.Crm.Dtos
{
    /// <summary>
    /// DTO to manage the object opportunity for edit purposes
    /// </summary>
    public class GetOpportunityForEditOutput
    {
        public CreateOrEditOpportunityDto Opportunity { get; set; }

        public string OpportunityStageDescription { get; set; }

        public string LeadSourceDescription { get; set; }

        public string OpportunityTypeDescription { get; set; }

        public string CustomerName { get; set; }

        public string CustomerNumber { get; set; }

        public string ContactName { get; set; }

        public string BranchName { get; set; }

        public string DepartmentTitle { get; set; }

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