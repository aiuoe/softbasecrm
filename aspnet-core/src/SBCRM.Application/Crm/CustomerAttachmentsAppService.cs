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
using SBCRM.Legacy;

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
        private readonly IRepository<Customer> _lookup_customerRepository;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="customerAttachmentRepository"></param>
        /// <param name="customerAttachmentsExcelExporter"></param>
        public CustomerAttachmentsAppService(
            IRepository<CustomerAttachment> customerAttachmentRepository, 
            ICustomerAttachmentsExcelExporter customerAttachmentsExcelExporter,
            IRepository<Customer> customerRepository)
        {
            _customerAttachmentRepository = customerAttachmentRepository;
            _customerAttachmentsExcelExporter = customerAttachmentsExcelExporter;
            _lookup_customerRepository = customerRepository;
        }

        /// <summary>
        /// Get all customer attachments filtered by an input
        /// </summary>
        /// <param name="input">An input filter</param>
        /// <returns></returns>
        [AbpAuthorize(AppPermissions.Pages_Customer)]
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
        [AbpAuthorize(
            AppPermissions.Pages_Customer_View_Attachments,
            AppPermissions.Pages_Customer_View_Attachments__Dynamic
        )]
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
        [AbpAuthorize(
            AppPermissions.Pages_Customer_Edit_Attachments,
            AppPermissions.Pages_Customer_Edit_Attachments__Dynamic
        )]
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
        [AbpAuthorize(
            AppPermissions.Pages_Customer_Add_Attachments,
            AppPermissions.Pages_Customer_Add_Attachments__Dynamic,
            AppPermissions.Pages_Customer_Edit_Attachments,
            AppPermissions.Pages_Customer_Edit_Attachments__Dynamic
        )]
        public async Task CreateOrEdit(CreateOrEditCustomerAttachmentDto input)
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
        /// Creates an attachment.
        /// </summary>
        /// <param name="input">An attachment to be created.</param>
        /// <returns></returns>
        [AbpAuthorize(
            AppPermissions.Pages_Customer_Add_Attachments,
            AppPermissions.Pages_Customer_Add_Attachments__Dynamic
        )]
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
        [AbpAuthorize(
            AppPermissions.Pages_Customer_Edit_Attachments,
            AppPermissions.Pages_Customer_Edit_Attachments__Dynamic
        )]
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
        [AbpAuthorize(
            AppPermissions.Pages_Customer_Remove_Attachments,
            AppPermissions.Pages_Customer_Remove_Attachments__Dynamic
        )]
        public async Task Delete(EntityDto input)
        {
            await _customerAttachmentRepository.DeleteAsync(input.Id);
        }

        /// <summary>
        /// Lists the customer atttachments on an Excel file.
        /// </summary>
        /// <param name="input">An input filter</param>
        /// <returns>The excel file</returns>
        [AbpAuthorize(AppPermissions.Pages_Customer)]
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

        /// <summary>
        /// Get a customers
        /// </summary>
        /// <param name="customerNumber"></param>
        /// <returns></returns>
        [AbpAuthorize(AppPermissions.Pages_Customer)]
        public async Task<CustomerAttachmentCustomerLookupTableDto> GetCustomerForPermissions(string customerNumber = null)
        {
            var isUserAssignedToCustomer = false;
            if (customerNumber != null)
                isUserAssignedToCustomer = VerifyUserIsAssignedCustomer(customerNumber);

            return await _lookup_customerRepository.GetAll()
                .WhereIf(customerNumber != null, x => x.Number == customerNumber)
                .Select(customer => new CustomerAttachmentCustomerLookupTableDto
                {
                    Number = customer.Number,
                    Name = customer == null || customer.Name == null ? "" : customer.Name.ToString(),
                    CanViewAttachments = HasAccessToViewAttachments(isUserAssignedToCustomer),
                    CanAddAttachments = HasAccessToAddAttachments(isUserAssignedToCustomer),
                    CanEditAttachments = HasAccessToEditAttachments(isUserAssignedToCustomer),
                    CanDownloadAttachments = HasAccessToDownloadAttachments(isUserAssignedToCustomer),
                    CanRemoveAttachments = HasAccessToRemoveAttachments(isUserAssignedToCustomer),
                }).FirstOrDefaultAsync();
        }

        /// <summary>
        /// Verify if the current user is assigned to the specified Customer
        /// </summary>
        /// <param name="customerNumber"></param>
        /// <returns></returns>
        internal bool VerifyUserIsAssignedCustomer(string customerNumber = null)
        {
            CustomerAttachmentCustomerLookupTableDto customer = _lookup_customerRepository.GetAll()
                .WhereIf(customerNumber != null, x => x.Number == customerNumber)
                .Select(customer => new CustomerAttachmentCustomerLookupTableDto
                {
                    Users = ObjectMapper.Map<List<AccountUserDto>>(customer.Users)
                }).FirstOrDefault();

            long currentUserId = GetCurrentUser().Id;
            return customer?.Users?.Any(x => x.UserId == currentUserId) ?? false;
        }


        /// <summary>
        /// Check whether the current user can view attachments on Customers
        /// </summary>
        /// <returns>True or False</returns>
        internal bool HasAccessToViewAttachments(bool isUserAssignedToCustomer)
        {
            var currentUser = GetCurrentUser();

            var canViewAttachments = UserManager.IsGranted(currentUser.Id, AppPermissions.Pages_Customer_View_Attachments);
            var canViewAttachmentsDynamic = UserManager.IsGranted(currentUser.Id, AppPermissions.Pages_Customer_View_Attachments__Dynamic);

            return canViewAttachments || (canViewAttachmentsDynamic && isUserAssignedToCustomer);
        }

        /// <summary>
        /// Check whether the current user can add attachments Customers.
        /// </summary>
        /// <returns>True or False</returns>
        internal bool HasAccessToAddAttachments(bool isUserAssignedToCustomer)
        {
            var currentUser = GetCurrentUser();

            var canAddAttachments = UserManager.IsGranted(currentUser.Id, AppPermissions.Pages_Customer_Add_Attachments);
            var canAddAttachmentsDynamic = UserManager.IsGranted(currentUser.Id, AppPermissions.Pages_Customer_Add_Attachments__Dynamic);

            return canAddAttachments || (canAddAttachmentsDynamic && isUserAssignedToCustomer);
        }

        /// <summary>
        /// Check whether the current user can edit attachments Customers.
        /// </summary>
        /// <returns>True or False</returns>
        internal bool HasAccessToEditAttachments(bool isUserAssignedToCustomer)
        {
            var currentUser = GetCurrentUser();

            var canEditAttachments = UserManager.IsGranted(currentUser.Id, AppPermissions.Pages_Customer_Edit_Attachments);
            var canEditAttachmentsDynamic = UserManager.IsGranted(currentUser.Id, AppPermissions.Pages_Customer_Edit_Attachments__Dynamic);

            return canEditAttachments || (canEditAttachmentsDynamic && isUserAssignedToCustomer);
        }

        /// <summary>
        /// Check whether the current user can download attachments Customers.
        /// </summary>
        /// <returns>True or False</returns>
        internal bool HasAccessToDownloadAttachments(bool isUserAssignedToCustomer)
        {
            var currentUser = GetCurrentUser();

            var canDownloadAttachments = UserManager.IsGranted(currentUser.Id, AppPermissions.Pages_Customer_Download_Attachments);
            var canDownloadAttachmentsDynamic = UserManager.IsGranted(currentUser.Id, AppPermissions.Pages_Customer_Download_Attachments__Dynamic);

            return canDownloadAttachments || (canDownloadAttachmentsDynamic && isUserAssignedToCustomer);
        }

        /// <summary>
        /// Check whether the current user can remove attachments Customers.
        /// </summary>
        /// <returns>True or False</returns>
        internal bool HasAccessToRemoveAttachments(bool isUserAssignedToCustomer)
        {
            var currentUser = GetCurrentUser();

            var canRemoveAttachments = UserManager.IsGranted(currentUser.Id, AppPermissions.Pages_Customer_Remove_Attachments);
            var canRemoveAttachmentsDynamic = UserManager.IsGranted(currentUser.Id, AppPermissions.Pages_Customer_Remove_Attachments__Dynamic);

            return canRemoveAttachments || (canRemoveAttachmentsDynamic && isUserAssignedToCustomer);
        }

    }
}