using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using SBCRM.Crm.Dtos;
using System.Collections.Generic;

namespace SBCRM.Crm
{
    /// <summary>
    /// Service for opportunity attachments.
    /// </summary>
    public interface IOpportunityAttachmentsAppService : IApplicationService
    {
        /// <summary>
        /// Get all opportunity attachments filtered by an input
        /// </summary>
        /// <param name="input">An input filter</param>
        /// <returns></returns>
        Task<PagedResultDto<GetOpportunityAttachmentForViewDto>> GetAll(GetAllOpportunityAttachmentsInput input);


        /// <summary>
        /// Gets a opportunity attachment for viewing
        /// </summary>
        /// <param name="id">An Id of the lead attachment to be viewed.</param>
        /// <returns></returns>
        Task<GetOpportunityAttachmentForViewDto> GetOpportunityAttachmentForView(int id);


        /// <summary>
        /// Gets a opportunity attachment for editing
        /// </summary>
        /// <param name="input">An Id of the opportunity attachment to be edited.</param>
        /// <returns></returns>
        Task<GetOpportunityAttachmentForEditOutput> GetOpportunityAttachmentForEdit(EntityDto input);


        /// <summary>
        /// Creates or edits an attachment.
        /// </summary>
        /// <param name="input">An attachment to be created or edited.</param>
        /// <returns></returns>
        Task CreateOrEdit(CreateOrEditOpportunityAttachmentDto input);


        /// <summary>
        /// Deletes an attachment.
        /// </summary>
        /// <param name="input">An attachment to be deleted.</param>
        /// <returns></returns>
        Task Delete(EntityDto input);


        /// <summary>
        /// Get a list of opportunities
        /// </summary>
        /// <returns></returns>
        Task<List<OpportunityAttachmentOpportunityLookupTableDto>> GetAllOpportunityForTableDropdown();

    }
}