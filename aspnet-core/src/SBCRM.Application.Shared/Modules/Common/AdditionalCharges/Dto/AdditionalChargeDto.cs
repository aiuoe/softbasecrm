using System;
using System.Collections.Generic;
using System.Text;

namespace SBCRM.Modules.Common.AdditionalCharges.Dto
{
    public class AdditionalChargeDto
    {
        public string Branch { get; set; }
        public string Dept { get; set; }
        public string MiscDescription { get; set; }
        public string MiscPercentage { get; set; }
        public string MiscSaleAccount { get; set; }
        public string AmountLimit { get; set; }
        public bool? LaborOnly { get; set; }
        public bool? PartsOnly { get; set; }
        public bool? Taxable { get; set; }
        public string AmountMin { get; set; }
        public DateTime? Created { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? Updated { get; set; }
        public string UpdatedBy { get; set; }
    }
}
