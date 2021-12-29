using System.Linq;
using System.Linq.Dynamic.Core;
using Abp.Linq.Extensions;
using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Domain.Repositories;
using SBCRM.Crm.Exporting;
using SBCRM.Crm.Dtos;
using SBCRM.Dto;
using Abp.Application.Services.Dto;
using SBCRM.Authorization;
using Abp.Authorization;
using Microsoft.EntityFrameworkCore;
using SBCRM.Auditing;
using SBCRM.Auditing.Dto;
using SBCRM.Legacy;

namespace SBCRM.Crm
{
    /// <summary>
    /// App service to handle Opportunities information
    /// </summary>
    [AbpAuthorize(AppPermissions.Pages_Opportunities)]
    public class OpportunitiesAppService : SBCRMAppServiceBase, IOpportunitiesAppService
    {
        private readonly IOpportunitiesExcelExporter _opportunitiesExcelExporter;
        private readonly IRepository<Opportunity> _opportunityRepository;
        private readonly IRepository<OpportunityStage, int> _lookupOpportunityStageRepository;
        private readonly IRepository<LeadSource, int> _lookupLeadSourceRepository;
        private readonly IRepository<OpportunityType, int> _lookupOpportunityTypeRepository;
        private readonly IRepository<Customer, int> _lookupCustomerRepository;
        private readonly IRepository<Contact, int> _lookupContactsRepository;
        private readonly IAuditEventsService _auditEventsService;

        /// <summary>
        /// Base constructor
        /// </summary>
        /// <param name="opportunityRepository"></param>
        /// <param name="opportunitiesExcelExporter"></param>
        /// <param name="lookupOpportunityStageRepository"></param>
        /// <param name="lookupLeadSourceRepository"></param>
        /// <param name="lookupOpportunityTypeRepository"></param>
        /// <param name="lookupCustomerRepository"></param>
        /// <param name="lookupContactsRepository"></param>
        /// <param name="auditEventsService"></param>    
        public OpportunitiesAppService(
            IOpportunitiesExcelExporter opportunitiesExcelExporter,
            IRepository<Opportunity> opportunityRepository,
            IRepository<OpportunityStage, int> lookupOpportunityStageRepository, 
            IRepository<LeadSource, int> lookupLeadSourceRepository, 
            IRepository<OpportunityType, int> lookupOpportunityTypeRepository,
            IRepository<Customer, int> lookupCustomerRepository,
            IRepository<Contact, int> lookupContactsRepository,
            IAuditEventsService auditEventsService)
        {
            _opportunityRepository = opportunityRepository;
            _opportunitiesExcelExporter = opportunitiesExcelExporter;
            _lookupOpportunityStageRepository = lookupOpportunityStageRepository;
            _lookupLeadSourceRepository = lookupLeadSourceRepository;
            _lookupOpportunityTypeRepository = lookupOpportunityTypeRepository;
            _lookupCustomerRepository = lookupCustomerRepository;
            _lookupContactsRepository = lookupContactsRepository;
            _auditEventsService = auditEventsService;
        }

