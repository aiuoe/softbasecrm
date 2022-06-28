using MediatR;
using SBCRM.Modules.Administration.Branch.Dtos;
using SBCRM.Modules.Administration.Branch.Queries;
using SBCRM.Modules.Administration.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SBCRM.Modules.Administration.Branch.Handlers
{
    public class GetInitialValuesForTaxSetupDropdownHandler : SBCRMAppServiceBase, IRequestHandler<GetInitialValuesForTaxSetupDropdownQuery, GetValuesForDropdownsInTaxSetupBanchDto>
    {
        public GetInitialValuesForTaxSetupDropdownHandler()
        {

        }
        public Task<GetValuesForDropdownsInTaxSetupBanchDto> Handle(GetInitialValuesForTaxSetupDropdownQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
