using System;
using System.Collections.Generic;
using System.Text;

namespace SBCRM.Dto.AvalaraConnection.TaxCodes
{
    public class GetTaxCodesParametersDto
    {
        public string Filter { get; set; }

        public string Include { get; set; }

        public string Top { get; set; }

        public string Skip { get; set; }

        public string OrderBy { get; set; }
    }
}
