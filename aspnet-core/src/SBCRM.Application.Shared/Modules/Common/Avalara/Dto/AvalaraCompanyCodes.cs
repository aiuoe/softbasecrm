using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace SBCRM.Modules.Common.Avalara.Dto
{
    /// <summary>
    /// Contains the information of a Company Code from Avalara
    /// </summary>
    public class AvalaraCompanyCodes
    {
        [JsonPropertyName("companyCode")]
        public string CompanyCode { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }
    }
}
