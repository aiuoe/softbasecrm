using System.ComponentModel.DataAnnotations;
using Abp.Runtime.Validation;

namespace SBCRM.Legacy.Dtos
{
    public class ConvertLeadToAccountRequestDto : ICustomValidate
    {
        [Required]
        public int LeadId { get; set; }
        
        public void AddValidationErrors(CustomValidationContext context)
        {
        }
    }
}