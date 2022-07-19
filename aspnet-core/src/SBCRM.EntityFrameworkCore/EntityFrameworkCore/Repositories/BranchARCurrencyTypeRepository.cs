using Abp.EntityFrameworkCore;
using SBCRM.Base;
using SBCRM.Core.BaseEntities;

namespace SBCRM.EntityFrameworkCore.Repositories
{
    /// <summary>
    /// Specific Branch AR Currency Type repository implementation
    /// </summary>
    public class BranchARCurrencyTypeRepository : SBCRMRepositoryBase<BranchArcurrency, long>, IBranchARCurrencyTypeRepository
    {
        private readonly SBCRMDbContext _dbContext;
        public BranchARCurrencyTypeRepository(IDbContextProvider<SBCRMDbContext> dbContextProvider) : base(dbContextProvider)
        {
            _dbContext = dbContextProvider.GetDbContext();
        }
    }
}
