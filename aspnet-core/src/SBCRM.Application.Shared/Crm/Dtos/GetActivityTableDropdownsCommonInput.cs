using System;
using System.Collections.Generic;
using System.Text;

namespace SBCRM.Crm.Dtos
{
    /// <summary>
    /// Serves as the model of the common query input from TableDropdown methods of ActivityAppService
    /// </summary>
    public class GetActivityTableDropdownsCommonInput
    {
        /// <summary>
        /// Whether the results will be used for create or not.
        /// </summary>
        public bool IsForCreate { get; set; }
    }
}
