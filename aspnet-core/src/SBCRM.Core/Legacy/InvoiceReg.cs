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

    }
}
