using System;
using System.Collections.Generic;
using SBCRM.Crm.Dtos;
using SBCRM.Dto;

namespace SBCRM.Crm.Exporting
{
    /// <summary>
    /// Handles all Excel exportation of Activites
    /// </summary>
    public interface IActivitiesExcelExporter
    {
        /// <summary>
        /// Creates an Excel file for the list of Activites
        /// </summary>
        /// <param name="activities">The list of Activities</param>
        /// <param name="timeZone">The time zone of the current user</param>
        /// <returns></returns>
        FileDto ExportToFile(List<GetActivityForViewExportDto> activities, TimeZoneInfo timeZone);
    }
}