using Abp.EntityFrameworkCore;
using SBCRM.Base;
using SBCRM.Core.BaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;


namespace SBCRM.EntityFrameworkCore.Repositories
{
    /// <summary>
    /// Specific ChartOfAccount repository implementation
    /// </summary>
    public class ChartOfAccountRepository : SBCRMRepositoryBase<ChartOfAccount, long>, IChartOfAccountRepository
    {
        private readonly SBCRMDbContext _dbContext;
        public ChartOfAccountRepository(IDbContextProvider<SBCRMDbContext> dbContextProvider) : base(dbContextProvider)
        {
            _dbContext = dbContextProvider.GetDbContext();
        }
    }
}
