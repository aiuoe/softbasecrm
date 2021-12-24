using System.Collections.Generic;
using Abp.Runtime.Session;
using Abp.Timing.Timezone;
using SBCRM.DataExporting.Excel.NPOI;
using SBCRM.Crm.Dtos;
using SBCRM.Dto;
using SBCRM.Storage;

namespace SBCRM.Crm.Exporting
{
    /// <summary>
    /// Handles all Excel exportation of Activity Priority
    /// </summary>
    public class ActivityPrioritiesExcelExporter : NpoiExcelExporterBase, IActivityPrioritiesExcelExporter
    {

        private readonly ITimeZoneConverter _timeZoneConverter;
        private readonly IAbpSession _abpSession;

        /// <summary>
        /// Constructor method
        /// </summary>
        /// <param name="timeZoneConverter"></param>
        /// <param name="abpSession"></param>
        /// <param name="tempFileCacheManager"></param>
        public ActivityPrioritiesExcelExporter(
            ITimeZoneConverter timeZoneConverter,
            IAbpSession abpSession,
            ITempFileCacheManager tempFileCacheManager) :
    base(tempFileCacheManager)
        {
            _timeZoneConverter = timeZoneConverter;
            _abpSession = abpSession;
        }

        /// <summary>
        /// Creates an Excel file for the list of Activity Priorities
        /// </summary>
        /// <param name="activityPriorities">The list of Activitiy Priorities</param>
        /// <returns></returns>
        public FileDto ExportToFile(List<GetActivityPriorityForViewDto> activityPriorities)
        {
            return CreateExcelPackage(
                "ActivityPriorities.xlsx",
                excelPackage =>
                {

                    var sheet = excelPackage.CreateSheet(L("ActivityPriorities"));

                    AddHeader(
                        sheet,
                        L("Description"),
                        L("Color")
                        );

                    AddObjects(
                        sheet, activityPriorities,
                        _ => _.ActivityPriority.Description,
                        _ => _.ActivityPriority.Color
                        );

                });
        }
    }
}