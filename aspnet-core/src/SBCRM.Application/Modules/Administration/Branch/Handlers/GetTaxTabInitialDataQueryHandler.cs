using MediatR;
using SBCRM.Modules.Administration.Branch.Dtos;
using SBCRM.Modules.Administration.Branch.Queries;
using System.Threading;
using System.Threading.Tasks;

namespace SBCRM.Modules.Administration.Branch.Handlers
{
    /// <summary>
    /// Get initial tax tab data query handler
    /// </summary>
    public class GetTaxTabInitialDataQueryHandler : SBCRMAppServiceBase, IRequestHandler<GetTaxTabInitialDataQuery, GetTaxTabInitialDataDto>
    {
        /// <summary>
        /// Handles request for getting initial data for tax tab dropdowns in branch module
        /// </summary>
        /// <param name="query"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<GetTaxTabInitialDataDto> Handle(GetTaxTabInitialDataQuery query, CancellationToken cancellationToken)
        {
            return new GetTaxTabInitialDataDto();
        }
    }
}
