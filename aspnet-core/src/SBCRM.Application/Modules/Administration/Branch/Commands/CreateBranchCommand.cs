using System.ComponentModel.DataAnnotations;
using Abp.Runtime.Validation;
using MediatR;
using SBCRM.Modules.Administration.Dtos;

namespace SBCRM.Modules.Administration.Branch.Commands
{
    /// <summary>
    /// Create branch use case command
    /// </summary>
    public class CreateBranchCommand : IRequest<GetBranchForEditDto>, ICustomValidate
    {
        public short Number { get; set; }
        public string Name { get; set; }
        public string SubName { get; set; }
        public string Address { get; set; }

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
