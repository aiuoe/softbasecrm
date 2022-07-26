using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace SBCRM.Modules.Common.Avalara.Dto
{
    /// <summary>
    /// Contains the List of Avalara Tax Types
    /// </summary>
    public class GetTaxCodeTypesDto
    {
        [JsonPropertyName("types")]
        public Dictionary<string,string> Types { get; set; }
    }
}
