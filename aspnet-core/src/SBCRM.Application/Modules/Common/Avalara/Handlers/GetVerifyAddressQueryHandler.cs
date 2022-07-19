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
    /// Verify Address Query Handler
    /// </summary>
    public class GetVerifyAddressQueryHandler : SBCRMAppServiceBase, IRequestHandler<GetVerifyAddressQuery, GetVerifyAddressDto>
    {

        private ISalesTaxIntegrationRepository _salesTaxIntegrationRepository;
        private IAvalaraService _avalaraService;

        /// <summary>
        /// base constructor
        /// </summary>
        /// <param name="salesTaxIntegrationRepository"></param>
        /// <param name="avalaraService"></param>
        public GetVerifyAddressQueryHandler(ISalesTaxIntegrationRepository salesTaxIntegrationRepository, IAvalaraService avalaraService)
        {
            _salesTaxIntegrationRepository = salesTaxIntegrationRepository;
            _avalaraService = avalaraService;
        }



        public async Task<GetVerifyAddressDto> Handle(GetVerifyAddressQuery request, CancellationToken cancellationToken)
        {

            var useDefaultTaxCodeCalc = await _salesTaxIntegrationRepository.CheckUseDefaultTaxCodeCalc();

            GetVerifyAddressDto verifiedAddress = new GetVerifyAddressDto();

            if (useDefaultTaxCodeCalc)
            {
                var connection = await _salesTaxIntegrationRepository.GetAvalaraConnectionSettings();
                var address = ObjectMapper.Map<AddressDto>(request);
                verifiedAddress = await _avalaraService.VerifyAddress(connection, address);
            }



            return verifiedAddress;

        }
    }
}
