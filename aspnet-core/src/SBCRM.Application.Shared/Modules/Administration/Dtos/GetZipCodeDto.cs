
namespace SBCRM.Modules.Administration.Dtos
{
    /// <summary>
    /// Dto for get city and state for a zipcode
    /// </summary>
    public class GetZipCodeDto
    {

        public string ZipCode { get; set; }
        public string City { get; set; }
        public string State { get; set; }

    }
}
