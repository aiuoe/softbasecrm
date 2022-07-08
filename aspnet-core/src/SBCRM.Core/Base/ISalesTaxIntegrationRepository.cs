using SBCRM.Core.BaseEntities;
using SBCRM.Dto;
using System.Threading.Tasks;

namespace SBCRM.Base
{
    /// <summary>
    /// Repository to provide data access of SalesTaxIntegration
    /// </summary>
    public interface ISalesTaxIntegrationRepository : Abp.Domain.Repositories.IRepository<SalesTaxIntegration, long>
    {
        Task<AvalaraConnectionDataDto> GetAvalaraConnectionSettings();
        Task<bool> CheckUseDefaultTaxCodeCalc();
    }
}
