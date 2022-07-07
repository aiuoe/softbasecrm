﻿using MediatR;
using SBCRM.Base;
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
    public class GetAdditionalChargesByBranchAndDepartmentCommandHandler : SBCRMAppServiceBase, IRequestHandler<GetAdditionalChargesByBranchAndDepartmentCommand, List<GetAdditionalChargeDto>>
    {
        private readonly IAdditionalChargesRepository _additionalChargesRepository;

        public GetAdditionalChargesByBranchAndDepartmentCommandHandler(IAdditionalChargesRepository additionalChargesRepository)
        {
            _additionalChargesRepository = additionalChargesRepository;
        }

        public async Task<List<GetAdditionalChargeDto>> Handle(GetAdditionalChargesByBranchAndDepartmentCommand request, CancellationToken cancellationToken)
        {
            var addnlCharges = await _additionalChargesRepository.GetAllListAsync(ac => ac.Branch == request.BranchNo && ac.Dept == request.DepartmentNo);
            List<GetAdditionalChargeDto> addnlChargesRes = null;

            if (addnlCharges.Count > 0)
            {
                addnlChargesRes = ObjectMapper.Map(addnlCharges, new List<GetAdditionalChargeDto>());
            }

            return addnlChargesRes;
        }
    }
}
