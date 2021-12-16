using Abp.Application.Services.Dto;
using System.ComponentModel.DataAnnotations;

namespace SBCRM.Crm.Dtos
{
    /// <summary>
    /// DTO to manage the object for creation/edition country
    /// </summary>
    public class CreateOrEditCountryDto : EntityDto<int?>
    {

        [Required]
        [StringLength(CountryConsts.MaxNameLength, MinimumLength = CountryConsts.MinNameLength)]
        public string Name { get; set; }

        [Required]
        [StringLength(CountryConsts.MaxCodeLength, MinimumLength = CountryConsts.MinCodeLength)]
        public string Code { get; set; }

    }
}