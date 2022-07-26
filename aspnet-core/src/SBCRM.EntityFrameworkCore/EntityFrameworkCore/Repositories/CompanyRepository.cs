using Abp.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SBCRM.Base;
using SBCRM.Core.BaseEntities;

namespace SBCRM.EntityFrameworkCore.Repositories
{
    /// <summary>
    /// Company repository implementation
    /// </summary>
    public class CompanyRepository : SBCRMRepositoryBase<Company, long>, ICompanyRepository
    {
        private readonly SBCRMDbContext _dbContext;
        public CompanyRepository(IDbContextProvider<SBCRMDbContext> dbContextProvider) : base(dbContextProvider)
        {
            _dbContext = dbContextProvider.GetDbContext();
        }
    }
}
