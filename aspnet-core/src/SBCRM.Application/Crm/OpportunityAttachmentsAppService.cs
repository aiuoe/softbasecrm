using System.Linq;
using System.Linq.Dynamic.Core;
using Abp.Linq.Extensions;
using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Domain.Repositories;
using SBCRM.Crm.Dtos;
using Abp.Application.Services.Dto;
using SBCRM.Authorization;
using Abp.Authorization;
using Microsoft.EntityFrameworkCore;
using SBCRM.Common;
using Abp.Domain.Entities;

namespace SBCRM.Crm
{
    /// <summary>
    /// Service for opportunity attachments.
    /// </summary>
    public class OpportunityAttachmentsAppService : SBCRMAppServiceBase, IOpportunityAttachmentsAppService
    {
        private readonly IRepository<OpportunityAttachment> _opportunityAttachmentRepository;
        private readonly IRepository<Opportunity, int> _lookup_opportunityRepository;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="opportunityAttachmentRepository"></param>
        /// <param name="lookup_opportunityRepository"></param>
        public OpportunityAttachmentsAppService(IRepository<OpportunityAttachment> opportunityAttachmentRepository, IRepository<Opportunity, int> lookup_opportunityRepository)
        {
            _opportunityAttachmentRepository = opportunityAttachmentRepository;
            _lookup_opportunityRepository = lookup_opportunityRepository;

        }

        /// <summary>
        /// Get all opportunity attachments filtered by an input
        /// </summary>
        /// <param name="input">An input filter</param>
        /// <returns></returns>
        [AbpAuthorize(AppPermissions.Pages_Opportunities)]
        public async Task<PagedResultDto<GetOpportunityAttachmentForViewDto>> GetAll(GetAllOpportunityAttachmentsInput input)
        {

            var filteredOpportunityAttachments = _opportunityAttachmentRepository.GetAll()
                        .Include(e => e.OpportunityFk)
                        .Where(e => e.OpportunityFk != null && e.OpportunityFk.Id == input.OpportunityId )
                        .WhereIf(!string.IsNullOrWhiteSpace(input.Filter), e => false || e.Name.Contains(input.Filter) || e.FilePath.Contains(input.Filter))
                        .WhereIf(!string.IsNullOrWhiteSpace(input.NameFilter), e => e.Name == input.NameFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.FilePathFilter), e => e.FilePath == input.FilePathFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.OpportunityNameFilter), e => e.OpportunityFk != null && e.OpportunityFk.Name == input.OpportunityNameFilter);

            var pagedAndFilteredOpportunityAttachments = filteredOpportunityAttachments
                .OrderBy(input.Sorting ?? "id asc")
                .PageBy(input);

            var opportunityAttachments = from o in pagedAndFilteredOpportunityAttachments
                                         join o1 in _lookup_opportunityRepository.GetAll() on o.OpportunityId equals o1.Id into j1
                                         from s1 in j1.DefaultIfEmpty()

                                         select new
                                         {

                                             o.Name,
                                             o.FilePath,
                                             Id = o.Id,
                                             OpportunityName = s1 == null || s1.Name == null ? "" : s1.Name.ToString()
                                         };

            var totalCount = await filteredOpportunityAttachments.CountAsync();

            var dbList = await opportunityAttachments.ToListAsync();
            var results = new List<GetOpportunityAttachmentForViewDto>();

            foreach (var o in dbList)
            {
                var res = new GetOpportunityAttachmentForViewDto()
                {
                    OpportunityAttachment = new OpportunityAttachmentDto
                    {

                        Name = o.Name,
                        FilePath = o.FilePath,
                        Id = o.Id,
                    },
                    OpportunityName = o.OpportunityName
                };

                results.Add(res);
            }

