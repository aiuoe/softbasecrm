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
        public GetTaxCodesQuery(string filter = "")
        {
            if(!string.IsNullOrWhiteSpace(filter))
            {
                Filter = filter;
            }
        }

        public string Filter { get; set; }
    }
}
