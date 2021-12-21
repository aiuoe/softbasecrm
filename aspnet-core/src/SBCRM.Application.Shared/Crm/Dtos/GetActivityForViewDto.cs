namespace SBCRM.Crm.Dtos
{
    public class GetActivityForViewDto
    {
        public ActivityDto Activity { get; set; }

        public string OpportunityName { get; set; }

        public string LeadCompanyName { get; set; }

        public string UserName { get; set; }

        public string ActivitySourceTypeDescription { get; set; }

        public string ActivityTaskTypeDescription { get; set; }

        public string ActivityStatusDescription { get; set; }

        public string ActivityPriorityDescription { get; set; }

    }
}