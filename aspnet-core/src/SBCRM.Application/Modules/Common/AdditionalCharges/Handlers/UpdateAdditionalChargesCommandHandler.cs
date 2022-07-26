using MediatR;
using SBCRM.Base;
using SBCRM.Modules.Common.AdditionalCharges.Commands;
using System.Threading;
using System.Threading.Tasks;

namespace SBCRM.Modules.Common.AdditionalCharges.Handlers
{
    public class UpdateAdditionalChargesCommandHandler : SBCRMAppServiceBase, IRequestHandler<UpdateAdditionalChargesCommand, Unit>
    {
        private readonly IAdditionalChargesRepository _additionalChargesRepository;

        public UpdateAdditionalChargesCommandHandler(IAdditionalChargesRepository additionalChargesRepository)
        {
            _additionalChargesRepository = additionalChargesRepository;
        }

        public async Task<Unit> Handle(UpdateAdditionalChargesCommand request, CancellationToken cancellationToken)
        {
            var addnlCharge = await _additionalChargesRepository.GetAsync(request.Id);
            request.AdditionalCharge.Id = addnlCharge.Id.ToString();
            if (addnlCharge != null)
            {
                await _additionalChargesRepository.UpdateAsync(ObjectMapper.Map(request.AdditionalCharge, addnlCharge));
            }
            return Unit.Value;  
        }
    }
}
