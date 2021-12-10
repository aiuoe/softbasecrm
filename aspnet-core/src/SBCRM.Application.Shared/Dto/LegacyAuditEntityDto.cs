using System;

namespace SBCRM.Dto
{
    public class LegacyAuditEntityDto
    {
        public DateTime? Added { get; set; }
        public string AddedBy { get; set; }
        public DateTime? Changed { get; set; }
        public string ChangedBy { get; set; }
    }
}
