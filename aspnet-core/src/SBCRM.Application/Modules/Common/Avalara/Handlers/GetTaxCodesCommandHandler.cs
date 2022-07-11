using MediatR;
using SBCRM.Avalara;
using SBCRM.Dto;
using SBCRM.Dto.AvalaraConnection.TaxCodes;
using SBCRM.Modules.Common.Avalara.Commands;
using SBCRM.Modules.Common.Avalara.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SBCRM.Modules.Common.Avalara.Handlers
{
    public class GetTaxCodesCommandHandler : SBCRMAppServiceBase, IRequestHandler<GetTaxCodesCommand, List<TaxCodeDto>>
    {
        private readonly IAvalaraService _avalaraService;

        public GetTaxCodesCommandHandler(IAvalaraService avalaraService)
        {
            _avalaraService = avalaraService;
        }

        public Task<List<TaxCodeDto>> Handle(GetTaxCodesCommand request, CancellationToken cancellationToken)
        {
            AvalaraConnectionDataDto connectionData = new AvalaraConnectionDataDto();
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
