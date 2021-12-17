using System.Collections.Generic;
using Abp.Runtime.Session;
using Abp.Timing.Timezone;
using SBCRM.DataExporting.Excel.NPOI;
using SBCRM.Crm.Dtos;
using SBCRM.Dto;
using SBCRM.Storage;
using NPOI.SS.UserModel;
using System;

namespace SBCRM.Crm.Exporting
{
    /// <summary>
    /// Lead Excel exporter
    /// </summary>
    public class LeadsExcelExporter : NpoiExcelExporterBase, ILeadsExcelExporter
    {

        private readonly ITimeZoneConverter _timeZoneConverter;
        private readonly IAbpSession _abpSession;

        /// <summary>
        /// Base constructor
        /// </summary>
        /// <param name="tempFileCacheManager"></param>
        public LeadsExcelExporter(
            ITimeZoneConverter timeZoneConverter,
            IAbpSession abpSession,
            ITempFileCacheManager tempFileCacheManager) :
            base(tempFileCacheManager)
        {
        }

        /// <summary>
        /// Export customers to file
        /// </summary>
        /// <param name="leads"></param>
        /// <returns></returns>
        public FileDto ExportToFile(List<GetLeadForViewDto> leads)
        {

            return CreateExcelPackage(
                "Leads_" + (DateTime.UtcNow.Date).ToString("MM/dd/yyyy") + ".xlsx",
                excelPackage =>
                {
                    var sheet = excelPackage.CreateSheet(L("Leads"));
                 
                    AddHeader(
                        sheet,
                        L("CompanyName"),
                        L("ContactName"),
                        L("Status"),
                        L("CompanyPhone"),
                        L("AssignedUser"),
                        L("CreationTime"),
                        (L("Priority"))
                        );

                    AddObjects(
                        sheet, leads,
                        _ => _.Lead.CompanyName,
                        _ => _.Lead.ContactName,
                        _ => _.LeadStatusDescription,
                        _ => _.Lead.CompanyPhone,
                        _ => L("Placeholder"),
                        _ => _.Lead.CreationTime.Value.ToString("MM/dd/yyyy"),                        
                        _ => _.PriorityDescription
                        );
                        
                        int numberOfColumns = sheet.GetRow(0).LastCellNum;
                        for(int column = 0; column < numberOfColumns; column++)
                            sheet.AutoSizeColumn(column);

                });
        }
    }
}