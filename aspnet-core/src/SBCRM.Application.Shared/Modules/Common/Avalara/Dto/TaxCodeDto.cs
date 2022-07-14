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

        /// <summary>
        /// The unique ID number of this tax code.
        /// </summary>
        [JsonPropertyName("id")]
        public int Id { get; set; }

        /// <summary>
        /// The unique ID number of the company that owns this tax code.
        /// </summary>
        [JsonPropertyName("companyId")]
        public int CompanyId { get; set; }

        /// <summary>
        /// A code string that identifies this tax code.
        /// </summary>
        [JsonPropertyName("taxCode")]
        public string TaxCode { get; set; }

        /// <summary>
        /// The type of this tax code.
        /// </summary>
        [JsonPropertyName("taxCodeTypeId")]
        public string TaxCodeTypeId { get; set; }

        /// <summary>
        /// A friendly description of this tax code.
        /// </summary>
        [JsonPropertyName("description")]
        public string Description { get; set; }

        /// <summary>
        /// If this tax code is a subset of a different tax code, this identifies the parent code.
        /// </summary>
        [JsonPropertyName("parentTaxCode")]
        public string ParentTaxCode { get; set; }

        /// <summary>
        /// True if this tax code is active and can be used in transactions.
        /// </summary>
        [JsonPropertyName("isActive")]
        public bool IsActive { get; set; }

    }
}
