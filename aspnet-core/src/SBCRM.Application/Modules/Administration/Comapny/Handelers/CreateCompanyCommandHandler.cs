using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SBCRM.Base;
using SBCRM.Modules.Administration.Comapny.Commands;
using SBCRM.Modules.Administration.Dtos;

namespace SBCRM.Modules.Administration.Comapny.Handelers
{
    public class CreateCompanyCommandHandler : SBCRMAppServiceBase, IRequestHandler<CreateComapnyCommand, GetCompanyForEditDto>
    {
        private readonly IComapanyRepository _companyRepository;

        public CreateCompanyCommandHandler(IComapanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
        }

        public Task<GetCompanyForEditDto> Handle(CreateComapnyCommand request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}
