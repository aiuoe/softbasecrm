using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SBCRM.Base;
using SBCRM.Modules.Administration.Branch.Commands;
using SBCRM.Modules.Administration.Branch.Queries;
using SBCRM.Modules.Administration.Dtos;

namespace SBCRM.Modules.Administration.Branch.Handlers
{
    /// <summary>
    /// Create branch use case command handler
    /// </summary>
    public class GetBranchDropdownQueryHandler : SBCRMAppServiceBase, IRequestHandler<GetBranchDropdownQuery, List<GetBranchForDropdownDto>>
    {
        private readonly IBranchRepository _branchRepository;

        /// <summary>
        /// Base constructor
        /// </summary>
        /// <param name="branchRepository"></param>
        public GetBranchDropdownQueryHandler(IBranchRepository branchRepository)
        {
            _branchRepository = branchRepository;
        }

        /// <summary>
        /// Create branch use case
        /// </summary>
        /// <param name="query"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<List<GetBranchForDropdownDto>> Handle(GetBranchDropdownQuery query, CancellationToken cancellationToken)
        {
            //var branch = new Core.BaseEntities.Branch
            //{
            //    Name = command.Name,
            //    Number = command.Number,
            //    SubName = command.SubName,
            //    Address = command.Address
            //};
            //SetTenant(branch);
            //branch.Id = await _branchRepository.InsertAndGetIdAsync(branch);
            //return new GetBranchForEditDto
            //{
            //    AdditionalPropertyA = "A",
            //    AdditionalPropertyB = "B",
            //    Branch = ObjectMapper.Map<BranchDto>(branch)
            //};

            var branches = await _branchRepository.GetAllListAsync();
            return ObjectMapper.Map<List<GetBranchForDropdownDto>>(branches);
        }
    }

}
