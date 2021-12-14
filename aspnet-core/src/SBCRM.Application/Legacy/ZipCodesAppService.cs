using System.Linq;
using System.Linq.Dynamic.Core;
using Abp.Linq.Extensions;
using System.Collections.Generic;
using System.Threading.Tasks;
using SBCRM.Legacy.Dtos;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Microsoft.EntityFrameworkCore;
using SBCRM.Base;

namespace SBCRM.Legacy
{
    //[AbpAuthorize(AppPermissions.Pages_ZipCodes)]
    [AbpAllowAnonymous]
    public class ZipCodesAppService : SBCRMAppServiceBase, IZipCodesAppService
    {
        private readonly IRepository<ZipCode> _zipCodeRepository;

        public ZipCodesAppService(IRepository<ZipCode> zipCodeRepository)
        {
            _zipCodeRepository = zipCodeRepository;
        }

        public async Task<PagedResultDto<GetZipCodeForViewDto>> GetAll(GetAllZipCodesInput input)
        {
            var filteredZipCodes = _zipCodeRepository.GetAll()
                .WhereIf(!string.IsNullOrWhiteSpace(input.ZipCodeFilter), e => e.ZipCodeField == input.ZipCodeFilter);

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
                var res = new GetZipCodeForViewDto
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