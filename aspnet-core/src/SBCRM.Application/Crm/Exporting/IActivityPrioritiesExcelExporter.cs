using System.Collections.Generic;
using SBCRM.Crm.Dtos;
using SBCRM.Dto;

namespace SBCRM.Crm.Exporting
{
    /// <summary>
    /// Handles all Excel exportation of Activity Priority
    /// </summary>
    public interface IActivityPrioritiesExcelExporter
    {
        /// <summary>
        /// Creates an Excel file for the list of Activity Priorities
        /// </summary>
        /// <param name="activityPriorities">The list of Activitiy Priorities</param>
        /// <returns></returns>
        FileDto ExportToFile(List<GetActivityPriorityForViewDto> activityPriorities);
    }
}