
using Abp.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SBCRM.Base;
using SBCRM.Core.BaseEntities;
using SBCRM.Dto;
using System.Threading.Tasks;

namespace SBCRM.EntityFrameworkCore.Repositories
{
   
    /// <summary>
    /// Implementation of SalesTaxIntegrationRepository
    /// </summary>
    public class SalesTaxIntegrationRepository : SBCRMRepositoryBase<SalesTaxIntegration, long>, ISalesTaxIntegrationRepository
    {
        private readonly SBCRMDbContext _dbContext;

        public const string SOFTBASE_TAX_PROVIDER = "Softbase";

        public SalesTaxIntegrationRepository(IDbContextProvider<SBCRMDbContext> dbContextProvider) : base(dbContextProvider)
        {
            _dbContext = dbContextProvider.GetDbContext();
        }



        /// <summary>
        /// Provides Avalara Connection Settings
        /// </summary>
        /// <returns>AvalaraConnectionDataDto</returns>
        public async Task<AvalaraConnectionDataDto> GetAvalaraConnectionSettings()
        {
            AvalaraConnectionDataDto result = null;

            var salesTaxIntegration = await _dbContext.SalesTaxIntegrations.FirstOrDefaultAsync();
            if (salesTaxIntegration != null)
            {
                result = new AvalaraConnectionDataDto
                {
                    SalesTaxProvider = salesTaxIntegration.SalesTaxProvider,
                    AccountNumber = salesTaxIntegration.AccountNumber,
                    LicenseKey = salesTaxIntegration.LicenseKey,
                    ServiceUrl = salesTaxIntegration.ServiceUrl,
                    RequestTimeout = salesTaxIntegration.RequestTimeout
                };
            }
            return result;
        }


        /// <summary>
        /// Return if SalesTaxProvider is Softbase or not
        /// </summary>
        /// <returns>boolean</returns>
        public async Task<bool> CheckUseDefaultTaxCodeCalc()
        {
            var result = await _dbContext.SalesTaxIntegrations.FirstAsync();
            return result.SalesTaxProvider.ToLower() != SOFTBASE_TAX_PROVIDER.ToLower();
        }
    }


}
