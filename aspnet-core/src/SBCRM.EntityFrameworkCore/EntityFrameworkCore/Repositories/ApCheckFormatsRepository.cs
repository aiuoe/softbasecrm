using Abp.EntityFrameworkCore;
using SBCRM.Base;
using SBCRM.Core.BaseEntities;

namespace SBCRM.EntityFrameworkCore.Repositories
{
    /// <summary>
    /// Repository for the CheckFormat Entity
    /// </summary>
    public class ApCheckFormatsRepository : SBCRMRepositoryBase<CheckFormat, long>, IApCheckFormatsRepository
    {
        private readonly SBCRMDbContext _dbContext;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="dbContextProvider">Database Context</param>
        public ApCheckFormatsRepository(IDbContextProvider<SBCRMDbContext> dbContextProvider) : base(dbContextProvider)
        {
            _dbContext = dbContextProvider.GetDbContext();
        }
    }
}
