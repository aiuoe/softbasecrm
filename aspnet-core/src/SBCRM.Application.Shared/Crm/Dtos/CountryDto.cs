using Abp.Application.Services.Dto;

namespace SBCRM.Crm.Dtos
{
    /// <summary>
    /// DTO to manage the object country
    /// </summary>
    public class CountryDto : EntityDto
    {
        public string Name { get; set; }

        public string Code { get; set; }

    }
}