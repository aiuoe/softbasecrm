using MediatR;
using SBCRM.Modules.Administration.Branch.Dtos;

namespace SBCRM.Modules.Administration.Branch.Queries
{
    /// <summary>
    /// Get branch dropdown query
    /// </summary>
    public class GetBranchInitialDataQuery : IRequest<GetBranchInitialDataDto>
    {
    }
}
