using SBCRM.Legacy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBCRM.Base
{
    /// <summary>
    /// Repository interface for the "Secure" repository
    /// </summary>
    public interface ISoftBaseSecureRepository
    {
        /// <summary>
        /// Gets a  dbo.secure record by employee number
        /// </summary>
        /// <param name="employeNumber"></param>
        /// <returns>The secure record with that matches the employe number or null</returns>
        Task<Secure> GetLegacyUserByEmployeNumber(int employeNumber);
    }
}
