using Abp.Dependency;
using SBCRM.Crm.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SBCRM.Crm
{
    /// <summary>
    /// Class that handles the method of auto-assigning users to an Opportunity
    /// </summary>
    public interface IOpportunityAutomateAssignment : ITransientDependency
    {
        /// <summary>
        /// Method that assigns a user to an Opportunity
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task AssignOpportunityUsersAsync(List<CreateOrEditOpportunityUserDto> input);
    }
}