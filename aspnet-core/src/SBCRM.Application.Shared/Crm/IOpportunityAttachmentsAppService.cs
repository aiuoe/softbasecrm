using System;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using SBCRM.Crm.Dtos;
using SBCRM.Dto;
using System.Collections.Generic;

namespace SBCRM.Crm
{
    public interface IOpportunityAttachmentsAppService : IApplicationService
    {
        Task<PagedResultDto<GetOpportunityAttachmentForViewDto>> GetAll(GetAllOpportunityAttachmentsInput input);

        Task<GetOpportunityAttachmentForViewDto> GetOpportunityAttachmentForView(int id);

        Task<GetOpportunityAttachmentForEditOutput> GetOpportunityAttachmentForEdit(EntityDto input);

        Task CreateOrEdit(CreateOrEditOpportunityAttachmentDto input);

        Task Delete(EntityDto input);

        Task<List<OpportunityAttachmentOpportunityLookupTableDto>> GetAllOpportunityForTableDropdown();

    }
}