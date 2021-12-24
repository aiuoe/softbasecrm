using System;
using System.Collections.Generic;
using System.Text;

namespace SBCRM.Crm.Dtos
{
    /// <summary>
    /// Activity Dto for Exporting
    /// </summary>
    public class GetActivityForViewExportDto : GetActivityForViewDto
    {
        /// <summary>
        /// Used for sorting the first name of the user
        /// </summary>
        public string UserFirstName { get; set; }

        /// <summary>
        /// Used for sorting the last name of the user
        /// </summary>
        public string UserLastName { get; set; }

        public DateTime DueDate { get; set; }

        public DateTime StartsAt { get; set; }
    }
}
