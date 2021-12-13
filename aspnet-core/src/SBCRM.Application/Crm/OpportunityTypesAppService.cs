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
    [AbpAuthorize(AppPermissions.Pages_OpportunityTypes)]
    public class OpportunityTypesAppService : SBCRMAppServiceBase, IOpportunityTypesAppService
    {
        private readonly IRepository<OpportunityType> _opportunityTypeRepository;

        public OpportunityTypesAppService(IRepository<OpportunityType> opportunityTypeRepository)
        {
            _opportunityTypeRepository = opportunityTypeRepository;

        }

        public async Task<PagedResultDto<GetOpportunityTypeForViewDto>> GetAll(GetAllOpportunityTypesInput input)
        {

            var filteredOpportunityTypes = _opportunityTypeRepository.GetAll()
                        .WhereIf(!string.IsNullOrWhiteSpace(input.Filter), e => false || e.Description.Contains(input.Filter))
                        .WhereIf(!string.IsNullOrWhiteSpace(input.DescriptionFilter), e => e.Description == input.DescriptionFilter);

            var pagedAndFilteredOpportunityTypes = filteredOpportunityTypes
                .OrderBy(input.Sorting ?? "id asc")
                .PageBy(input);

            var opportunityTypes = from o in pagedAndFilteredOpportunityTypes
                                   select new
                                   {

                                       o.Description,
                                       o.Order,
                                       Id = o.Id
                                   };

            var totalCount = await filteredOpportunityTypes.CountAsync();

            var dbList = await opportunityTypes.ToListAsync();
            var results = new List<GetOpportunityTypeForViewDto>();

            foreach (var o in dbList)
            {
                var res = new GetOpportunityTypeForViewDto()
                {
                    OpportunityType = new OpportunityTypeDto
                    {

                        Description = o.Description,
                        Order = o.Order,
                        Id = o.Id,
                    }
                };

                results.Add(res);
            }

            return new PagedResultDto<GetOpportunityTypeForViewDto>(
                totalCount,
                results
            );

        }

        public async Task<GetOpportunityTypeForViewDto> GetOpportunityTypeForView(int id)
        {
            var opportunityType = await _opportunityTypeRepository.GetAsync(id);

            var output = new GetOpportunityTypeForViewDto { OpportunityType = ObjectMapper.Map<OpportunityTypeDto>(opportunityType) };

            return output;
        }

        [AbpAuthorize(AppPermissions.Pages_OpportunityTypes_Edit)]
        public async Task<GetOpportunityTypeForEditOutput> GetOpportunityTypeForEdit(EntityDto input)
        {
            var opportunityType = await _opportunityTypeRepository.FirstOrDefaultAsync(input.Id);

            var output = new GetOpportunityTypeForEditOutput { OpportunityType = ObjectMapper.Map<CreateOrEditOpportunityTypeDto>(opportunityType) };

            return output;
        }

        public async Task CreateOrEdit(CreateOrEditOpportunityTypeDto input)
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

        [AbpAuthorize(AppPermissions.Pages_OpportunityTypes_Create)]
        protected virtual async Task Create(CreateOrEditOpportunityTypeDto input)
        {
            var opportunityType = ObjectMapper.Map<OpportunityType>(input);

            await _opportunityTypeRepository.InsertAsync(opportunityType);

        }

        [AbpAuthorize(AppPermissions.Pages_OpportunityTypes_Edit)]
        protected virtual async Task Update(CreateOrEditOpportunityTypeDto input)
        {
            var opportunityType = await _opportunityTypeRepository.FirstOrDefaultAsync((int)input.Id);
            ObjectMapper.Map(input, opportunityType);

        }

        [AbpAuthorize(AppPermissions.Pages_OpportunityTypes_Delete)]
        public async Task Delete(EntityDto input)
        {
            await _opportunityTypeRepository.DeleteAsync(input.Id);
        }

    }
}