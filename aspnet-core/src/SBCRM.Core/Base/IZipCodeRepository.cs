using SBCRM.Core.BaseEntities;


namespace SBCRM.Base
{
    /// <summary>
    /// Specific ZipCode repository
    /// </summary>
    public interface IZipCodeRepository : Abp.Domain.Repositories.IRepository<ZipCode, long>
    {
    }
}
