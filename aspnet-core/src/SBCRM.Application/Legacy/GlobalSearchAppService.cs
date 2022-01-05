using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using Microsoft.EntityFrameworkCore;
using SBCRM.Authorization;
using SBCRM.Crm;
using SBCRM.Legacy.Dtos;

namespace SBCRM.Legacy
{
    /// <summary>
    /// App service to handle Global search information
    /// </summary>
    [AbpAuthorize(AppPermissions.Pages_GlobalSearch)]
    public class GlobalSearchAppService : SBCRMAppServiceBase, IGlobalSearchAppService
    {
        private readonly IRepository<Customer> _customerRepository;
        private readonly IRepository<Lead> _leadRepository;
        private readonly IRepository<Opportunity> _opportunityRepository;
        private readonly IRepository<Activity, long> _activityRepository;

        /// <summary>
        /// Base constructor
        /// </summary>
        /// <param name="customerRepository"></param>
        /// <param name="leadRepository"></param>
        /// <param name="opportunityRepository"></param>
        /// <param name="activityRepository"></param>
        public GlobalSearchAppService(
            IRepository<Customer> customerRepository,
            IRepository<Lead> leadRepository,
            IRepository<Opportunity> opportunityRepository,
            IRepository<Activity, long> activityRepository
            )
        {
            _customerRepository = customerRepository;
            _leadRepository = leadRepository;
            _opportunityRepository = opportunityRepository;
            _activityRepository = activityRepository;
        }

        /// <summary>
        /// Get all global search
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<PagedResultDto<GetGlobalSearchItemDto>> GetAll(GetGlobalSearchInput input)
        {
            try
            {
                var currentUser = await GetCurrentUserAsync();

                var hasViewAccessToAllLeads = await UserManager.IsGrantedAsync(
                    currentUser.Id, AppPermissions.Pages_Leads_ViewAllLeads__Dynamic);

                var hasViewAccessToAllActivities = await UserManager.IsGrantedAsync(
                    currentUser.Id, AppPermissions.Pages_Activities_View_AssignedUserFilter);

                var hasViewAccessToAllOpportunities = await UserManager.IsGrantedAsync(
                    currentUser.Id, AppPermissions.Pages_Opportunities_ViewAllOpportunities__Dynamic);

                var globalSearchCategory = input.CategoryCode;

                var customersQuery = _customerRepository.GetAll()
                    .Where(x => GlobalSearchCategory.All == globalSearchCategory || GlobalSearchCategory.Account == globalSearchCategory)
                    .Select(x => new GetGlobalSearchItemDto
                    {
                        Id =Convert.ToString(x.Number),
                        Name = Convert.ToString(x.Name),
                        Type = Convert.ToString(L("Customer"))
                    });

                var leadsQuery = _leadRepository.GetAll()
                    .Where(x => GlobalSearchCategory.All == globalSearchCategory || GlobalSearchCategory.Lead == globalSearchCategory)
                    .Include(x => x.Users)
                    .WhereIf(!hasViewAccessToAllLeads, x => x.Users != null && x.Users.Select(y => y.UserId).Contains(currentUser.Id))
                    .Select(x => new GetGlobalSearchItemDto
                    {
                        Id = Convert.ToString(x.Id),
                        Name = Convert.ToString(x.CompanyName),
                        Type = Convert.ToString(L("Lead"))
                    });

                var opportunityQuery = _opportunityRepository.GetAll()
                    .Where(x => GlobalSearchCategory.All == globalSearchCategory || GlobalSearchCategory.Opportunity == globalSearchCategory)
                    .Include(x => x.Users)
                    .WhereIf(!hasViewAccessToAllOpportunities, x => x.Users != null && x.Users.Select(y => y.UserId).Contains(currentUser.Id))
                    .Select(x => new GetGlobalSearchItemDto
                    {
                        Id = Convert.ToString(x.Id),
                        Name = Convert.ToString(x.Name),
                        Type = Convert.ToString(L("Opportunity"))
                    });

                var activityQuery=_activityRepository.GetAll()
                    .Where(x => GlobalSearchCategory.All == globalSearchCategory || GlobalSearchCategory.Activity == globalSearchCategory)
                    .WhereIf(!hasViewAccessToAllActivities, x => x.UserId==currentUser.Id)
                    .Select(x => new GetGlobalSearchItemDto
                    {
                        Id = Convert.ToString(x.Id),
                        Name = Convert.ToString(x.TaskName),
                        Type = Convert.ToString(L("Activity"))
                    });


                var unionQuery = customersQuery
                    .Union(leadsQuery)
                    .Union(opportunityQuery)
                    .Union(activityQuery)
                    ;

                unionQuery = unionQuery.WhereIf(!string.IsNullOrEmpty(input.Filter),
                    x => x.Name.Contains(input.Filter));


                var totalCount = await unionQuery.CountAsync();

                unionQuery = unionQuery
                    .OrderBy(input.Sorting ?? $"{nameof(GetGlobalSearchItemDto.Name)} asc")
                    .PageBy(input);


                var dbList = await unionQuery.ToListAsync();
                var results = new List<GetGlobalSearchItemDto>();
                foreach (var row in dbList)
                {
                    var globalSearchItem = new GetGlobalSearchItemDto();
                    globalSearchItem.Id = row.Id;
                    globalSearchItem.Name = row.Name;
                    globalSearchItem.Type = row.Type;
                    results.Add(globalSearchItem);
                }

                return new PagedResultDto<GetGlobalSearchItemDto>(
                    totalCount,
                    results
                );
            }
            catch (Exception e)
            {
                Logger.Error("Error in GlobalSearchAppService -> ", e);
                throw;
            }
        }
    }
}