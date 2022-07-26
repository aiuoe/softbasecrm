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
    /// Contains Query parameters and return type for the Get Tax Code Types Method
    /// </summary>
    public class GetTaxCodeTypesQuery : IRequest<List<TaxCodeTypeDto>>
    {
    }
}
