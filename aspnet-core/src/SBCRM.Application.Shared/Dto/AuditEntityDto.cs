using System;
using Abp.Application.Services.Dto;

namespace SBCRM.Dto
{
    public class AuditEntityDto : EntityDto
    {
        public DateTime? CreationTime { get; set; }
    }
}