        /// <summary>
        /// Get all opportunities
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<PagedResultDto<GetOpportunityForViewDto>> GetAll(GetAllOpportunitiesInput input)
        {
            var filteredOpportunities = _opportunityRepository.GetAll()
                        .Include(e => e.OpportunityStageFk)
                        .Include(e => e.LeadSourceFk)
                        .Include(e => e.OpportunityTypeFk)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.Filter), e => false || e.Name.Contains(input.Filter) || e.Description.Contains(input.Filter) || e.Branch.Contains(input.Filter) || e.Department.Contains(input.Filter))
                        .WhereIf(!string.IsNullOrWhiteSpace(input.NameFilter), e => e.Name.Contains(input.NameFilter))
                        .WhereIf(input.MinAmountFilter != null, e => e.Amount >= input.MinAmountFilter)
                        .WhereIf(input.MaxAmountFilter != null, e => e.Amount <= input.MaxAmountFilter)
                        .WhereIf(input.MinProbabilityFilter != null, e => e.Probability >= input.MinProbabilityFilter)
                        .WhereIf(input.MaxProbabilityFilter != null, e => e.Probability <= input.MaxProbabilityFilter)
                        .WhereIf(input.MinCloseDateFilter != null, e => e.CloseDate >= input.MinCloseDateFilter)
                        .WhereIf(input.MaxCloseDateFilter != null, e => e.CloseDate <= input.MaxCloseDateFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.DescriptionFilter), e => e.Description == input.DescriptionFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.BranchFilter), e => e.Branch == input.BranchFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.DepartmentFilter), e => e.Department == input.DepartmentFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.OpportunityStageDescriptionFilter), e => e.OpportunityStageFk != null && e.OpportunityStageFk.Description == input.OpportunityStageDescriptionFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.LeadSourceDescriptionFilter), e => e.LeadSourceFk != null && e.LeadSourceFk.Description == input.LeadSourceDescriptionFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.OpportunityTypeDescriptionFilter), e => e.OpportunityTypeFk != null && e.OpportunityTypeFk.Description == input.OpportunityTypeDescriptionFilter)
                        .WhereIf(input.OpportunityStageId.HasValue, x => input.OpportunityStageId == x.OpportunityStageFk.Id);

            IQueryable<Opportunity> pagedAndFilteredOpportunities;

            if (input.Sorting != null)
                pagedAndFilteredOpportunities = filteredOpportunities
                .OrderBy(input.Sorting)
                .PageBy(input);
            else
                pagedAndFilteredOpportunities = filteredOpportunities
                .OrderByDescending(o => o.CloseDate)
                .ThenBy(o => o.Name)
                .ThenBy(o => o.Branch)
                .ThenBy(o => o.Department)
                .PageBy(input);

            pagedAndFilteredOpportunities = filteredOpportunities
                .OrderBy(input.Sorting ?? "id asc")
                .PageBy(input);

            var opportunities = from o in pagedAndFilteredOpportunities
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

            var totalCount = await filteredOpportunities.CountAsync();

            var dbList = await opportunities.ToListAsync();
            var results = new List<GetOpportunityForViewDto>();

            foreach (var o in dbList)
            {
                var res = new GetOpportunityForViewDto()
                {
                    Opportunity = new OpportunityDto
                    {
                        Name = o.Name,
                        Amount = o.Amount,
                        Probability = o.Probability,
                        CloseDate = o.CloseDate,
                        Description = o.Description,
                        Branch = o.Branch,
                        Department = o.Department,
                        Id = o.Id,
                    },
                    OpportunityStageDescription = o.OpportunityStageDescription,
                    OpportunityStageColor = o.OpportunityStageColor,
                    LeadSourceDescription = o.LeadSourceDescription,
                    OpportunityTypeDescription = o.OpportunityTypeDescription,
                    CustomerName = o.CustomerName,
                    CustomerNumber = o.CustomerNumber,
                    ContactName = o.ContactName
                };

                results.Add(res);
            }

            return new PagedResultDto<GetOpportunityForViewDto>(
                totalCount,
                results
            );
        }

        /// <summary>
        /// Get opportunity for view mode by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<GetOpportunityForViewDto> GetOpportunityForView(int id)
        {
            var opportunity = await _opportunityRepository.GetAsync(id);

            var output = new GetOpportunityForViewDto { Opportunity = ObjectMapper.Map<OpportunityDto>(opportunity) };

            if (output.Opportunity.OpportunityStageId != null)
            {
                var _lookupOpportunityStage = await _lookupOpportunityStageRepository.FirstOrDefaultAsync((int)output.Opportunity.OpportunityStageId);
                output.OpportunityStageDescription = _lookupOpportunityStage?.Description?.ToString();
            }

            if (output.Opportunity.LeadSourceId != null)
            {
                var _lookupLeadSource = await _lookupLeadSourceRepository.FirstOrDefaultAsync((int)output.Opportunity.LeadSourceId);
                output.LeadSourceDescription = _lookupLeadSource?.Description?.ToString();
            }

            if (output.Opportunity.OpportunityTypeId != null)
            {
                var _lookupOpportunityType = await _lookupOpportunityTypeRepository.FirstOrDefaultAsync((int)output.Opportunity.OpportunityTypeId);
                output.OpportunityTypeDescription = _lookupOpportunityType?.Description?.ToString();
            }

            if (output.Opportunity.CustomerNumber != null)
            {
                var _lookupCustomer = await _lookupCustomerRepository.FirstOrDefaultAsync(e => e.Number == output.Opportunity.CustomerNumber);
                output.CustomerName = _lookupCustomer?.Name?.ToString();
            }

            if (output.Opportunity.CustomerNumber != null)
            {
                var _lookupCustomer = await _lookupCustomerRepository.FirstOrDefaultAsync(e => e.Number == output.Opportunity.CustomerNumber);
                output.CustomerNumber = _lookupCustomer?.Number?.ToString();
            }

            if (output.Opportunity.ContactId != null)
            {
                var _lookupContact = await _lookupContactsRepository.FirstOrDefaultAsync((int)output.Opportunity.ContactId);
                output.ContactName = _lookupContact?.ContactField?.ToString();
            }

            return output;
        }

        /// <summary>
        /// Get opportunity for edition mode
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [AbpAuthorize(AppPermissions.Pages_Opportunities_Edit)]
        public async Task<GetOpportunityForEditOutput> GetOpportunityForEdit(EntityDto input)
        {
            var opportunity = await _opportunityRepository.FirstOrDefaultAsync(input.Id);

            var output = new GetOpportunityForEditOutput { Opportunity = ObjectMapper.Map<CreateOrEditOpportunityDto>(opportunity) };

            if (output.Opportunity.OpportunityStageId != null)
            {
                var _lookupOpportunityStage = await _lookupOpportunityStageRepository.FirstOrDefaultAsync((int)output.Opportunity.OpportunityStageId);
                output.OpportunityStageDescription = _lookupOpportunityStage?.Description?.ToString();
            }

            if (output.Opportunity.LeadSourceId != null)
            {
                var _lookupLeadSource = await _lookupLeadSourceRepository.FirstOrDefaultAsync((int)output.Opportunity.LeadSourceId);
                output.LeadSourceDescription = _lookupLeadSource?.Description?.ToString();
            }

            if (output.Opportunity.OpportunityTypeId != null)
            {
                var _lookupOpportunityType = await _lookupOpportunityTypeRepository.FirstOrDefaultAsync((int)output.Opportunity.OpportunityTypeId);
                output.OpportunityTypeDescription = _lookupOpportunityType?.Description?.ToString();
            }

            if (output.Opportunity.CustomerNumber != null)
            {
                var _lookupCustomer = await _lookupCustomerRepository.FirstOrDefaultAsync(e => e.Number == output.Opportunity.CustomerNumber);
                output.CustomerName = _lookupCustomer?.Name?.ToString();
            }

            if (output.Opportunity.CustomerNumber != null)
            {
                var _lookupCustomer = await _lookupCustomerRepository.FirstOrDefaultAsync(e => e.Number == output.Opportunity.CustomerNumber);
                output.CustomerNumber = _lookupCustomer?.Number?.ToString();
            }

            if (output.Opportunity.ContactId != null)
            {        
                var _lookupContact = await _lookupContactsRepository.FirstOrDefaultAsync(e => e.ContactId == output.Opportunity.ContactId);
                output.ContactName = _lookupContact?.ContactField?.ToString();
            }

            return output;
        }

        /// <summary>
        /// Create or edit opportunity
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task CreateOrEdit(CreateOrEditOpportunityDto input)
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

        /// <summary>
        /// Create opportunity
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [AbpAuthorize(AppPermissions.Pages_Opportunities_Create)]
        protected virtual async Task Create(CreateOrEditOpportunityDto input)
        {
            var opportunity = ObjectMapper.Map<Opportunity>(input);

            if (AbpSession.TenantId != null)
            {
                opportunity.TenantId = AbpSession.TenantId;
            }

            await _opportunityRepository.InsertAsync(opportunity);

            await _auditEventsService.AddEvent(AuditEventDto.ForCreate(
                entityType: typeof(Customer),
                entityId: opportunity.CustomerNumber,
                message: $"Added opportunity, {opportunity.Name}")
            );

        }

        /// <summary>
        /// Update opportunity
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [AbpAuthorize(AppPermissions.Pages_Opportunities_Edit)]
        protected virtual async Task Update(CreateOrEditOpportunityDto input)
        {
            var opportunity = await _opportunityRepository.FirstOrDefaultAsync((int)input.Id);
            ObjectMapper.Map(input, opportunity);
        }

        /// <summary>
        /// Get Opportunities for excel export
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [AbpAuthorize(AppPermissions.Pages_Opportunities_Delete)]
        public async Task Delete(EntityDto input)
        {
            await _opportunityRepository.DeleteAsync(input.Id);
        }

        public async Task<FileDto> GetOpportunitiesToExcel(GetAllOpportunitiesForExcelInput input)
        {
            var filteredOpportunities = _opportunityRepository.GetAll()
                        .Include(e => e.OpportunityStageFk)
                        .Include(e => e.LeadSourceFk)
                        .Include(e => e.OpportunityTypeFk)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.Filter), e => false || e.Name.Contains(input.Filter) || e.Description.Contains(input.Filter) || e.Branch.Contains(input.Filter) || e.Department.Contains(input.Filter))
                        .WhereIf(!string.IsNullOrWhiteSpace(input.NameFilter), e => e.Name.Contains(input.NameFilter))
                        .WhereIf(input.MinAmountFilter != null, e => e.Amount >= input.MinAmountFilter)
                        .WhereIf(input.MaxAmountFilter != null, e => e.Amount <= input.MaxAmountFilter)
                        .WhereIf(input.MinProbabilityFilter != null, e => e.Probability >= input.MinProbabilityFilter)
                        .WhereIf(input.MaxProbabilityFilter != null, e => e.Probability <= input.MaxProbabilityFilter)
                        .WhereIf(input.MinCloseDateFilter != null, e => e.CloseDate >= input.MinCloseDateFilter)
                        .WhereIf(input.MaxCloseDateFilter != null, e => e.CloseDate <= input.MaxCloseDateFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.DescriptionFilter), e => e.Description == input.DescriptionFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.BranchFilter), e => e.Branch == input.BranchFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.DepartmentFilter), e => e.Department == input.DepartmentFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.OpportunityStageDescriptionFilter), e => e.OpportunityStageFk != null && e.OpportunityStageFk.Description == input.OpportunityStageDescriptionFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.LeadSourceDescriptionFilter), e => e.LeadSourceFk != null && e.LeadSourceFk.Description == input.LeadSourceDescriptionFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.OpportunityTypeDescriptionFilter), e => e.OpportunityTypeFk != null && e.OpportunityTypeFk.Description == input.OpportunityTypeDescriptionFilter)
                        .WhereIf(input.OpportunityStageId.HasValue, x => input.OpportunityStageId == x.OpportunityStageFk.Id);

            var query = (from o in filteredOpportunities
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

                         select new GetOpportunityForViewDto()
                         {
                             Opportunity = new OpportunityDto
                             {
                                 Name = o.Name,
                                 Amount = o.Amount,
                                 Probability = o.Probability,
                                 CloseDate = o.CloseDate,
                                 Description = o.Description,
                                 Branch = o.Branch,
                                 Department = o.Department,
                                 Id = o.Id
                             },
                             OpportunityStageDescription = s1 == null || s1.Description == null ? "" : s1.Description.ToString(),
                             LeadSourceDescription = s2 == null || s2.Description == null ? "" : s2.Description.ToString(),
                             OpportunityTypeDescription = s3 == null || s3.Description == null ? "" : s3.Description.ToString(),
                             CustomerName = s4 == null || s4.Name == null ? "" : s4.Name.ToString(),
                             CustomerNumber = s4 == null || s4.Number == null ? "" : s4.Number.ToString(),
                             ContactName = s5 == null || s5.ContactField == null ? "" : s5.ContactField.ToString()
                         });

            var opportunityListDtos = await query.ToListAsync();

            return _opportunitiesExcelExporter.ExportToFile(opportunityListDtos);
        }

        /// <summary>
        /// Get Opportunity Stage lookup
        /// </summary>
        /// <returns></returns>
        [AbpAuthorize(AppPermissions.Pages_Opportunities)]
        public async Task<List<OpportunityOpportunityStageLookupTableDto>> GetAllOpportunityStageForTableDropdown()
        {
            return await _lookupOpportunityStageRepository.GetAll()
                .Select(opportunityStage => new OpportunityOpportunityStageLookupTableDto
                {
                    Id = opportunityStage.Id,
                    DisplayName = opportunityStage == null || opportunityStage.Description == null ? "" : opportunityStage.Description.ToString()
                }).ToListAsync();
        }

        /// <summary>
        /// Get Lead source lookup
        /// </summary>
        /// <returns></returns>
        [AbpAuthorize(AppPermissions.Pages_Opportunities)]
        public async Task<List<OpportunityLeadSourceLookupTableDto>> GetAllLeadSourceForTableDropdown()
        {
            return await _lookupLeadSourceRepository.GetAll()
                .Select(leadSource => new OpportunityLeadSourceLookupTableDto
                {
                    Id = leadSource.Id,
                    DisplayName = leadSource == null || leadSource.Description == null ? "" : leadSource.Description.ToString()
                }).ToListAsync();
        }

        /// <summary>
        /// Get Opportunity type lookup
        /// </summary>
        /// <returns></returns>
        [AbpAuthorize(AppPermissions.Pages_Opportunities)]
        public async Task<List<OpportunityOpportunityTypeLookupTableDto>> GetAllOpportunityTypeForTableDropdown()
        {
            return await _lookupOpportunityTypeRepository.GetAll()
                .Select(opportunityType => new OpportunityOpportunityTypeLookupTableDto
                {
                    Id = opportunityType.Id,
                    DisplayName = opportunityType == null || opportunityType.Description == null ? "" : opportunityType.Description.ToString()
                }).ToListAsync();
        }

        /// <summary>
        /// Get Customer lookup
        /// </summary>
        /// <returns></returns>
        [AbpAuthorize(AppPermissions.Pages_Opportunities)]
        public async Task<List<OpportunityCustomerLookupTableDto>> GetAllCustomerForTableDropdown()
        {
            return await _lookupCustomerRepository.GetAll()
                .Select(customer => new OpportunityCustomerLookupTableDto
                {
                    Number = customer.Number,
                    Name = customer == null || customer.Name == null ? "" : customer.Name.ToString()
                }).ToListAsync();
        }

        /// <summary>
        /// Get Contacts lookup
        /// </summary>
        /// <returns></returns>
        [AbpAuthorize(AppPermissions.Pages_Opportunities)]
        public async Task<List<OpportunityContactsLookupTableDto>> GetAllContactsForTableDropdown()
        {
            return await _lookupContactsRepository.GetAll()
                .Select(contact => new OpportunityContactsLookupTableDto
                {
                    Id = contact.ContactId,
                    ContactName = contact == null || contact.ContactField == null ? "" : contact.ContactField.ToString()
                }).ToListAsync();
        }

        /// <summary>
        /// Get Contacts specific to costumer lookup
        /// </summary>
        /// <returns></returns>
        public async Task<List<OpportunityContactsLookupTableDto>> GetAllContactsForTableDropdownCustomerSpecific(string customerNumber)
        {
            return await _lookupContactsRepository.GetAll().WhereIf(!string.IsNullOrWhiteSpace(customerNumber), e => e.CustomerNo == customerNumber)
                .Select(contact => new OpportunityContactsLookupTableDto
                {
                    Id = contact.ContactId,
                    ContactName = contact == null || contact.ContactField == null ? "" : contact.ContactField.ToString()
                }).ToListAsync();
        }

        /// <summary>
        /// Get al events
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [AbpAuthorize(AppPermissions.Pages_Opportunities_View_Events)]
        public async Task<PagedResultDto<EntityChangeListDto>> GetEntityTypeChanges(GetEntityTypeChangeInput input)
        {
            input.EntityTypeFullName = typeof(Opportunity).FullName;
            return await _auditEventsService.GetEntityTypeChanges(input);
        }
    }
}