using System;

namespace SBCRM.Crm.Dtos
{
    /// <summary>
    /// DTO to manage the object the user assigned dto
    /// </summary>
    public class UserAssignedDto
    {

        public string Name { get; set; }

        public string Surname { get; set; }

        public string FullName { get; set; }

        public Guid? ProfilePictureId { get; set; }
    }
}