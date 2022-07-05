using MediatR;
using SBCRM.Modules.Administration.Dtos;
using System.Collections.Generic;

namespace SBCRM.Modules.Administration.Company.Queries
{
    /// <summary>
    /// Zip Code query Class
    /// </summary>
    public class GetZipCodeQuery : IRequest<List<GetZipCodeDto>>
    {
        public string ZipCode;
        public GetZipCodeQuery(string zipCode)
        {
            ZipCode = zipCode;
        }

    }
}
