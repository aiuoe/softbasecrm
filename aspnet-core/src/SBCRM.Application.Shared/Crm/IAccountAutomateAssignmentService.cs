using Abp.Dependency;
using SBCRM.Crm.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SBCRM.Crm
{
    /// <summary>
    /// Class that handles the method of auto-assigning users to an account
    /// </summary>
    public interface IAccountAutomateAssignmentService : ITransientDependency
    {
        /// <summary>
        /// Method that assigns a user to an account
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task AssignAccountUsersAsync(List<CreateOrEditAccountUserDto> input);
    }
}