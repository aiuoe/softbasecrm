using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SBCRM.Legacy
{
    [Table("ARTerms", Schema = "dbo")]
    public class ARTerms
    {
        [Key]
        [Required]
        [StringLength(ARTermsConsts.MaxTermsLength, MinimumLength = ARTermsConsts.MinTermsLength)]
        public virtual string Terms { get; set; }

        public virtual short? COD { get; set; }

        public virtual short? DaysDue { get; set; }

        public virtual short? Days { get; set; }

        public virtual short? DayOfMonth { get; set; }

        public virtual short? Day { get; set; }

        public virtual short? PrintWaterMark { get; set; }

        [StringLength(ARTermsConsts.MaxAddedByLength, MinimumLength = ARTermsConsts.MinAddedByLength)]
        public virtual string AddedBy { get; set; }

        public virtual DateTime? DateAdded { get; set; }

        [StringLength(ARTermsConsts.MaxChangedByLength, MinimumLength = ARTermsConsts.MinChangedByLength)]
        public virtual string ChangedBy { get; set; }

        public virtual DateTime? DateChanged { get; set; }

        public virtual short? CreditCard { get; set; }

    }
}