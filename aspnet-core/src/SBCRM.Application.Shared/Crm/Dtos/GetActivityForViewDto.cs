namespace SBCRM.Crm.Dtos
{
    /// <summary>
    /// Activity Dto for Viewing
    /// </summary>
    public class GetActivityForViewDto
    {
        public ActivityDto Activity { get; set; }

        public string CompanyName { get; set; }

        public string OpportunityName { get; set; }

        public string LeadCompanyName { get; set; }

        public string UserName { get; set; }

        public string ActivitySourceTypeDescription { get; set; }

        public string ActivityTaskTypeDescription { get; set; }

        public string ActivityStatusDescription { get; set; }

        public string ActivityStatusColor { get; set; }

        public string ActivityPriorityDescription { get; set; }

        public string ActivityPriorityColor { get; set; }

        public string CustomerName { get; set; }
        public string ActivityTaskTypeColor { get; set; }
    }
}