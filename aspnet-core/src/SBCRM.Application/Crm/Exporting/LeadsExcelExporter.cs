using System.Collections.Generic;
using Abp.Runtime.Session;
using Abp.Timing.Timezone;
using SBCRM.DataExporting.Excel.NPOI;
using SBCRM.Crm.Dtos;
using SBCRM.Dto;
using SBCRM.Storage;
using NPOI.SS.UserModel;

namespace SBCRM.Crm.Exporting
{
    public class LeadsExcelExporter : NpoiExcelExporterBase, ILeadsExcelExporter
    {

        private readonly ITimeZoneConverter _timeZoneConverter;
        private readonly IAbpSession _abpSession;

        public LeadsExcelExporter(
            ITimeZoneConverter timeZoneConverter,
            IAbpSession abpSession,
            ITempFileCacheManager tempFileCacheManager) :
    base(tempFileCacheManager)
        {
            _timeZoneConverter = timeZoneConverter;
            _abpSession = abpSession;
        }

        public FileDto ExportToFile(List<GetLeadForViewDto> leads)
        {

            return CreateExcelPackage(
                "Leads.xlsx",
                excelPackage =>
                {
                    var sheet = excelPackage.CreateSheet(L("Leads"));
                 
                    AddHeader(
                        sheet,
                        L("CompanyName"),
                        L("ContactName"),
                        L("CompanyPhone"),
                        L("CreationTime"),
                        (L("LeadStatus")),
                        (L("Priority"))
                        );

                    AddObjects(
                        sheet, leads,
                        _ => _.Lead.CompanyName,
                        _ => _.Lead.ContactName,
                        _ => _.Lead.CompanyPhone,
                        _ => _.Lead.CreationTime.Value.ToString("MM/dd/yyyy"),
                        _ => _.LeadStatusDescription,
                        _ => _.PriorityDescription
                        );
                        
                        int numberOfColumns = sheet.GetRow(0).LastCellNum;
                        for(int column = 0; column < numberOfColumns; column++)
                            sheet.AutoSizeColumn(column);

                });
        }
    }
}