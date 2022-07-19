using MediatR;
using SBCRM.Modules.Administration.Branch.Dtos;

namespace SBCRM.Modules.Administration.Branch.Queries
{
    /// <summary>
    /// Query for getting zipcode details
    /// </summary>
    public class GetZipCodeDetailsQuery : IRequest<GetZipCodeDetailsDto>
    {
        public string ZipCode { get; set; }


        /// <summary>
        /// Base constructor
        /// </summary>
        /// <param name="zipCode"></param>
        public GetZipCodeDetailsQuery(string zipCode)
        {
            ZipCode = zipCode;
        }
    }
}
