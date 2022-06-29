using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SBCRM.Base;
using SBCRM.Modules.Administration.Branch.Commands;
using SBCRM.Modules.Administration.Dtos;

namespace SBCRM.Modules.Administration.Branch.Handlers
{
    /// <summary>
    /// Patch branch currency type query handler
    /// </summary>
    public class PatchBranchCurrencyTypeCommandHandler : SBCRMAppServiceBase, IRequestHandler<PatchBranchCurrencyTypeCommand, BranchCurrencyTypeDto>
    {
        private readonly IBranchARCurrencyTypeRepository _branchARCurrencyTypeRepository;

        /// <summary>
        /// Base constructor
        /// </summary>
        /// <param name="branchARCurrencyTypeRepository"></param>
        public PatchBranchCurrencyTypeCommandHandler(IBranchARCurrencyTypeRepository branchARCurrencyTypeRepository)
        {
            _branchARCurrencyTypeRepository = branchARCurrencyTypeRepository;
        }

        /// <summary>
        /// Patch branch currency type
        /// </summary>
        /// <param name="command"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<BranchCurrencyTypeDto> Handle(PatchBranchCurrencyTypeCommand command, CancellationToken cancellationToken)
        {
            var branchCurrencyType = await _branchARCurrencyTypeRepository.FirstOrDefaultAsync(x => x.Branch == command.Branch && x.CurrencyType == command.CurrencyType);
            branchCurrencyType.AraccountNo = command.request.AraccountNo;
            branchCurrencyType.DebitAccount = command.request.DebitAccount;
            branchCurrencyType.CreditAccount = command.request.CreditAccount;
            branchCurrencyType.DebitAccountReevaluate = command.request.DebitAccountReevaluate;
            branchCurrencyType.CreditAccountReevaluate = command.request.CreditAccountReevaluate;
            await _branchARCurrencyTypeRepository.UpdateAsync(branchCurrencyType);
            return ObjectMapper.Map<BranchCurrencyTypeDto>(branchCurrencyType);
        }
    }
}
