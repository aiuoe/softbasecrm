using SBCRM.Core.BaseEntities;

namespace SBCRM.Base
{
    /// <summary>
    /// Specific Company repository
    /// </summary>
    public interface ICompanyRepository : Abp.Domain.Repositories.IRepository<Company, long>
    {
        
    }
}