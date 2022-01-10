using System;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using SBCRM.Crm.Dtos;
using SBCRM.Dto;
using System.Collections.Generic;

namespace SBCRM.Crm
{
    public interface ILeadAttachmentsAppService : IApplicationService
    {
        Task<PagedResultDto<GetLeadAttachmentForViewDto>> GetAll(GetAllLeadAttachmentsInput input);

        Task<GetLeadAttachmentForViewDto> GetLeadAttachmentForView(int id);

        Task<GetLeadAttachmentForEditOutput> GetLeadAttachmentForEdit(EntityDto input);

        Task CreateOrEdit(CreateOrEditLeadAttachmentDto input);

        Task Delete(EntityDto input);

        Task<FileDto> GetLeadAttachmentsToExcel(GetAllLeadAttachmentsForExcelInput input);

        Task<List<LeadAttachmentLeadLookupTableDto>> GetAllLeadForTableDropdown();

    }
}