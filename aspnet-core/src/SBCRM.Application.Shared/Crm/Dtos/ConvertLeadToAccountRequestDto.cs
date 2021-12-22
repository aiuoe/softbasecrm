using System.ComponentModel.DataAnnotations;
using Abp.Runtime.Validation;

namespace SBCRM.Legacy.Dtos
{
    /// <summary>
    /// DTO that containing the information on the conversion of
    /// a Lead to an Account from an Lead endpoint perspective.
    /// </summary>
    public class ConvertLeadToAccountRequestDto : ICustomValidate
    {
        [Required]
        public int LeadId { get; set; }
        
        /// <summary>
        /// Validations
        /// </summary>
        /// <param name="context"></param>
        public void AddValidationErrors(CustomValidationContext context)
        {
        }
    }
}