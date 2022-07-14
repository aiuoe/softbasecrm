using Abp.UI;
using MediatR;
using SBCRM.Avalara;
using SBCRM.Base;
using SBCRM.Common;
using SBCRM.Dto;
using SBCRM.Modules.Common.Avalara.Dto;
using SBCRM.Modules.Common.Avalara.Queries;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SBCRM.Modules.Common.Avalara.Handlers
{
    /// <summary>
    /// Handler for the Get Tax Code Types Query
    /// </summary>
    public class GetTaxCodeTypesQueryHandler : UseCaseServiceBase, IRequestHandler<GetTaxCodeTypesQuery, List<TaxCodeTypeDto>>
    {
        private readonly IAvalaraService _avalaraService;
        private readonly ISalesTaxIntegrationRepository _salesTaxIntegrationRepository;
        public GetTaxCodeTypesQueryHandler(IAvalaraService avalaraService, ISalesTaxIntegrationRepository salesTaxIntegrationRepository)
        {
            _avalaraService = avalaraService;
            _salesTaxIntegrationRepository = salesTaxIntegrationRepository;
        }

        public async Task<List<TaxCodeTypeDto>> Handle(GetTaxCodeTypesQuery request, CancellationToken cancellationToken)
        {
            List<TaxCodeTypeDto> taxCodeTypes = new List<TaxCodeTypeDto>();

            if (await _salesTaxIntegrationRepository.CheckUseDefaultTaxCodeCalc())
            {
                AvalaraConnectionDataDto connectionData = await _salesTaxIntegrationRepository.GetAvalaraConnectionSettings();
                GuardHelper.ThrowIf(connectionData == null, new UserFriendlyException(L("TenantHasNoIntegrationTaxSettings")));

                taxCodeTypes = await _avalaraService.GetTaxCodeTypes(connectionData);
            }

            return taxCodeTypes;
        }
    }
}
