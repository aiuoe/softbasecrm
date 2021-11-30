using System.ComponentModel.DataAnnotations;

namespace SBCRM.Authorization.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}
