using MediatR;
using SBCRM.Base;
using SBCRM.Modules.Common.SalesTaxIntegration.Dto;
using SBCRM.Modules.Common.SalesTaxIntegration.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SBCRM.Modules.Common.SalesTaxIntegration.Handlers
{
    public class SalesTaxIntegrationQueryHandler : SBCRMAppServiceBase, IRequestHandler<SalesTaxIntegrationQuery, SalesTaxIntegrationDto>
    {
        private readonly ISalesTaxIntegrationRepository _salesTaxIntegrationRepository;

        public SalesTaxIntegrationQueryHandler(ISalesTaxIntegrationRepository salesTaxIntegrationRepository)
        {
            _salesTaxIntegrationRepository = salesTaxIntegrationRepository;
        }

        public async Task<SalesTaxIntegrationDto> Handle(SalesTaxIntegrationQuery request, CancellationToken cancellationToken)
        {
            var values = await _salesTaxIntegrationRepository.GetAllListAsync();
            return ObjectMapper.Map<SalesTaxIntegrationDto>(values.FirstOrDefault());
        }
    }
}
