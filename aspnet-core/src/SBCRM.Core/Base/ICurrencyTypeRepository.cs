using SBCRM.Core.BaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBCRM.Base
{
    /// <summary>
    /// Specific CurrencyType repository
    /// </summary>
    public interface ICurrencyTypeRepository : Abp.Domain.Repositories.IRepository<CurrencyType, long>
    {

    }
}
