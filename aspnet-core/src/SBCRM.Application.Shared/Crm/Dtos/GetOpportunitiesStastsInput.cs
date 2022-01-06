using System;
using System.Collections.Generic;
using System.Text;

namespace SBCRM.Crm.Dtos
{
    public class GetOpportunitiesStastsInput
    {
        public DateTime? FromDate { get; set; }

        public DateTime? ToDate { get; set; }

        public string Account { get; set; }

        public string Branch { get; set; }

        public string Department { get; set; }
    }
}
