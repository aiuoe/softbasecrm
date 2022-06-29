using Abp.EntityFrameworkCore;
using SBCRM.Base;
using SBCRM.Core.BaseEntities;

namespace SBCRM.EntityFrameworkCore.Repositories
{
    /// <summary>
    /// Specific StateTaxCode repository implementation
    /// </summary>
    public class StateTaxCodeRepository : SBCRMRepositoryBase<StateTaxCode, long>, IStateTaxCodeRepository
    {
        private readonly SBCRMDbContext _dbContext;
        public StateTaxCodeRepository(IDbContextProvider<SBCRMDbContext> dbContextProvider) : base(dbContextProvider)
        {
            _dbContext = dbContextProvider.GetDbContext();
        }
    }
}
