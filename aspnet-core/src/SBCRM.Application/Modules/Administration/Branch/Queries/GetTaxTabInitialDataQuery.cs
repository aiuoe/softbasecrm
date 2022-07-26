using MediatR;
using SBCRM.Modules.Administration.Branch.Dtos;

namespace SBCRM.Modules.Administration.Branch.Queries
{
    /// <summary>
    /// Get tax tab dropdown data in Branch sub module query
    /// </summary>
    public class GetTaxTabInitialDataQuery: IRequest<GetTaxTabInitialDataDto>
    {
    }
}
