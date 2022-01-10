using System;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using SBCRM.Crm.Dtos;
using SBCRM.Dto;
using System.Collections.Generic;

namespace SBCRM.Crm
{
    /// <summary>
    /// Service for lead attachments.
    /// </summary>
    public interface ILeadAttachmentsAppService : IApplicationService
    {
        /// <summary>
        /// Get all customer attachments filtered by an input
        /// </summary>
        /// <param name="input">An input filter</param>
        /// <returns></returns>
        Task<PagedResultDto<GetLeadAttachmentForViewDto>> GetAll(GetAllLeadAttachmentsInput input);

        /// <summary>
        /// Gets a lead attachment for viewing
        /// </summary>
        /// <param name="id">An Id of the lead attachment to be viewed.</param>
        /// <returns></returns>
        Task<GetLeadAttachmentForViewDto> GetLeadAttachmentForView(int id);

        /// <summary>
        /// Gets a lead attachment for editing
        /// </summary>
        /// <param name="input">An Id of the lead attachment to be edited.</param>
        /// <returns></returns>
        Task<GetLeadAttachmentForEditOutput> GetLeadAttachmentForEdit(EntityDto input);

        /// <summary>
        /// Creates or edits an attachment.
        /// </summary>
        /// <param name="input">An attachment to be created or edited.</param>
        /// <returns></returns>
        Task CreateOrEdit(CreateOrEditLeadAttachmentDto input);

        /// <summary>
        /// Deletes an attachment.
        /// </summary>
        /// <param name="input">An attachment to be deleted.</param>
        /// <returns></returns>
        Task Delete(EntityDto input);

        /// <summary>
        /// Lists the lead atttachments on an Excel file.
        /// </summary>
        /// <param name="input">An input filter</param>
        /// <returns>The excel file</returns>
        Task<FileDto> GetLeadAttachmentsToExcel(GetAllLeadAttachmentsForExcelInput input);

        /// <summary>
        /// Get a list of leads
        /// </summary>
        /// <returns></returns>
        Task<List<LeadAttachmentLeadLookupTableDto>> GetAllLeadForTableDropdown();

    }
}