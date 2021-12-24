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
        public DateTime DueDate { get; set; }

        public DateTime StartsAt { get; set; }
    }
}
