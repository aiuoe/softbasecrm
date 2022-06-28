using Abp.EntityFrameworkCore;
using SBCRM.Base;
using SBCRM.Core.BaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBCRM.EntityFrameworkCore.Repositories
{
    /// <summary>
    /// Specific CurrencyType repository implementation
    /// </summary>
    public class CurrencyTypeRepository : SBCRMRepositoryBase<CurrencyType, long>, ICurrencyTypeRepository
    {
        private readonly SBCRMDbContext _dbContext;
        public CurrencyTypeRepository(IDbContextProvider<SBCRMDbContext> dbContextProvider) : base(dbContextProvider)
        {
            _dbContext = dbContextProvider.GetDbContext();
        }
    }
}
