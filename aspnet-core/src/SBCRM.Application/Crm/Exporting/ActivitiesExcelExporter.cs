using System.Collections.Generic;
using SBCRM.DataExporting.Excel.NPOI;
using SBCRM.Crm.Dtos;
using SBCRM.Dto;
using SBCRM.Storage;
using System;
using Abp.Timing;

namespace SBCRM.Crm.Exporting
{
    /// <summary>
    /// Handles all Excel exportation of Activities
    /// </summary>
    public class ActivitiesExcelExporter : NpoiExcelExporterBase, IActivitiesExcelExporter
    {

        /// <summary>
        /// Constructor method
        /// </summary>
        /// <param name="timeZoneConverter"></param>
        /// <param name="abpSession"></param>
        /// <param name="tempFileCacheManager"></param>
        public ActivitiesExcelExporter(ITempFileCacheManager tempFileCacheManager) :
            base(tempFileCacheManager)
        {
        }

        /// <summary>
        /// Creates an Excel file for the list of Activities
        /// </summary>
        /// <param name="activities">The list of Activities</param>
        /// <returns></returns>
        public FileDto ExportToFile(List<GetActivityForViewExportDto> activities, TimeZoneInfo timeZone)
        {
            return CreateExcelPackage(
                $"Activities_{Clock.Now:MM_dd_yyyy}.xlsx",
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
                        _ => _.IsReminderType ? TimeZoneInfo.ConvertTime(_.DueDate, timeZone).Date : TimeZoneInfo.ConvertTime(_.DueDate, timeZone),
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