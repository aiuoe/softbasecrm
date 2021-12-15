using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SBCRM.Legacy
{
    /// <summary>
    /// Equipment entity from legacy schema
    /// </summary>
    [Table("Equipment", Schema = "dbo")]
    public class Equipment
    {
        [Key]
        public virtual string SerialNo { get; set; }
        public virtual string CustomerNo { get; set; }
        public virtual string AttachedTo { get; set; }
        public virtual string UnitNo { get; set; }
        public virtual string ModelYear { get; set; }
        public virtual string Make { get; set; }
        public virtual string Model { get; set; }
        public double? DeliveryHourMeter { get; set; }
        public short? Customer { get; set; }
    }
}
