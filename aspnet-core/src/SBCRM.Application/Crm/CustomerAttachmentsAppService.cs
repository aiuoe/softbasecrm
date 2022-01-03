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
    [AbpAuthorize(AppPermissions.Pages_CustomerAttachments)]
    public class CustomerAttachmentsAppService : SBCRMAppServiceBase, ICustomerAttachmentsAppService
    {
        private readonly IRepository<CustomerAttachment> _customerAttachmentRepository;
        private readonly ICustomerAttachmentsExcelExporter _customerAttachmentsExcelExporter;

        public CustomerAttachmentsAppService(IRepository<CustomerAttachment> customerAttachmentRepository, ICustomerAttachmentsExcelExporter customerAttachmentsExcelExporter)
        {
            _customerAttachmentRepository = customerAttachmentRepository;
            _customerAttachmentsExcelExporter = customerAttachmentsExcelExporter;

        }

        public async Task<PagedResultDto<GetCustomerAttachmentForViewDto>> GetAll(GetAllCustomerAttachmentsInput input)
        {

            var filteredCustomerAttachments = _customerAttachmentRepository.GetAll()
                        .WhereIf(!string.IsNullOrWhiteSpace(input.Filter), e => false || e.Name.Contains(input.Filter) || e.FilePath.Contains(input.Filter))
                        .WhereIf(!string.IsNullOrWhiteSpace(input.NameFilter), e => e.Name == input.NameFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.FilePathFilter), e => e.FilePath == input.FilePathFilter);

            var pagedAndFilteredCustomerAttachments = filteredCustomerAttachments
                .OrderBy(input.Sorting ?? "id asc")
                .PageBy(input);

            var customerAttachments = from o in pagedAndFilteredCustomerAttachments
                                      select new
                                      {

                                          o.Name,
                                          o.FilePath,
                                          Id = o.Id
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
                    }
                };

                results.Add(res);
            }

            return new PagedResultDto<GetCustomerAttachmentForViewDto>(
                totalCount,
                results
            );

        }

        public async Task<GetCustomerAttachmentForViewDto> GetCustomerAttachmentForView(int id)
        {
            var customerAttachment = await _customerAttachmentRepository.GetAsync(id);

            var output = new GetCustomerAttachmentForViewDto { CustomerAttachment = ObjectMapper.Map<CustomerAttachmentDto>(customerAttachment) };

            return output;
        }

        [AbpAuthorize(AppPermissions.Pages_CustomerAttachments_Edit)]
        public async Task<GetCustomerAttachmentForEditOutput> GetCustomerAttachmentForEdit(EntityDto input)
        {
            var customerAttachment = await _customerAttachmentRepository.FirstOrDefaultAsync(input.Id);

            var output = new GetCustomerAttachmentForEditOutput { CustomerAttachment = ObjectMapper.Map<CreateOrEditCustomerAttachmentDto>(customerAttachment) };

            return output;
        }

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

        [AbpAuthorize(AppPermissions.Pages_CustomerAttachments_Create)]
        protected virtual async Task Create(CreateOrEditCustomerAttachmentDto input)
        {
            var customerAttachment = ObjectMapper.Map<CustomerAttachment>(input);

            await _customerAttachmentRepository.InsertAsync(customerAttachment);

        }

        [AbpAuthorize(AppPermissions.Pages_CustomerAttachments_Edit)]
        protected virtual async Task Update(CreateOrEditCustomerAttachmentDto input)
        {
            var customerAttachment = await _customerAttachmentRepository.FirstOrDefaultAsync((int)input.Id);
            ObjectMapper.Map(input, customerAttachment);

        }

        [AbpAuthorize(AppPermissions.Pages_CustomerAttachments_Delete)]
        public async Task Delete(EntityDto input)
        {
            await _customerAttachmentRepository.DeleteAsync(input.Id);
        }

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