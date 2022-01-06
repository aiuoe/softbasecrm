using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Collections.Extensions;
using Abp.Domain.Repositories;
using Abp.Domain.Uow;
using Abp.EntityHistory;
using Microsoft.EntityFrameworkCore;
using SBCRM.Auditing;
using SBCRM.Authorization;
using SBCRM.Crm.Dtos;
using SBCRM.Crm.Exporting;
using SBCRM.Dto;
using SBCRM.Legacy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SBCRM.Legacy.Dtos;

namespace SBCRM.Crm
{
    /// <summary>
    /// Service used to get information for the oportunities dashboard
    /// </summary>
    [AbpAuthorize(AppPermissions.Pages_Dashboard)]
    public class OpportunitiesDashboardAppService : SBCRMAppServiceBase, IOpportunitiesDashboardAppService
    {
        private readonly IOpportunitiesExcelExporter _opportunitiesExcelExporter;
        private readonly IRepository<Opportunity> _opportunityRepository;
        private readonly IRepository<OpportunityStage, int> _lookupOpportunityStageRepository;
        private readonly IRepository<LeadSource, int> _lookupLeadSourceRepository;
        private readonly IRepository<OpportunityType, int> _lookupOpportunityTypeRepository;
        private readonly IRepository<Customer, int> _lookupCustomerRepository;
        private readonly IRepository<Contact, int> _lookupContactsRepository;
        private readonly IAuditEventsService _auditEventsService;
        private readonly IEntityChangeSetReasonProvider _reasonProvider;
        private readonly IUnitOfWorkManager _unitOfWorkManager;
        private readonly IRepository<Branch> _lookupBranchRepository;
        private readonly IRepository<Department> _lookupDepartmentRepository;

        /// <summary>
        /// Main Constructor
        /// </summary>
        /// <param name="opportunitiesExcelExporter"></param>
        /// <param name="opportunityRepository"></param>
        /// <param name="lookupOpportunityStageRepository"></param>
        /// <param name="lookupLeadSourceRepository"></param>
        /// <param name="lookupOpportunityTypeRepository"></param>
        /// <param name="lookupCustomerRepository"></param>
        /// <param name="lookupContactsRepository"></param>
        /// <param name="auditEventsService"></param>
        /// <param name="reasonProvider"></param>
        /// <param name="unitOfWorkManager"></param>
        /// <param name="lookupBranchRepository"></param>
        /// <param name="lookupDepartmentRepository"></param>
        public OpportunitiesDashboardAppService(IOpportunitiesExcelExporter opportunitiesExcelExporter,
            IRepository<Opportunity> opportunityRepository,
            IRepository<OpportunityStage, int> lookupOpportunityStageRepository,
            IRepository<LeadSource, int> lookupLeadSourceRepository,
            IRepository<OpportunityType, int> lookupOpportunityTypeRepository,
            IRepository<Customer, int> lookupCustomerRepository,
            IRepository<Contact, int> lookupContactsRepository,
            IAuditEventsService auditEventsService,
            IEntityChangeSetReasonProvider reasonProvider,
            IUnitOfWorkManager unitOfWorkManager,
            IRepository<Branch> lookupBranchRepository,
            IRepository<Department> lookupDepartmentRepository)
        {
            _opportunityRepository = opportunityRepository;
            _opportunitiesExcelExporter = opportunitiesExcelExporter;
            _lookupOpportunityStageRepository = lookupOpportunityStageRepository;
            _lookupLeadSourceRepository = lookupLeadSourceRepository;
            _lookupOpportunityTypeRepository = lookupOpportunityTypeRepository;
            _lookupCustomerRepository = lookupCustomerRepository;
            _lookupContactsRepository = lookupContactsRepository;
            _auditEventsService = auditEventsService;
            _reasonProvider = reasonProvider;
            _unitOfWorkManager = unitOfWorkManager;
            _lookupBranchRepository = lookupBranchRepository;
            _lookupDepartmentRepository = lookupDepartmentRepository;
        }

