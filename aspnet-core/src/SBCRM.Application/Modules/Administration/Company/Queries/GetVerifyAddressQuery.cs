using MediatR;
using SBCRM.Modules.Administration.Dtos;
namespace SBCRM.Modules.Administration.Company.Queries
{
    /// <summary>
    /// Verify address Query which uses avalara service
    /// </summary>
    public class GetVerifyAddressQuery : IRequest<GetVerifyAddressDto>
    {
        public string City { get; set; }
        public string Country { get; set; }
        public string ZipCode { get; set; }
        public string State { get; set; }
        public string Address { get; set; }

        /// <summary>
        /// input address to query map contructor
        /// </summary>
        /// <param name="address"></param>
        public GetVerifyAddressQuery(GetVerifyAddressInputDto address)
        {
            City = address.City;
            Country = address.Country;
            ZipCode = address.ZipCode;
            State = address.State;
            Address = address.Address;
        }

    }
}
