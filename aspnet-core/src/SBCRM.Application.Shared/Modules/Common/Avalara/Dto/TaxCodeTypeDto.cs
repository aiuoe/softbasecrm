using System;
using System.Collections.Generic;
using System.Text;

namespace SBCRM.Modules.Common.Avalara.Dto
{
    /// <summary>
    /// Defines the types of Tax Code that can be used
    /// </summary>
    public class TaxCodeTypeDto
    {
        /// <summary>
        /// Type of Tax Code
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Description of the type
        /// </summary>
        public string Description { get; set; }
    }
}
