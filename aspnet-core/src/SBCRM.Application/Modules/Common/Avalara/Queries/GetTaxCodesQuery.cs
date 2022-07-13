using MediatR;
using SBCRM.Modules.Common.Avalara.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBCRM.Modules.Common.Avalara.Queries
{
    /// <summary>
    /// Contains Query parameters and return type for the Get Tax Codes Method
    /// </summary>
    public class GetTaxCodesQuery : IRequest<List<TaxCodeDto>>
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="taxCodeType">Type of tax code (single letter)</param>
        /// <param name="taxCode">Partial tax code</param>
        /// <param name="parentTaxCode">Parent tax code</param>
        /// <param name="description">Partial description</param>
        public GetTaxCodesQuery( string taxCodeType = "", string taxCode = "", string parentTaxCode = "", string description = "")
        {
            if(!string.IsNullOrWhiteSpace(taxCodeType))
            {
                TaxCodeType = taxCodeType;
            }
            if (!string.IsNullOrWhiteSpace(taxCode))
            {
                TaxCode = taxCode;
            }
            if (!string.IsNullOrWhiteSpace(parentTaxCode))
            {
                ParentTaxCode = parentTaxCode;
            }
            if (!string.IsNullOrWhiteSpace(description))
            {
                Description = description;
            }
        }

        /// <summary>
        /// Tax code type
        /// </summary>
        public string TaxCodeType { get; set; }

        /// <summary>
        /// Partial tax code
        /// </summary>
        public string TaxCode { get; set; }

        /// <summary>
        /// Parent tax code
        /// </summary>
        public string ParentTaxCode { get; set; }

        /// <summary>
        ///Partial Description
        /// </summary>
        public string Description { get; set; }
    }
}
