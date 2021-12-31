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
using SBCRM.Legacy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBCRM.Crm
{
    /// <summary>
    /// Service used to get information for the oportunities dashboard
    /// </summary>
    [AbpAuthorize(AppPermissions.Pages_Opportunities)]
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

        public OpportunitiesDashboardAppService(IOpportunitiesExcelExporter opportunitiesExcelExporter,
            IRepository<Opportunity> opportunityRepository,
            IRepository<OpportunityStage, int> lookupOpportunityStageRepository,
            IRepository<LeadSource, int> lookupLeadSourceRepository,
            IRepository<OpportunityType, int> lookupOpportunityTypeRepository,
            IRepository<Customer, int> lookupCustomerRepository,
            IRepository<Contact, int> lookupContactsRepository,
            IAuditEventsService auditEventsService,
            IEntityChangeSetReasonProvider reasonProvider,
            IUnitOfWorkManager unitOfWorkManager)
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
        }

        /// <summary>
        /// Gets all the information for the opportunities dashboard
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public GetOpportunitiesStastsOutput Get(GetOpportunitiesStastsInput input)
        {

            var filteredOpportunities = _opportunityRepository.GetAll()
                      .Include(e => e.OpportunityStageFk)
                      .Include(e => e.LeadSourceFk)
                      .Include(e => e.OpportunityTypeFk)
                      .WhereIf(input.FromDate.HasValue, e => e.CloseDate >= input.FromDate)
                      .WhereIf(input.ToDate.HasValue, e => e.CloseDate <= input.ToDate)
                      .WhereIf(!string.IsNullOrWhiteSpace(input.Account), e => e.CustomerNumber == input.Account)
                      .WhereIf(!string.IsNullOrWhiteSpace(input.Branch), e => e.Branch == input.Branch)
                      .WhereIf(!string.IsNullOrWhiteSpace(input.Department), e => e.Department == input.Department);

            var opportunities = from o in filteredOpportunities
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

                                select new
                                {
                                    o.Name,
                                    o.Amount,
                                    o.Probability,
                                    o.CloseDate,
                                    o.Description,
                                    o.Branch,
                                    o.Department,
                                    Id = o.Id,
                                    OpportunityStageDescription = s1 == null || s1.Description == null ? "" : s1.Description.ToString(),
                                    OpportunityStageColor = s1 != null ? s1.Color : string.Empty,
                                    LeadSourceDescription = s2 == null || s2.Description == null ? "" : s2.Description.ToString(),
                                    OpportunityTypeDescription = s3 == null || s3.Description == null ? "" : s3.Description.ToString(),
                                    CustomerName = s4 == null || s4.Name == null ? "" : s4.Name.ToString(),
                                    CustomerNumber = s4 == null || s4.Number == null ? "" : s4.Number.ToString(),
                                    ContactName = s5 == null || s5.ContactField == null ? "" : s5.ContactField.ToString()
                                };



            var dbList = opportunities.ToList();

            var results = new GetOpportunitiesStastsOutput
            {
                TotalClosedSales = 1000,
                AverageDealSize = 50,
                AverageSales = 20,
                CloseRate = 10
            };

            results.OpportunitiesId = dbList
                .Select(op => op.Id)
                .ToList();

            return results;
        }

        /// <summary>
        /// Gets all branches on the opportunity table as a dropdown
        /// </summary>
        /// <returns></returns>
        public async Task<List<OpportunityBranchLookupTableDto>> GetAllBranchForTableDropdown()
        {
            var opportunities = await _opportunityRepository.GetAll()
                   .ToListAsync();

            var branches = opportunities
                .Select((o, index) => new OpportunityBranchLookupTableDto
                {
                    Id = index,
                    Name = o.Branch
                }).ToList();

            branches.Add(new OpportunityBranchLookupTableDto { Name = "All", Id = null });

            return branches;
        }

        /// <summary>
        /// Gets all the customers for the dropdown
        /// </summary>
        /// <returns></returns>
        public async Task<List<OpportunityCustomerLookupTableDto>> GetAllCustomerForTableDropdown()
        {
            var opportunities = _opportunityRepository.GetAll()
                    .Include(e => e.OpportunityStageFk)
                    .Include(e => e.LeadSourceFk)
                    .Include(e => e.OpportunityTypeFk);

            var accountsOnOpportunity = from o in opportunities
                                        join o4 in _lookupCustomerRepository.GetAll() on o.CustomerNumber equals o4.Number into j4
                                        from s4 in j4.DefaultIfEmpty()
                                        select new OpportunityCustomerLookupTableDto
                                        {
                                            Name = s4 == null || s4.Name == null ? "" : s4.Name.ToString(),
                                            Number = s4 == null || s4.Number == null ? "" : s4.Number.ToString()
                                        };

            var dbList = await accountsOnOpportunity.ToListAsync();

            dbList.Add(new OpportunityCustomerLookupTableDto { Name = "All", Number = null });

            return dbList;
        }

        /// <summary>
        /// Gets all deparments on the opportunity table as a dropdown
        /// </summary>
        /// <returns></returns>
        public async Task<List<OpportunityDepartmentLookupTableDto>> GetAllDepartmentForTableDropdown()
        {

            var opportunities = await _opportunityRepository.GetAll()
                .ToListAsync();

            var departments = opportunities
                .Select((o, index) => new OpportunityDepartmentLookupTableDto
                {
                    Id = index,
                    Name = o.Department
                }).ToList();

            departments.Add(new OpportunityDepartmentLookupTableDto { Name = "All", Id = null });

            return departments;
        }
    }
}
