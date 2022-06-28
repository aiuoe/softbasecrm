using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SBCRM.Base;
using SBCRM.Modules.Administration.Comapny.Commands;
using SBCRM.Modules.Administration.Dtos;

namespace SBCRM.Modules.Administration.Comapny.Handelers
{
    public class CreateCompanyCommandHandler : SBCRMAppServiceBase, IRequestHandler<CreateCompanyCommand, GetCompanyForEditDto>
    {
        private readonly ICompanyRepository _companyRepository;

        public CreateCompanyCommandHandler(ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
        }

        public Task<GetCompanyForEditDto> Handle(CreateCompanyCommand request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}
