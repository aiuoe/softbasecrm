namespace SBCRM.Crm.Dtos
{
    /// <summary>
    /// DTO to manage the customer - country lookup object
    /// </summary>
    public class CustomerCountryLookupTableDto
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string DisplayName { get; set; }
    }
}
