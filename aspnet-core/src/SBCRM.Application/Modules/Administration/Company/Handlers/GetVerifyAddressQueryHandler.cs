using MediatR;
using SBCRM.Avalara;
using SBCRM.Base;
using SBCRM.Dto;
using SBCRM.Modules.Administration.Company.Queries;
using SBCRM.Modules.Administration.Dtos;
using System.Threading;
using System.Threading.Tasks;

namespace SBCRM.Modules.Administration.Company.Handlers
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

            var is_true = await _salesTaxIntegrationRepository.CheckUseDefaultTaxCodeCalc();
            if (!is_true)
            {
                return new GetVerifyAddressDto()
                {
                    CheckUseDefaultTaxCodeCalc = false,
                    Address = request.Address,
                    ZipCode = request.ZipCode,
                    City = request.City,
                    State = request.State,

                };
            }

            var connection = _salesTaxIntegrationRepository.GetAvalaraConnectionSettings();
            var address = new AddressDto()
            {
                Address = request.Address,
                ZipCode = request.ZipCode,
                City = request.City,
                State = request.State,
                Country = request.Country,

            };

            var verifiedAddress = await _avalaraService.VerifyAddress(connection.Result, address);

            return verifiedAddress;

        }
    }
}
