using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SBCRM.Base;
using SBCRM.Modules.Administration.Company.Commands;
using SBCRM.Modules.Administration.Dtos;

namespace SBCRM.Modules.Administration.Company.Handlers
{
    /// <summary>
    /// Create company use case command handler
    /// </summary>
    public class CreateCompanyCommandHandler : SBCRMAppServiceBase, IRequestHandler<CreateCompanyCommand, GetCompanyForEditDto>
    {
        private readonly ICompanyRepository _companyRepository;

        public CreateCompanyCommandHandler(ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
        }

        /// <summary>
        /// Create company use case
        /// </summary>
        /// <param name="command"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<GetCompanyForEditDto> Handle(CreateCompanyCommand command, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}
