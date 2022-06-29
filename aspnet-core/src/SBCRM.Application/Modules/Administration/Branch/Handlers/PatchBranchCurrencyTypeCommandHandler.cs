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
        private readonly IBranchRepository _branchRepository;
        private readonly IBranchARCurrencyTypeRepository _branchARCurrencyTypeRepository;
        private readonly ICurrencyTypeRepository _currencyTypeRepository;

        /// <summary>
        /// Base constructor
        /// </summary>
        /// <param name="branchRepository"></param>
        /// <param name="branchARCurrencyTypeRepository"></param>
        /// <param name="currencyTypeRepository"></param>
        public PatchBranchCurrencyTypeCommandHandler(
            IBranchRepository branchRepository,
            IBranchARCurrencyTypeRepository branchARCurrencyTypeRepository,
            ICurrencyTypeRepository currencyTypeRepository)
        {
            _branchRepository = branchRepository;
            _branchARCurrencyTypeRepository = branchARCurrencyTypeRepository;
            _currencyTypeRepository = currencyTypeRepository;
        }

        /// <summary>
        /// Patch branch currency type
        /// </summary>
        /// <param name="command"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<BranchCurrencyTypeDto> Handle(PatchBranchCurrencyTypeCommand command, CancellationToken cancellationToken)
        {
            var branch = await _branchRepository.FirstOrDefaultAsync(x => x.Id == command.BranchId);
            var currencyType = await _currencyTypeRepository.FirstOrDefaultAsync(x => x.Id == command.CurrencyTypeId);
            var branchCurrencyType = await _branchARCurrencyTypeRepository.FirstOrDefaultAsync(x => x.Branch == branch.Number && x.CurrencyType == currencyType.CurrencyTypeName);
            branchCurrencyType.AraccountNo = command.AraccountNo;
            branchCurrencyType.DebitAccount = command.DebitAccount;
            branchCurrencyType.CreditAccount = command.CreditAccount;
            branchCurrencyType.DebitAccountReevaluate = command.DebitAccountReevaluate;
            branchCurrencyType.CreditAccountReevaluate = command.CreditAccountReevaluate;
            await _branchARCurrencyTypeRepository.UpdateAsync(branchCurrencyType);
            return ObjectMapper.Map<BranchCurrencyTypeDto>(branchCurrencyType);
        }
    }
}
