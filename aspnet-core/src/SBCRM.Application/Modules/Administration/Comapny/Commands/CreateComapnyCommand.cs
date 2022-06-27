using System.ComponentModel.DataAnnotations;
using Abp.Runtime.Validation;
using MediatR;
using SBCRM.Modules.Administration.Dtos;

namespace SBCRM.Modules.Administration.Comapny.Commands
{
    public class CreateComapnyCommand : IRequest<GetCompanyForEditDto>, ICustomValidate
    {
        public string Name { get; set; }

        public void AddValidationErrors(CustomValidationContext context)
        {
            if (string.IsNullOrWhiteSpace(Name))
            {
                context.Results.Add(new ValidationResult(context.GetLocalizationMessage("NameIsRequired")));
            }
        }
    }
}
