using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SBCRM.Legacy
{
    /// <summary>
    /// WO entity from legacy schema
    /// </summary>
    [Table("WO", Schema = "dbo")]
    public class WO
    {
        [Key]
        public virtual int? WONo { get; set; }
        public virtual string PoNo { get; set; }
        public virtual int? RentalContractNo { get; set; }
        public virtual string SerialNo { get; set; }
        public virtual string BillTo { get; set; }
        public virtual string ShipTo { get; set; }
        public virtual string UnitNo { get; set; }
        public virtual int? AssociatedWONo { get; set; }
        public virtual int? NumeroDeFactura { get; set; }
        public virtual short? Disposition { get; set; }
        public virtual string Make { get; set; }
        public virtual string Model { get; set; }
        public virtual string Salesman { get; set; }
        public virtual short? CustomerSale { get; set; }
        public virtual DateTime? OpenDate { get; set; }
    }
}
