using MediatR;
using SBCRM.Avalara;
using SBCRM.Dto;
using SBCRM.Modules.Common.Avalara.Dto;
using SBCRM.Modules.Common.Avalara.Queries;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SBCRM.Modules.Common.Avalara.Handlers
{
    /// <summary>
    /// Verify Address Query Handler
    /// </summary>
    public class GetAvalaraCompanyCodesQueryHandler : UseCaseServiceBase, IRequestHandler<GetAvalaraCompanyCodesQuery, List<AvalaraCompanyCodes>>
    {

        private readonly IAvalaraService _avalaraService;

        /// <summary>
        /// base constructor
        /// </summary>
        /// <param name="avalaraService"></param>
        public GetAvalaraCompanyCodesQueryHandler(IAvalaraService avalaraService)
        {
            _avalaraService = avalaraService;
        }

        public async Task<List<AvalaraCompanyCodes>> Handle(GetAvalaraCompanyCodesQuery query, CancellationToken cancellationToken)
        {
            var connectionData = new AvalaraConnectionDataDto()
            {
                SalesTaxProvider = string.Empty,
                AccountNumber = query.AccountNumber,
                LicenseKey = query.LicenseKey,
                ServiceUrl = query.ServiceUrl,
                RequestTimeout = query.RequestTimeout,
            };

            return await _avalaraService.GetCompanyCodes(connectionData);
        }
    }
}
