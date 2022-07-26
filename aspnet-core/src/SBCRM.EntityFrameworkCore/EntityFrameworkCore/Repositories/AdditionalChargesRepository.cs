using Abp.EntityFrameworkCore;
using SBCRM.Base;
using SBCRM.Core.BaseEntities;

namespace SBCRM.EntityFrameworkCore.Repositories
{
    /// <summary>
    /// Specific AdditionalChargesRepository implementation
    /// </summary>
    public class AdditionalChargesRepository : SBCRMRepositoryBase<AdditionalCharge, long>, IAdditionalChargesRepository
    {
        private readonly SBCRMDbContext _dbContext;
        public AdditionalChargesRepository(IDbContextProvider<SBCRMDbContext> dbContextProvider) : base(dbContextProvider)
        {
            _dbContext = dbContextProvider.GetDbContext();
        }
    }
}
