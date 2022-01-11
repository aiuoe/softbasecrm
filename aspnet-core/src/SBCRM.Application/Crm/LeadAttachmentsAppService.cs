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
    [AbpAuthorize(AppPermissions.Pages_LeadAttachments)]
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
        [AbpAuthorize(AppPermissions.Pages_LeadAttachments_Edit)]
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
        [AbpAuthorize(AppPermissions.Pages_LeadAttachments_Create)]
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
        [AbpAuthorize(AppPermissions.Pages_LeadAttachments_Edit)]
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
        [AbpAuthorize(AppPermissions.Pages_LeadAttachments_Delete)]
        public async Task Delete(EntityDto input)
        {
            await _leadAttachmentRepository.DeleteAsync(input.Id);
        }


        /// <summary>
        /// Lists the lead atttachments on an Excel file.
        /// </summary>
        /// <param name="input">An input filter</param>
        /// <returns>The excel file</returns>
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
        /// <returns></returns>
        [AbpAuthorize(AppPermissions.Pages_LeadAttachments)]
        public async Task<List<LeadAttachmentLeadLookupTableDto>> GetAllLeadForTableDropdown()
        {
            return await _lookup_leadRepository.GetAll()
                .Select(lead => new LeadAttachmentLeadLookupTableDto
                {
                    Id = lead.Id,
                    DisplayName = lead == null || lead.CompanyName == null ? "" : lead.CompanyName.ToString()
                }).ToListAsync();
        }

    }
}