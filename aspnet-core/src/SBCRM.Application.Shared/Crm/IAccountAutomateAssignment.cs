using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Abp.Dependency;
using SBCRM.Crm.Dtos;

namespace SBCRM.Crm
{
    public interface IAccountAutomateAssignment : ITransientDependency
    {
        Task AssignAccountUsersAsync(List<CreateOrEditAccountUserDto> input);
    }
}