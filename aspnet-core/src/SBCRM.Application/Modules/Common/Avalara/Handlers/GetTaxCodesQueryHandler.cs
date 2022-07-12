using MediatR;
using SBCRM.Avalara;
using SBCRM.Base;
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
    public class GetTaxCodesQueryHandler : SBCRMAppServiceBase, IRequestHandler<GetTaxCodesQuery, List<TaxCodeDto>>
    {
        private readonly IAvalaraService _avalaraService;
        //private readonly ISalesTaxIntegrationRepository _salesTaxIntegrationRepository;

        public GetTaxCodesQueryHandler(IAvalaraService avalaraService/*, ISalesTaxIntegrationRepository salesTaxIntegrationRepository*/)
        {
            _avalaraService = avalaraService;
            //_salesTaxIntegrationRepository = salesTaxIntegrationRepository;
        }

        public async Task<List<TaxCodeDto>> Handle(GetTaxCodesQuery request, CancellationToken cancellationToken)
        {
            AvalaraConnectionDataDto connectionData = new AvalaraConnectionDataDto();
            //connectionData = await _salesTaxIntegrationRepository.GetAvalaraConnectionSettings();            
            connectionData.SalesTaxProvider = "Avalara";
            connectionData.AccountNumber = "2001520504";
            connectionData.ServiceUrl = "https://sandbox-rest.avatax.com/";
            connectionData.LicenseKey = "1331EBDA8070CD00";
            connectionData.RequestTimeout = 0;
            GetTaxCodesParametersDto parameters = new GetTaxCodesParametersDto();
            if (!string.IsNullOrWhiteSpace(request.Filter))
            {
                parameters.Filter = request.Filter;
            }
            
            var response = _avalaraService.GetTaxCodes(connectionData,parameters);
            throw new NotImplementedException();

            //var branches = await _branchRepository.GetAllListAsync(b => b.Number == request.Number);

            //return ObjectMapper.Map(branches, new List<GetBranchDto>());
        }
    }
}
