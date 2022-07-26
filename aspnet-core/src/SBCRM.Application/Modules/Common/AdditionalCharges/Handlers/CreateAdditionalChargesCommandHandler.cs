using MediatR;
using SBCRM.Base;
using SBCRM.Core.BaseEntities;
using SBCRM.Modules.Common.AdditionalCharges.Commands;
using SBCRM.Modules.Common.AdditionalCharges.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SBCRM.Modules.Common.AdditionalCharges.Handlers
{
    public class CreateAdditionalChargesCommandHandler : SBCRMAppServiceBase, IRequestHandler<CreateAdditionalChargesCommand, CreatedAdditionalChargeResponseDto>
    {
        private readonly IAdditionalChargesRepository _additionalChargesRepository;

        public CreateAdditionalChargesCommandHandler(IAdditionalChargesRepository additionalChargesRepository)
        {
            _additionalChargesRepository = additionalChargesRepository;
        }

        public async Task<CreatedAdditionalChargeResponseDto> Handle(CreateAdditionalChargesCommand request, CancellationToken cancellationToken)
        {
            var addnlCharge = ObjectMapper.Map<AdditionalCharge>(request.AdditionalCharges);
            addnlCharge.Id = 0;
            SetTenant(addnlCharge);
            addnlCharge.Id = await _additionalChargesRepository.InsertAndGetIdAsync(addnlCharge);

            return new CreatedAdditionalChargeResponseDto {       
                Branch = addnlCharge.Branch.ToString(),
                Dept = addnlCharge.Dept.ToString(), 
                Id = addnlCharge.Id.ToString(),
                MiscDescription = addnlCharge.MiscDescription
            };
        }
    }
}
