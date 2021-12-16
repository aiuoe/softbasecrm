using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SBCRM.Legacy
{
    /// <summary>
    /// Equipment entity from legacy schema
    /// </summary>
    [Table("EQCustomFields", Schema = "dbo")]
    public class EQCustomFields
    {
        [Key]
        public virtual string SerialNo { get; set; }
        public virtual string Custom01 { get; set; }
        public virtual string Custom02 { get; set; }
        public virtual string Custom03 { get; set; }
        public virtual string Custom04 { get; set; }
        public virtual string Custom05 { get; set; }
        public virtual string Custom06 { get; set; }
        public virtual string Custom07 { get; set; }
        public virtual string Custom08 { get; set; }
        public virtual string Custom09 { get; set; }
        public virtual string Custom010 { get; set; }
        public virtual string Custom011 { get; set; }
        public virtual string Custom012 { get; set; }
        public virtual string Custom013 { get; set; }
        public virtual string Custom014 { get; set; }
        public virtual string Custom015 { get; set; }
        public virtual string Custom016 { get; set; }
        public virtual string Custom017 { get; set; }
        public virtual string Custom018 { get; set; }
        public virtual string Custom019 { get; set; }
        public virtual string Custom020 { get; set; }
    }
}
