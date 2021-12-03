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
    [AbpAuthorize(AppPermissions.Pages_Industries)]
    public class IndustriesAppService : SBCRMAppServiceBase, IIndustriesAppService
    {
        private readonly IRepository<Industry> _industryRepository;

        public IndustriesAppService(IRepository<Industry> industryRepository)
        {
            _industryRepository = industryRepository;

        }

        public async Task<PagedResultDto<GetIndustryForViewDto>> GetAll(GetAllIndustriesInput input)
        {

            var filteredIndustries = _industryRepository.GetAll()
                        .WhereIf(!string.IsNullOrWhiteSpace(input.Filter), e => false || e.Description.Contains(input.Filter));

            var pagedAndFilteredIndustries = filteredIndustries
                .OrderBy(input.Sorting ?? "id asc")
                .PageBy(input);

            var industries = from o in pagedAndFilteredIndustries
                             select new
                             {

                                 Id = o.Id
                             };

            var totalCount = await filteredIndustries.CountAsync();

            var dbList = await industries.ToListAsync();
            var results = new List<GetIndustryForViewDto>();

            foreach (var o in dbList)
            {
                var res = new GetIndustryForViewDto()
                {
                    Industry = new IndustryDto
                    {

                        Id = o.Id,
                    }
                };

                results.Add(res);
            }

            return new PagedResultDto<GetIndustryForViewDto>(
                totalCount,
                results
            );

        }

        [AbpAuthorize(AppPermissions.Pages_Industries_Edit)]
        public async Task<GetIndustryForEditOutput> GetIndustryForEdit(EntityDto input)
        {
            var industry = await _industryRepository.FirstOrDefaultAsync(input.Id);

            var output = new GetIndustryForEditOutput { Industry = ObjectMapper.Map<CreateOrEditIndustryDto>(industry) };

            return output;
        }

        public async Task CreateOrEdit(CreateOrEditIndustryDto input)
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

        [AbpAuthorize(AppPermissions.Pages_Industries_Create)]
        protected virtual async Task Create(CreateOrEditIndustryDto input)
        {
            var industry = ObjectMapper.Map<Industry>(input);

            await _industryRepository.InsertAsync(industry);

        }

        [AbpAuthorize(AppPermissions.Pages_Industries_Edit)]
        protected virtual async Task Update(CreateOrEditIndustryDto input)
        {
            var industry = await _industryRepository.FirstOrDefaultAsync((int)input.Id);
            ObjectMapper.Map(input, industry);

        }

        [AbpAuthorize(AppPermissions.Pages_Industries_Delete)]
        public async Task Delete(EntityDto input)
        {
            await _industryRepository.DeleteAsync(input.Id);
        }

    }
}