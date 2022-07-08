
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
            var result = await _dbContext.SalesTaxIntegrations.FirstAsync();
            return new AvalaraConnectionDataDto()
            {
                SalesTaxProvider = result.SalesTaxProvider,
                AccountNumber = result.AccountNumber,
                LicenseKey = result.LicenseKey,
                ServiceUrl = result.ServiceUrl,
                RequestTimeout = result.RequestTimeout

            };
        }


        /// <summary>
        /// Return if SalesTaxProvider is Softbase or not
        /// </summary>
        /// <returns>boolean</returns>
        public async Task<bool> UseDefaultTaxCodeCalc()
        {
            var result = await _dbContext.SalesTaxIntegrations.FirstAsync();
            return result.SalesTaxProvider.ToLower() != "SoftBase".ToLower();
        }
    }


}
