using Abp.Runtime.Validation;
using MediatR;
using SBCRM.Modules.Common.Avalara.Dto;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SBCRM.Modules.Common.Avalara.Queries
{
    /// <summary>
    /// get avalara company codes query
    /// </summary>
    public class GetAvalaraCompanyCodesQuery : IRequest<List<AvalaraCompanyCodes>>, ICustomValidate
    {
        public string AccountNumber { get; set; }
        public string LicenseKey { get; set; }
        public string ServiceUrl { get; set; }
        public int RequestTimeout { get; set; }

        /// <summary>
        /// Validation command
        /// </summary>
        /// <param name="context"></param>
        public void AddValidationErrors(CustomValidationContext context)
        {
            if (string.IsNullOrWhiteSpace(AccountNumber))
            {
                context.Results.Add(new ValidationResult(context.GetLocalizationMessage("AccountNumberRequired")));
            }

            if (string.IsNullOrWhiteSpace(LicenseKey))
            {
                context.Results.Add(new ValidationResult(context.GetLocalizationMessage("LicenseKeyRequired")));
            }

            if (string.IsNullOrWhiteSpace(ServiceUrl))
            {
                context.Results.Add(new ValidationResult(context.GetLocalizationMessage("ServiceUrlRequired")));
            }
        }
    }
}