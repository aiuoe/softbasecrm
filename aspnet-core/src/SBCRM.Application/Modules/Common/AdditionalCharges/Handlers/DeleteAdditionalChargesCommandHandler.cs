using MediatR;
using SBCRM.Base;
using SBCRM.Modules.Common.AdditionalCharges.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SBCRM.Modules.Common.AdditionalCharges.Handlers
{
    public class DeleteAdditionalChargesCommandHandler : SBCRMAppServiceBase, IRequestHandler<DeleteAdditionalChargesCommand, Unit>
    {
        private readonly IAdditionalChargesRepository _additionalChargesRepository;

        public DeleteAdditionalChargesCommandHandler(IAdditionalChargesRepository additionalChargesRepository)
        {
            _additionalChargesRepository = additionalChargesRepository;
        }
        public async Task<Unit> Handle(DeleteAdditionalChargesCommand request, CancellationToken cancellationToken)
        {
            var addnlCharge = await _additionalChargesRepository.GetAsync(request.Id);

            if (addnlCharge.IsDeleted == false)
            {
                await _additionalChargesRepository.DeleteAsync(request.Id); 
            }
            return Unit.Value;
        }
    }
}
