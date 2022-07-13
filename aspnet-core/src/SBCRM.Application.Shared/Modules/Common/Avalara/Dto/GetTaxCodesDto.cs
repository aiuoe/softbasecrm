using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace SBCRM.Modules.Common.Avalara.Dto
{
    public class GetTaxCodesDto
    {
        [JsonPropertyName("@recordsetCount")]
        public int RecordsetCount { get; set; }

        [JsonPropertyName("value")]
        public List<TaxCodeDto> Value { get; set; }

        [JsonPropertyName("@nextLink")]
        public string NextLink { get; set; }

        [JsonPropertyName("@pageKey")]
        public string PageKey { get; set; }
    }
}
