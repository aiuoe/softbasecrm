using Newtonsoft.Json.Linq;
using Abp.UI;
using SBCRM.Avalara;
using SBCRM.Common;
using SBCRM.Dto;
using SBCRM.Dto.AvalaraConnection.TaxCodes;
using SBCRM.Modules.Common.Avalara.Dto;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;

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
        /// Test avalara connection
        /// </summary>
        /// <param name="connectionData"></param>
        public async Task<bool> TestConnection(AvalaraConnectionDataDto connectionData)
        {
            string url = $"{connectionData.ServiceUrl.TrimEnd('/')}/{AvalaraConsts.TestConnectionApi}";
            var httpClient = GetAvalaraHttpAuthenticatedconnection(connectionData);
            try
            {
                var responseMessage = await httpClient.GetAsync(url);
                var response = await responseMessage.Content.ReadAsStringAsync();
                return JObject.Parse(response).SelectToken("authenticated").Value<bool>();
            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(ex.Message);
            }
        }

        /// <summary>
        /// Get avalara company codes
        /// </summary>
        /// <param name="connectionData"></param>
        public async Task<List<AvalaraCompanyCodes>> GetCompanyCodes(AvalaraConnectionDataDto connectionData)
        {
            string url = $"{connectionData.ServiceUrl.TrimEnd('/')}/{AvalaraConsts.CompanyCodesApi}";
            var httpClient = GetAvalaraHttpAuthenticatedconnection(connectionData);
            try
            {
                var responseMessage = await httpClient.GetAsync(url);
                var response = await responseMessage.Content.ReadAsStringAsync();
                return JObject.Parse(response).SelectToken("value").ToObject<List<AvalaraCompanyCodes>>();
            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(ex.Message);
            }
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
            catch (Exception)
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

        #region Standard Connection Methods

        /// <summary>
        /// Provide url for avalara connection depending on the method to be used
        /// </summary>
        /// <param name="connectionDto">Avalara connection information</param>
        /// <param name="method">Method to be called</param>
        /// <param name="paramString">Parameters</param>
        /// <returns></returns>
        private string GetStandartUrl(AvalaraConnectionDataDto connectionDto, string method, string paramString)
        {
            return connectionDto.ServiceUrl + method + paramString;
        }

        /// <summary>
        /// Instantiates an HttpClient using Avalara credentials and setting up the authentication by default
        /// </summary>
        /// <param name="connectionCredentials">Credentials needed to login into Avalara Api</param>
        /// <returns>Http Client ready for sending request to Avalara Api</returns>
        private HttpClient GetAvalaraHttpAuthenticatedconnection(AvalaraConnectionDataDto connectionCredentials)
        {
            var httpClient = _httpClientFactory.CreateClient();
            httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
            var encodedBase64string = System.Text.Encoding.UTF8.GetBytes(connectionCredentials.AccountNumber + ":" + connectionCredentials.LicenseKey);
            httpClient.DefaultRequestHeaders.Add("Authorization", "Basic " + Convert.ToBase64String(encodedBase64string).ToString());
            return httpClient;
        }

        #endregion

        #region GetTaxCodes

        /// <summary>
        /// Builds the parameter string query according to the parameters filled
        /// </summary>
        /// <param name="baseParameterString">Parameters so far added</param>
        /// <param name="newParameter">New parameter to add</param>
        /// <returns>Parameters string query</returns>
        private string FirstParameter(string baseParameterString, string newParameter)
        {
            if (string.IsNullOrEmpty(baseParameterString))
            {
                return "?$" + newParameter;
            }
            else
            {
                return baseParameterString + "&$" + newParameter;
            }
        }

        /// <summary>
        /// Builds the GetTaxCodes method query string
        /// </summary>
        /// <param name="getTaxCodesParametersDto">parameters selected</param>
        /// <returns>Query String for the Get method</returns>
        private string GetTaxCodesParamString(GetTaxCodesParametersDto getTaxCodesParametersDto)
        {
            string parameterString = String.Empty;
            if (getTaxCodesParametersDto != null && !string.IsNullOrWhiteSpace(getTaxCodesParametersDto.Filter))
            {
                parameterString = FirstParameter(parameterString, "filter=" + getTaxCodesParametersDto.Filter);
            }
            if (getTaxCodesParametersDto != null && !string.IsNullOrWhiteSpace(getTaxCodesParametersDto.Include))
            {
                parameterString = FirstParameter(parameterString, "include=" + getTaxCodesParametersDto.Include);
            }
            if (getTaxCodesParametersDto != null && !string.IsNullOrWhiteSpace(getTaxCodesParametersDto.Top))
            {
                parameterString = FirstParameter(parameterString, "top=" + getTaxCodesParametersDto.Top);
            }
            if (getTaxCodesParametersDto != null && !string.IsNullOrWhiteSpace(getTaxCodesParametersDto.Skip))
            {
                parameterString = FirstParameter(parameterString, "skip=" + getTaxCodesParametersDto.Skip);
            }
            if (getTaxCodesParametersDto != null && !string.IsNullOrWhiteSpace(getTaxCodesParametersDto.OrderBy))
            {
                parameterString = FirstParameter(parameterString, "order=" + getTaxCodesParametersDto.OrderBy);
            }
            return parameterString;
        }

        /// <summary>
        /// Search in the Avalara service for the list of Tax codes
        /// </summary>
        /// <param name="avalaraConnectionData">Credentials needed to connect to Avalara</param>
        /// <param name="getTaxCodesParameters">Search parameters if any to find the tax codes</param>
        /// <returns>List of Tax Codes</returns>
        public async Task<PagedResultDto<TaxCodeDto>> GetTaxCodes(AvalaraConnectionDataDto avalaraConnectionData, GetTaxCodesParametersDto getTaxCodesParameters)
        {            
            string paramString = GetTaxCodesParamString(getTaxCodesParameters);
            string url = GetStandartUrl(avalaraConnectionData, "api/v2/definitions/taxcodes", paramString);
            var httpClient = GetAvalaraHttpAuthenticatedconnection(avalaraConnectionData);
            var streamTask = httpClient.GetStreamAsync(url);
            try
            {
                var response = JsonSerializer.DeserializeAsync<GetTaxCodesDto>(await streamTask);
                return new PagedResultDto<TaxCodeDto>(response.Result.RecordsetCount, response.Result.Value);
            }catch (Exception ex)
            {
                throw ex;
            }
            
        }

        #endregion

        #region TaxCodeTypes

        /// <summary>
        /// Retrieves from Avalara Tax Code Type list
        /// </summary>
        /// <param name="avalaraConnectionData">Credentials needed to connect to Avalara</param>
        /// <returns>List of tax code types</returns>
        public async Task<List<TaxCodeTypeDto>> GetTaxCodeTypes(AvalaraConnectionDataDto avalaraConnectionData)
        {
            string url = GetStandartUrl(avalaraConnectionData, "api/v2/definitions/taxcodetypes", "");
            var httpClient = GetAvalaraHttpAuthenticatedconnection(avalaraConnectionData);
            var streamTask = httpClient.GetStreamAsync(url);
            List<TaxCodeTypeDto> types = new List<TaxCodeTypeDto>();
            try
            {
                var response = JsonSerializer.DeserializeAsync<GetTaxCodeTypesDto>(await streamTask);
                foreach ( var key in response.Result.Types)
                {
                    types.Add(new TaxCodeTypeDto() { Type = key.Key, Description = key.Value });  
                }
                return types;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        #endregion
    }
}
