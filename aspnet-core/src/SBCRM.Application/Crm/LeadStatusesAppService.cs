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
    [AbpAuthorize(AppPermissions.Pages_LeadStatuses)]
    public class LeadStatusesAppService : SBCRMAppServiceBase, ILeadStatusesAppService
    {
        private readonly IRepository<LeadStatus> _leadStatusRepository;

        public LeadStatusesAppService(IRepository<LeadStatus> leadStatusRepository)
        {
            _leadStatusRepository = leadStatusRepository;

        }

        public async Task<PagedResultDto<GetLeadStatusForViewDto>> GetAll(GetAllLeadStatusesInput input)
        {

            var filteredLeadStatuses = _leadStatusRepository.GetAll()
                        .WhereIf(!string.IsNullOrWhiteSpace(input.Filter), e => false || e.Description.Contains(input.Filter) || e.Color.Contains(input.Filter))
                        .WhereIf(!string.IsNullOrWhiteSpace(input.DescriptionFilter), e => e.Description == input.DescriptionFilter);

            var pagedAndFilteredLeadStatuses = filteredLeadStatuses
                .OrderBy(input.Sorting ?? "id asc")
                .PageBy(input);

            var leadStatuses = from o in pagedAndFilteredLeadStatuses
                               select new
                               {

                                   o.Description,
                                   o.IsLeadConversionValid,
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

        public async Task<GetLeadStatusForViewDto> GetLeadStatusForView(int id)
        {
            var leadStatus = await _leadStatusRepository.GetAsync(id);

            var output = new GetLeadStatusForViewDto { LeadStatus = ObjectMapper.Map<LeadStatusDto>(leadStatus) };

            return output;
        }

        [AbpAuthorize(AppPermissions.Pages_LeadStatuses_Edit)]
        public async Task<GetLeadStatusForEditOutput> GetLeadStatusForEdit(EntityDto input)
        {
            var leadStatus = await _leadStatusRepository.FirstOrDefaultAsync(input.Id);

            var output = new GetLeadStatusForEditOutput { LeadStatus = ObjectMapper.Map<CreateOrEditLeadStatusDto>(leadStatus) };

            return output;
        }

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

        [AbpAuthorize(AppPermissions.Pages_LeadStatuses_Create)]
        protected virtual async Task Create(CreateOrEditLeadStatusDto input)
        {
            var leadStatus = ObjectMapper.Map<LeadStatus>(input);

            await _leadStatusRepository.InsertAsync(leadStatus);

        }

        [AbpAuthorize(AppPermissions.Pages_LeadStatuses_Edit)]
        protected virtual async Task Update(CreateOrEditLeadStatusDto input)
        {
            var leadStatus = await _leadStatusRepository.FirstOrDefaultAsync((int)input.Id);
            ObjectMapper.Map(input, leadStatus);

        }

        [AbpAuthorize(AppPermissions.Pages_LeadStatuses_Delete)]
        public async Task Delete(EntityDto input)
        {
            await _leadStatusRepository.DeleteAsync(input.Id);
        }

    }
}