
using SBCRM.Dto;
using SBCRM.Dto.AvalaraConnection.TaxCodes;
using SBCRM.Modules.Common.Avalara.Dto;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace SBCRM.Avalara
{
    /// <summary>
    /// Interface to provide avalara services
    /// </summary>
    public interface IAvalaraService
    {
        void VerifyAddress(AvalaraConnectionDataDto avalaraConnectionData, AddressDto address);

        Task<List<TaxCodeDto>> GetTaxCodes(AvalaraConnectionDataDto avalaraConnectionDataDto, GetTaxCodesParametersDto getTaxCodesParameters);

        Task<List<TaxCodeTypeDto>> GetTaxCodeTypes(AvalaraConnectionDataDto avalaraConnectionData);
    }
}
