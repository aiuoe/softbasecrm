using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace SBCRM.Modules.Common.Avalara.Dto
{
    /// <summary>
    /// Contains the list of Tax codes from Avalara, as well as the fields needed to keep up the server pagination
    /// </summary>
    public class GetTaxCodesDto
    {
        /// <summary>
        /// Count of the number of records obtained by the query
        /// </summary>
        [JsonPropertyName("@recordsetCount")]
        public int RecordsetCount { get; set; }

        /// <summary>
        /// List of records (Tax Codes)
        /// </summary>
        [JsonPropertyName("value")]
        public List<TaxCodeDto> Value { get; set; }

        /// <summary>
        /// Next link 
        /// </summary>
        [JsonPropertyName("@nextLink")]
        public string NextLink { get; set; }

        /// <summary>
        /// Pagination Key
        /// </summary>
        [JsonPropertyName("@pageKey")]
        public string PageKey { get; set; }
    }
}
