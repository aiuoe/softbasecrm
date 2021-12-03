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
                        L("FirstName"),
                        L("LastName"),
                        L("Title"),
                        L("WebSite"),
                        L("Address"),
                        L("Country"),
                        L("State"),
                        L("Description"),
                        (L("Industry")) + L("Description"),
                        (L("LeadSource")) + L("Description"),
                        (L("LeadStatus")) + L("Description")
                        );

                    AddObjects(
                        sheet, leads,
                        _ => _.Lead.CompanyName,
                        _ => _.Lead.FirstName,
                        _ => _.Lead.LastName,
                        _ => _.Lead.Title,
                        _ => _.Lead.WebSite,
                        _ => _.Lead.Address,
                        _ => _.Lead.Country,
                        _ => _.Lead.State,
                        _ => _.Lead.Description,
                        _ => _.IndustryDescription,
                        _ => _.LeadSourceDescription,
                        _ => _.LeadStatusDescription
                        );

                });
        }
    }
}