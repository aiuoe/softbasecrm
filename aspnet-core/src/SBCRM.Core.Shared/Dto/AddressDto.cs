namespace SBCRM.Dto
{
    /// <summary>
    /// Dto to verify address
    /// </summary>
    public class AddressDto
    {
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string Country { get; set; }
    }
}
