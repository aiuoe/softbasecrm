using MediatR;
using SBCRM.Avalara;
using SBCRM.Base;
using SBCRM.Dto;
using SBCRM.Modules.Common.Avalara.Dto;
using SBCRM.Modules.Common.Avalara.Queries;
using System.Threading;
using System.Threading.Tasks;

namespace SBCRM.Modules.Common.Avalara.Handlers
{
    /// <summary>
    /// Test avalara connection query handler
    /// </summary>
    public class TestAvalaraConnectionQueryHandler : UseCaseServiceBase, IRequestHandler<TestAvalaraConnectionQuery, bool>
    {

        private readonly IAvalaraService _avalaraService;

        /// <summary>
        /// base constructor
        /// </summary>
        /// <param name="avalaraService"></param>
        public TestAvalaraConnectionQueryHandler(IAvalaraService avalaraService)
        {
            _avalaraService = avalaraService;
        }

        public async Task<bool> Handle(TestAvalaraConnectionQuery query, CancellationToken cancellationToken)
        {
            var connectionData = new AvalaraConnectionDataDto()
            {
                SalesTaxProvider = string.Empty,
                AccountNumber = query.AccountNumber,
                LicenseKey = query.LicenseKey,
                ServiceUrl = query.ServiceUrl,
                RequestTimeout = query.RequestTimeout,
            };

            return await _avalaraService.TestConnection(connectionData);
        }
    }
}
