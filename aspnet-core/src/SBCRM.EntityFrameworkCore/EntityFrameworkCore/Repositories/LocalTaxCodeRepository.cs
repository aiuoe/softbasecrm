using Abp.EntityFrameworkCore;
using SBCRM.Base;
using SBCRM.Core.BaseEntities;


namespace SBCRM.EntityFrameworkCore.Repositories
{
    /// <summary>
    /// Specific LocalTaxCode repository implementation
    /// </summary>
    public class LocalTaxCodeRepository : SBCRMRepositoryBase<LocalTaxCode, long>, ILocalTaxCodeRepository
    {
        private readonly SBCRMDbContext _dbContext;
        public LocalTaxCodeRepository(IDbContextProvider<SBCRMDbContext> dbContextProvider) : base(dbContextProvider)
        {
            _dbContext = dbContextProvider.GetDbContext();
        }
    }
}
