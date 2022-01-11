using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using Microsoft.EntityFrameworkCore;
using SBCRM.Authorization;
using SBCRM.Crm.Dtos;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;

namespace SBCRM.Crm
{
    /// <summary>
    /// Class app service for lead status
    /// </summary>
    [AbpAuthorize(AppPermissions.Pages_LeadStatuses)]
    public class LeadStatusesAppService : SBCRMAppServiceBase, ILeadStatusesAppService
    {
        private readonly IRepository<LeadStatus> _leadStatusRepository;

        /// <summary>
        /// Class constructor
        /// </summary>
        /// <param name="leadStatusRepository"></param>
        public LeadStatusesAppService(IRepository<LeadStatus> leadStatusRepository)
        {
            _leadStatusRepository = leadStatusRepository;
        }

        /// <summary>
        /// Get all lead statuses
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<PagedResultDto<GetLeadStatusForViewDto>> GetAll(GetAllLeadStatusesInput input)
        {
            IQueryable<LeadStatus> filteredLeadStatuses = _leadStatusRepository.GetAll()
                        .WhereIf(!string.IsNullOrWhiteSpace(input.Filter), e => false || e.Description.Contains(input.Filter) || e.Color.Contains(input.Filter))
                        .WhereIf(!string.IsNullOrWhiteSpace(input.DescriptionFilter), e => e.Description == input.DescriptionFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.ColorFilter), e => e.Color == input.ColorFilter)
                        .WhereIf(input.IsLeadConversionValidFilter.HasValue && input.IsLeadConversionValidFilter > -1, e => (input.IsLeadConversionValidFilter == 1 && e.IsLeadConversionValid) || (input.IsLeadConversionValidFilter == 0 && !e.IsLeadConversionValid))
                        .WhereIf(input.IsDefaultFilter.HasValue && input.IsDefaultFilter > -1, e => (input.IsDefaultFilter == 1 && e.IsDefault) || (input.IsDefaultFilter == 0 && !e.IsDefault));

            IQueryable<LeadStatus> pagedAndFilteredLeadStatuses = filteredLeadStatuses
                .OrderBy(input.Sorting ?? "id asc")
                .PageBy(input);

            var leadStatuses = from o in pagedAndFilteredLeadStatuses
                               select new
                               {
                                   o.Description,
                                   o.Color,
                                   o.IsLeadConversionValid,
                                   o.IsDefault,
                                   o.Order,
                                   Id = o.Id
                               };

            int totalCount = await filteredLeadStatuses.CountAsync();

            var dbList = await leadStatuses.OrderBy(x => x.Order).ToListAsync();
            List<GetLeadStatusForViewDto> results = new List<GetLeadStatusForViewDto>();

            foreach (var o in dbList)
            {
                GetLeadStatusForViewDto res = new GetLeadStatusForViewDto()
                {
                    LeadStatus = new LeadStatusDto
                    {
                        Description = o.Description,
                        Color = o.Color,
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
        /// Get lead statusfor view mode
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<GetLeadStatusForViewDto> GetLeadStatusForView(int id)
        {
            LeadStatus leadStatus = await _leadStatusRepository.GetAsync(id);

            GetLeadStatusForViewDto output = new GetLeadStatusForViewDto { LeadStatus = ObjectMapper.Map<LeadStatusDto>(leadStatus) };

            return output;
        }

        /// <summary>
        /// Get lead status for edition mode
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [AbpAuthorize(AppPermissions.Pages_LeadStatuses_Edit)]
        public async Task<GetLeadStatusForEditOutput> GetLeadStatusForEdit(EntityDto input)
        {
            LeadStatus leadStatus = await _leadStatusRepository.FirstOrDefaultAsync(input.Id);

            GetLeadStatusForEditOutput output = new GetLeadStatusForEditOutput { LeadStatus = ObjectMapper.Map<CreateOrEditLeadStatusDto>(leadStatus) };

            return output;
        }

        /// <summary>
        /// Create or edit lead status
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
        /// Method that Create a lead status
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [AbpAuthorize(AppPermissions.Pages_LeadStatuses_Create)]
        protected virtual async Task Create(CreateOrEditLeadStatusDto input)
        {
            int lastLeadStatusOrder = _leadStatusRepository.GetAll().Max(x => x.Order);
            input.Order = lastLeadStatusOrder + 1;

            LeadStatus leadStatus = ObjectMapper.Map<LeadStatus>(input);

            leadStatus.TenantId = GetTenantId();

            await _leadStatusRepository.InsertAsync(leadStatus);
        }

        /// <summary>
        /// Method that edit a lead status
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [AbpAuthorize(AppPermissions.Pages_LeadStatuses_Edit)]
        protected virtual async Task Update(CreateOrEditLeadStatusDto input)
        {
            LeadStatus leadStatus = await _leadStatusRepository.FirstOrDefaultAsync((int)input.Id);
            ObjectMapper.Map(input, leadStatus);
        }

        /// <summary>
        /// Method that updates the order of a list
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [AbpAuthorize(AppPermissions.Pages_LeadStatuses_Edit)]
        public virtual async Task UpdateOrder(List<UpdateOrderLeadStatusDto> input)
        {
            int indexSrc = input[0].Order;
            int indexDst = input[1].Order;

            List<LeadStatus> allLeadStatuses = _leadStatusRepository.GetAll().OrderBy(x => x.Order).ToList();

            int originalCount = allLeadStatuses.Count;

            LeadStatus leadStatusSrc = allLeadStatuses[indexSrc];

            List<LeadStatus> modifiedOrderList = new List<LeadStatus>();

            allLeadStatuses.RemoveAt(indexSrc);

            int index = 0;
            foreach (LeadStatus status in allLeadStatuses)
            {
                if (index != indexDst)
                    modifiedOrderList.Add(status);
                else
                {
                    modifiedOrderList.Add(leadStatusSrc);
                    modifiedOrderList.Add(status);
                }
                index++;
            }

            if (modifiedOrderList.Count != originalCount)
                modifiedOrderList.Add(leadStatusSrc);

            int order = 1;
            foreach (LeadStatus status in modifiedOrderList)
            {
                status.Order = order;
                await _leadStatusRepository.FirstOrDefaultAsync(status.Id);
                order++;

            }
        }

        /// <summary>
        /// Delete a lead status
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [AbpAuthorize(AppPermissions.Pages_LeadStatuses_Delete)]
        public async Task Delete(EntityDto input)
        {
            _leadStatusRepository.Delete(input.Id);            
        } 
    }
}