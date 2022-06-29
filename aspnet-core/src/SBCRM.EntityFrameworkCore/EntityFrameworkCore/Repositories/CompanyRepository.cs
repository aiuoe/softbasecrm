using Abp.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SBCRM.Base;
using SBCRM.Core.BaseEntities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SBCRM.EntityFrameworkCore.Repositories
{
    public class CompanyRepository : SBCRMRepositoryBase<Company, long>, ICompanyRepository
    {
        private readonly SBCRMDbContext _dbContext;
        public CompanyRepository(IDbContextProvider<SBCRMDbContext> dbContextProvider) : base(dbContextProvider)
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
            var result = await _dbContext.ZipCodes2.Where(x => x.ZipCode1 == zipCode).ToListAsync();
            return result;
        }
    }
}
