using System;
using System.Collections.Generic;
using System.Text;

namespace SBCRM.Modules.Common.Avalara.Dto
{
    public class GetTaxCodesDto
    {
        public int RecordsetCount { get; set; }

        public List<TaxCodeDto> value { get; set; }
        
        public string NextLink { get; set; }

        public string PageKey { get; set; }
    }
}
