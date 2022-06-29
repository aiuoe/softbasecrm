using MediatR;
using SBCRM.Modules.Administration.Branch.Dtos;
using SBCRM.Modules.Administration.Branch.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SBCRM.Modules.Administration.Branch.Handlers
{
    public class GetBranchDetailsQueryHandler : SBCRMAppServiceBase, IRequestHandler<GetBranchDetailsQuery, GetBranchDetailsDto>
    {
        public GetBranchDetailsQueryHandler()
        {

        }

        public Task<GetBranchDetailsDto> Handle(GetBranchDetailsQuery query, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
