using System;
using System.Linq;
using System.Linq.Dynamic.Core;
using Abp.Linq.Extensions;
using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Domain.Repositories;
using SBCRM.Legacy.Dtos;
using SBCRM.Dto;
using Abp.Application.Services.Dto;
using SBCRM.Authorization;
using Abp.Extensions;
using Abp.Authorization;
using Microsoft.EntityFrameworkCore;
using Abp.UI;
using SBCRM.Storage;

namespace SBCRM.Legacy
{
    //[AbpAuthorize(AppPermissions.Pages_ARTerms)]
    public class ARTermsAppService : SBCRMAppServiceBase, IARTermsAppService
    {
        private readonly Base.IRepository<ARTerms> _arTermsRepository;

        public ARTermsAppService(Base.IRepository<ARTerms> arTermsRepository)
        {
            _arTermsRepository = arTermsRepository;

        }

        public async Task<PagedResultDto<GetARTermsForViewDto>> GetAll(GetAllARTermsInput input)
        {

            var filteredARTerms = _arTermsRepository.GetAll()
                        .WhereIf(!string.IsNullOrWhiteSpace(input.Filter), e => false || e.Terms.Contains(input.Filter) || e.AddedBy.Contains(input.Filter) || e.ChangedBy.Contains(input.Filter))
                        .WhereIf(!string.IsNullOrWhiteSpace(input.TermsFilter), e => e.Terms == input.TermsFilter)
                        .WhereIf(input.MinCODFilter != null, e => e.COD >= input.MinCODFilter)
                        .WhereIf(input.MaxCODFilter != null, e => e.COD <= input.MaxCODFilter)
                        .WhereIf(input.MinDaysDueFilter != null, e => e.DaysDue >= input.MinDaysDueFilter)
                        .WhereIf(input.MaxDaysDueFilter != null, e => e.DaysDue <= input.MaxDaysDueFilter)
                        .WhereIf(input.MinDaysFilter != null, e => e.Days >= input.MinDaysFilter)
                        .WhereIf(input.MaxDaysFilter != null, e => e.Days <= input.MaxDaysFilter)
                        .WhereIf(input.MinDayOfMonthFilter != null, e => e.DayOfMonth >= input.MinDayOfMonthFilter)
                        .WhereIf(input.MaxDayOfMonthFilter != null, e => e.DayOfMonth <= input.MaxDayOfMonthFilter)
                        .WhereIf(input.MinDayFilter != null, e => e.Day >= input.MinDayFilter)
                        .WhereIf(input.MaxDayFilter != null, e => e.Day <= input.MaxDayFilter)
                        .WhereIf(input.MinPrintWaterMarkFilter != null, e => e.PrintWaterMark >= input.MinPrintWaterMarkFilter)
                        .WhereIf(input.MaxPrintWaterMarkFilter != null, e => e.PrintWaterMark <= input.MaxPrintWaterMarkFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.AddedByFilter), e => e.AddedBy == input.AddedByFilter)
                        .WhereIf(input.MinDateAddedFilter != null, e => e.DateAdded >= input.MinDateAddedFilter)
                        .WhereIf(input.MaxDateAddedFilter != null, e => e.DateAdded <= input.MaxDateAddedFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.ChangedByFilter), e => e.ChangedBy == input.ChangedByFilter)
                        .WhereIf(input.MinDateChangedFilter != null, e => e.DateChanged >= input.MinDateChangedFilter)
                        .WhereIf(input.MaxDateChangedFilter != null, e => e.DateChanged <= input.MaxDateChangedFilter)
                        .WhereIf(input.MinCreditCardFilter != null, e => e.CreditCard >= input.MinCreditCardFilter)
                        .WhereIf(input.MaxCreditCardFilter != null, e => e.CreditCard <= input.MaxCreditCardFilter);

            var pagedAndFilteredARTerms = filteredARTerms
                .OrderBy(input.Sorting ?? $"{nameof(ARTerms.Terms)} asc")
                .PageBy(input);

            var arTerms = from o in pagedAndFilteredARTerms
                          select new
                          {

                              o.Terms,
                              o.COD,
                              o.DaysDue,
                              o.Days,
                              o.DayOfMonth,
                              o.Day,
                              o.PrintWaterMark,
                              o.AddedBy,
                              o.DateAdded,
                              o.ChangedBy,
                              o.DateChanged,
                              o.CreditCard
                          };

            var totalCount = await filteredARTerms.CountAsync();

            var dbList = await arTerms.ToListAsync();
            var results = new List<GetARTermsForViewDto>();

            foreach (var o in dbList)
            {
                var res = new GetARTermsForViewDto()
                {
                    ARTerms = new ARTermsDto
                    {

                        Terms = o.Terms,
                        COD = o.COD,
                        DaysDue = o.DaysDue,
                        Days = o.Days,
                        DayOfMonth = o.DayOfMonth,
                        Day = o.Day,
                        PrintWaterMark = o.PrintWaterMark,
                        AddedBy = o.AddedBy,
                        DateAdded = o.DateAdded,
                        ChangedBy = o.ChangedBy,
                        DateChanged = o.DateChanged,
                        CreditCard = o.CreditCard
                    }
                };

                results.Add(res);
            }

            return new PagedResultDto<GetARTermsForViewDto>(
                totalCount,
                results
            );

        }
    }
}