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
    /// Repository class for the dbo.dept table
    /// </summary>
    public class SoftBaseDepartmentRepository : ISoftBaseDepartmentRepository
    {
        private readonly SBCRMDbContext _dbContext;

        /// <summary>
        /// Main constructor
        /// </summary>
        /// <param name="dbContext">The database context</param>
        public SoftBaseDepartmentRepository(SBCRMDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// Gets all the departments
        /// </summary>
        /// <returns></returns>
        public async Task<List<Department>> GetAllAsync()
        {
            return await _dbContext.Department.ToListAsync();
        }

        public async Task<Department> GetByDeptNumberAsync(short dept)
        {
            return await _dbContext.Department.FirstOrDefaultAsync(d => d.Dept == dept);
        }
    }
}
