using Abp.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SBCRM.Base;
using SBCRM.Core.BaseEntities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SBCRM.EntityFrameworkCore.Repositories
{
    /// <summary>
    /// Zip code repository implementation
    /// </summary>
    public class ZipCodeRepository : SBCRMRepositoryBase<ZipCode, long>, IZipCodeRepository
    {
        private readonly SBCRMDbContext _dbContext;
        public ZipCodeRepository(IDbContextProvider<SBCRMDbContext> dbContextProvider) : base(dbContextProvider)
        {
            _dbContext = dbContextProvider.GetDbContext();
        }


        /// <summary>
        /// Get ZipCode entry from DB
        /// </summary>
        /// <param name="zipCode"></param>
        /// <returns> ZipCode table entry</returns>
        public async Task<List<ZipCode>> GetZipCode(string zipCode)
        {
            return await _dbContext.ZipCodes2.Where(x => x.ZipCode1 == zipCode).ToListAsync();
        }
    }
}
