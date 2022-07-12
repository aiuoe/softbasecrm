using Newtonsoft.Json.Linq;
using SBCRM.Avalara;
using SBCRM.Dto;
using SBCRM.Modules.Administration.Dtos;
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
        public const string UNKNOWN_ADDRESS_TYPE = "UnknownAddressType";
        public AvalaraService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;


        }
        /// <summary>
        /// Verify address
        /// </summary>
        /// <param name="avalaraConnectionData"></param>
        /// <param name="address"></param>
        public async Task<GetVerifyAddressDto> VerifyAddress(AvalaraConnectionDataDto avalaraConnectionData, AddressDto address)
        {
            string paramString = GetParamString(address);
            string url = GetUrl(avalaraConnectionData, paramString);

            var httpClient = _httpClientFactory.CreateClient();
            httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
            var encodedBase64string = System.Text.Encoding.UTF8.GetBytes(avalaraConnectionData.AccountNumber + ":" + avalaraConnectionData.LicenseKey);
            httpClient.DefaultRequestHeaders.Add("Authorization", "Basic " + Convert.ToBase64String(encodedBase64string).ToString());

            try
            {
                var responseMessage = await httpClient.GetAsync(url);
                var response = await responseMessage.Content.ReadAsStringAsync();
                var avalaraAddress = JObject.Parse(response)["validatedAddresses"][0];

                if (avalaraAddress["addressType"].ToString().ToLower() == UNKNOWN_ADDRESS_TYPE.ToLower())
                {
                    throw new Exception();
                }
                return new GetVerifyAddressDto()
                {
                    CheckUseDefaultTaxCodeCalc = true,
                    Address = avalaraAddress["line1"].ToString(),
                    City = avalaraAddress["city"].ToString(),
                    State = avalaraAddress["region"].ToString(),
                    ZipCode = avalaraAddress["postalCode"].ToString(),
                    Country = avalaraAddress["country"].ToString(),
                };
            }
            catch (Exception ex)
            {
                return new GetVerifyAddressDto();
            }

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
