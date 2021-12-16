using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using SBCRM.Crm.Dtos;
using SBCRM.Dto;

namespace SBCRM.Crm
{
    /// <summary>
    /// App service to handle Countries information
    /// </summary>
    public interface ICountriesAppService : IApplicationService
    {
        /// <summary>
        /// Get all countries
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<PagedResultDto<GetCountryForViewDto>> GetAll(GetAllCountriesInput input);

        /// <summary>
        /// Get all countries for dropdown
        /// </summary>
        /// <returns></returns>
        Task<List<GetCountryForViewDto>> GetAllForTableDropdown();

        /// <summary>
        /// Get country for view mode by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<GetCountryForViewDto> GetCountryForView(int id);

        /// <summary>
        /// Get country for edition mode
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<GetCountryForEditOutput> GetCountryForEdit(EntityDto input);

        /// <summary>
        /// Create or edit country
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task CreateOrEdit(CreateOrEditCountryDto input);

        /// <summary>
        /// Delete country
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task Delete(EntityDto input);

        /// <summary>
        /// Get countries to excel
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<FileDto> GetCountriesToExcel(GetAllCountriesForExcelInput input);

    }
}