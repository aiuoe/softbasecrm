using Abp.Application.Services.Dto;
using MediatR;
using SBCRM.Modules.Common.Avalara.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBCRM.Modules.Common.Avalara.Queries
{
    /// <summary>
    /// Contains Query parameters and return type for the Get Tax Codes Method
    /// </summary>
    public class GetTaxCodesQuery : IRequest<PagedResultDto<TaxCodeDto>>
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="skip">Results to Skip</param>
        /// <param name="max">Max result number</param>
        /// <param name="taxCodeType">Type of tax code (single letter)</param>
        /// <param name="taxCode">Partial tax code</param>
        /// <param name="parentTaxCode">Parent tax code</param>
        /// <param name="description">Partial description</param>
        public GetTaxCodesQuery(int skip, int max = AppConsts.DefaultPageSize, string taxCodeType = "", string taxCode = "", string parentTaxCode = "", string description = "")
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
            MaxResultCount = max;
            SkipCount = skip;
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

        /// <summary>
        /// Max Result Amount
        /// </summary>
        [Range(1, AppConsts.MaxPageSize)]
        public int MaxResultCount { get; set; }

        /// <summary>
        /// Results to Skip
        /// </summary>
        [Range(0, int.MaxValue)]
        public int SkipCount { get; set; }

    }
}
