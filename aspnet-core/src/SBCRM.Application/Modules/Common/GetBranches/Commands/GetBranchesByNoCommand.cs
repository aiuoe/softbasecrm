using MediatR;
using SBCRM.Modules.Administration.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBCRM.Modules.Common.GetBranches.Commands
{
    public class GetBranchesByNoCommand : IRequest<List<GetBranchDto>>
    {
        public GetBranchesByNoCommand(short number)
        {
            Number = number;
        }

        public short Number { get; set; }   

    }
}
