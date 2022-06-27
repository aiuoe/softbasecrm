using SBCRM.Core.BaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBCRM.Base
{
    /// <summary>
    /// Specific ChartOfAccount repository
    /// </summary>
    public interface IChartOfAccountRepository : Abp.Domain.Repositories.IRepository<ChartOfAccount, long>
    {

    }
}
