using SBCRM.Legacy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBCRM.Base
{
    /// <summary>
    /// Repository interface for the "Branch" repository
    /// </summary>
    public interface ISoftBaseBranchRepository
    {
        /// <summary>
        /// Gets all branch from dbo.Branch
        /// </summary>
        /// <returns></returns>
        Task<List<Branch>> GetAllAsync();

        /// <summary>
        /// Gets a branch by branch number
        /// </summary>
        /// <param name="branchNumber"></param>
        /// <returns></returns>
        Task<Branch> GetByBranchNumberAsync(short branchNumber);
    }
}
