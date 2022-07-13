
namespace SBCRM.Modules.Administration.Dtos
{
    /// <summary>
    /// Verify address input Dto
    /// </summary>
    public class GetVerifyAddressInputDto
    {
        public string City { get; set; }
        public string Country { get; set; }
        public string ZipCode { get; set; }
        public string State { get; set; }
        public string Address { get; set; }
    }
}
