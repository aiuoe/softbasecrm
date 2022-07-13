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

    }
}
