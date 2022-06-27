using Abp.Application.Services.Dto;

namespace SBCRM.Modules.Administration.Dtos
{
    public class CompanyDto : FullAuditedEntityDto<long>
    {
        public short Number { get; set; }
        public string Name { get; set; }
    }
}
