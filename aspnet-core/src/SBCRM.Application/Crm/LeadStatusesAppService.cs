using System;
using System.Linq;
using System.Linq.Dynamic.Core;
using Abp.Linq.Extensions;
using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Domain.Repositories;
using SBCRM.Crm.Dtos;
using SBCRM.Dto;
using Abp.Application.Services.Dto;
using SBCRM.Authorization;
using Abp.Extensions;
using Abp.Authorization;
using Microsoft.EntityFrameworkCore;
using Abp.UI;
using SBCRM.Storage;

namespace SBCRM.Crm
{
    /// <summary>
    /// LeadStatusesAppService
    /// </summary>
    [AbpAuthorize(AppPermissions.Pages_LeadStatuses)]
    public class LeadStatusesAppService : SBCRMAppServiceBase, ILeadStatusesAppService
    {
        private readonly IRepository<LeadStatus> _leadStatusRepository;

        public LeadStatusesAppService(IRepository<LeadStatus> leadStatusRepository)
        {
            _leadStatusRepository = leadStatusRepository;

        }

        /// <summary>
        /// Gets all lead statuses
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<PagedResultDto<GetLeadStatusForViewDto>> GetAll(GetAllLeadStatusesInput input)
        {

            var filteredLeadStatuses = _leadStatusRepository.GetAll()
                        .WhereIf(!string.IsNullOrWhiteSpace(input.Filter), e => false || e.Description.Contains(input.Filter) || e.Color.Contains(input.Filter))
                        .WhereIf(!string.IsNullOrWhiteSpace(input.DescriptionFilter), e => e.Description == input.DescriptionFilter)
                        .WhereIf(input.IsLeadConversionValidFilter.HasValue && input.IsLeadConversionValidFilter > -1, e => (input.IsLeadConversionValidFilter == 1 && e.IsLeadConversionValid) || (input.IsLeadConversionValidFilter == 0 && !e.IsLeadConversionValid))
                        .WhereIf(input.IsDefaultFilter.HasValue && input.IsDefaultFilter > -1, e => (input.IsDefaultFilter == 1 && e.IsDefault) || (input.IsDefaultFilter == 0 && !e.IsDefault));

            var pagedAndFilteredLeadStatuses = filteredLeadStatuses
                .OrderBy(input.Sorting ?? "id asc")
                .PageBy(input);

            var leadStatuses = from o in pagedAndFilteredLeadStatuses
                               select new
                               {

                                   o.Description,
                                   o.IsLeadConversionValid,
                                   o.IsDefault,
                                   Id = o.Id
                               };

            var totalCount = await filteredLeadStatuses.CountAsync();

            var dbList = await leadStatuses.ToListAsync();
            var results = new List<GetLeadStatusForViewDto>();

            foreach (var o in dbList)
            {
                var res = new GetLeadStatusForViewDto()
                {
                    LeadStatus = new LeadStatusDto
                    {

                        Description = o.Description,
                        IsLeadConversionValid = o.IsLeadConversionValid,
                        IsDefault = o.IsDefault,
                        Id = o.Id,
                    }
                };

                results.Add(res);
            }

            return new PagedResultDto<GetLeadStatusForViewDto>(
                totalCount,
                results
            );

        }

        /// <summary>
        /// Gets leads status for view by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<GetLeadStatusForViewDto> GetLeadStatusForView(int id)
        {
            var leadStatus = await _leadStatusRepository.GetAsync(id);

            var output = new GetLeadStatusForViewDto { LeadStatus = ObjectMapper.Map<LeadStatusDto>(leadStatus) };

            return output;
        }

        /// <summary>
        /// Gets a lead status to be edited
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [AbpAuthorize(AppPermissions.Pages_LeadStatuses_Edit)]
        public async Task<GetLeadStatusForEditOutput> GetLeadStatusForEdit(EntityDto input)
        {
            var leadStatus = await _leadStatusRepository.FirstOrDefaultAsync(input.Id);

            var output = new GetLeadStatusForEditOutput { LeadStatus = ObjectMapper.Map<CreateOrEditLeadStatusDto>(leadStatus) };

            return output;
        }

        /// <summary>
        /// Method used to create or edit a lead status
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task CreateOrEdit(CreateOrEditLeadStatusDto input)
        {
            if (input.Id == null)
            {
                await Create(input);
            }
            else
            {
                await Update(input);
            }
        }

        /// <summary>
        /// Creates a new lead status
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [AbpAuthorize(AppPermissions.Pages_LeadStatuses_Create)]
        protected virtual async Task Create(CreateOrEditLeadStatusDto input)
        {
            var leadStatus = ObjectMapper.Map<LeadStatus>(input);

            await _leadStatusRepository.InsertAsync(leadStatus);

        }

        /// <summary>
        /// Updates a lead status
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [AbpAuthorize(AppPermissions.Pages_LeadStatuses_Edit)]
        protected virtual async Task Update(CreateOrEditLeadStatusDto input)
        {
            var leadStatus = await _leadStatusRepository.FirstOrDefaultAsync((int)input.Id);
            ObjectMapper.Map(input, leadStatus);

        }

        /// <summary>
        /// Deletes a lead status
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [AbpAuthorize(AppPermissions.Pages_LeadStatuses_Delete)]
        public async Task Delete(EntityDto input)
        {
            await _leadStatusRepository.DeleteAsync(input.Id);
        }

    }
}