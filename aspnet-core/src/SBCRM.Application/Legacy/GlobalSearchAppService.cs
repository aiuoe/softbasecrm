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
        private readonly IRepository<Contact> _contactRepository;

        /// <summary>
        /// Base constructor
        /// </summary>
        /// <param name="customerRepository"></param>
        /// <param name="leadRepository"></param>
        /// <param name="opportunityRepository"></param>
        /// <param name="activityRepository"></param>
        /// <param name="contactRepository"></param>
        public GlobalSearchAppService(
            IRepository<Customer> customerRepository,
            IRepository<Lead> leadRepository,
            IRepository<Opportunity> opportunityRepository,
            IRepository<Activity, long> activityRepository,
            IRepository<Contact> contactRepository
            )
        {
            _customerRepository = customerRepository;
            _leadRepository = leadRepository;
            _opportunityRepository = opportunityRepository;
            _activityRepository = activityRepository;
            _contactRepository = contactRepository;
        }

        /// <summary>
        /// Get all global search
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<PagedResultDto<GetGlobalSearchItemDto>> GetAll(GetGlobalSearchInput input)
        {
            string typeCustomer = Convert.ToString(L("Customer"));
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
                    .WhereIf(!string.IsNullOrWhiteSpace(input.Filter), e => false || e.Name.Contains(input.Filter))
                    .Select(x => new GetGlobalSearchItemDto
                    {
                        Id = Convert.ToString(x.Number),
                        Name = Convert.ToString(x.Name),
                        Type = typeCustomer
                    });

                var contactsQuery = _contactRepository.GetAll()
                    .Where(x => GlobalSearchCategory.All == globalSearchCategory || GlobalSearchCategory.Account == globalSearchCategory)
                    .WhereIf(!string.IsNullOrWhiteSpace(input.Filter), e => false || e.ContactField.Contains(input.Filter))
                    .Select(x => new GetGlobalSearchItemDto
                    {
                        Id = Convert.ToString(x.CustomerNo),
                        Name = Convert.ToString(x.ContactField),
                        Type = typeCustomer
                    }); ;

                var named_contacts = from contacts in contactsQuery
                                     join o1 in _customerRepository.GetAll() on contacts.Id equals o1.Number into j1
                                     from Customer in j1.DefaultIfEmpty()
                                     select new GetGlobalSearchItemDto
                                     {
                                         Id = Convert.ToString(contacts.Id),
                                         Name = Convert.ToString(Customer.Name),
                                         Type = typeCustomer
                                     };

                var customers_contacts = customersQuery
                    .Union(named_contacts);

                var leadsQuery = _leadRepository.GetAll()
                    .Where(x => GlobalSearchCategory.All == globalSearchCategory || GlobalSearchCategory.Lead == globalSearchCategory)
                    .Include(x => x.Users)
                    .WhereIf(!hasViewAccessToAllLeads, x => x.Users != null && x.Users.Select(y => y.UserId).Contains(currentUser.Id))
                    .WhereIf(!string.IsNullOrWhiteSpace(input.Filter), e => false || e.ContactName.Contains(input.Filter) || e.CompanyName.Contains(input.Filter))
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
                    .WhereIf(!string.IsNullOrWhiteSpace(input.Filter), e => false || e.Name.Contains(input.Filter))
                    .Select(x => new GetGlobalSearchItemDto
                    {
                        Id = Convert.ToString(x.Id),
                        Name = Convert.ToString(x.Name),
                        Type = Convert.ToString(L("Opportunity"))
                    });

                var activityQuery = _activityRepository.GetAll()
                    .Where(x => GlobalSearchCategory.All == globalSearchCategory || GlobalSearchCategory.Activity == globalSearchCategory)
                    .WhereIf(!hasViewAccessToAllActivities, x => x.UserId == currentUser.Id);

                var activities = from activity in activityQuery
                                 join o1 in _leadRepository.GetAll() on activity.LeadId equals o1.Id into j1
                                 from lead in j1.DefaultIfEmpty()
                                 join o2 in _customerRepository.GetAll() on activity.CustomerNumber equals o2.Number into j2
                                 from customer in j2.DefaultIfEmpty()
                                 join o3 in _opportunityRepository.GetAll() on activity.OpportunityId equals o3.Id into j3
                                 from opportunity in j3.DefaultIfEmpty()
                                 select new GetGlobalSearchItemDto
                                 {
                                     Id = Convert.ToString(activity.Id),
                                     Name = lead != null
                                     ? Convert.ToString(lead.CompanyName)
                                     : customer != null
                                         ? Convert.ToString(customer.Name)
                                         : opportunity != null && opportunity.CustomerFk != null
                                             ? Convert.ToString(opportunity.CustomerFk.Name)
                                             : string.Empty,
                                     Type = Convert.ToString(L("Activity"))
                                 };

                activities = activities.WhereIf(!string.IsNullOrWhiteSpace(input.Filter), e => false || e.Name.Contains(input.Filter));

                var unionQuery = customers_contacts
                    .Union(leadsQuery)
                    .Union(opportunityQuery)
                    .Union(activities)
                    ;

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