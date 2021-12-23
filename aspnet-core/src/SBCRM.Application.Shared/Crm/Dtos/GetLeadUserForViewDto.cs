namespace SBCRM.Crm.Dtos
{
    /// <summary>
    /// DTO to manage the object lead user for view purposes
    /// </summary>
    public class GetLeadUserForViewDto
    {
        public LeadUserDto LeadUser { get; set; }

        public string LeadCompanyName { get; set; }

        public string UserName { get; set; }

    }
}