using MediatR;
using SBCRM.Modules.Administration.Branch.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBCRM.Modules.Administration.Branch.Queries
{
    public class GetBranchDetailsQuery: IRequest<GetBranchDetailsDto>
    {
    }
}
