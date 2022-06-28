using System.ComponentModel.DataAnnotations;
using Abp.Runtime.Validation;
using MediatR;
using SBCRM.Modules.Administration.Dtos;

namespace SBCRM.Modules.Administration.Comapny.Commands
{
    /// <summary>
    /// Create company use case command
    /// </summary>
    public class CreateCompanyCommand : IRequest<GetCompanyForEditDto>, ICustomValidate
    {
        public string Name { get; set; }

        /// <summary>
        /// Validation command
        /// </summary>
        /// <param name="context"></param>
        public void AddValidationErrors(CustomValidationContext context)
        {
            if (string.IsNullOrWhiteSpace(Name))
            {
                context.Results.Add(new ValidationResult(context.GetLocalizationMessage("NameIsRequired")));
            }
        }
    }
}
