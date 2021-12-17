using SBCRM.Infrastructure.Attribute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBCRM.DataImporting
{
    class LeadImportedInputDto
    {
        [PositionExcel(1)]
        public string CompanyName { get; set; }

        [PositionExcel(2)]
        public string Phone { get; set; }

        [PositionExcel(3)]
        public string CompanyEmail { get; set; }

        [PositionExcel(4)]
        public string Website { get; set; }

        [PositionExcel(5)]
        public string CompanyAdress { get; set; }

        [PositionExcel(6)]
        public string Country { get; set; }

        [PositionExcel(7)]
        public string City { get; set; }

        [PositionExcel(8)]
        public string StateProvince { get; set; }

        [PositionExcel(9)]
        public string ZipCode { get; set; }

        [PositionExcel(10)]
        public string PoBox { get; set; }

        [PositionExcel(11)]
        public string ContactName { get; set; }

        [PositionExcel(12)]
        public string ContactPosition { get; set; }

        [PositionExcel(13)]
        public string ContactPhone { get; set; }

        [PositionExcel(13)]
        public string ContactExtention { get; set; }

        [PositionExcel(14)]
        public string ContactCelphone { get; set; }

        [PositionExcel(15)]
        public string ContactFax { get; set; }

        [PositionExcel(16)]
        public string ContactPager { get; set; }

        [PositionExcel(17)]
        public string ContactEmail { get; set; }
    }
}
