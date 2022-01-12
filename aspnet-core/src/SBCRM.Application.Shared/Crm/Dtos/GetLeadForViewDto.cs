using System;

namespace SBCRM.Crm.Dtos
{
    /// <summary>
    /// DTO to manage the object lead for view purposes
    /// </summary>
    public class GetLeadForViewDto
    {
        public LeadDto Lead { get; set; }

        public string LeadSourceDescription { get; set; }

        public string LeadStatusDescription { get; set; }

        public string LeadStatusColor { get; set; }

        public string PriorityDescription { get; set; }

        public object City { get; set; }

        public bool LeadCanBeConvert { get; set; }

        public string PriorityColor { get; set; }

        public long? FirstUserAssignedId { get; set; }

        public string FirstUserAssignedName { get; set; }

        public string FirstUserAssignedSurName { get; set; }

        public string FirstUserAssignedFullName { get; set; }

        public Guid? FirstUserProfilePictureUrl { get; set; }

        public int AssignedUsers { get; set; }

        public bool CanViewActivityWidget { get; set; }
        public bool CanCreateActivity { get; set; }
        public bool CanViewScheduleMeetingOption { get; set; }
        public bool CanViewScheduleCallOption { get; set; }
        public bool CanViewEmailReminderOption { get; set; }
        public bool CanViewToDoReminderOption { get; set; }
        public bool CanEditActivity { get; set; }
        public bool CanAssignAnyUserInActivity { get; set; }
        public bool CanViewAttachmentsWidget { get; set; }
    }
}