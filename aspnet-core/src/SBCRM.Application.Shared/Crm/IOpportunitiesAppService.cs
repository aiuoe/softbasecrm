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
    /// App service to handle opportunities information
    /// </summary>
    public interface IOpportunitiesAppService : IApplicationService
    {
        /// <summary>
        /// Get all opportunities 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<PagedResultDto<GetOpportunityForViewDto>> GetAll(GetAllOpportunitiesInput input);

        /// <summary>
        /// Get opportunity for view mode
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<GetOpportunityForViewDto> GetOpportunityForView(int id);

        /// <summary>
        /// Get opportunity for edition mode
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<GetOpportunityForEditOutput> GetOpportunityForEdit(EntityDto input);

        /// <summary>
        /// Create or edit opportunity
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task CreateOrEdit(CreateOrEditOpportunityDto input);

        /// <summary>
        /// Delete opportunity
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task Delete(EntityDto input);

        /// <summary>
        /// Get opportunities to excel
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<FileDto> GetOpportunitiesToExcel(GetAllOpportunitiesForExcelInput input);

        /// <summary>
        /// Get opportunity stage type dropdown
        /// </summary>
        /// <returns></returns>
        Task<List<OpportunityOpportunityStageLookupTableDto>> GetAllOpportunityStageForTableDropdown();

        /// <summary>
        /// Get Lead Source type dropdown
        /// </summary>
        /// <returns></returns>
        Task<List<OpportunityLeadSourceLookupTableDto>> GetAllLeadSourceForTableDropdown();

        /// <summary>
        /// Get Opportunity type type dropdown
        /// </summary>
        /// <returns></returns>
        Task<List<OpportunityOpportunityTypeLookupTableDto>> GetAllOpportunityTypeForTableDropdown();

        /// <summary>
        /// Get Customer type dropdown
        /// </summary>
        /// <returns></returns>
        Task<List<OpportunityCustomerLookupTableDto>> GetAllCustomerForTableDropdown();

        /// <summary>
        /// Get Contacts type dropdown
        /// </summary>
        /// <returns></returns>
        Task<List<OpportunityContactsLookupTableDto>> GetAllContactsForTableDropdown();

        /// <summary>
        /// Get Contacts - Customer specific type dropdown
        /// </summary>
        /// <returns></returns>
        Task<List<OpportunityContactsLookupTableDto>> GetAllContactsForTableDropdownCustomerSpecific(string customerNumber);

        /// <summary>
        /// Get al events
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<PagedResultDto<EntityChangeListDto>> GetEntityTypeChanges(GetCrmEntityTypeChangeInput input);

        /// <summary>
        /// Get Branches lookup
        /// </summary>
        /// <returns></returns>
        Task<List<BranchLookupTableDto>> GetAllBranchesForTableDropdown();

        /// <summary>
        /// Get Departments lookup
        /// </summary>
        /// <returns></returns>
        Task<List<DepartmentLookupTableDto>> GetAllDepartmentsForTableDropdown();
    }
}