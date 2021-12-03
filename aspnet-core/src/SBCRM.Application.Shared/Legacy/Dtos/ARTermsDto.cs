using System;

namespace SBCRM.Legacy.Dtos
{
    public class ARTermsDto
    {
        public string Terms { get; set; }

        public short? COD { get; set; }

        public short? DaysDue { get; set; }

        public short? Days { get; set; }

        public short? DayOfMonth { get; set; }

        public short? Day { get; set; }

        public short? PrintWaterMark { get; set; }

        public string AddedBy { get; set; }

        public DateTime? DateAdded { get; set; }

        public string ChangedBy { get; set; }

        public DateTime? DateChanged { get; set; }

        public short? CreditCard { get; set; }

    }
}