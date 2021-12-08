using System;
using Abp.Application.Services.Dto;
using System.ComponentModel.DataAnnotations;

namespace SBCRM.Legacy.Dtos
{
    public class CreateOrEditARTermsDto
    {

        [Required]
        [StringLength(ARTermsConsts.MaxTermsLength, MinimumLength = ARTermsConsts.MinTermsLength)]
        public string Terms { get; set; }

        public short? COD { get; set; }

        public short? DaysDue { get; set; }

        public short? Days { get; set; }

        public short? DayOfMonth { get; set; }

        public short? Day { get; set; }

        public short? PrintWaterMark { get; set; }

        [StringLength(ARTermsConsts.MaxAddedByLength, MinimumLength = ARTermsConsts.MinAddedByLength)]
        public string AddedBy { get; set; }

        public DateTime? DateAdded { get; set; }

        [StringLength(ARTermsConsts.MaxChangedByLength, MinimumLength = ARTermsConsts.MinChangedByLength)]
        public string ChangedBy { get; set; }

        public DateTime? DateChanged { get; set; }

        public short? CreditCard { get; set; }

    }
}