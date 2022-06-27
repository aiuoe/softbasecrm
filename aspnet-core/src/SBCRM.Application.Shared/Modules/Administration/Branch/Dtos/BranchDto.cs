using Abp.Application.Services.Dto;

namespace SBCRM.Modules.Administration.Dtos
{
    /// <summary>
    /// Branch DTO class
    /// </summary>
    public class BranchDto : FullAuditedEntityDto<long>
    {
        public short Number { get; set; }
        public string Name { get; set; }
    }
}
