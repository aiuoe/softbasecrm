using SBCRM.Core.BaseEntities;

namespace SBCRM.Base
{
    /// <summary>
    /// Specific Branch repository
    /// </summary>
    public interface IBranchRepository : Abp.Domain.Repositories.IRepository<Branch, long>
    {
        
    }
}