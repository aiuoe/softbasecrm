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

        /// <summary>
        /// This method returns an excel sheet with duplicated leads
        /// </summary>
        /// <param name="leads"></param>
        /// <returns></returns>
        public FileDto ExportDuplicatedLeadsToExcel(List<LeadDto> leads)
        {
            return CreateExcelPackage(
               "DuplicatedLeads.xlsx",
               excelPackage =>
               {
                   var sheet = excelPackage.CreateSheet(L("Leads"));

                   AddHeader(
                       sheet,
                       L("CompanyName"),
                       L("CompanyPhone"),
                       ("Company Email"),
                       ("Website"),
                       ("Company Address"),
                       ("Country"),
                       ("City"),
                       ("State / Province"),
                       ("Zip Code /  Postal Code"),
                       ("PO Box"),
                       ("Contact Name"),
                       ("Contact Position"),
                       ("Contact Phone"),
                       ("Contact Extension"),
                       ("Contact Cell Phone"),
                       ("Contact Fax"),
                       ("Contact Pager"),
                       ("Contact Email")
                       );

                   AddObjects(
                       sheet, leads,
                       _ => _.CompanyName,
                       _ => _.CompanyPhone,
                       _ => _.CompanyEmail,
                       _ => _.WebSite,
                       _ => _.Address,
                       _ => _.Country,
                       _ => _.City,
                       _ => _.State,
                       _ => _.ZipCode,
                       _ => _.PoBox,
                       _ => _.ContactName,
                       _ => _.ContactPosition,
                       _ => _.ContactPhone,
                       _ => _.ContactPhoneExtension,
                       _ => _.ContactCellPhone,
                       _ => _.ContactFaxNumber,
                       _ => _.PagerNumber,
                       _ => _.ContactEmail
                       );

                   int numberOfColumns = sheet.GetRow(0).LastCellNum;
                   for (int column = 0; column < numberOfColumns; column++)
                       sheet.AutoSizeColumn(column);

               });
        }
    }
}