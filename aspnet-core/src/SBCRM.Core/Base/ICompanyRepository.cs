using SBCRM.Core.BaseEntities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SBCRM.Base
{
    /// <summary>
    /// Specific Company repository
    /// </summary>
    public interface ICompanyRepository : Abp.Domain.Repositories.IRepository<Company, long>
    {
        Task<List<ZipCode>> GetZipCode(string zipCode);

    }
}