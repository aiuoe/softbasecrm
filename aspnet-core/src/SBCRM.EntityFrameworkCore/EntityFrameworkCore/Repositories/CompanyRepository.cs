using Abp.EntityFrameworkCore;
using SBCRM.Base;
using SBCRM.Core.BaseEntities;

namespace SBCRM.EntityFrameworkCore.Repositories
{
    internal class CompanyRepository : SBCRMRepositoryBase<Company, long>, IComapanyRepository
    {
        private readonly SBCRMDbContext _dbContext;
        public CompanyRepository(IDbContextProvider<SBCRMDbContext> dbContextProvider) : base(dbContextProvider)
        {
            _dbContext = dbContextProvider.GetDbContext();
        }
    }
}
