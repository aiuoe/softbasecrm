using Abp.Runtime.Validation;
using MediatR;
using SBCRM.Modules.Common.AdditionalCharges.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBCRM.Modules.Common.AdditionalCharges.Commands
{
    public class CreateAdditionalChargesCommand : IRequest<CreatedAdditionalChargeResponseDto>, ICustomValidate
    {
        public CreateAdditionalChargesCommand(AdditionalChargeDto additionalCharges)
        {
            this.AdditionalCharges = additionalCharges;
        }

        public AdditionalChargeDto AdditionalCharges { get; set; }

        public void AddValidationErrors(CustomValidationContext context)
        {
            /*
			 * TO DO: need to verify Branch & Dept is Numeric. i.e. short.TryParse(Branch, out _) 
			 */
            if (string.IsNullOrWhiteSpace(AdditionalCharges.Branch) || string.IsNullOrWhiteSpace(AdditionalCharges.Dept))
            {
                context.Results.Add(new ValidationResult(context.GetLocalizationMessage("DeptOrBranchWasNotProperlyGiven")));
            }
        }
    }
}
