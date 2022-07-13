using MediatR;
using SBCRM.Modules.Common.ARTerms.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBCRM.Modules.Common.ARTerms.Queries
{
    public class ARTermsQuery : IRequest<List<ARTermDto>>
    {
    }
}
