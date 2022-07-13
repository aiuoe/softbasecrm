using SBCRM.Core.BaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBCRM.Base
{
    public interface IARTermsRepository : Abp.Domain.Repositories.IRepository<Arterm, long>
    {
    }
}
