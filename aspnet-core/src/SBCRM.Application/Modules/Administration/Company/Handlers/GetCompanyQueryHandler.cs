using MediatR;
using SBCRM.Base;
using SBCRM.Core.BaseEntities;
using SBCRM.Modules.Administration.Company.Queries;
using SBCRM.Modules.Administration.Dtos;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SBCRM.Modules.Administration.Company.Handelers
{
    /// <summary>
    /// Create company use case command handler
    /// </summary>
    public class GetCompanyQueryHandler : SBCRMAppServiceBase, IRequestHandler<GetCompanyQuery, List<GetCompanyDto>>
    {
        private readonly ICompanyRepository _companyRepository;

        /// <summary>
        /// Base constructor
        /// </summary>
        /// <param name="companyRepository"></param>
        public GetCompanyQueryHandler(ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
        }

        /// <summary>
        /// Create company use case
        /// </summary>
        /// <param name="query"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<List<GetCompanyDto>> Handle(GetCompanyQuery query, CancellationToken cancellationToken)
        {
            var companies = await _companyRepository.GetAllListAsync();
            return ObjectMapper.Map<List<GetCompanyDto>>(companies);
        }
    }
}
