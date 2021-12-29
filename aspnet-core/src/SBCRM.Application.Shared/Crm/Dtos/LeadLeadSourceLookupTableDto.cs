namespace SBCRM.Crm.Dtos
{
    /// <summary>
    /// A lookup table dto for lead sources
    /// </summary>
    public class LeadLeadSourceLookupTableDto
    {
        public int Id { get; set; }

        public string DisplayName { get; set; }

        public bool IsDefault { get; set; }
    }
}