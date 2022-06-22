using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.UI;
using SBCRM.Authorization;
using SBCRM.Core.BaseEntities;
using SBCRM.Crm.Dtos;

namespace SBCRM.Modules.Administration
{
    /// <summary>
    /// Branches app service
    /// </summary>
    [RemoteService(false)]
    [AbpAuthorize(AppPermissions.Pages_Branches)]
    public class BranchesAppService : SBCRMAppServiceBase, IBranchesAppService
    {
        private readonly IRepository<Branch, long> _branchRepository;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="leadRepository"></param>
        public BranchesAppService(IRepository<Branch, long> leadRepository)
        {
            _branchRepository = leadRepository;
        }

        /// <summary>
        /// Retrieve all branches
        /// </summary>
        /// <returns></returns>
        public async Task<IList<GetLeadForViewDto>> GetAll()
        {
            return await Task.FromResult(new List<GetLeadForViewDto>());
        }

        /// <summary>
        /// Retrieve paged branches
        /// </summary>
        /// <returns></returns>
        public async Task<PagedResultDto<GetLeadForViewDto>> GetAllPaged()
        {
            return await Task.FromResult(new PagedResultDto<GetLeadForViewDto>());
        }

        /// <summary>
        /// Retrieve branch by id
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<GetLeadForEditOutput> Get(EntityDto<long> input)
        {
            return await Task.FromResult(new GetLeadForEditOutput());
        }

        /// <summary>
        /// Create branch
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<GetLeadForEditOutput> Insert(CreateOrEditLeadDto input)
        {
            var currentTenantId = GetTenantId();

            var branch = await _branchRepository.FirstOrDefaultAsync(x => x.Number == 1);
            branch.Name += "-A";
            await _branchRepository.UpdateAsync(branch);

            throw new UserFriendlyException(L("ErrorUploadingMessage"));
        }

        /// <summary>
        /// Update branch
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<GetLeadForEditOutput> Update(CreateOrEditLeadDto input)
        {
            return await Task.FromResult(new GetLeadForEditOutput());
        }

        /// <summary>
        /// Delete branch
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task Delete(EntityDto<long> input)
        {
            throw new System.NotImplementedException();
        }
    }
}
