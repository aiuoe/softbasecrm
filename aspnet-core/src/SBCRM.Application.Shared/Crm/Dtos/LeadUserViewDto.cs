using System;
using System.Collections.Generic;
using System.Text;

namespace SBCRM.Crm.Dtos
{
    /// <summary>
    /// DTO for the lead user object for view
    /// </summary>
    public class LeadUserViewDto
    {
        public int? LeadId { get; set; }
        public long? UserId { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public Guid? ProfilePictureUrl { get; set; }
        public string FullName { get; set; }
    }
}
