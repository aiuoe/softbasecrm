using System;
using System.Collections.Generic;
using System.Text;

namespace SBCRM.Modules.Common.AdditionalCharges.Dto
{
    public class CreatedAdditionalChargeResponseDto
    {
        public string Id { get; set; }  
        public string Branch { get; set; }
        public string Dept { get; set; }
        public string MiscDescription { get; set; }
    }
}
