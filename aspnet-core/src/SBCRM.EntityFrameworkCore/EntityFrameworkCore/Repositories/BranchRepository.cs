using Abp.EntityFrameworkCore;
using SBCRM.Base;
using SBCRM.Core.BaseEntities;

namespace SBCRM.EntityFrameworkCore.Repositories
{
    /// <summary>
    /// Specific Branch repository implementation
    /// </summary>
    public class BranchRepository : SBCRMRepositoryBase<Branch, long>, IBranchRepository
    {
        private readonly SBCRMDbContext _dbContext;
        public BranchRepository(IDbContextProvider<SBCRMDbContext> dbContextProvider) : base(dbContextProvider)
        {
            _dbContext = dbContextProvider.GetDbContext();
        }
    }
}
