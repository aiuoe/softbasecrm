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
    /// Repository class for the dbo.secure table
    /// </summary>
    public class SoftBasePersonRepository : ISoftBasePersonRepository
    {
        private readonly SBCRMDbContext _dbContext;

        /// <summary>
        /// Main constructor
        /// </summary>
        /// <param name="dbContext">The database context</param>
        public SoftBasePersonRepository(SBCRMDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// Gets a  dbo.secure record by employee number
        /// </summary>
        /// <param name="employeNumber"></param>
        /// <returns>The secure record with that matches the employe number or null</returns>
        public async Task<Person> GetPersonByEmployeeNumberAsync(int employeNumber)
        {
            return await _dbContext.Person.FirstOrDefaultAsync(s => s.Number == employeNumber);
        }
    }
}
