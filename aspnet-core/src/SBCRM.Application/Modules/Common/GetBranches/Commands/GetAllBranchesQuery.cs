using MediatR;
using SBCRM.Modules.Administration.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBCRM.Modules.Common.GetBranches.Commands
{
    /// <summary>
    /// Used to get branch by branch number
    /// </summary>
    public class GetAllBranchesQuery : IRequest<List<BranchForDepartmentDto>>
    {  

    }
}
