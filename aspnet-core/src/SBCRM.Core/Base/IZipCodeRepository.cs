using SBCRM.Core.BaseEntities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SBCRM.Base
{
    /// <summary>
    /// Specific zip code repository
    /// </summary>
    public interface IZipCodeRepository : Abp.Domain.Repositories.IRepository<ZipCode, long>
    {
        Task<List<ZipCode>> GetZipCode(string zipCode);
    }
}
