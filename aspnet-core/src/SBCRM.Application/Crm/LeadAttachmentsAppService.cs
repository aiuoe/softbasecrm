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

namespace SBCRM.Crm
{
    /// <summary>
    /// Service for lead attachments.
    /// </summary>
    public class LeadAttachmentsAppService : SBCRMAppServiceBase, ILeadAttachmentsAppService
    {
        private readonly IRepository<LeadAttachment> _leadAttachmentRepository;
        private readonly ILeadAttachmentsExcelExporter _leadAttachmentsExcelExporter;
        private readonly IRepository<Lead, int> _lookup_leadRepository;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="leadAttachmentRepository"></param>
        /// <param name="leadAttachmentsExcelExporter"></param>
        /// <param name="lookup_leadRepository"></param>
        public LeadAttachmentsAppService(IRepository<LeadAttachment> leadAttachmentRepository, ILeadAttachmentsExcelExporter leadAttachmentsExcelExporter, IRepository<Lead, int> lookup_leadRepository)
        {
            _leadAttachmentRepository = leadAttachmentRepository;
            _leadAttachmentsExcelExporter = leadAttachmentsExcelExporter;
            _lookup_leadRepository = lookup_leadRepository;

        }

        /// <summary>
        /// Get all customer attachments filtered by an input
        /// </summary>
        /// <param name="input">An input filter</param>
        /// <returns></returns>
        [AbpAuthorize(AppPermissions.Pages_Leads)]
        public async Task<PagedResultDto<GetLeadAttachmentForViewDto>> GetAll(GetAllLeadAttachmentsInput input)
        {

            var filteredLeadAttachments = _leadAttachmentRepository.GetAll()
                        .Include(e => e.LeadFk)
                        .Where(e => e.LeadFk != null && e.LeadFk.Id == input.LeadIdFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.Filter), e => false || e.Name.Contains(input.Filter) || e.FilePath.Contains(input.Filter))
                        .WhereIf(!string.IsNullOrWhiteSpace(input.NameFilter), e => e.Name == input.NameFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.FilePathFilter), e => e.FilePath == input.FilePathFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.LeadCompanyNameFilter), e => e.LeadFk != null && e.LeadFk.CompanyName == input.LeadCompanyNameFilter);

            var pagedAndFilteredLeadAttachments = filteredLeadAttachments
                .OrderBy(input.Sorting ?? "id asc")
                .PageBy(input);

            var leadAttachments = from o in pagedAndFilteredLeadAttachments
                                  join o1 in _lookup_leadRepository.GetAll() on o.LeadId equals o1.Id into j1
                                  from s1 in j1.DefaultIfEmpty()

                                  select new
                                  {
                                      o.Name,
                                      o.FilePath,
                                      Id = o.Id,
                                      LeadCompanyName = s1 == null || s1.CompanyName == null ? "" : s1.CompanyName.ToString()
                                  };

            var totalCount = await filteredLeadAttachments.CountAsync();

            var dbList = await leadAttachments.ToListAsync();
            var results = new List<GetLeadAttachmentForViewDto>();

            foreach (var o in dbList)
            {
                var res = new GetLeadAttachmentForViewDto()
                {
                    LeadAttachment = new LeadAttachmentDto
                    {

                        Name = o.Name,
                        FilePath = o.FilePath,
                        Id = o.Id,
                    },
                };

                results.Add(res);
            }

            return new PagedResultDto<GetLeadAttachmentForViewDto>(
                totalCount,
                results
            );

        }

        /// <summary>
        /// Gets a lead attachment for viewing
        /// </summary>
        /// <param name="id">An Id of the lead attachment to be viewed.</param>
        /// <returns></returns>
        [AbpAuthorize(
            AppPermissions.Pages_Leads_View_Attachments,
            AppPermissions.Pages_Leads_View_Attachments__Dynamic
        )]
        public async Task<GetLeadAttachmentForViewDto> GetLeadAttachmentForView(int id)
        {
            var leadAttachment = await _leadAttachmentRepository.GetAsync(id);

            var output = new GetLeadAttachmentForViewDto { LeadAttachment = ObjectMapper.Map<LeadAttachmentDto>(leadAttachment) };

            return output;
        }


        /// <summary>
        /// Gets a lead attachment for editing
        /// </summary>
        /// <param name="input">An Id of the lead attachment to be edited.</param>
        /// <returns></returns>
        [AbpAuthorize(
            AppPermissions.Pages_Leads_Edit_Attachments,
            AppPermissions.Pages_Leads_Edit_Attachments__Dynamic
        )]
        public async Task<GetLeadAttachmentForEditOutput> GetLeadAttachmentForEdit(EntityDto input)
        {
            var leadAttachment = await _leadAttachmentRepository.FirstOrDefaultAsync(input.Id);

            var output = new GetLeadAttachmentForEditOutput { LeadAttachment = ObjectMapper.Map<CreateOrEditLeadAttachmentDto>(leadAttachment) };

            return output;
        }


        /// <summary>
        /// Creates or edits an attachment.
        /// </summary>
        /// <param name="input">An attachment to be created or edited.</param>
        /// <returns></returns>
        [AbpAuthorize(
            AppPermissions.Pages_Leads_Add_Attachments,
            AppPermissions.Pages_Leads_Add_Attachments__Dynamic,
            AppPermissions.Pages_Leads_Edit_Attachments,
            AppPermissions.Pages_Leads_Edit_Attachments__Dynamic
        )]
        public async Task CreateOrEdit(CreateOrEditLeadAttachmentDto input)
        {
            if (input.Id == null || input.Id == 0)
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
            AppPermissions.Pages_Leads_Add_Attachments,
            AppPermissions.Pages_Leads_Add_Attachments__Dynamic
        )]
        protected virtual async Task Create(CreateOrEditLeadAttachmentDto input)
        {
            var leadAttachment = ObjectMapper.Map<LeadAttachment>(input);

            await _leadAttachmentRepository.InsertAsync(leadAttachment);

        }

        /// <summary>
        /// Updates an exiting attachment.
        /// </summary>
        /// <param name="input">An attachment to be updated.</param>
        /// <returns></returns>
        [AbpAuthorize(
            AppPermissions.Pages_Leads_Edit_Attachments,
            AppPermissions.Pages_Leads_Edit_Attachments__Dynamic
        )]
        protected virtual async Task Update(CreateOrEditLeadAttachmentDto input)
        {
            var leadAttachment = await _leadAttachmentRepository.FirstOrDefaultAsync((int)input.Id);
            ObjectMapper.Map(input, leadAttachment);

        }


        /// <summary>
        /// Deletes an attachment.
        /// </summary>
        /// <param name="input">An attachment to be deleted.</param>
        /// <returns></returns>
        [AbpAuthorize(
            AppPermissions.Pages_Leads_Remove_Attachments,
            AppPermissions.Pages_Leads_Remove_Attachments__Dynamic
        )]
        public async Task Delete(EntityDto input)
        {
            await _leadAttachmentRepository.DeleteAsync(input.Id);
        }


        /// <summary>
        /// Lists the lead atttachments on an Excel file.
        /// </summary>
        /// <param name="input">An input filter</param>
        /// <returns>The excel file</returns>
        [AbpAuthorize(AppPermissions.Pages_Leads)]
        public async Task<FileDto> GetLeadAttachmentsToExcel(GetAllLeadAttachmentsForExcelInput input)
        {

            var filteredLeadAttachments = _leadAttachmentRepository.GetAll()
                        .Include(e => e.LeadFk)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.Filter), e => false || e.Name.Contains(input.Filter) || e.FilePath.Contains(input.Filter))
                        .WhereIf(!string.IsNullOrWhiteSpace(input.NameFilter), e => e.Name == input.NameFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.FilePathFilter), e => e.FilePath == input.FilePathFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.LeadCompanyNameFilter), e => e.LeadFk != null && e.LeadFk.CompanyName == input.LeadCompanyNameFilter);

            var query = (from o in filteredLeadAttachments
                         join o1 in _lookup_leadRepository.GetAll() on o.LeadId equals o1.Id into j1
                         from s1 in j1.DefaultIfEmpty()

                         select new GetLeadAttachmentForViewDto()
                         {
                             LeadAttachment = new LeadAttachmentDto
                             {
                                 Name = o.Name,
                                 FilePath = o.FilePath,
                                 Id = o.Id
                             },
                         });

            var leadAttachmentListDtos = await query.ToListAsync();

            return _leadAttachmentsExcelExporter.ExportToFile(leadAttachmentListDtos);
        }


        /// <summary>
        /// Get a list of leads
        /// </summary>
        /// <param name="leadId"></param>
        /// <returns></returns>
        [AbpAuthorize(AppPermissions.Pages_Leads)]
        public async Task<List<LeadAttachmentLeadLookupTableDto>> GetAllLeadForTableDropdown(int leadId = 0)
        {
            var isUserAssignedToLead = false;
            if (leadId > 0)
                isUserAssignedToLead = VerifyUserIsAssignedLead(leadId);

            return await _lookup_leadRepository.GetAll()
                .WhereIf(leadId > 0, x => x.Id == leadId)
                .Select(lead => new LeadAttachmentLeadLookupTableDto
                {
                    Id = lead.Id,
                    DisplayName = lead == null || lead.CompanyName == null ? "" : lead.CompanyName.ToString(),
                    CanViewAttachments = HasAccessToViewAttachments(isUserAssignedToLead),
                    CanAddAttachments = HasAccessToAddAttachments(isUserAssignedToLead),
                    CanEditAttachments = HasAccessToEditAttachments(isUserAssignedToLead),
                    CanDownloadAttachments = HasAccessToDownloadAttachments(isUserAssignedToLead),
                    CanRemoveAttachments = HasAccessToRemoveAttachments(isUserAssignedToLead),
                }).ToListAsync();
        }

        /// <summary>
        /// Verify if the current user is assigned to the specified Lead
        /// </summary>
        /// <param name="leadId"></param>
        /// <returns></returns>
        internal bool VerifyUserIsAssignedLead(int leadId)
        {
            LeadAttachmentLeadLookupTableDto lead = _lookup_leadRepository.GetAll()
                .WhereIf(leadId > 0, x => x.Id == leadId)
                .Select(lead => new LeadAttachmentLeadLookupTableDto
                {
                    Users = ObjectMapper.Map<List<LeadUserDto>>(lead.Users)
                }).FirstOrDefault();

            long currentUserId = GetCurrentUser().Id;
            return lead?.Users?.Any(x => x.UserId == currentUserId) ?? false;
        }


        /// <summary>
        /// Check whether the current user can view attachments on Leads.
        /// </summary>
        /// <returns>True or False</returns>
        internal bool HasAccessToViewAttachments(bool isUserAssignedToLead)
        {
            var currentUser = GetCurrentUser();

            var canViewAttachments = UserManager.IsGranted(currentUser.Id, AppPermissions.Pages_Leads_View_Attachments);
            var canViewAttachmentsDynamic = UserManager.IsGranted(currentUser.Id, AppPermissions.Pages_Leads_View_Attachments__Dynamic);

            return canViewAttachments || (canViewAttachmentsDynamic && isUserAssignedToLead);
        }

        /// <summary>
        /// Check whether the current user can add attachments Leads.
        /// </summary>
        /// <returns>True or False</returns>
        internal bool HasAccessToAddAttachments(bool isUserAssignedToLead)
        {
            var currentUser = GetCurrentUser();

            var canAddAttachments = UserManager.IsGranted(currentUser.Id, AppPermissions.Pages_Leads_Add_Attachments);
            var canAddAttachmentsDynamic = UserManager.IsGranted(currentUser.Id, AppPermissions.Pages_Leads_Add_Attachments__Dynamic);

            return canAddAttachments || (canAddAttachmentsDynamic && isUserAssignedToLead);
        }

        /// <summary>
        /// Check whether the current user can edit attachments Leads.
        /// </summary>
        /// <returns>True or False</returns>
        internal bool HasAccessToEditAttachments(bool isUserAssignedToLead)
        {
            var currentUser = GetCurrentUser();

            var canEditAttachments = UserManager.IsGranted(currentUser.Id, AppPermissions.Pages_Leads_Edit_Attachments);
            var canEditAttachmentsDynamic = UserManager.IsGranted(currentUser.Id, AppPermissions.Pages_Leads_Edit_Attachments__Dynamic);

            return canEditAttachments || (canEditAttachmentsDynamic && isUserAssignedToLead);
        }

        /// <summary>
        /// Check whether the current user can download attachments Leads.
        /// </summary>
        /// <returns>True or False</returns>
        internal bool HasAccessToDownloadAttachments(bool isUserAssignedToLead)
        {
            var currentUser = GetCurrentUser();

            var canDownloadAttachments = UserManager.IsGranted(currentUser.Id, AppPermissions.Pages_Leads_Download_Attachments);
            var canDownloadAttachmentsDynamic = UserManager.IsGranted(currentUser.Id, AppPermissions.Pages_Leads_Download_Attachments__Dynamic);

            return canDownloadAttachments || (canDownloadAttachmentsDynamic && isUserAssignedToLead);
        }

        /// <summary>
        /// Check whether the current user can remove attachments Leads.
        /// </summary>
        /// <returns>True or False</returns>
        internal bool HasAccessToRemoveAttachments(bool isUserAssignedToLead)
        {
            var currentUser = GetCurrentUser();

            var canRemoveAttachments = UserManager.IsGranted(currentUser.Id, AppPermissions.Pages_Leads_Remove_Attachments);
            var canRemoveAttachmentsDynamic = UserManager.IsGranted(currentUser.Id, AppPermissions.Pages_Leads_Remove_Attachments__Dynamic);

            return canRemoveAttachments || (canRemoveAttachmentsDynamic && isUserAssignedToLead);
        }
    }
}