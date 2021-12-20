using System;

namespace SBCRM.Legacy.Dtos
{
    /// <summary>
    /// DTO to manage the object customer for view purposes
    /// </summary>
    public class GetCustomerForViewDto
    {
        public CustomerDto Customer { get; set; }
        public string AccountTypeDescription { get; set; }
        public long? FirstUserAssignedId { get; set; }
        public string FirstUserAssignedName { get; set; }
        public string FirstUserAssignedSurName { get; set; }
        public string FirstUserAssignedFullName { get; set; }
        public Guid? FirstUserProfilePictureUrl { get; set; }
        public int AssignedUsers { get; set; }
    }
}