using System;

namespace SBCRM.Crm.Dtos
{
    public class GetOpportunitiesStastsInput
    {
        public DateTime? FromDate { get; set; }

        public DateTime? ToDate { get; set; }

        public string[] Account { get; set; }

        public short[] Branches { get; set; }

        public short[] Departments { get; set; }
    }
}
