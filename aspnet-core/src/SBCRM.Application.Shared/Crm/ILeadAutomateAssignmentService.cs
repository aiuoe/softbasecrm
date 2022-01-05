using Abp.Dependency;
using SBCRM.Crm.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SBCRM.Crm
{
    /// <summary>
    /// Class that handles the method of auto-assigning users to a lead
    /// </summary>
    public interface ILeadAutomateAssignmentService : ITransientDependency
    {
        /// <summary>
        /// Method that assigns a user to a lead
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task AssignLeadUsersAsync(List<CreateOrEditLeadUserDto> input);
    }
}