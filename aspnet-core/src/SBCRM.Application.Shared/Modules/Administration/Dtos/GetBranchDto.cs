using System;
using System.Collections.Generic;
using System.Text;

namespace SBCRM.Modules.Administration.Dtos
{
    public class GetBranchDto
    {
        public long Id { get; set; }    
        public short Number { get; set; }
        public string Name { get; set; }
        public string SubName { get; set; }
    }
}
