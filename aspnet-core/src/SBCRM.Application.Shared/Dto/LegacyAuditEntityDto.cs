using System;

namespace SBCRM.Dto
{
    /// <summary>
    /// DTO to manage the legacy object audit
    /// </summary>
    public class LegacyAuditEntityDto
    {
        public DateTime? Added { get; set; }
        public string AddedBy { get; set; }
        public DateTime? Changed { get; set; }
        public string ChangedBy { get; set; }
    }
}
