using System.ComponentModel.DataAnnotations;

namespace SBCRM.Authorization.Accounts.Dto
{
    public class SendEmailActivationLinkInput
    {
        [Required]
        public string EmailAddress { get; set; }
    }
}