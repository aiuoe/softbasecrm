using System;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SBCRM.Legacy
{
    /// <summary>
    /// InvoiceReg VIEW from legacy schema
    /// </summary>
    [Keyless]
    public class InvoiceRegList
    {
        public virtual int? WONo { get; set; }

        [ForeignKey("WONo")]
        public virtual WO WoFk { get; set; }
        
        [ForeignKey("WONo")]
        public virtual InvoiceReg InvoiceRegFk { get; set; }

        public virtual string SerialNo { get; set; }
        [ForeignKey("SerialNo")]
        public virtual Equipment EquipmentFk { get; set; }

        public virtual short? Disposition { get; set; }
        public virtual DateTime? InvoiceDate { get; set; }
        public virtual short? CustomerFlag { get; set; }
        public virtual short? SaleBranch { get; set; }
        public virtual short? SaleDept { get; set; }
        public virtual string SaleCode { get; set; }
        public virtual short? ExpBranch { get; set; }
        public virtual short? ExpDept { get; set; }
        public virtual string ExpCode { get; set; }
    }
}
