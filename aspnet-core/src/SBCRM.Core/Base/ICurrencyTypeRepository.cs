using SBCRM.Core.BaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBCRM.Base
{
    public interface ICurrencyTypeRepository : Abp.Domain.Repositories.IRepository<CurrencyType, long>
    {

    }
}
