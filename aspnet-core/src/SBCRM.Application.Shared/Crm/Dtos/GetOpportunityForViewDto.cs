using System;

namespace SBCRM.Crm.Dtos
{
    /// <summary>
    /// DTO to manage the object opportunity for view purposes
    /// </summary>
    public class GetOpportunityForViewDto
    {
        public OpportunityDto Opportunity { get; set; }

        public string OpportunityStageDescription { get; set; }

        public string OpportunityStageColor { get; set; }

        public string LeadSourceDescription { get; set; }

        public string OpportunityTypeDescription { get; set; }

        public string CustomerName { get; set; }

        public string CustomerNumber { get; set; }

        public string ContactName { get; set; }

        public long? FirstUserAssignedId { get; set; }

        public string FirstUserAssignedName { get; set; }

        public string FirstUserAssignedSurName { get; set; }

        public string FirstUserAssignedFullName { get; set; }

        public Guid? FirstUserProfilePictureUrl { get; set; }

        public int AssignedUsers { get; set; }

        public string BranchName { get; set; }

        public string DepartmentTitle { get; set; }

        public bool CanViewScheduleMeetingOption { get; set; }
        public bool CanViewScheduleCallOption { get; set; }
        public bool CanViewEmailReminderOption { get; set; }
        public bool CanViewToDoReminderOption { get; set; }
    }
}