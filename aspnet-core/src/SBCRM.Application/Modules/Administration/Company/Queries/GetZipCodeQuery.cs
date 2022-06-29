using MediatR;
using SBCRM.Modules.Administration.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBCRM.Modules.Administration.Company.Queries
{
    public class GetZipCodeQuery : IRequest<List<GetZipCodeDto>>
    {
        public string _zipCode;
        public GetZipCodeQuery(string zipCode)
        {
            _zipCode = zipCode;


        }

    }
}
