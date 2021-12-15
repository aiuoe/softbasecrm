using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SBCRM.Legacy
{
    /// <summary>
    /// Invoice entity from legacy schema
    /// </summary>
    [Table("InvoiceReg", Schema = "dbo")]
    public class InvoiceReg
    {
        [Key]
        public virtual int? InvoiceNo { get; set; }
        public virtual decimal? GrandTotal { get; set; }
        public virtual string SerialNo { get; set; }
        public virtual decimal? TotalTax { get; set; }
        public virtual decimal? RentalTaxable { get; set; }
        public virtual decimal? RentalNonTax { get; set; }
        public virtual decimal? EquipmentTaxable { get; set; }
        public virtual decimal? EquipmentNonTax { get; set; }
        public virtual short? Customer { get; set; }

    }
}
