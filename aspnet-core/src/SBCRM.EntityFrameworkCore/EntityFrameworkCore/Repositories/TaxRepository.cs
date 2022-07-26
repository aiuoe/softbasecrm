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
    /// Specific Tax repository implementation
    /// </summary>
    public class TaxRepository : SBCRMRepositoryBase<Tax, long>, ITaxRepository
    {
        private readonly SBCRMDbContext _dbContext;
        public TaxRepository(IDbContextProvider<SBCRMDbContext> dbContextProvider) : base(dbContextProvider)
        {
            _dbContext = dbContextProvider.GetDbContext();
        }
    }
}
