using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Entities;
using Abp.Domain.Repositories;
using Abp.Domain.Uow;
using Abp.EntityHistory;
using Abp.Linq.Extensions;
using Castle.Components.DictionaryAdapter;
using Microsoft.EntityFrameworkCore;
using SBCRM.Auditing;
using SBCRM.Auditing.Dto;
using SBCRM.Authorization;
using SBCRM.Authorization.Users;
using SBCRM.Common;
using SBCRM.Crm.Dtos;
using SBCRM.Crm.Exporting;
using SBCRM.Dto;
using SBCRM.Legacy;
using SBCRM.Legacy.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;

namespace SBCRM.Crm
{
    /// <summary>
    /// App service to handle Opportunities information
    /// </summary>
    [AbpAuthorize(AppPermissions.Pages_Opportunities)]
    public class OpportunitiesAppService : SBCRMAppServiceBase, IOpportunitiesAppService
    {
        private readonly IAuditEventsService _auditEventsService;
        private readonly IEntityChangeSetReasonProvider _reasonProvider;
        private readonly IOpportunitiesExcelExporter _opportunitiesExcelExporter;
        private readonly IOpportunityAutomateAssignmentService _opportunityAutomateAssignment;
        private readonly IUnitOfWorkManager _unitOfWorkManager;
        private readonly IRepository<Contact, int> _lookupContactsRepository;
        private readonly IRepository<Customer, int> _lookupCustomerRepository;
        private readonly IRepository<LeadSource, int> _lookupLeadSourceRepository;
        private readonly IRepository<Opportunity> _opportunityRepository;
        private readonly IRepository<OpportunityStage, int> _lookupOpportunityStageRepository;
        private readonly IRepository<OpportunityType, int> _lookupOpportunityTypeRepository;
        private readonly IRepository<OpportunityUser> _opportunityUserRepository;
        private readonly IRepository<User, long> _lookupUserRepository;
        private readonly IRepository<Branch> _lookupBranchRepository;
        private readonly IRepository<Department> _lookupDepartmentRepository;

        private readonly string _assignedUserSortKey = "users.userFk.name";

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
        /// <param name="reasonProvider"></param>
        /// <param name="unitOfWorkManager"></param>
        /// <param name="lookupUserRepository"></param>
        /// <param name="opportunityUserRepository"></param>
        /// <param name="lookupBranchRepository"></param>
        /// <param name="lookupDepartmentRepository"></param>
        /// <param name="opportunityAutomateAssignment"></param>
        public OpportunitiesAppService(
            IOpportunitiesExcelExporter opportunitiesExcelExporter,
            IRepository<Opportunity> opportunityRepository,
            IRepository<OpportunityStage, int> lookupOpportunityStageRepository,
            IRepository<LeadSource, int> lookupLeadSourceRepository,
            IRepository<OpportunityType, int> lookupOpportunityTypeRepository,
            IRepository<Customer, int> lookupCustomerRepository,
            IRepository<Contact, int> lookupContactsRepository,
            IAuditEventsService auditEventsService,
            IEntityChangeSetReasonProvider reasonProvider,
            IUnitOfWorkManager unitOfWorkManager,
            IRepository<User, long> lookupUserRepository,
            IRepository<OpportunityUser> opportunityUserRepository,
            IRepository<Branch> lookupBranchRepository,
            IRepository<Department> lookupDepartmentRepository,
            IOpportunityAutomateAssignmentService opportunityAutomateAssignment)
        {
            _auditEventsService = auditEventsService;
            _lookupUserRepository = lookupUserRepository;
            _lookupContactsRepository = lookupContactsRepository;
            _lookupCustomerRepository = lookupCustomerRepository;
            _lookupLeadSourceRepository = lookupLeadSourceRepository;
            _lookupOpportunityStageRepository = lookupOpportunityStageRepository;
            _lookupOpportunityTypeRepository = lookupOpportunityTypeRepository;
            _opportunitiesExcelExporter = opportunitiesExcelExporter;
            _opportunityRepository = opportunityRepository;
            _opportunityUserRepository = opportunityUserRepository;
            _reasonProvider = reasonProvider;
            _unitOfWorkManager = unitOfWorkManager;
            _lookupBranchRepository = lookupBranchRepository;
            _lookupDepartmentRepository = lookupDepartmentRepository;
            _opportunityAutomateAssignment = opportunityAutomateAssignment;
        }

        /// <summary>
        /// Get the dynamic permission based on the current user.
        /// The user will be shown all the leads if he has permission for it
        /// </summary>
        /// <returns></returns>
        public bool CanSeeAllOpportunities()
        {
            User currentUser = GetCurrentUser();
            return UserManager.IsGranted(
                currentUser.Id, AppPermissions.Pages_Opportunities_ViewAllOpportunities__Dynamic);
        }

        /// <summary>
        /// Get the static permission based on the current user.
        /// </summary>
        /// <returns></returns>
        public bool HasStaticAccessToAddOpportunity(long userId)
        {
            return UserManager.IsGranted(
                userId, AppPermissions.Pages_Customer_Add_Opportunity);
        }

        /// <summary>
        /// Get the dynamic permission based on the current user.
        /// </summary>
        /// <returns></returns>
        public bool HasDynamicAccessToAddOpportunity(long userId)
        {
            return UserManager.IsGranted(
                userId, AppPermissions.Pages_Customer_Add_Opportunity__Dynamic);
        }

