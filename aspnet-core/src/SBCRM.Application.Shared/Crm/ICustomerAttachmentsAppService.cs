using System;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using SBCRM.Crm.Dtos;
using SBCRM.Dto;

namespace SBCRM.Crm
{
    public interface ICustomerAttachmentsAppService : IApplicationService
    {
        Task<PagedResultDto<GetCustomerAttachmentForViewDto>> GetAll(GetAllCustomerAttachmentsInput input);

        Task<GetCustomerAttachmentForViewDto> GetCustomerAttachmentForView(int id);

        Task<GetCustomerAttachmentForEditOutput> GetCustomerAttachmentForEdit(EntityDto input);

        Task CreateOrEdit(CreateOrEditCustomerAttachmentDto input);

        Task Delete(EntityDto input);

        Task<FileDto> GetCustomerAttachmentsToExcel(GetAllCustomerAttachmentsForExcelInput input);

    }
}