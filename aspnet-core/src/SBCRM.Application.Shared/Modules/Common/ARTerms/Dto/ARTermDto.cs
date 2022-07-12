using System;
using System.Collections.Generic;
using System.Text;

namespace SBCRM.Modules.Common.ARTerms.Dto
{
    public class ARTermDto
    {
        public string Id { get; set; }  
        public string Terms { get; set; }
        public string Cod { get; set; }
        public string DaysDue { get; set; }
        public string Days { get; set; }
        public string DayOfMonth { get; set; }
        public string Day { get; set; }
        public string PrintWaterMark { get; set; }
        public bool? CreditCard { get; set; }
    }
}
