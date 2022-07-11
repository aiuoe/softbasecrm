
using SBCRM.Dto;
using SBCRM.Dto.AvalaraConnection.TaxCodes;
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

        Task<HttpResponseMessage> GetTaxCodes(AvalaraConnectionDataDto avalaraConnectionDataDto, GetTaxCodesParametersDto getTaxCodesParameters);
    }
}
