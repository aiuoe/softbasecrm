using SBCRM.Legacy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBCRM.Base
{
    /// <summary>
    /// Repository interface for the "Person" repository
    /// </summary>
    public interface ISoftBasePersonRepository
    {
        /// <summary>
        /// Gets a  dbo.person record by employee number
        /// </summary>
        /// <param name="employeNumber"></param>
        /// <returns>The person record with that matches the employe number or null</returns>
        Task<Person> GetPersonByEmployeeNumberAsync(int employeNumber);
    }
}
