namespace SBCRM.Crm.Dtos
{
    /// <summary>
    /// DTO to manage the object opportunity user for view purposes
    /// </summary>
    public class GetOpportunityUserForViewDto
    {
        public OpportunityUserDto OpportunityUser { get; set; }

        public string UserName { get; set; }

        public string OpportunityName { get; set; }

    }
}