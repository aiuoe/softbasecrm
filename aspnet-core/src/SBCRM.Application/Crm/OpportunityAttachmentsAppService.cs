using SBCRM.Crm;

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
    [AbpAuthorize(AppPermissions.Pages_OpportunityAttachments)]
    public class OpportunityAttachmentsAppService : SBCRMAppServiceBase, IOpportunityAttachmentsAppService
    {
        private readonly IRepository<OpportunityAttachment> _opportunityAttachmentRepository;
        private readonly IRepository<Opportunity, int> _lookup_opportunityRepository;

        public OpportunityAttachmentsAppService(IRepository<OpportunityAttachment> opportunityAttachmentRepository, IRepository<Opportunity, int> lookup_opportunityRepository)
        {
            _opportunityAttachmentRepository = opportunityAttachmentRepository;
            _lookup_opportunityRepository = lookup_opportunityRepository;

        }

        public async Task<PagedResultDto<GetOpportunityAttachmentForViewDto>> GetAll(GetAllOpportunityAttachmentsInput input)
        {

            var filteredOpportunityAttachments = _opportunityAttachmentRepository.GetAll()
                        .Include(e => e.OpportunityFk)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.Filter), e => false || e.Name.Contains(input.Filter) || e.FilePath.Contains(input.Filter))
                        .WhereIf(!string.IsNullOrWhiteSpace(input.NameFilter), e => e.Name == input.NameFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.FilePathFilter), e => e.FilePath == input.FilePathFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.OpportunityNameFilter), e => e.OpportunityFk != null && e.OpportunityFk.Name == input.OpportunityNameFilter);

            var pagedAndFilteredOpportunityAttachments = filteredOpportunityAttachments
                .OrderBy(input.Sorting ?? "id asc")
                .PageBy(input);

            var opportunityAttachments = from o in pagedAndFilteredOpportunityAttachments
                                         join o1 in _lookup_opportunityRepository.GetAll() on o.OpportunityId equals o1.Id into j1
                                         from s1 in j1.DefaultIfEmpty()

                                         select new
                                         {

                                             o.Name,
                                             o.FilePath,
                                             Id = o.Id,
                                             OpportunityName = s1 == null || s1.Name == null ? "" : s1.Name.ToString()
                                         };

            var totalCount = await filteredOpportunityAttachments.CountAsync();

            var dbList = await opportunityAttachments.ToListAsync();
            var results = new List<GetOpportunityAttachmentForViewDto>();

            foreach (var o in dbList)
            {
                var res = new GetOpportunityAttachmentForViewDto()
                {
                    OpportunityAttachment = new OpportunityAttachmentDto
                    {

                        Name = o.Name,
                        FilePath = o.FilePath,
                        Id = o.Id,
                    },
                    OpportunityName = o.OpportunityName
                };

                results.Add(res);
            }

            return new PagedResultDto<GetOpportunityAttachmentForViewDto>(
                totalCount,
                results
            );

        }

        public async Task<GetOpportunityAttachmentForViewDto> GetOpportunityAttachmentForView(int id)
        {
            var opportunityAttachment = await _opportunityAttachmentRepository.GetAsync(id);

            var output = new GetOpportunityAttachmentForViewDto { OpportunityAttachment = ObjectMapper.Map<OpportunityAttachmentDto>(opportunityAttachment) };

            if (output.OpportunityAttachment.OpportunityId != null)
            {
                var _lookupOpportunity = await _lookup_opportunityRepository.FirstOrDefaultAsync((int)output.OpportunityAttachment.OpportunityId);
                output.OpportunityName = _lookupOpportunity?.Name?.ToString();
            }

            return output;
        }

        [AbpAuthorize(AppPermissions.Pages_OpportunityAttachments_Edit)]
        public async Task<GetOpportunityAttachmentForEditOutput> GetOpportunityAttachmentForEdit(EntityDto input)
        {
            var opportunityAttachment = await _opportunityAttachmentRepository.FirstOrDefaultAsync(input.Id);

            var output = new GetOpportunityAttachmentForEditOutput { OpportunityAttachment = ObjectMapper.Map<CreateOrEditOpportunityAttachmentDto>(opportunityAttachment) };

            if (output.OpportunityAttachment.OpportunityId != null)
            {
                var _lookupOpportunity = await _lookup_opportunityRepository.FirstOrDefaultAsync((int)output.OpportunityAttachment.OpportunityId);
                output.OpportunityName = _lookupOpportunity?.Name?.ToString();
            }

            return output;
        }

        public async Task CreateOrEdit(CreateOrEditOpportunityAttachmentDto input)
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

        [AbpAuthorize(AppPermissions.Pages_OpportunityAttachments_Create)]
        protected virtual async Task Create(CreateOrEditOpportunityAttachmentDto input)
        {
            var opportunityAttachment = ObjectMapper.Map<OpportunityAttachment>(input);

            await _opportunityAttachmentRepository.InsertAsync(opportunityAttachment);

        }

        [AbpAuthorize(AppPermissions.Pages_OpportunityAttachments_Edit)]
        protected virtual async Task Update(CreateOrEditOpportunityAttachmentDto input)
        {
            var opportunityAttachment = await _opportunityAttachmentRepository.FirstOrDefaultAsync((int)input.Id);
            ObjectMapper.Map(input, opportunityAttachment);

        }

        [AbpAuthorize(AppPermissions.Pages_OpportunityAttachments_Delete)]
        public async Task Delete(EntityDto input)
        {
            await _opportunityAttachmentRepository.DeleteAsync(input.Id);
        }
        [AbpAuthorize(AppPermissions.Pages_OpportunityAttachments)]
        public async Task<List<OpportunityAttachmentOpportunityLookupTableDto>> GetAllOpportunityForTableDropdown()
        {
            return await _lookup_opportunityRepository.GetAll()
                .Select(opportunity => new OpportunityAttachmentOpportunityLookupTableDto
                {
                    Id = opportunity.Id,
                    DisplayName = opportunity == null || opportunity.Name == null ? "" : opportunity.Name.ToString()
                }).ToListAsync();
        }

    }
}