using System.Collections.Generic;
using Abp.Runtime.Session;
using Abp.Timing.Timezone;
using SBCRM.DataExporting.Excel.NPOI;
using SBCRM.Crm.Dtos;
using SBCRM.Dto;
using SBCRM.Storage;

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
                        //L("ContactPosition"),
                        //L("WebSite"),
                        //L("Address"),
                        //L("Country"),
                        //L("State"),
                        //L("Description"),
                        L("CompanyPhone"),
                        //L("CompanyEmail"),
                        //L("PoBox"),
                        //L("ZipCode"),
                        //L("ContactPhone"),
                        //L("ContactPhoneExtension"),
                        //L("ContactCellPhone"),
                        //L("ContactFaxNumber"),
                        //L("PagerNumber"),
                        //L("ContactEmail"),
                        //(L("LeadSource")) + L("Description"),
                        (L("LeadStatus")),
                        (L("Priority"))
                        );

                    AddObjects(
                        sheet, leads,
                        _ => _.Lead.CompanyName,
                        _ => _.Lead.ContactName,
                        //_ => _.Lead.ContactPosition,
                        //_ => _.Lead.WebSite,
                        //_ => _.Lead.Address,
                        //_ => _.Lead.Country,
                        //_ => _.Lead.State,
                        //_ => _.Lead.Description,
                        _ => _.Lead.CompanyPhone,
                        //_ => _.Lead.CompanyEmail,
                        //_ => _.Lead.PoBox,
                        //_ => _.Lead.ZipCode,
                        //_ => _.Lead.ContactPhone,
                        //_ => _.Lead.ContactPhoneExtension,
                        //_ => _.Lead.ContactCellPhone,
                        //_ => _.Lead.ContactFaxNumber,
                        //_ => _.Lead.PagerNumber,
                        //_ => _.Lead.ContactEmail,
                        //_ => _.LeadSourceDescription,
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