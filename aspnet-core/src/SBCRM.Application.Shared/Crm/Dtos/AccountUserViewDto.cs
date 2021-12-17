using System;
using Abp.Application.Services.Dto;

namespace SBCRM.Crm.Dtos
{
    /// <summary>
    /// DTO to manage the object account user assigned
    /// </summary>
    public class AccountUserViewDto : EntityDto
    {
        public long UserId { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public Guid? ProfilePictureUrl { get; set; }
        public string FullName { get; set; }
    }
}
