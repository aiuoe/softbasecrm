using Microsoft.EntityFrameworkCore;
using SBCRM.Base;
using SBCRM.Legacy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBCRM.EntityFrameworkCore.Repositories
{
    /// <summary>
    /// Repository class for the dbo.Branch table
    /// </summary>
    public class SoftBaseBranchRepository : ISoftBaseBranchRepository
    {
        private readonly SBCRMDbContext _dbContext;

        /// <summary>
        /// Main constructor
        /// </summary>
        /// <param name="dbContext">The database context</param>
        public SoftBaseBranchRepository(SBCRMDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// Gets all the branches
        /// </summary>
        /// <returns></returns>
        public async Task<List<Branch>> GetAllAsync()
        {
            var branches = await _dbContext.Branch.ToListAsync();
            return branches;
        }

        /// <summary>
        /// Gets a branch by branch number
        /// </summary>
        /// <param name="branchNumber"></param>
        /// <returns></returns>
        public Task<Branch> GetByBranchNumberAsync(short branchNumber)
        {
            var branch = _dbContext.Branch.FirstOrDefaultAsync(b => b.Number == branchNumber);
            return branch;
        }
    }
}
