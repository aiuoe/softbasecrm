using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace SBCRM.Modules.Common.Avalara.Dto
{
    /// <summary>
    /// Contains the information of a Tax Code from Avalara
    /// </summary>
    public class TaxCodeDto
    {
        [JsonPropertyName("id")]
        /// <summary>
        /// The unique ID number of this tax code.
        /// </summary>
        public int Id { get; set; }

        [JsonPropertyName("companyId")]
        /// <summary>
        /// The unique ID number of the company that owns this tax code.
        /// </summary>
        public int CompanyId { get; set; }

        [JsonPropertyName("taxCode")]
        /// <summary>
        /// A code string that identifies this tax code.
        /// </summary>
        public string TaxCode { get; set; }

        [JsonPropertyName("taxCodeTypeId")]
        /// <summary>
        /// The type of this tax code.
        /// </summary>
        public string TaxCodeTypeId { get; set; }

        [JsonPropertyName("description")]
        /// <summary>
        /// A friendly description of this tax code.
        /// </summary>
        public string Description { get; set; }

        [JsonPropertyName("parentTaxCode")]
        /// <summary>
        /// If this tax code is a subset of a different tax code, this identifies the parent code.
        /// </summary>
        public string ParentTaxCode { get; set; }

        [JsonPropertyName("isActive")]
        /// <summary>
        /// True if this tax code is active and can be used in transactions.
        /// </summary>
        public bool IsActive { get; set; }

    }
}
