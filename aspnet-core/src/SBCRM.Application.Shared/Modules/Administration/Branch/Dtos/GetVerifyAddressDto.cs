
namespace SBCRM.Modules.Administration.Dtos
{
    /// <summary>
    /// Verifiy address dto
    /// </summary>
    public class GetVerifyAddressDto
    {
        public bool CheckUseDefaultTaxCodeCalc { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string ZipCode { get; set; }
        public string State { get; set; }
        public string Address { get; set; }
    }
}
