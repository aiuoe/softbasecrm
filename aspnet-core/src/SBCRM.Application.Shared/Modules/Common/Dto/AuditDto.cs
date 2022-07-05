using System;

namespace SBCRM.Modules.Common.Dto
{
    /// <summary>
    /// partial DTO for Audit
    /// </summary>
    public abstract class AuditDto
    {
        public string CreatorUserName { get; set; }
        public DateTime CreationTime { get; set; }
        public string LastModifierUserName { get; set; }
        public DateTime? LastModificationTime { get; set; }
    }
}
