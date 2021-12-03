using System.Linq;
using System.Linq.Dynamic.Core;
using Abp.Linq.Extensions;
using System.Collections.Generic;
using System.Threading.Tasks;
using SBCRM.Legacy.Dtos;
using Abp.Application.Services.Dto;
using Microsoft.EntityFrameworkCore;

namespace SBCRM.Legacy
{
    //[AbpAuthorize(AppPermissions.Pages_ZipCodes)]
    public class ZipCodesAppService : SBCRMAppServiceBase, IZipCodesAppService
    {
        private readonly Base.IRepository<ZipCode> _zipCodeRepository;

        public ZipCodesAppService(Base.IRepository<ZipCode> zipCodeRepository)
        {
            _zipCodeRepository = zipCodeRepository;
        }

        public async Task<PagedResultDto<GetZipCodeForViewDto>> GetAll(GetAllZipCodesInput input)
        {
            var filteredZipCodes = _zipCodeRepository.GetAll()
                .WhereIf(!string.IsNullOrWhiteSpace(input.Filter),
                    e => false || e.ZipCodeField.Contains(input.Filter) || e.City.Contains(input.Filter) ||
                         e.State.Contains(input.Filter) || e.County.Contains(input.Filter) ||
                         e.AddedBy.Contains(input.Filter) || e.ChangedBy.Contains(input.Filter))
                .WhereIf(!string.IsNullOrWhiteSpace(input.ZipCodeFilter), e => e.ZipCodeField == input.ZipCodeFilter)
                .WhereIf(!string.IsNullOrWhiteSpace(input.CityFilter), e => e.City == input.CityFilter)
                .WhereIf(!string.IsNullOrWhiteSpace(input.StateFilter), e => e.State == input.StateFilter)
                .WhereIf(!string.IsNullOrWhiteSpace(input.CountyFilter), e => e.County == input.CountyFilter)
                .WhereIf(!string.IsNullOrWhiteSpace(input.AddedByFilter), e => e.AddedBy == input.AddedByFilter)
                .WhereIf(!string.IsNullOrWhiteSpace(input.ChangedByFilter), e => e.ChangedBy == input.ChangedByFilter)
                .WhereIf(input.MinDateAddedFilter != null, e => e.DateAdded >= input.MinDateAddedFilter)
                .WhereIf(input.MaxDateAddedFilter != null, e => e.DateAdded <= input.MaxDateAddedFilter)
                .WhereIf(input.MinDateChangedFilter != null, e => e.DateChanged >= input.MinDateChangedFilter)
                .WhereIf(input.MaxDateChangedFilter != null, e => e.DateChanged <= input.MaxDateChangedFilter);

            var pagedAndFilteredZipCodes = filteredZipCodes
                .OrderBy(input.Sorting ?? $"{nameof(ZipCode.ZipCodeField)} asc")
                .PageBy(input);

            var zipCodes = from o in pagedAndFilteredZipCodes
                select new
                {
                    o.ZipCodeField,
                    o.City,
                    o.State,
                    o.County,
                    o.AddedBy,
                    o.ChangedBy,
                    o.DateAdded,
                    o.DateChanged
                };

            var totalCount = await filteredZipCodes.CountAsync();

            var dbList = await zipCodes.ToListAsync();
            var results = new List<GetZipCodeForViewDto>();

            foreach (var o in dbList)
            {
                var res = new GetZipCodeForViewDto()
                {
                    ZipCode = new ZipCodeDto
                    {
                        ZipCode = o.ZipCodeField,
                        City = o.City,
                        State = o.State,
                        County = o.County,
                        AddedBy = o.AddedBy,
                        ChangedBy = o.ChangedBy,
                        DateAdded = o.DateAdded,
                        DateChanged = o.DateChanged
                    }
                };

                results.Add(res);
            }

            return new PagedResultDto<GetZipCodeForViewDto>(
                totalCount,
                results
            );
        }
    }
}