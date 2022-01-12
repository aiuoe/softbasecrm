using System;
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
using Abp.Extensions;
using Abp.Authorization;
using Microsoft.EntityFrameworkCore;
using Abp.UI;
using SBCRM.Storage;

namespace SBCRM.Crm
{
    /// <summary>
    /// A service for customer attachments.
    /// </summary>
    [AbpAuthorize(AppPermissions.Pages_CustomerAttachments)]
    public class CustomerAttachmentsAppService : SBCRMAppServiceBase, ICustomerAttachmentsAppService
    {
        private readonly IRepository<CustomerAttachment> _customerAttachmentRepository;
        private readonly ICustomerAttachmentsExcelExporter _customerAttachmentsExcelExporter;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="customerAttachmentRepository"></param>
        /// <param name="customerAttachmentsExcelExporter"></param>
        public CustomerAttachmentsAppService(IRepository<CustomerAttachment> customerAttachmentRepository, ICustomerAttachmentsExcelExporter customerAttachmentsExcelExporter)
        {
            _customerAttachmentRepository = customerAttachmentRepository;
            _customerAttachmentsExcelExporter = customerAttachmentsExcelExporter;

        }

        /// <summary>
        /// Get all customer attachments filtered by an input
        /// </summary>
        /// <param name="input">An input filter</param>
        /// <returns></returns>
        public async Task<PagedResultDto<GetCustomerAttachmentForViewDto>> GetAll(GetAllCustomerAttachmentsInput input)
        {

            var filteredCustomerAttachments = _customerAttachmentRepository.GetAll()
                        .Include(e => e.CustomerFk)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.Filter), e => false || e.Name.Contains(input.Filter) || e.FilePath.Contains(input.Filter))
                        .WhereIf(!string.IsNullOrWhiteSpace(input.NameFilter), e => e.Name == input.NameFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.FilePathFilter), e => e.FilePath == input.FilePathFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.CustomerNumberFilter), e => e.CustomerNumber == input.CustomerNumberFilter);

            var pagedAndFilteredCustomerAttachments = filteredCustomerAttachments
                .OrderBy(input.Sorting ?? "id asc")
                .PageBy(input);

            var customerAttachments = from o in pagedAndFilteredCustomerAttachments
                                      select new
                                      {

                                          o.Name,
                                          o.FilePath,
                                          Id = o.Id,
                                          o.CustomerNumber
                                      };

            var totalCount = await filteredCustomerAttachments.CountAsync();

            var dbList = await customerAttachments.ToListAsync();
            var results = new List<GetCustomerAttachmentForViewDto>();

            foreach (var o in dbList)
            {
                var res = new GetCustomerAttachmentForViewDto()
                {
                    CustomerAttachment = new CustomerAttachmentDto
                    {

                        Name = o.Name,
                        FilePath = o.FilePath,
                        Id = o.Id,
                        CustomerNumber = o.CustomerNumber
                    }
                };

                results.Add(res);
            }

            return new PagedResultDto<GetCustomerAttachmentForViewDto>(
                totalCount,
                results
            );

        }

        /// <summary>
        /// Gets a customer attachment for viewing
        /// </summary>
        /// <param name="id">An Id of the customer attachment to be viewed.</param>
        /// <returns></returns>
        public async Task<GetCustomerAttachmentForViewDto> GetCustomerAttachmentForView(int id)
        {
            var customerAttachment = await _customerAttachmentRepository.GetAsync(id);

            var output = new GetCustomerAttachmentForViewDto { CustomerAttachment = ObjectMapper.Map<CustomerAttachmentDto>(customerAttachment) };

            return output;
        }

        /// <summary>
        /// Gets a customer attachment for editing
        /// </summary>
        /// <param name="id">An Id of the customer attachment to be edited.</param>
        /// <returns></returns>
        [AbpAuthorize(AppPermissions.Pages_CustomerAttachments_Edit)]
        public async Task<GetCustomerAttachmentForEditOutput> GetCustomerAttachmentForEdit(EntityDto input)
        {
            var customerAttachment = await _customerAttachmentRepository.FirstOrDefaultAsync(input.Id);

            var output = new GetCustomerAttachmentForEditOutput { CustomerAttachment = ObjectMapper.Map<CreateOrEditCustomerAttachmentDto>(customerAttachment) };

            return output;
        }

        /// <summary>
        /// Creates or edits an attachment.
        /// </summary>
        /// <param name="input">An attachment to be created or edited.</param>
        /// <returns></returns>
        public async Task CreateOrEdit(CreateOrEditCustomerAttachmentDto input)
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
        [AbpAuthorize(AppPermissions.Pages_CustomerAttachments_Create)]
        protected virtual async Task Create(CreateOrEditCustomerAttachmentDto input)
        {
            var customerAttachment = ObjectMapper.Map<CustomerAttachment>(input);

            await _customerAttachmentRepository.InsertAsync(customerAttachment);

        }

        /// <summary>
        /// Updates an exiting attachment.
        /// </summary>
        /// <param name="input">An attachment to be updated.</param>
        /// <returns></returns>
        [AbpAuthorize(AppPermissions.Pages_CustomerAttachments_Edit)]
        protected virtual async Task Update(CreateOrEditCustomerAttachmentDto input)
        {
            var customerAttachment = await _customerAttachmentRepository.FirstOrDefaultAsync((int)input.Id);
            ObjectMapper.Map(input, customerAttachment);

        }

        /// <summary>
        /// Deletes an attachment.
        /// </summary>
        /// <param name="input">An attachment to be deleted.</param>
        /// <returns></returns>
        [AbpAuthorize(AppPermissions.Pages_CustomerAttachments_Delete)]
        public async Task Delete(EntityDto input)
        {
            await _customerAttachmentRepository.DeleteAsync(input.Id);
        }

        /// <summary>
        /// Lists the customer atttachments on an Excel file.
        /// </summary>
        /// <param name="input">An input filter</param>
        /// <returns>The excel file</returns>
        public async Task<FileDto> GetCustomerAttachmentsToExcel(GetAllCustomerAttachmentsForExcelInput input)
        {

            var filteredCustomerAttachments = _customerAttachmentRepository.GetAll()
                        .WhereIf(!string.IsNullOrWhiteSpace(input.Filter), e => false || e.Name.Contains(input.Filter) || e.FilePath.Contains(input.Filter))
                        .WhereIf(!string.IsNullOrWhiteSpace(input.NameFilter), e => e.Name == input.NameFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.FilePathFilter), e => e.FilePath == input.FilePathFilter);

            var query = (from o in filteredCustomerAttachments
                         select new GetCustomerAttachmentForViewDto()
                         {
                             CustomerAttachment = new CustomerAttachmentDto
                             {
                                 Name = o.Name,
                                 FilePath = o.FilePath,
                                 Id = o.Id
                             }
                         });

            var customerAttachmentListDtos = await query.ToListAsync();

            return _customerAttachmentsExcelExporter.ExportToFile(customerAttachmentListDtos);
        }

    }
}