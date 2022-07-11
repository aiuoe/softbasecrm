using MediatR;
using SBCRM.Base;
using SBCRM.Core.BaseEntities;
using SBCRM.Modules.Common.ARTerms.Dto;
using SBCRM.Modules.Common.ARTerms.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SBCRM.Modules.Common.ARTerms.Handlers
{
    public class ARTermsQueryHandler : SBCRMAppServiceBase, IRequestHandler<ARTermsQuery, List<ARTermDto>>
    {
        private readonly IARTermsRepository _arTermsRepository;

        public ARTermsQueryHandler(IARTermsRepository arTermsRepository)
        {
            _arTermsRepository = arTermsRepository;
        }

        public async Task<List<ARTermDto>> Handle(ARTermsQuery request, CancellationToken cancellationToken)
        {
            var arTerms = await _arTermsRepository.GetAllListAsync();
            
            var vals = from term in arTerms
                       orderby term.Cod descending, term.Terms
                       select term;

            return ObjectMapper.Map(vals, new List<ARTermDto>());
        }
    }
}
