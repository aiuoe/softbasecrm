using MediatR;
using SBCRM.Modules.Common.Avalara.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBCRM.Modules.Common.Avalara.Commands
{
    public class GetTaxCodesCommand : IRequest<List<TaxCodeDto>>
    {
        public GetTaxCodesCommand(string filter)
        {
            Filter = filter;
        }

        public string Filter { get; set; }

    }
}
