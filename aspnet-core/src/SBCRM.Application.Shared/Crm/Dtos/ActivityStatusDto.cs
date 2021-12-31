using Abp.Application.Services.Dto;

namespace SBCRM.Crm.Dtos
{
    /// <summary>
    /// Dto for the Activity Status entity
    /// </summary>
    public class ActivityStatusDto : EntityDto
    {
        public string Description { get; set; }

        public int Order { get; set; }

        public string Color { get; set; }

        public bool IsCompletedStatus { get; set; }
    }
}