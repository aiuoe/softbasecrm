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
    public class WarehouseRepository : SBCRMRepositoryBase<Warehouse, long>, IWarehouseRepository
    {
        private readonly SBCRMDbContext _dbContext;
        public WarehouseRepository(IDbContextProvider<SBCRMDbContext> dbContextProvider) : base(dbContextProvider)
        {
            _dbContext = dbContextProvider.GetDbContext();
        }
    }
}
