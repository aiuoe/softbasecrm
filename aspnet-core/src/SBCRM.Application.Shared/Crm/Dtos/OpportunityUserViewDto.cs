using System;

namespace SBCRM.Crm.Dtos
{
    /// <summary>
    /// DTO to manage the object opportunity user for view purposes
    /// </summary>
    public class OpportunityUserViewDto
    {
        public int? OpportunityId { get; set; }
        public long? UserId { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public Guid? ProfilePictureUrl { get; set; }
        public string FullName { get; set; }
    }
}