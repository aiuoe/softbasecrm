using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SBCRM.Configuration.CommonSettings.Dto
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
