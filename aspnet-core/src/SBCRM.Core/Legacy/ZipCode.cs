using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SBCRM.Legacy
{
    [Table("ZipCode", Schema = "dbo")]
    public class ZipCode
    {
        [Key]
        [Column("ZipCode")]
        [Required]
        [StringLength(ZipCodeConsts.MaxZipCodeLength, MinimumLength = ZipCodeConsts.MinZipCodeLength)]
        public virtual string ZipCodeField { get; set; }

        [StringLength(ZipCodeConsts.MaxCityLength, MinimumLength = ZipCodeConsts.MinCityLength)]
        public virtual string City { get; set; }

        [StringLength(ZipCodeConsts.MaxStateLength, MinimumLength = ZipCodeConsts.MinStateLength)]
        public virtual string State { get; set; }

        [StringLength(ZipCodeConsts.MaxCountyLength, MinimumLength = ZipCodeConsts.MinCountyLength)]
        public virtual string County { get; set; }

        [StringLength(ZipCodeConsts.MaxAddedByLength, MinimumLength = ZipCodeConsts.MinAddedByLength)]
        public virtual string AddedBy { get; set; }

        [StringLength(ZipCodeConsts.MaxChangedByLength, MinimumLength = ZipCodeConsts.MinChangedByLength)]
        public virtual string ChangedBy { get; set; }

        public virtual DateTime? DateAdded { get; set; }

        public virtual DateTime? DateChanged { get; set; }

    }
}