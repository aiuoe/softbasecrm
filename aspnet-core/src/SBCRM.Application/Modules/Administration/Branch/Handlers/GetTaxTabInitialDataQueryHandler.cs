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
        public Task<GetTaxTabInitialDataDto> Handle(GetTaxTabInitialDataQuery query, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
