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
        public virtual string AttachedTo { get; set; }
    }
}
