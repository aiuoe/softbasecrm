using MediatR;
using SBCRM.Modules.Administration.Dtos;

namespace SBCRM.Modules.Administration.Branch.Queries
{
    /// <summary>
    /// Get branch currency type query
    /// </summary>
    public class GetBranchCurrencyTypeQuery : IRequest<BranchCurrencyTypeDto>
    {
        public int Branch { get; set; }
        public string CurrencyType { get; set; }
    }
}
