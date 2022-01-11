namespace SBCRM.Crm.Dtos
{
    /// <summary>
    /// A opportunity attachment model for viewing purposes.
    /// </summary>
    public class GetOpportunityAttachmentForViewDto
    {
        public OpportunityAttachmentDto OpportunityAttachment { get; set; }

        public string OpportunityName { get; set; }

    }
}