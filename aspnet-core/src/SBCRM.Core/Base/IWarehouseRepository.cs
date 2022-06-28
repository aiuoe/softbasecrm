using SBCRM.Core.BaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBCRM.Base
{
    /// <summary>
    /// Specific Warehouse repository
    /// </summary>
    public interface IWarehouseRepository : Abp.Domain.Repositories.IRepository<Warehouse, long>
    {

    }
}