        /// <summary>
        /// Gets all the information for the opportunities dashboard
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public GetOpportunitiesStastsOutput Get(GetOpportunitiesStastsInput input)
        {

            var opportunities = _opportunityRepository.GetAll()
                      .Include(e => e.OpportunityStageFk)
                      .Include(e => e.LeadSourceFk)
                      .Include(e => e.OpportunityTypeFk)
                      .WhereIf(input.FromDate.HasValue, e => e.CloseDate >= input.FromDate)
                      .WhereIf(input.ToDate.HasValue, e => e.CloseDate <= input.ToDate)
                      .WhereIf((input.Account?.Any() ?? false), e => input.Account.Contains(e.CustomerNumber))
                      .WhereIf((input.Branches?.Any() ?? false), e => input.Branches.Contains(e.Branch))
                      .WhereIf((input.Departments?.Any() ?? false), e => input.Departments.Contains(e.Dept))
                      .Where(o => o.OpportunityStageId == 6 || o.OpportunityStageId == 7);//closed / won, closed / lost

            var dbList = opportunities.ToList();
            var wonOpportunities = dbList.Where(o => o.OpportunityStageId == 6);
            //The total duration is the SUM of all integer values(days) from ‘Closed Date’ -(minus) ‘Create Date’ of the opportunity.
            var averageSalesCycle = dbList.Sum(o => (o.CloseDate - o.CreationTime).Value.TotalDays);

            //close rate
            //Formula: won/(total won + total lost)
            var totalWon = wonOpportunities.Count();//all won
            var closedRate = dbList.Count > 0 ? (totalWon / dbList.Count) : 0;

            // average deal size
            var sumAmount = wonOpportunities.Sum(o => o.Amount);
            var averageDealSize = totalWon > 0 ? (sumAmount / totalWon) : 0;


            var results = new GetOpportunitiesStastsOutput
            {
                TotalClosedSales = (int)sumAmount,
                AverageDealSize = (int)averageDealSize,
                AverageSales = (int)averageSalesCycle,
                CloseRate = closedRate
            };

            return results;
        }

        /// <summary>
        /// Gets all branches on the opportunity table as a dropdown
        /// </summary>
        /// <returns></returns>
        public async Task<List<BranchLookupTableDto>> GetAllBranchForTableDropdown()
        {
            var opportunities = await _lookupBranchRepository.GetAll()
                   .ToListAsync();

            var branches = opportunities
                .Select((o) => new BranchLookupTableDto
                {
                    Number = o.Number,
                    Name = o.Name
                }).ToList();

            return branches;
        }

        /// <summary>
        /// Gets all the customers for the dropdown
        /// </summary>
        /// <returns></returns>
        public async Task<List<OpportunityCustomerLookupTableDto>> GetAllCustomerForTableDropdown()
        {
            var accounts = await _lookupCustomerRepository.GetAll()
                .Select(customer => new OpportunityCustomerLookupTableDto
                {
                    Number = customer.Number,
                    Name = customer == null || customer.Name == null ? "" : customer.Name.ToString()
                }).ToListAsync();

            return accounts;
        }

        /// <summary>
        /// Gets all deparments on the opportunity table as a dropdown
        /// </summary>
        /// <returns></returns>
        public async Task<List<DepartmentLookupTableDto>> GetAllDepartmentForTableDropdown()
        {

            var opportunities = await _lookupDepartmentRepository.GetAll()
                .ToListAsync();

            var departments = opportunities
                .Select((o) => new DepartmentLookupTableDto
                {
                    Branch = o.Branch,
                    Dept = o.Dept,
                    Title = o.Title
                }).ToList();

            return departments;
        }

