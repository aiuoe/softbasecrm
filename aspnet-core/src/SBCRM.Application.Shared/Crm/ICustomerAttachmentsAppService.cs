using System;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using SBCRM.Crm.Dtos;
using SBCRM.Dto;

namespace SBCRM.Crm
{
    /// <summary>
    /// A service for customer attachments.
    /// </summary>
    public interface ICustomerAttachmentsAppService : IApplicationService
    {
        /// <summary>
        /// Get all customer attachments filtered by an input
        /// </summary>
        /// <param name="input">An input filter</param>
        /// <returns></returns>
        Task<PagedResultDto<GetCustomerAttachmentForViewDto>> GetAll(GetAllCustomerAttachmentsInput input);

        /// <summary>
        /// Gets a customer attachment for viewing
        /// </summary>
        /// <param name="id">An Id of the customer attachment to be viewed.</param>
        /// <returns></returns>
        Task<GetCustomerAttachmentForViewDto> GetCustomerAttachmentForView(int id);

        /// <summary>
        /// Gets a customer attachment for editing
        /// </summary>
        /// <param name="id">An Id of the customer attachment to be edited.</param>
        /// <returns></returns>
        Task<GetCustomerAttachmentForEditOutput> GetCustomerAttachmentForEdit(EntityDto input);

        /// <summary>
        /// Creates or edits an attachment.
        /// </summary>
        /// <param name="input">An attachment to be created or edited.</param>
        /// <returns></returns>
        Task CreateOrEdit(CreateOrEditCustomerAttachmentDto input);

        /// <summary>
        /// Deletes an attachment.
        /// </summary>
        /// <param name="input">An attachment to be deleted.</param>
        /// <returns></returns>
        Task Delete(EntityDto input);

        /// <summary>
        /// Lists the customer atttachments on an Excel file.
        /// </summary>
        /// <param name="input">An input filter</param>
        /// <returns>The excel file</returns>
        Task<FileDto> GetCustomerAttachmentsToExcel(GetAllCustomerAttachmentsForExcelInput input);

        /// <summary>
        /// Get a customers
        /// </summary>
        /// <param name="customerNumber"></param>
        /// <returns></returns>
        Task<CustomerAttachmentPermissionsDto> GetWidgetPermissionsForCustomer(string customerNumber);

    }
}