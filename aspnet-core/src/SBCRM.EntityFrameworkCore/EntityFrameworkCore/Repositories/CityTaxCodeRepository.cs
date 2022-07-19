using Abp.EntityFrameworkCore;
using SBCRM.Base;
using SBCRM.Core.BaseEntities;


namespace SBCRM.EntityFrameworkCore.Repositories
{
    /// <summary>
    /// Specific CityTaxCode repository implementation
    /// </summary>
    public class CityTaxCodeRepository : SBCRMRepositoryBase<CityTaxCode, long>, ICityTaxCodeRepository
    {
        private readonly SBCRMDbContext _dbContext;
        public CityTaxCodeRepository(IDbContextProvider<SBCRMDbContext> dbContextProvider) : base(dbContextProvider)
        {
            _dbContext = dbContextProvider.GetDbContext();
        }
    }
}
