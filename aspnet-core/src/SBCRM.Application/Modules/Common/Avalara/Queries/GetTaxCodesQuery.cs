using MediatR;
using SBCRM.Modules.Common.Avalara.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBCRM.Modules.Common.Avalara.Queries
{
    public class GetTaxCodesQuery : IRequest<List<TaxCodeDto>>
    {
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

        public string TaxCodeType { get; set; }

        public string TaxCode { get; set; }

        public string ParentTaxCode { get; set; }

        public string Description { get; set; }
    }
}
