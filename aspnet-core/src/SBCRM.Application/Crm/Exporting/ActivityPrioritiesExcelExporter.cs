using System.Collections.Generic;
using Abp.Runtime.Session;
using Abp.Timing.Timezone;
using SBCRM.DataExporting.Excel.NPOI;
using SBCRM.Crm.Dtos;
using SBCRM.Dto;
using SBCRM.Storage;

namespace SBCRM.Crm.Exporting
{
    public class ActivityPrioritiesExcelExporter : NpoiExcelExporterBase, IActivityPrioritiesExcelExporter
    {

        private readonly ITimeZoneConverter _timeZoneConverter;
        private readonly IAbpSession _abpSession;

        public ActivityPrioritiesExcelExporter(
            ITimeZoneConverter timeZoneConverter,
            IAbpSession abpSession,
            ITempFileCacheManager tempFileCacheManager) :
    base(tempFileCacheManager)
        {
            _timeZoneConverter = timeZoneConverter;
            _abpSession = abpSession;
        }

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