        /// <summary>
        /// Gets an excel file with the items on the dashboard
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public FileDto GetOpportunitiesDashboardToExcel(GetAllOpportunitiesDashboardForExcelInput input)
        {
            var filteredOpportunities = _opportunityRepository.GetAll()
                                .Include(e => e.OpportunityStageFk)
                                .Include(e => e.LeadSourceFk)
                                .Include(e => e.OpportunityTypeFk)
                                .Include(x => x.Users)
                                    .ThenInclude(x => x.UserFk)
                                .WhereIf(input.FromDate.HasValue, e => e.CloseDate >= input.FromDate)
                                .WhereIf(input.ToDate.HasValue, e => e.CloseDate <= input.ToDate)
                                .WhereIf((input.Account?.Any() ?? false), e => input.Account.Contains(e.CustomerNumber))
                                .WhereIf((input.Branches?.Any() ?? false), e => input.Branches.Contains(e.Branch))
                                .WhereIf((input.Departments?.Any() ?? false), e => input.Departments.Contains(e.Dept));


            var opportunities = (from o in filteredOpportunities
                                 join o1 in _lookupOpportunityStageRepository.GetAll() on o.OpportunityStageId equals o1.Id into j1
                                 from s1 in j1.DefaultIfEmpty()

                                 join o2 in _lookupLeadSourceRepository.GetAll() on o.LeadSourceId equals o2.Id into j2
                                 from s2 in j2.DefaultIfEmpty()

                                 join o3 in _lookupOpportunityTypeRepository.GetAll() on o.OpportunityTypeId equals o3.Id into j3
                                 from s3 in j3.DefaultIfEmpty()

                                 join o4 in _lookupCustomerRepository.GetAll() on o.CustomerNumber equals o4.Number into j4
                                 from s4 in j4.DefaultIfEmpty()

                                 join o5 in _lookupContactsRepository.GetAll() on o.ContactId equals o5.ContactId into j5
                                 from s5 in j5.DefaultIfEmpty()

                                 join o6 in _lookupBranchRepository.GetAll() on o.Branch equals o6.Number into j6
                                 from s6 in j6.DefaultIfEmpty()

                                 join o7 in _lookupDepartmentRepository.GetAll() on o.Dept equals o7.Dept into j7
                                 from s7 in j7.DefaultIfEmpty()

                                 select new OpportunityQueryDto
                                 {
                                     Name = o.Name,
                                     Amount = o.Amount,
                                     Probability = o.Probability,
                                     CloseDate = o.CloseDate,
                                     Description = o.Description,
                                     BranchName = s6 == null || s6.Name == null ? "" : s6.Name,
                                     DepartmentTitle = s7 == null || s7.Title == null ? "" : s7.Title,
                                     Id = o.Id,
                                     OpportunityStageId = s1.Id,
                                     Users = o.Users,
                                     OpportunityStageDescription = s1 == null || s1.Description == null ? "" : s1.Description.ToString(),
                                     OpportunityStageColor = s1 != null ? s1.Color : string.Empty,
                                     LeadSourceDescription = s2 == null || s2.Description == null ? "" : s2.Description.ToString(),
                                     OpportunityTypeDescription = s3 == null || s3.Description == null ? "" : s3.Description.ToString(),
                                     CustomerName = s4 == null || s4.Name == null ? "" : s4.Name.ToString(),
                                     CustomerNumber = s4 == null || s4.Number == null ? "" : s4.Number.ToString(),
                                     ContactName = s5 == null || s5.ContactField == null ? "" : s5.ContactField.ToString(),
                                     CreationTime = o.CreationTime
                                 }).ToList();

            var views = GetOpportunityForViewDtos(opportunities);

            return _opportunitiesExcelExporter.ExportToFile(views);
        }

        /// <summary>
        /// Get list of Opportunity Query Dtos for view
        /// </summary>
        /// <param name="dbList"></param>
        /// <returns></returns>
        private static List<GetOpportunityForViewDto> GetOpportunityForViewDtos(List<OpportunityQueryDto> dbList)
        {
            var results = new List<GetOpportunityForViewDto>();

            foreach (var o in dbList)
            {
                var res = new GetOpportunityForViewDto
                {
                    Opportunity = new OpportunityDto
                    {
                        Name = o.Name,
                        Amount = o.Amount,
                        Probability = o.Probability,
                        CloseDate = o.CloseDate,
                        Description = o.Description,
                        Id = o.Id,
                    },
                    BranchName = o.BranchName,
                    DepartmentTitle = o.DepartmentTitle,
                    OpportunityStageDescription = o.OpportunityStageDescription,
                    OpportunityStageColor = o.OpportunityStageColor,
                    LeadSourceDescription = o.LeadSourceDescription,
                    OpportunityTypeDescription = o.OpportunityTypeDescription,
                    CustomerName = o.CustomerName,
                    CustomerNumber = o.CustomerNumber,
                    ContactName = o.ContactName
                };

                if ((o.Users?.Any() ?? false))
                {
                    var OpportunityUsers = o.Users
                        .Select(x => new OpportunityUserViewDto
                        {
                            OpportunityId = x.Id,
                            UserId = x.UserFk.Id,
                            Name = x.UserFk.Name,
                            SurName = x.UserFk.Surname,
                            FullName = x.UserFk.FullName,
                            ProfilePictureUrl = x.UserFk.ProfilePictureId
                        }).ToList();
                    res.Opportunity.Users = OpportunityUsers;
                    var OpportunityUser = OpportunityUsers.OrderBy(x => x.Name).First();
                    res.FirstUserAssignedName = OpportunityUser.Name;
                    res.FirstUserAssignedSurName = OpportunityUser.SurName;
                    res.FirstUserAssignedFullName = OpportunityUser.FullName;
                    res.FirstUserProfilePictureUrl = OpportunityUser.ProfilePictureUrl;
                    res.FirstUserAssignedId = OpportunityUser.UserId;
                    res.AssignedUsers = OpportunityUsers.Count;
                }

                results.Add(res);
            }

            return results;
        }
    }
}
