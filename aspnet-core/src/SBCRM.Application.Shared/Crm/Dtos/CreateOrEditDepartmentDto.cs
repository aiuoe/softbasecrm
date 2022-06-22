using System;
using System.Collections.Generic;
using System.Text;
using Abp.Application.Services.Dto;
using Abp.Runtime.Validation;

namespace SBCRM.Crm.Dtos
{
    /// <summary>
    /// Department dto used by the ui to create or edit a department
    /// </summary>
    public class CreateOrEditDepartmentDto : EntityDto<int?>, ICustomValidate
    {
        public string Branch { get; set; }
        public string Department { get; set; }
        public string Title { get; set; }
        public string SaleGroup { get; set; }
        public string ReportingGroup { get; set; }
        public string MechanicGroup { get; set; }
        public string TermsOverride { get; set; }
        public string InvoiceType { get; set; }
        public string InvoiceName { get; set; }
        public string InvoiceFrench { get; set; }
        public bool AllowPartsPricingOverride { get; set; }
        public bool SuppressLaborHours { get; set; }
        public bool TaxAtDealer { get; set; }
        public bool NoCreditCardTransactions { get; set; }
        public bool InitialComments { get; set; }
        public bool SuppressPartsPricing { get; set; }
        public bool NoCreditCheckForQuotes { get; set; }
        public string LaborAccount { get; set; }
        public string EquipmentAccount { get; set; }
        public string CashAccount { get; set; }
        public string CreditCardAccount { get; set; }

        /// <summary>
        /// Custom validator for department
        /// </summary>
        /// <param name="context"></param>
        public void AddValidationErrors(CustomValidationContext context)
        {

        }
    }
}
