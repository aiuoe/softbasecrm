using SBCRM.Avalara;
using SBCRM.Dto;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace SBCRM.Infrastructure.Avalara
{
    /// <summary>
    /// Class to implement avalara services
    /// </summary>
    public class AvalaraService : IAvalaraService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public AvalaraService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
            

        }
        /// <summary>
        /// Verify address
        /// </summary>
        /// <param name="avalaraConnectionData"></param>
        /// <param name="address"></param>
        public async void VerifyAddress(AvalaraConnectionDataDto avalaraConnectionData, AddressDto address)
        {
            string paramString = GetParamString(address);
            string url = GetUrl(avalaraConnectionData, paramString);

            var httpClient = _httpClientFactory.CreateClient();
            httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
            var encodedBase64string = System.Text.Encoding.UTF8.GetBytes(avalaraConnectionData.AccountNumber + ":" + avalaraConnectionData.LicenseKey);
            httpClient.DefaultRequestHeaders.Add("Authorization", "Basic "+ Convert.ToBase64String(encodedBase64string).ToString());
            var responseMessage = await httpClient.GetAsync(url);

        }

        /// <summary>
        /// Return URL param string
        /// </summary>
        /// <param name="address"></param>
        /// <returns></returns>
        private string GetParamString(AddressDto address)
        {
            return "?line1=" + address.Address + "&city=" + address.City + "&region=" + address.State + "&postalCode=" + address.ZipCode + "&country=" + address.Country + "&textCase=0";
        }

        /// <summary>
        /// Provide url for avalara connection
        /// </summary>
        /// <param name="connectionDto"></param>
        /// <param name="paramString"></param>
        /// <returns></returns>
        private string GetUrl(AvalaraConnectionDataDto connectionDto, string paramString)
        {
            return connectionDto.ServiceUrl + "api/v2/addresses/resolve" + paramString;

        }

    }
}
