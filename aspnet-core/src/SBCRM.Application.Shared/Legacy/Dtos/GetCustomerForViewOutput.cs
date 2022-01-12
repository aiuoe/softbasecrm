namespace SBCRM.Legacy.Dtos
{
    /// <summary>
    /// DTO to manage the object customer for view purposes
    /// </summary>
    public class GetCustomerForViewOutput
    {
        public CreateOrEditCustomerDto Customer { get; set; }
        public string AccountTypeDescription { get; set; }
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