        /// <summary>
        /// Get the id of the current user.
        /// </summary>
        /// <returns></returns>
        public long GetCurrentUserId()
        {
            User currentUser = GetCurrentUser();
            return currentUser.Id;
        }

        /// <summary>
        /// Get all opportunities
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<PagedResultDto<GetOpportunityForViewDto>> GetAll(GetAllOpportunitiesInput input)
        {
            try
            {
                var filteredOpportunities = _opportunityRepository.GetAll()
                        .Include(e => e.OpportunityStageFk)
                        .Include(e => e.LeadSourceFk)
                        .Include(e => e.OpportunityTypeFk)
                        .Include(e => e.DepartmentFk)
                        .Include(x => x.Users)
                        .ThenInclude(x => x.UserFk)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.NameFilter), e => e.Name.Contains(input.NameFilter))
                        .WhereIf(input.MinAmountFilter != null, e => e.Amount >= input.MinAmountFilter)
                        .WhereIf(input.MaxAmountFilter != null, e => e.Amount <= input.MaxAmountFilter)
                        .WhereIf(input.MinProbabilityFilter != null, e => e.Probability >= input.MinProbabilityFilter)
                        .WhereIf(input.MaxProbabilityFilter != null, e => e.Probability <= input.MaxProbabilityFilter)
                        .WhereIf(input.MinCloseDateFilter != null, e => e.CloseDate >= input.MinCloseDateFilter)
                        .WhereIf(input.MaxCloseDateFilter != null, e => e.CloseDate <= input.MaxCloseDateFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.DescriptionFilter), e => e.Description == input.DescriptionFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.OpportunityStageDescriptionFilter), e => e.OpportunityStageFk != null && e.OpportunityStageFk.Description == input.OpportunityStageDescriptionFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.LeadSourceDescriptionFilter), e => e.LeadSourceFk != null && e.LeadSourceFk.Description == input.LeadSourceDescriptionFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.OpportunityTypeDescriptionFilter), e => e.OpportunityTypeFk != null && e.OpportunityTypeFk.Description == input.OpportunityTypeDescriptionFilter)
                        .WhereIf(input.OpportunityStageId.HasValue, x => input.OpportunityStageId == x.OpportunityStageFk.Id)
                        .WhereIf(!CanSeeAllOpportunities(), x => x.Users != null && x.Users.Select(y => y.UserId).Contains(GetCurrentUserId()))
                        .WhereIf(input.UserIds.Any() && !input.UserIds.Contains(-1), x => x.Users.Any(y => input.UserIds.Contains(y.UserId)))
                        .WhereIf(input.UserIds.Contains(-1), x => !x.Users.Any())
                        .Select(x => new
                        {
                            x.Id,
                            x.Name,
                            x.Amount,
                            x.CloseDate,
                            x.Description,
                            x.Probability,
                            x.Users,
                            x.CustomerNumber,
                            x.ContactId,
                            x.Dept,
                            x.Branch,
                            x.OpportunityStageId,
                            x.LeadSourceId,
                            x.OpportunityTypeId,
                            OpportunityTypeDescription = x.OpportunityTypeFk.Description,
                            LeadSourceDescription = x.LeadSourceFk.Description,
                            OpportunityStageColor = x.OpportunityStageFk.Color,
                            ContactName = x.ContactFk.ContactField,
                            DepartmentTitle = x.DepartmentFk.Title,
                            BranchName = x.DepartmentFk.BranchFk.Name,
                            OpportunityStageDescription = x.OpportunityStageFk.Description,
                            CustomerName = x.CustomerFk.Name,
                        });

                bool isAssignedUserSorting = input.Sorting != null && input.Sorting.StartsWith(_assignedUserSortKey);

                IQueryable<OpportunityQueryDto> opportunities;

                if (isAssignedUserSorting)
                {
                    input.Sorting = input.Sorting.Replace(_assignedUserSortKey, $"{nameof(OpportunityQueryDto.FirstUserAssignedName)}");
                    opportunities = from o in filteredOpportunities
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

                                    join o6 in _lookupDepartmentRepository.GetAll() on new
                                    {
                                        Key1 = o.Dept,
                                        Key2 = o.Branch
                                    }
                                                                                        equals
                                                                                        new
                                                                                        {
                                                                                            Key1 = o6.Dept,
                                                                                            Key2 = o6.Branch
                                                                                        }
                                                                                        into j6
                                    from s6 in j6.DefaultIfEmpty()

                                    join o7 in _lookupBranchRepository.GetAll() on o.Branch equals o7.Number into j7
                                    from s7 in j7.DefaultIfEmpty()

                                    select new OpportunityQueryDto
                                    {
                                        Name = o.Name,
                                        Amount = o.Amount,
                                        Probability = o.Probability,
                                        CloseDate = o.CloseDate,
                                        Description = o.Description,
                                        Id = o.Id,
                                        Users = ObjectMapper.Map<List<OpportunityUserDto>>(o.Users),
                                        OpportunityStageDescription = s1 == null || s1.Description == null ? "" : s1.Description,
                                        OpportunityStageColor = s1 != null ? s1.Color : string.Empty,
                                        LeadSourceDescription = s2 == null || s2.Description == null ? "" : s2.Description,
                                        OpportunityTypeDescription = s3 == null || s3.Description == null ? "" : s3.Description,
                                        CustomerName = s4 == null || s4.Name == null ? "" : s4.Name,
                                        CustomerNumber = s4 == null || s4.Number == null ? "" : s4.Number,
                                        ContactName = s5 == null || s5.ContactField == null ? "" : s5.ContactField,
                                        DepartmentTitle = s6 == null | s6.Title == null ? "" : s6.Title,
                                        BranchName = s7 == null | s7.Name == null ? "" : s7.Name.ToString(),
                                        FirstUserAssignedName = (from user in _opportunityUserRepository.GetAll().Include(x => x.UserFk)
                                                                 where user.OpportunityId == o.Id
                                                                 select user.UserFk.Name).FirstOrDefault()
                                    };

                    opportunities = opportunities
                            .OrderBy(input.Sorting)
                            .PageBy(input);
                }
                else
                {
                    if (input.Sorting != null)
                        opportunities = from o in (filteredOpportunities
                                .OrderBy(input.Sorting)
                                .PageBy(input))
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

                                        join o6 in _lookupDepartmentRepository.GetAll() on new
                                        {
                                            Key1 = o.Dept,
                                            Key2 = o.Branch
                                        }
                                        equals
                                        new
                                        {
                                            Key1 = o6.Dept,
                                            Key2 = o6.Branch
                                        }
                                        into j6
                                        from s6 in j6.DefaultIfEmpty()

                                        join o7 in _lookupBranchRepository.GetAll() on o.Branch equals o7.Number into j7
                                        from s7 in j7.DefaultIfEmpty()

                                        select new OpportunityQueryDto
                                        {
                                            Name = o.Name,
                                            Amount = o.Amount,
                                            Probability = o.Probability,
                                            CloseDate = o.CloseDate,
                                            Description = o.Description,
                                            Id = o.Id,
                                            Users = ObjectMapper.Map<List<OpportunityUserDto>>(o.Users),
                                            OpportunityStageDescription = s1 == null || s1.Description == null ? "" : s1.Description,
                                            OpportunityStageColor = s1 != null ? s1.Color : string.Empty,
                                            LeadSourceDescription = s2 == null || s2.Description == null ? "" : s2.Description,
                                            OpportunityTypeDescription = s3 == null || s3.Description == null ? "" : s3.Description,
                                            CustomerName = s4 == null || s4.Name == null ? "" : s4.Name,
                                            CustomerNumber = s4 == null || s4.Number == null ? "" : s4.Number,
                                            ContactName = s5 == null || s5.ContactField == null ? "" : s5.ContactField,
                                            DepartmentTitle = s6 == null || s6.Title == null ? "" : s6.Title,
                                            BranchName = s7 == null || s7.Name == null ? "" : s7.Name.ToString()
                                        };
                    else
                        opportunities = from o in (filteredOpportunities
                                .OrderByDescending(o => o.CloseDate)
                                .ThenBy(o => o.Name)
                                .ThenBy(o => o.DepartmentTitle)
                                .ThenBy(o => o.BranchName)
                                .PageBy(input))
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

                                        join o6 in _lookupDepartmentRepository.GetAll() on new
                                        {
                                            Key1 = o.Dept,
                                            Key2 = o.Branch
                                        }
                                        equals
                                        new
                                        {
                                            Key1 = o6.Dept,
                                            Key2 = o6.Branch
                                        }
                                        into j6
                                        from s6 in j6.DefaultIfEmpty()

                                        join o7 in _lookupBranchRepository.GetAll() on o.Branch equals o7.Number into j7
                                        from s7 in j7.DefaultIfEmpty()

                                        select new OpportunityQueryDto
                                        {
                                            Name = o.Name,
                                            Amount = o.Amount,
                                            Probability = o.Probability,
                                            CloseDate = o.CloseDate,
                                            Description = o.Description,
                                            Id = o.Id,
                                            Users = ObjectMapper.Map<List<OpportunityUserDto>>(o.Users),
                                            OpportunityStageDescription = s1 == null || s1.Description == null ? "" : s1.Description,
                                            OpportunityStageColor = s1 != null ? s1.Color : string.Empty,
                                            LeadSourceDescription = s2 == null || s2.Description == null ? "" : s2.Description,
                                            OpportunityTypeDescription = s3 == null || s3.Description == null ? "" : s3.Description,
                                            CustomerName = s4 == null || s4.Name == null ? "" : s4.Name,
                                            CustomerNumber = s4 == null || s4.Number == null ? "" : s4.Number,
                                            ContactName = s5 == null || s5.ContactField == null ? "" : s5.ContactField,
                                            DepartmentTitle = s6 == null || s6.Title == null ? "" : s6.Title,
                                            BranchName = s7 == null || s7.Name == null ? "" : s7.Name.ToString()
                                        };
                }

                int totalCount = await filteredOpportunities.CountAsync();

                List<OpportunityQueryDto> dbList = await opportunities.ToListAsync();
                List<GetOpportunityForViewDto> results = GetOpportunityForViewDtos(dbList);

                foreach (GetOpportunityForViewDto result in results)
                {
                    var isUserAssignedToOpportunity = VerifyUserIsAssigneOpportunity(result);
                    result.CanViewActivityWidget = HasAccessActivityWidget(isUserAssignedToOpportunity);
                    result.CanCreateActivity = HasAccessCreateActivity(isUserAssignedToOpportunity);
                    result.CanViewScheduleMeetingOption = HasAccessToScheduleMeeting(isUserAssignedToOpportunity);
                    result.CanViewScheduleCallOption = HasAccessToScheduleCall(isUserAssignedToOpportunity);
                    result.CanViewEmailReminderOption = HasAccessToEmailReminder(isUserAssignedToOpportunity);
                    result.CanViewToDoReminderOption = HasAccessToDoReminder(isUserAssignedToOpportunity);
                    result.CanEditActivity = HasAccessEditActivity(isUserAssignedToOpportunity);
                    result.CanAssignAnyUserInActivity = CanAssignAnyUserWhenCreatingOrUpdatingAnActivity();
                }

                return new PagedResultDto<GetOpportunityForViewDto>(
                    totalCount,
                    results
                );
            }
            catch (Exception e)
            {
                Logger.Error("Error in OpportunitiesAppService -> ", e);
                throw;
            }
        }

        /// <summary>
        /// Get list of Opportunity Query Dtos for view
        /// </summary>
        /// <param name="dbList"></param>
        /// <returns></returns>
        private static List<GetOpportunityForViewDto> GetOpportunityForViewDtos(List<OpportunityQueryDto> dbList)
        {
            List<GetOpportunityForViewDto> results = new List<GetOpportunityForViewDto>();

            foreach (OpportunityQueryDto o in dbList)
            {
                GetOpportunityForViewDto res = new GetOpportunityForViewDto
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
                    OpportunityStageDescription = o.OpportunityStageDescription,
                    OpportunityStageColor = o.OpportunityStageColor,
                    LeadSourceDescription = o.LeadSourceDescription,
                    OpportunityTypeDescription = o.OpportunityTypeDescription,
                    CustomerName = o.CustomerName,
                    CustomerNumber = o.CustomerNumber,
                    ContactName = o.ContactName,
                    BranchName = o.BranchName,
                    DepartmentTitle = o.DepartmentTitle
                };

                if (o.Users.Any())
                {
                    List<OpportunityUserViewDto> OpportunityUsers = o.Users
                        .Select(x => new OpportunityUserViewDto
                        {
                            OpportunityId = x.Id,
                            UserId = x.UserId,
                            Name = x.UserFk.Name,
                            SurName = x.UserFk.Surname,
                            FullName = x.UserFk.FullName,
                            ProfilePictureUrl = x.UserFk.ProfilePictureId
                        }).ToList();
                    res.Opportunity.Users = OpportunityUsers;
                    OpportunityUserViewDto OpportunityUser = OpportunityUsers.OrderBy(x => x.Name).First();
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

        /// <summary>
        /// Get opportunity for view mode by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<GetOpportunityForViewDto> GetOpportunityForView(int id)
        {
            Opportunity opportunity = await _opportunityRepository.GetAsync(id);
            await _opportunityRepository.EnsureCollectionLoadedAsync(opportunity, x => x.Users);

            GetOpportunityForViewDto output = new GetOpportunityForViewDto { Opportunity = ObjectMapper.Map<OpportunityDto>(opportunity) };

            if (output.Opportunity.OpportunityStageId != null)
            {
                OpportunityStage _lookupOpportunityStage = await _lookupOpportunityStageRepository.FirstOrDefaultAsync((int)output.Opportunity.OpportunityStageId);
                output.OpportunityStageDescription = _lookupOpportunityStage?.Description;
            }

            if (output.Opportunity.LeadSourceId != null)
            {
                LeadSource _lookupLeadSource = await _lookupLeadSourceRepository.FirstOrDefaultAsync((int)output.Opportunity.LeadSourceId);
                output.LeadSourceDescription = _lookupLeadSource?.Description;
            }

            if (output.Opportunity.OpportunityTypeId != null)
            {
                OpportunityType _lookupOpportunityType = await _lookupOpportunityTypeRepository.FirstOrDefaultAsync((int)output.Opportunity.OpportunityTypeId);
                output.OpportunityTypeDescription = _lookupOpportunityType?.Description;
            }

            if (output.Opportunity.CustomerNumber != null)
            {
                Customer _lookupCustomer = await _lookupCustomerRepository.FirstOrDefaultAsync(e => e.Number == output.Opportunity.CustomerNumber);
                output.CustomerName = _lookupCustomer?.Name;
            }

            if (output.Opportunity.CustomerNumber != null)
            {
                Customer _lookupCustomer = await _lookupCustomerRepository.FirstOrDefaultAsync(e => e.Number == output.Opportunity.CustomerNumber);
                output.CustomerNumber = _lookupCustomer?.Number;
            }

            if (output.Opportunity.ContactId != null)
            {
                Contact _lookupContact = await _lookupContactsRepository.FirstOrDefaultAsync((int)output.Opportunity.ContactId);
                output.ContactName = _lookupContact?.ContactField;
            }
            //if (output.Opportunity.BranchId.HasValue)
            //{
            //    var branch = await _softBaseBranchRepository.GetByBranchNumberAsync(output.Opportunity.BranchId.Value);
            //    output.BranchName = branch.Name;
            //}

            //if (output.Opportunity.DepartmentId.HasValue)
            //{
            //    var dept = await _softBaseDepartmentRepository.GetByDeptNumberAsync(output.Opportunity.DepartmentId.Value);
            //    output.DepartmentTitle = dept.Title;
            //}

            var isUserAssignedToOpportunity = VerifyUserIsAssigneOpportunity(output);
            output.CanViewActivityWidget = HasAccessActivityWidget(isUserAssignedToOpportunity);
            output.CanCreateActivity = HasAccessCreateActivity(isUserAssignedToOpportunity);
            output.CanViewScheduleMeetingOption = HasAccessToScheduleMeeting(isUserAssignedToOpportunity);
            output.CanViewScheduleCallOption = HasAccessToScheduleCall(isUserAssignedToOpportunity);
            output.CanViewEmailReminderOption = HasAccessToEmailReminder(isUserAssignedToOpportunity);
            output.CanViewToDoReminderOption = HasAccessToDoReminder(isUserAssignedToOpportunity);
            output.CanEditActivity = HasAccessEditActivity(isUserAssignedToOpportunity);
            output.CanAssignAnyUserInActivity = CanAssignAnyUserWhenCreatingOrUpdatingAnActivity();

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
            Opportunity opportunity;

            if (CanSeeAllOpportunities())
            {
                opportunity = await _opportunityRepository.FirstOrDefaultAsync(input.Id);
            }
            else
            {
                opportunity = await _opportunityUserRepository.GetAll()
                    .Include(x => x.UserFk)
                    .Include(x => x.OpportunityFk)
                    .Where(x => x.UserId == GetCurrentUser().Id && x.OpportunityId == input.Id)
                    .Select(x => x.OpportunityFk)
                    .FirstOrDefaultAsync();
            }

            await _opportunityRepository.EnsureCollectionLoadedAsync(opportunity, x => x.Users);

            GuardHelper.ThrowIf(opportunity == null, new EntityNotFoundException(L("OpportunityNotExist")));

            GetOpportunityForEditOutput output = new GetOpportunityForEditOutput { Opportunity = ObjectMapper.Map<CreateOrEditOpportunityDto>(opportunity) };

            if (output.Opportunity.OpportunityStageId != null)
            {
                OpportunityStage _lookupOpportunityStage = await _lookupOpportunityStageRepository.FirstOrDefaultAsync((int)output.Opportunity.OpportunityStageId);
                output.OpportunityStageDescription = _lookupOpportunityStage?.Description;
            }

            if (output.Opportunity.LeadSourceId != null)
            {
                LeadSource _lookupLeadSource = await _lookupLeadSourceRepository.FirstOrDefaultAsync((int)output.Opportunity.LeadSourceId);
                output.LeadSourceDescription = _lookupLeadSource?.Description;
            }

            if (output.Opportunity.OpportunityTypeId != null)
            {
                OpportunityType _lookupOpportunityType = await _lookupOpportunityTypeRepository.FirstOrDefaultAsync((int)output.Opportunity.OpportunityTypeId);
                output.OpportunityTypeDescription = _lookupOpportunityType?.Description;
            }

            if (output.Opportunity.CustomerNumber != null)
            {
                Customer _lookupCustomer = await _lookupCustomerRepository.FirstOrDefaultAsync(e => e.Number == output.Opportunity.CustomerNumber);
                output.CustomerName = _lookupCustomer?.Name;
            }

            if (output.Opportunity.CustomerNumber != null)
            {
                Customer _lookupCustomer = await _lookupCustomerRepository.FirstOrDefaultAsync(e => e.Number == output.Opportunity.CustomerNumber);
                output.CustomerNumber = _lookupCustomer?.Number;
            }

            if (output.Opportunity.ContactId != null)
            {
                Contact _lookupContact = await _lookupContactsRepository.FirstOrDefaultAsync(e => e.ContactId == output.Opportunity.ContactId);
                output.ContactName = _lookupContact?.ContactField;
            }

            var isUserAssignedToOpportunity = opportunity.Users?.Any(x => x.UserId == GetCurrentUserId()) ?? false;
            output.CanViewActivityWidget = HasAccessActivityWidget(isUserAssignedToOpportunity);
            output.CanCreateActivity = HasAccessCreateActivity(isUserAssignedToOpportunity);
            output.CanViewScheduleMeetingOption = HasAccessToScheduleMeeting(isUserAssignedToOpportunity);
            output.CanViewScheduleCallOption = HasAccessToScheduleCall(isUserAssignedToOpportunity);
            output.CanViewEmailReminderOption = HasAccessToEmailReminder(isUserAssignedToOpportunity);
            output.CanViewToDoReminderOption = HasAccessToDoReminder(isUserAssignedToOpportunity);
            output.CanEditActivity = HasAccessEditActivity(isUserAssignedToOpportunity);
            output.CanAssignAnyUserInActivity = CanAssignAnyUserWhenCreatingOrUpdatingAnActivity();

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
            Opportunity opportunity = ObjectMapper.Map<Opportunity>(input);
            opportunity.CloseDate = opportunity.CloseDate?.ToUniversalTime();
            opportunity.TenantId = GetTenantId();

            Department _dept = _lookupDepartmentRepository.GetAllList(x => x.Dept == input.Dept && x.Branch == input.Branch).First();

            opportunity.DepartmentFk = _dept;

            using (_reasonProvider.Use("Opportunity created"))
            {
                await _opportunityRepository.InsertAsync(opportunity);
                await _unitOfWorkManager.Current.SaveChangesAsync();

                // Automate Assignment
                User currentUser = await GetCurrentUserAsync();
                bool hasDynamicPermission = await UserManager.IsGrantedAsync(currentUser.Id, AppPermissions.Pages_OpportunityUsers_AutomateAssignment__Dynamic);
                if (hasDynamicPermission)
                {
                    List<CreateOrEditOpportunityUserDto> listCreateOrEditOpportunityUserDto = new EditableList<CreateOrEditOpportunityUserDto>
                    {
                        new()
                        {
                            OpportunityId = opportunity.Id,
                            UserId = currentUser.Id
                        }
                    };

                    await _opportunityAutomateAssignment.AssignOpportunityUsersAsync(listCreateOrEditOpportunityUserDto);
                }
            }

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
            Opportunity opportunity = await _opportunityRepository.FirstOrDefaultAsync((int)input.Id);
            input.CloseDate = input.CloseDate?.ToUniversalTime();
            ObjectMapper.Map(input, opportunity);

            Department _dept = _lookupDepartmentRepository.GetAllList(x => x.Dept == input.Dept && x.Branch == input.Branch).First();

            opportunity.DepartmentFk = _dept;

            using (_reasonProvider.Use("Opportunity updated"))
            {
                ObjectMapper.Map(input, opportunity);
                await _unitOfWorkManager.Current.SaveChangesAsync();
            }
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

        /// <summary>
        /// Method that you get the opportunities to export to excel file
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<FileDto> GetOpportunitiesToExcel(GetAllOpportunitiesForExcelInput input)
        {
            TimeZoneInfo timeZone = TimeZoneInfo.FindSystemTimeZoneById(input.TimeZone);

            IQueryable<Opportunity> filteredOpportunities = _opportunityRepository.GetAll()
                        .Include(e => e.OpportunityStageFk)
                        .Include(e => e.LeadSourceFk)
                        .Include(e => e.OpportunityTypeFk)
                        .Include(x => x.Users)
                        .ThenInclude(x => x.UserFk)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.NameFilter), e => e.Name.Contains(input.NameFilter))
                        .WhereIf(input.MinAmountFilter != null, e => e.Amount >= input.MinAmountFilter)
                        .WhereIf(input.MaxAmountFilter != null, e => e.Amount <= input.MaxAmountFilter)
                        .WhereIf(input.MinProbabilityFilter != null, e => e.Probability >= input.MinProbabilityFilter)
                        .WhereIf(input.MaxProbabilityFilter != null, e => e.Probability <= input.MaxProbabilityFilter)
                        .WhereIf(input.MinCloseDateFilter != null, e => e.CloseDate >= input.MinCloseDateFilter)
                        .WhereIf(input.MaxCloseDateFilter != null, e => e.CloseDate <= input.MaxCloseDateFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.DescriptionFilter), e => e.Description == input.DescriptionFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.OpportunityStageDescriptionFilter), e => e.OpportunityStageFk != null && e.OpportunityStageFk.Description == input.OpportunityStageDescriptionFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.LeadSourceDescriptionFilter), e => e.LeadSourceFk != null && e.LeadSourceFk.Description == input.LeadSourceDescriptionFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.OpportunityTypeDescriptionFilter), e => e.OpportunityTypeFk != null && e.OpportunityTypeFk.Description == input.OpportunityTypeDescriptionFilter)
                        .WhereIf(input.OpportunityStageId.HasValue, x => input.OpportunityStageId == x.OpportunityStageFk.Id)
                        .WhereIf(!CanSeeAllOpportunities(), x => x.Users != null && x.Users.Select(y => y.UserId).Contains(GetCurrentUserId()))
                        .WhereIf(input.UserIds.Any() && !input.UserIds.Contains(-1), x => x.Users.Any(y => input.UserIds.Contains(y.UserId)))
                        .WhereIf(input.UserIds.Contains(-1), x => !x.Users.Any());

            IQueryable<OpportunityQueryDto> query = (from o in filteredOpportunities
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

                                                     select new OpportunityQueryDto
                                                     {
                                                         Name = o.Name,
                                                         Amount = o.Amount,
                                                         Probability = o.Probability,
                                                         CloseDate = o.CloseDate.HasValue ? TimeZoneInfo.ConvertTime((DateTime)o.CloseDate, timeZone) : null,
                                                         Description = o.Description,
                                                         BranchName = o.Name,
                                                         DepartmentTitle = o.Name,
                                                         Id = o.Id,
                                                         Users = ObjectMapper.Map<List<OpportunityUserDto>>(o.Users),
                                                         OpportunityStageDescription = s1 == null || s1.Description == null ? "" : s1.Description,
                                                         LeadSourceDescription = s2 == null || s2.Description == null ? "" : s2.Description,
                                                         OpportunityTypeDescription = s3 == null || s3.Description == null ? "" : s3.Description,
                                                         CustomerName = s4 == null || s4.Name == null ? "" : s4.Name,
                                                         CustomerNumber = s4 == null || s4.Number == null ? "" : s4.Number,
                                                         ContactName = s5 == null || s5.ContactField == null ? "" : s5.ContactField.ToString()
                                                     });

            List<OpportunityQueryDto> dbList = await query.ToListAsync();
            List<GetOpportunityForViewDto> opportunities = GetOpportunityForViewDtos(dbList);

            return _opportunitiesExcelExporter.ExportToFile(opportunities);
        }

        /// <summary>
        /// Get Opportunity Stage lookup
        /// </summary>
        /// <returns></returns>
        [AbpAuthorize(AppPermissions.Pages_Opportunities)]
        public async Task<List<OpportunityOpportunityStageLookupTableDto>> GetAllOpportunityStageForTableDropdown()
        {
            return await _lookupOpportunityStageRepository.GetAll()
                .OrderBy(x => x.Order)
                .Select(opportunityStage => new OpportunityOpportunityStageLookupTableDto
                {
                    Id = opportunityStage.Id,
                    DisplayName = opportunityStage == null || opportunityStage.Description == null ? "" : opportunityStage.Description.ToString()
                }).ToListAsync();
        }

        /// <summary>
        /// Get Opportunity User type dropdown
        /// </summary>
        /// <returns></returns>
        [AbpAuthorize(AppPermissions.Pages_Opportunities)]
        public async Task<List<LeadUserUserLookupTableDto>> GetAllUsersForTableDropdown()
        {
            return await _lookupUserRepository.GetAll()
                .Select(user => new LeadUserUserLookupTableDto
                {
                    Id = user.Id,
                    DisplayName = user == null || user.FullName == null ? string.Empty : user.FullName
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
        public async Task<List<OpportunityCustomerLookupTableDto>> GetAllCustomerForTableDropdown(string customerNumber = null)
        {
            bool userCanSelectAllAccountsDynamic = false;

            long currentUserId = GetCurrentUser().Id;

            bool userCanSelectAllAccountsStatic = HasStaticAccessToAddOpportunity(currentUserId);

            if (!userCanSelectAllAccountsStatic)
                userCanSelectAllAccountsDynamic = HasDynamicAccessToAddOpportunity(currentUserId);

            if (userCanSelectAllAccountsDynamic || userCanSelectAllAccountsStatic)
            {
                List<OpportunityCustomerLookupTableDto> customers = await _lookupCustomerRepository.GetAll()
                    .Include(x => x.Users)
                    .WhereIf(customerNumber != null, x => x.Number != null && x.Number == customerNumber)
                    .WhereIf(!userCanSelectAllAccountsStatic, x => x.Users != null && x.Users.Select(y => y.UserId).Contains(currentUserId))
                    .Select(customer => new OpportunityCustomerLookupTableDto
                    {
                        Number = customer.Number,
                        Name = customer == null || customer.Name == null ? "" : customer.Name.ToString()
                    }).ToListAsync();

                if (customerNumber != null)
                    GuardHelper.ThrowIf(customers.Count == 0, new EntityNotFoundException(L("AccountNotExist")));

                return customers;
            }

            return null;
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
            return await _lookupContactsRepository.GetAll()
                .WhereIf(!string.IsNullOrWhiteSpace(customerNumber), e => e.CustomerNo == customerNumber)
                .Select(contact => new OpportunityContactsLookupTableDto
                {
                    Id = contact.ContactId,
                    ContactName = contact == null || contact.ContactField == null ? "" : contact.ContactField.ToString()
                }).ToListAsync();
        }

        /// <summary>
        /// Get all events
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [AbpAuthorize(AppPermissions.Pages_Opportunities_View_Events)]
        public async Task<PagedResultDto<EntityChangeListDto>> GetEntityTypeChanges(GetCrmEntityTypeChangeInput input)
        {
            input.EntityTypeFullName = typeof(Opportunity).FullName;
            return await _auditEventsService.GetEntityTypeChanges(ObjectMapper.Map<GetEntityTypeChangeInput>(input));
        }

        /// <summary>
        /// Get Branches lookup
        /// </summary>
        /// <returns></returns>
        [AbpAuthorize(AppPermissions.Pages_Opportunities)]
        public async Task<List<BranchLookupTableDto>> GetAllBranchesForTableDropdown()
        {
            return await _lookupBranchRepository.GetAll()
                .Select(x => new BranchLookupTableDto
                {
                    Number = x.Number,
                    Name = x.Name
                }).ToListAsync();
        }

        /// <summary>
        /// Get Departments lookup
        /// </summary>
        /// <returns></returns>
        [AbpAuthorize(AppPermissions.Pages_Opportunities)]
        public async Task<List<DepartmentLookupTableDto>> GetAllDepartmentsForTableDropdown()
        {
            List<DepartmentLookupTableDto> result = await _lookupDepartmentRepository.GetAll()
                .Select(x => new DepartmentLookupTableDto
                {
                    Branch = x.Branch,
                    Dept = x.Dept,
                    Title = x.Title
                }).ToListAsync();
            return result;
        }

        /// <summary>
        /// Get Departments lookup for an specific branch
        /// </summary>
        /// <returns></returns>
        [AbpAuthorize(AppPermissions.Pages_Opportunities)]
        public async Task<List<DepartmentLookupTableDto>> GetAllDepartmentsForTableDropdownBranchSpecific(short branchNumber)
        {
            List<DepartmentLookupTableDto> result = await _lookupDepartmentRepository.GetAll()
                .Where(e => e.Branch == branchNumber)
                .Select(x => new DepartmentLookupTableDto
                {
                    Branch = x.Branch,
                    Dept = x.Dept,
                    Title = x.Title
                }).ToListAsync();
            return result;
        }

        /// <summary>
        /// Verify if the current user is assigned to the specified Lead
        /// </summary>
        /// <param name="opportunity"></param>
        /// <returns></returns>
        private bool VerifyUserIsAssigneOpportunity(GetOpportunityForViewDto opportunity)
        {
            long currentUserId = GetCurrentUser().Id;
            return opportunity?.Opportunity?.Users?.Any(x => x.UserId == currentUserId) ?? false;
        }

        /// <summary>
        /// Get the dynamic permission based on the current user.
        /// </summary>
        /// <returns></returns>
        internal bool HasAccessToScheduleMeeting(bool isUserAssignedToOpportunity)
        {
            var currentUser = GetCurrentUser();
            return UserManager.IsGranted(currentUser.Id, AppPermissions.Pages_Opportunities_ScheduleMeeting) ||
                (UserManager.IsGranted(currentUser.Id, AppPermissions.Pages_Opportunities_ScheduleMeeting__Dynamic) && isUserAssignedToOpportunity);
        }

        /// <summary>
        /// Get the dynamic permission based on the current user.
        /// </summary>
        /// <returns></returns>
        internal bool HasAccessToScheduleCall(bool isUserAssignedToOpportunity)
        {
            var currentUser = GetCurrentUser();
            return UserManager.IsGranted(currentUser.Id, AppPermissions.Pages_Opportunities_ScheduleCall) ||
                (UserManager.IsGranted(currentUser.Id, AppPermissions.Pages_Opportunities_ScheduleCall__Dynamic) && isUserAssignedToOpportunity);
        }

        /// <summary>
        /// Get the dynamic permission based on the current user.
        /// </summary>
        /// <returns></returns>
        internal bool HasAccessToEmailReminder(bool isUserAssignedToOpportunity)
        {
            var currentUser = GetCurrentUser();
            return UserManager.IsGranted(currentUser.Id, AppPermissions.Pages_Opportunities_EmailReminder) ||
                (UserManager.IsGranted(currentUser.Id, AppPermissions.Pages_Opportunities_EmailReminder__Dynamic) && isUserAssignedToOpportunity);
        }

        /// <summary>
        /// Get the dynamic permission based on the current user.
        /// </summary>
        /// <returns></returns>
        internal bool HasAccessToDoReminder(bool isUserAssignedToOpportunity)
        {
            var currentUser = GetCurrentUser();
            return UserManager.IsGranted(currentUser.Id, AppPermissions.Pages_Opportunities_ToDoReminder) ||
                (UserManager.IsGranted(currentUser.Id, AppPermissions.Pages_Opportunities_ToDoReminder__Dynamic) && isUserAssignedToOpportunity);
        }

        /// <summary>
        /// Check whether the current user can view the Opportunity Activity widget.
        /// The user can see the widget if any of these conditions are met:
        /// 1. The current user has <see cref="AppPermissions.Pages_Opportunities_View_Activities_Of_All_Users"/> permission, which is oriented for Managers., OR...
        /// 2. The current user has <see cref="AppPermissions.Pages_Opportunities_View_Activities"/> permission and also assigned to the Opportunity
        /// </summary>
        /// <param name="isUserAssignedToOpportunity">Is the current user assigned to the Opportunity?</param>
        /// <returns>True or False</returns>
        internal bool HasAccessActivityWidget(bool isUserAssignedToOpportunity)
        {
            var currentUser = GetCurrentUser();

            var canViewAllActivities = UserManager.IsGranted(currentUser.Id, AppPermissions.Pages_Opportunities_View_Activities_Of_All_Users);
            var canViewActivities = UserManager.IsGranted(currentUser.Id, AppPermissions.Pages_Opportunities_View_Activities);

            return canViewAllActivities || (canViewActivities && isUserAssignedToOpportunity);
        }

        /// <summary>
        /// Check whether the current user can create an activity for the Opportunity.
        /// </summary>
        /// <returns>True or False</returns>
        internal bool HasAccessCreateActivity(bool isUserAssignedToOpportunity)
        {
            var currentUser = GetCurrentUser();

            var canCreateActivities = UserManager.IsGranted(currentUser.Id, AppPermissions.Pages_Opportunities_Create_Activities);
            var canCreateActivitiesDynamic = UserManager.IsGranted(currentUser.Id, AppPermissions.Pages_Opportunities_Create_Activities__Dynamic);

            return canCreateActivities || (canCreateActivitiesDynamic && isUserAssignedToOpportunity);
        }

        /// <summary>
        /// Check whether the current user can edit an activity of Opportunity.
        /// </summary>
        /// <returns>True or False</returns>
        internal bool HasAccessEditActivity(bool isUserAssignedToOpportunity)
        {
            var currentUser = GetCurrentUser();

            var canEditActivity = UserManager.IsGranted(currentUser.Id, AppPermissions.Pages_Opportunities_Edit_Activities);
            var canEditActivityDynamic = UserManager.IsGranted(currentUser.Id, AppPermissions.Pages_Opportunities_Edit_Activities__Dynamic);

            return canEditActivity || (canEditActivityDynamic && isUserAssignedToOpportunity);
        }

        /// <summary>
        /// Check whether the current user can view all activities of all users in Opportunities.
        /// </summary>
        /// <returns>True or False</returns>
        internal bool CanViewAllActivitiesOfAllUsers()
        {
            var currentUser = GetCurrentUser();
            return UserManager.IsGranted(currentUser.Id, AppPermissions.Pages_Opportunities_View_Activities_Of_All_Users);
        }

        /// <summary>
        /// Check whether the current user can assign any user.
        /// </summary>
        /// <returns>True or False</returns>
        internal bool CanAssignAnyUserWhenCreatingOrUpdatingAnActivity()
        {
            var currentUser = GetCurrentUser();
            return UserManager.IsGranted(currentUser.Id, AppPermissions.Pages_Opportunities_Assign_Activity_To_Any_Users);
        }
    }
}