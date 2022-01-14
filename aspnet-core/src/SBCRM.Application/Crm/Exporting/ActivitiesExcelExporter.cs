using System.Collections.Generic;
using Abp.Runtime.Session;
using Abp.Timing.Timezone;
using SBCRM.DataExporting.Excel.NPOI;
using SBCRM.Crm.Dtos;
using SBCRM.Dto;
using SBCRM.Storage;
using System;

namespace SBCRM.Crm.Exporting
{
    /// <summary>
    /// Handles all Excel exportation of Activites
    /// </summary>
    public class ActivitiesExcelExporter : NpoiExcelExporterBase, IActivitiesExcelExporter
    {

        private readonly ITimeZoneConverter _timeZoneConverter;
        private readonly IAbpSession _abpSession;

        /// <summary>
        /// Constructor method
        /// </summary>
        /// <param name="timeZoneConverter"></param>
        /// <param name="abpSession"></param>
        /// <param name="tempFileCacheManager"></param>
        public ActivitiesExcelExporter(
            ITimeZoneConverter timeZoneConverter,
            IAbpSession abpSession,
            ITempFileCacheManager tempFileCacheManager) :
    base(tempFileCacheManager)
        {
            _timeZoneConverter = timeZoneConverter;
            _abpSession = abpSession;
        }

        /// <summary>
        /// Creates an Excel file for the list of Activites
        /// </summary>
        /// <param name="activities">The list of Activities</param>
        /// <returns></returns>
        public FileDto ExportToFile(List<GetActivityForViewExportDto> activities, TimeZoneInfo timeZone)
        {
            var fileName = $"Activities_{DateTime.UtcNow:MM_dd_yyyy}.xlsx";

            return CreateExcelPackage(
                fileName,
                excelPackage =>
                {

                    var sheet = excelPackage.CreateSheet(L("Activities"));

                    AddHeader(
                        sheet,
                        L("Status"),
                        L("SourceType"),
                        L("CompanyName"),
                        L("Activity"),
                        L("Priority"),
                        L("ScheduleAndDueDate"),
                        L("AssignedUser")
                        );

                    AddObjects(
                        sheet, activities,
                        _ => _.ActivityStatusDescription,
                        _ => _.ActivitySourceTypeDescription,
                        _ => _.CompanyName,
                        _ => _.ActivityTaskTypeDescription,
                        _ => _.ActivityPriorityDescription,
                        _ => TimeZoneInfo.ConvertTime(_.DueDate, timeZone),
                        _ => _.UserName
                        );

                    for (var i = 1; i <= activities.Count; i++)
                    {
                        SetCellDataFormat(sheet.GetRow(i).Cells[5], "mm/dd/yyyy");
                    }
                    sheet.AutoSizeColumn(1);
                });
        }
    }
}