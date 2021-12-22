using System.Collections.Generic;
using Abp.Runtime.Session;
using Abp.Timing.Timezone;
using SBCRM.DataExporting.Excel.NPOI;
using SBCRM.Crm.Dtos;
using SBCRM.Dto;
using SBCRM.Storage;

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
            return CreateExcelPackage(
                "Activities.xlsx",
                excelPackage =>
                {

                    var sheet = excelPackage.CreateSheet(L("Activities"));

                    AddHeader(
                        sheet,
                        L("DueDate"),
                        (L("Opportunity")) + L("Name"),
                        (L("Lead")) + L("CompanyName"),
                        (L("User")) + L("Name"),
                        (L("ActivitySourceType")) + L("Description"),
                        (L("ActivityTaskType")) + L("Description"),
                        (L("ActivityStatus")) + L("Description"),
                        (L("ActivityPriority")) + L("Description"),
                        L("CompanyName")
                        );

                    AddObjects(
                        sheet, activities,
                        _ => _timeZoneConverter.Convert(_.Activity.DueDate, _abpSession.TenantId, _abpSession.GetUserId()),
                        _ => _.OpportunityName,
                        _ => _.LeadCompanyName,
                        _ => _.UserName,
                        _ => _.ActivitySourceTypeDescription,
                        _ => _.ActivityTaskTypeDescription,
                        _ => _.ActivityStatusDescription,
                        _ => _.ActivityPriorityDescription,
                        _ => _.CustomerName
                        );

                    for (var i = 1; i <= activities.Count; i++)
                    {
                        SetCellDataFormat(sheet.GetRow(i).Cells[1], "yyyy-mm-dd");
                    }
                    sheet.AutoSizeColumn(1);
                });
        }
    }
}