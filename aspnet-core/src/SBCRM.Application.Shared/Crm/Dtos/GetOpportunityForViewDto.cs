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

    }
}