            return new PagedResultDto<GetOpportunityAttachmentForViewDto>(
                totalCount,
                results
            );

        }

        /// <summary>
        /// Gets a opportunity attachment for viewing
        /// </summary>
        /// <param name="id">An Id of the lead attachment to be viewed.</param>
        /// <returns></returns>
        [AbpAuthorize(
            AppPermissions.Pages_Opportunities_View_Attachments,
            AppPermissions.Pages_Opportunities_View_Attachments__Dynamic
        )]
        public async Task<GetOpportunityAttachmentForViewDto> GetOpportunityAttachmentForView(int id)
        {
            var opportunityAttachment = await _opportunityAttachmentRepository.GetAsync(id);

            var output = new GetOpportunityAttachmentForViewDto { OpportunityAttachment = ObjectMapper.Map<OpportunityAttachmentDto>(opportunityAttachment) };

            if (output.OpportunityAttachment.OpportunityId != null)
            {
                var _lookupOpportunity = await _lookup_opportunityRepository.FirstOrDefaultAsync((int)output.OpportunityAttachment.OpportunityId);
                output.OpportunityName = _lookupOpportunity?.Name?.ToString();
            }

            return output;
        }


        /// <summary>
        /// Gets a opportunity attachment for editing
        /// </summary>
        /// <param name="input">An Id of the opportunity attachment to be edited.</param>
        /// <returns></returns>
        [AbpAuthorize(
            AppPermissions.Pages_Opportunities_Edit_Attachments,
            AppPermissions.Pages_Opportunities_Edit_Attachments__Dynamic
        )]
        public async Task<GetOpportunityAttachmentForEditOutput> GetOpportunityAttachmentForEdit(EntityDto input)
        {
            var opportunityAttachment = await _opportunityAttachmentRepository.FirstOrDefaultAsync(input.Id);

            var output = new GetOpportunityAttachmentForEditOutput { OpportunityAttachment = ObjectMapper.Map<CreateOrEditOpportunityAttachmentDto>(opportunityAttachment) };

            if (output.OpportunityAttachment.OpportunityId != null)
            {
                var _lookupOpportunity = await _lookup_opportunityRepository.FirstOrDefaultAsync((int)output.OpportunityAttachment.OpportunityId);
                output.OpportunityName = _lookupOpportunity?.Name?.ToString();
            }

            return output;
        }


        /// <summary>
        /// Creates or edits an attachment.
        /// </summary>
        /// <param name="input">An attachment to be created or edited.</param>
        /// <returns></returns>
        [AbpAuthorize(
            AppPermissions.Pages_Opportunities_Add_Attachments,
            AppPermissions.Pages_Opportunities_Add_Attachments__Dynamic,
            AppPermissions.Pages_Opportunities_Edit_Attachments,
            AppPermissions.Pages_Opportunities_Edit_Attachments__Dynamic
        )]
        public async Task CreateOrEdit(CreateOrEditOpportunityAttachmentDto input)
        {
            if (input.Id == 0)
            {
                await Create(input);
            }
            else
            {
                await Update(input);
            }
        }


        /// <summary>
        /// Creates an attachment.
        /// </summary>
        /// <param name="input">An attachment to be created.</param>
        /// <returns></returns>
        [AbpAuthorize(
            AppPermissions.Pages_Opportunities_Add_Attachments,
            AppPermissions.Pages_Opportunities_Add_Attachments__Dynamic
        )]
        protected virtual async Task Create(CreateOrEditOpportunityAttachmentDto input)
        {
            var opportunityAttachment = ObjectMapper.Map<OpportunityAttachment>(input);

            await _opportunityAttachmentRepository.InsertAsync(opportunityAttachment);

        }


        /// <summary>
        /// Updates an exiting attachment.
        /// </summary>
        /// <param name="input">An attachment to be updated.</param>
        /// <returns></returns>
        [AbpAuthorize(
            AppPermissions.Pages_Opportunities_Edit_Attachments,
            AppPermissions.Pages_Opportunities_Edit_Attachments__Dynamic
        )]
        protected virtual async Task Update(CreateOrEditOpportunityAttachmentDto input)
        {
            var opportunityAttachment = await _opportunityAttachmentRepository.FirstOrDefaultAsync((int)input.Id);
            ObjectMapper.Map(input, opportunityAttachment);

        }

        /// <summary>
        /// Deletes an attachment.
        /// </summary>
        /// <param name="input">An attachment to be deleted.</param>
        /// <returns></returns>
        [AbpAuthorize(
            AppPermissions.Pages_Opportunities_Remove_Attachments,
            AppPermissions.Pages_Opportunities_Remove_Attachments__Dynamic
        )]
        public async Task Delete(EntityDto input)
        {
            await _opportunityAttachmentRepository.DeleteAsync(input.Id);
        }

        /// <summary>
        /// Get a list of opportunities
        /// </summary>
        /// <returns></returns>
        [AbpAuthorize(AppPermissions.Pages_Opportunities)]
        public async Task<OpportunityAttachmentPermissionsDto> GetWidgetPermissionsForOpportunity(int opportunityId)
        {
            GuardHelper.ThrowIf(opportunityId <= 0, new EntityNotFoundException(L("OpportunityNotExist")));

            var isUserAssignedToOpportunity = false;
            isUserAssignedToOpportunity = VerifyUserIsAssignedToOpportunity(opportunityId);

            OpportunityAttachmentPermissionsDto opportunity = await _lookup_opportunityRepository.GetAll()
                .Where(x => x.Id == opportunityId)
                .Select(opportunity => new OpportunityAttachmentPermissionsDto
                {
                    Id = opportunity.Id,
                    DisplayName = opportunity == null || opportunity.Name == null ? "" : opportunity.Name.ToString(),
                    CanViewAttachments = HasAccessToViewAttachments(isUserAssignedToOpportunity),
                    CanAddAttachments = HasAccessToAddAttachments(isUserAssignedToOpportunity),
                    CanEditAttachments = HasAccessToEditAttachments(isUserAssignedToOpportunity),
                    CanDownloadAttachments = HasAccessToDownloadAttachments(isUserAssignedToOpportunity),
                    CanRemoveAttachments = HasAccessToRemoveAttachments(isUserAssignedToOpportunity),
                }).FirstOrDefaultAsync();

            GuardHelper.ThrowIf(opportunity == null, new EntityNotFoundException(L("OpportunityNotExist")));

            return opportunity;
        }

        /// <summary>
        /// Verify if the current user is assigned to the specified Opportunity
        /// </summary>
        /// <param name="opportunityId"></param>
        /// <returns></returns>
        internal bool VerifyUserIsAssignedToOpportunity(int opportunityId)
        {
            OpportunityAttachmentPermissionsDto opportunity = _lookup_opportunityRepository.GetAll()
                .Where(x => x.Id == opportunityId)
                .Select(opportunity => new OpportunityAttachmentPermissionsDto
                {
                    Users = ObjectMapper.Map<List<OpportunityUserDto>>(opportunity.Users)
                }).FirstOrDefault();

            long currentUserId = GetCurrentUser().Id;
            return opportunity?.Users?.Any(x => x.UserId == currentUserId) ?? false;
        }


        /// <summary>
        /// Check whether the current user can view attachments on Opportunities
        /// </summary>
        /// <returns>True or False</returns>
        internal bool HasAccessToViewAttachments(bool isUserAssignedToOpportunity)
        {
            var currentUser = GetCurrentUser();

            var canViewAttachments = UserManager.IsGranted(currentUser.Id, AppPermissions.Pages_Opportunities_View_Attachments);
            var canViewAttachmentsDynamic = UserManager.IsGranted(currentUser.Id, AppPermissions.Pages_Opportunities_View_Attachments__Dynamic);

            return canViewAttachments || (canViewAttachmentsDynamic && isUserAssignedToOpportunity);
        }

        /// <summary>
        /// Check whether the current user can add attachments Opportunities.
        /// </summary>
        /// <returns>True or False</returns>
        internal bool HasAccessToAddAttachments(bool isUserAssignedToOpportunity)
        {
            var currentUser = GetCurrentUser();

            var canAddAttachments = UserManager.IsGranted(currentUser.Id, AppPermissions.Pages_Opportunities_Add_Attachments);
            var canAddAttachmentsDynamic = UserManager.IsGranted(currentUser.Id, AppPermissions.Pages_Opportunities_Add_Attachments__Dynamic);

            return canAddAttachments || (canAddAttachmentsDynamic && isUserAssignedToOpportunity);
        }

        /// <summary>
        /// Check whether the current user can edit attachments Opportunities.
        /// </summary>
        /// <returns>True or False</returns>
        internal bool HasAccessToEditAttachments(bool isUserAssignedToOpportunity)
        {
            var currentUser = GetCurrentUser();

            var canEditAttachments = UserManager.IsGranted(currentUser.Id, AppPermissions.Pages_Opportunities_Edit_Attachments);
            var canEditAttachmentsDynamic = UserManager.IsGranted(currentUser.Id, AppPermissions.Pages_Opportunities_Edit_Attachments__Dynamic);

            return canEditAttachments || (canEditAttachmentsDynamic && isUserAssignedToOpportunity);
        }

        /// <summary>
        /// Check whether the current user can download attachments Opportunities.
        /// </summary>
        /// <returns>True or False</returns>
        internal bool HasAccessToDownloadAttachments(bool isUserAssignedToOpportunity)
        {
            var currentUser = GetCurrentUser();

            var canDownloadAttachments = UserManager.IsGranted(currentUser.Id, AppPermissions.Pages_Opportunities_Download_Attachments);
            var canDownloadAttachmentsDynamic = UserManager.IsGranted(currentUser.Id, AppPermissions.Pages_Opportunities_Download_Attachments__Dynamic);

            return canDownloadAttachments || (canDownloadAttachmentsDynamic && isUserAssignedToOpportunity);
        }

        /// <summary>
        /// Check whether the current user can remove attachments Opportunities.
        /// </summary>
        /// <returns>True or False</returns>
        internal bool HasAccessToRemoveAttachments(bool isUserAssignedToOpportunity)
        {
            var currentUser = GetCurrentUser();

            var canRemoveAttachments = UserManager.IsGranted(currentUser.Id, AppPermissions.Pages_Opportunities_Remove_Attachments);
            var canRemoveAttachmentsDynamic = UserManager.IsGranted(currentUser.Id, AppPermissions.Pages_Opportunities_Remove_Attachments__Dynamic);

            return canRemoveAttachments || (canRemoveAttachmentsDynamic && isUserAssignedToOpportunity);
        }

    }
}