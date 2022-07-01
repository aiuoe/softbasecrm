using Abp.EntityFrameworkCore;
using SBCRM.Base;
using SBCRM.Core.BaseEntities;


namespace SBCRM.EntityFrameworkCore.Repositories
{
    /// <summary>
    /// Specific ZipCode repository implementation
    /// </summary>
    public class ZipCodeRepository : SBCRMRepositoryBase<ZipCode, long>, IZipCodeRepository
    {
        private readonly SBCRMDbContext _dbContext;

        /// <summary>
        /// Base constructor
        /// </summary>
        /// <param name="dbContextProvider"></param>
        public ZipCodeRepository(IDbContextProvider<SBCRMDbContext> dbContextProvider) : base(dbContextProvider)
        {
            _dbContext = dbContextProvider.GetDbContext();
        }
    }
}
