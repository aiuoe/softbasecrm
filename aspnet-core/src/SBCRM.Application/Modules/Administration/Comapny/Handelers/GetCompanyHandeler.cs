using MediatR;
using SBCRM.Base;
using SBCRM.Core.BaseEntities;
using SBCRM.Modules.Administration.Comapny.Queries;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SBCRM.Modules.Administration.Comapny.Handelers
{
    public class GetCompanyHandeler : IRequestHandler<GetCompanyQuery, IEnumerable<Company>>
    {
        private readonly IComapanyRepository _companyRepository;

        public GetCompanyHandeler(IComapanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
        }

        public  Task<IEnumerable<Company>> Handle(GetCompanyQuery request, CancellationToken cancellationToken)
        {
            return (Task<IEnumerable<Company>>)_companyRepository.GetAll();
        }
    }
}
