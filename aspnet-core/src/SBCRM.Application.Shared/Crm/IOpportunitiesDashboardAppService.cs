using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using SBCRM.Crm.Dtos;
using SBCRM.Dto;
using System.Collections.Generic;
using SBCRM.Auditing.Dto;
using SBCRM.Legacy.Dtos;

namespace SBCRM.Crm
{
    /// <summary>
    /// App service to handle opportunities dashboard information
    /// </summary>
    public interface IOpportunitiesDashboardAppService : IApplicationService
    {
        /// <summary>
        /// Gets the information for the opportunities stas dashboard
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<GetOpportunitiesStastsOutput> Get(GetOpportunitiesStastsInput input);

        /// <summary>
        /// Get Customer type dropdown
        /// </summary>
        /// <returns></returns>
        Task<List<OpportunityCustomerLookupTableDto>> GetAllCustomerForTableDropdown();

        /// <summary>
        /// Get Branch type dropdown
        /// </summary>
        /// <returns></returns>
        Task<List<BranchLookupTableDto>> GetAllBranchForTableDropdown();

        /// <summary>
        /// Get Branch type dropdown
        /// </summary>
        /// <returns></returns>
        Task<List<DepartmentLookupTableDto>> GetAllDepartmentForTableDropdown();

        /// <summary>
        /// Gets an excel file with the closed won items on the dashboard
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        FileDto GetClosedWonOpportunitiesDashboardToExcel(GetAllOpportunitiesDashboardForExcelInput input);

        /// <summary>
        /// Gets an excel file with the opportunities selected
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        FileDto GetOpportunitiesDashboardToExcel(GetAllOpportunitiesDashboardForExcelInput input);
    }
}