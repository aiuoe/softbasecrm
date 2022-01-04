using SBCRM.Legacy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBCRM.Base
{
    /// <summary>
    /// Repository interface for the "Deparment" repository
    /// </summary>
    public interface ISoftBaseDepartmentRepository
    {
        /// <summary>
        /// Gets all Deparment from dbo.Dept
        /// </summary>
        /// <returns></returns>
        Task<List<Department>> GetAllAsync();

        /// <summary>
        /// Gets a dpeartment by dept number
        /// </summary>
        /// <param name="dept"></param>
        /// <returns></returns>
        Task<Department> GetByDeptNumberAsync(short dept);
    }
}
