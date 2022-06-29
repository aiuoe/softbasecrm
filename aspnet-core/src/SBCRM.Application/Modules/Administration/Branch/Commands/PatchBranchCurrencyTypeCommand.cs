using MediatR;
using SBCRM.Modules.Administration.Dtos;

namespace SBCRM.Modules.Administration.Branch.Commands
{
    /// <summary>
    /// Pathch branch cuurrency type command
    /// </summary>
    public class PatchBranchCurrencyTypeCommand : IRequest<BranchCurrencyTypeDto>
    {
        public int Branch { get; set; }
        public string CurrencyType { get; set; }
        public BranchCurrencyTypeDto request { get; set; }
    }
}
