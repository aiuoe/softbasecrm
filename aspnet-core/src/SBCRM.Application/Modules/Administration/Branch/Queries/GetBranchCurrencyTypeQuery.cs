using MediatR;
using SBCRM.Modules.Administration.Branch.Dtos;

namespace SBCRM.Modules.Administration.Branch.Queries
{
    /// <summary>
    /// Get branch currency type query
    /// </summary>
    public class GetBranchCurrencyTypeQuery : IRequest<BranchCurrencyTypeDto>
    {
        public long BranchId { get; set; }
        public long CurrencyTypeId { get; set; }
    }
}
