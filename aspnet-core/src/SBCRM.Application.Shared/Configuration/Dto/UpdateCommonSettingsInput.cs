using System.ComponentModel.DataAnnotations;

namespace SBCRM.Configuration.Dto
{

    /// <summary>
    /// DTO used for updating Common Settings 
    /// </summary>
    public class UpdateCommonSettingsInput
    {
        [Required]
        public string SettingName { get; set; }

        [Required]
        public string SettingValue { get; set; }
    }
}
