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
    public class ActivitiesExcelExporter : NpoiExcelExporterBase, IActivitiesExcelExporter
    {

        private readonly ITimeZoneConverter _timeZoneConverter;
        private readonly IAbpSession _abpSession;

        public ActivitiesExcelExporter(
            ITimeZoneConverter timeZoneConverter,
            IAbpSession abpSession,
            ITempFileCacheManager tempFileCacheManager) :
    base(tempFileCacheManager)
        {
            _timeZoneConverter = timeZoneConverter;
            _abpSession = abpSession;
        }

        public FileDto ExportToFile(List<GetActivityForViewDto> activities)
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
                        L("StartsAt"),
                        L("AssignedUser")
                        );

                    AddObjects(
                        sheet, activities,
                        _ => _.ActivityStatusDescription,
                        _ => _.ActivitySourceTypeDescription,
                        _ => _.CompanyName,
                        _ => _.ActivityTaskTypeDescription,
                        _ => _.ActivityPriorityDescription,
                        _ => _timeZoneConverter.Convert(_.Activity.StartsAt, _abpSession.TenantId, _abpSession.GetUserId()),
                        _ => _.UserName
                        );

                    for (var i = 1; i <= activities.Count; i++)
                    {
                        SetCellDataFormat(sheet.GetRow(i).Cells[1], "mm/dd/yyyy");
                    }
                    sheet.AutoSizeColumn(1);
                });
        }
    }
}