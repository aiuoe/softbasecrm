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
    public class OpportunitiesExcelExporter : NpoiExcelExporterBase, IOpportunitiesExcelExporter
    {

        private readonly ITimeZoneConverter _timeZoneConverter;
        private readonly IAbpSession _abpSession;

        public OpportunitiesExcelExporter(
            ITimeZoneConverter timeZoneConverter,
            IAbpSession abpSession,
            ITempFileCacheManager tempFileCacheManager) :
    base(tempFileCacheManager)
        {
            _timeZoneConverter = timeZoneConverter;
            _abpSession = abpSession;
        }

        public FileDto ExportToFile(List<GetOpportunityForViewDto> opportunities)
        {
            return CreateExcelPackage(
                "Opportunities_" + (DateTime.UtcNow.Date).ToString("MM/dd/yyyy") + ".xlsx",
                excelPackage =>
                {

                    var sheet = excelPackage.CreateSheet(L("Opportunities"));

                    AddHeader(
                        sheet,
                        L("Name"),
                        L("Amount"),
                        L("Probability"),
                        L("CloseDate"),
                        L("Description"),
                        L("Branch"),
                        L("Department"),
                        (L("OpportunityStage")) + L("Description"),
                        (L("LeadSource")) + L("Description"),
                        (L("OpportunityType")) + L("Description")
                        );

                    AddObjects(
                        sheet, opportunities,
                        _ => _.Opportunity.Name,
                        _ => _.Opportunity.Amount,
                        _ => _.Opportunity.Probability,
                        _ => _timeZoneConverter.Convert(_.Opportunity.CloseDate, _abpSession.TenantId, _abpSession.GetUserId()),
                        _ => _.Opportunity.Description,
                        _ => _.Opportunity.Branch,
                        _ => _.Opportunity.Department,
                        _ => _.OpportunityStageDescription,
                        _ => _.LeadSourceDescription,
                        _ => _.OpportunityTypeDescription
                        );

                    for (var i = 1; i <= opportunities.Count; i++)
                    {
                        SetCellDataFormat(sheet.GetRow(i).Cells[4], "yyyy-mm-dd");
                    }
                    sheet.AutoSizeColumn(4);
                });
        }
    }
}