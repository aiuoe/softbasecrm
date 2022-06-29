using MediatR;
using SBCRM.Modules.Administration.Dtos;

namespace SBCRM.Modules.Administration.Branch.Commands
{
    /// <summary>
    /// Patch branch cuurrency type command
    /// </summary>
    public class PatchBranchCurrencyTypeCommand : IRequest<BranchCurrencyTypeDto>
    {
        public long BranchId { get; set; }
        public long CurrencyTypeId { get; set; }
        public string ArAccountNo { get; set; }
        public string DebitAccount { get; set; }
        public string CreditAccount { get; set; }
        public string DebitAccountReevaluate { get; set; }
        public string CreditAccountReevaluate { get; set; }
    }
}
