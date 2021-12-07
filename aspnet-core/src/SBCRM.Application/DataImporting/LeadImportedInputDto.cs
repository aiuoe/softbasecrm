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
    }
}
