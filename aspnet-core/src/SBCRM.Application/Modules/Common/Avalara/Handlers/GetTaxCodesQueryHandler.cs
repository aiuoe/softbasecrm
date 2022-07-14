using Abp.Application.Services.Dto;
using Abp.UI;
using MediatR;
using SBCRM.Avalara;
using SBCRM.Base;
using SBCRM.Common;
using SBCRM.Dto;
using SBCRM.Dto.AvalaraConnection.TaxCodes;
using SBCRM.Modules.Common.Avalara.Dto;
using SBCRM.Modules.Common.Avalara.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SBCRM.Modules.Common.Avalara.Handlers
{
    /// <summary>
    /// Handler for the Get Tax Codes Method
    /// </summary>
    public class GetTaxCodesQueryHandler : UseCaseServiceBase, IRequestHandler<GetTaxCodesQuery, PagedResultDto<TaxCodeDto>>
    {
        private readonly IAvalaraService _avalaraService;
        private readonly ISalesTaxIntegrationRepository _salesTaxIntegrationRepository;

        public GetTaxCodesQueryHandler(IAvalaraService avalaraService, ISalesTaxIntegrationRepository salesTaxIntegrationRepository)
        {
            _avalaraService = avalaraService;
            _salesTaxIntegrationRepository = salesTaxIntegrationRepository;
        }

        public async Task<PagedResultDto<TaxCodeDto>> Handle(GetTaxCodesQuery request, CancellationToken cancellationToken)
        {
            PagedResultDto<TaxCodeDto> taxCodes = new PagedResultDto<TaxCodeDto>();

            if (await _salesTaxIntegrationRepository.CheckUseDefaultTaxCodeCalc())
            {
                AvalaraConnectionDataDto connectionData = await _salesTaxIntegrationRepository.GetAvalaraConnectionSettings();
                GuardHelper.ThrowIf(connectionData == null, new UserFriendlyException(L("TenantHasNoIntegrationTaxSettings")));

                GetTaxCodesParametersDto parameters = new GetTaxCodesParametersDto(request.SkipCount, request.MaxResultCount,request.TaxCodeType,
                    request.TaxCode, request.ParentTaxCode, request.Description);

                taxCodes = await _avalaraService.GetTaxCodes(connectionData, parameters);
            }

            return taxCodes;
        }
    }
}
