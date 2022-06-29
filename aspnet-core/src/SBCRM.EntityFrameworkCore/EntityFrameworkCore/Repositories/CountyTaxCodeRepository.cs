using Abp.EntityFrameworkCore;
using SBCRM.Base;
using SBCRM.Core.BaseEntities;


namespace SBCRM.EntityFrameworkCore.Repositories
{
    /// <summary>
    /// Specific CountyTaxCode repository implementation
    /// </summary>
    public class CountyTaxCodeRepository : SBCRMRepositoryBase<CountyTaxCode, long>, ICountyTaxCodeRepository
    {
        private readonly SBCRMDbContext _dbContext;
        public CountyTaxCodeRepository(IDbContextProvider<SBCRMDbContext> dbContextProvider) : base(dbContextProvider)
        {
            _dbContext = dbContextProvider.GetDbContext();
        }
    }
}
