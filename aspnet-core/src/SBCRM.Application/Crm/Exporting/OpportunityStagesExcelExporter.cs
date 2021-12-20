using System.Collections.Generic;
using Abp.Runtime.Session;
using Abp.Timing.Timezone;
using SBCRM.DataExporting.Excel.NPOI;
using SBCRM.Crm.Dtos;
using SBCRM.Dto;
using SBCRM.Storage;

namespace SBCRM.Crm.Exporting
{
    public class OpportunityStagesExcelExporter : NpoiExcelExporterBase, IOpportunityStagesExcelExporter
    {

        private readonly ITimeZoneConverter _timeZoneConverter;
        private readonly IAbpSession _abpSession;

        public OpportunityStagesExcelExporter(
            ITimeZoneConverter timeZoneConverter,
            IAbpSession abpSession,
            ITempFileCacheManager tempFileCacheManager) :
    base(tempFileCacheManager)
        {
            _timeZoneConverter = timeZoneConverter;
            _abpSession = abpSession;
        }

        public FileDto ExportToFile(List<GetOpportunityStageForViewDto> opportunityStages)
        {
            return CreateExcelPackage(
                "OpportunityStages.xlsx",
                excelPackage =>
                {

                    var sheet = excelPackage.CreateSheet(L("OpportunityStages"));

                    AddHeader(
                        sheet,
                        L("Description"),
                        L("Order"),
                        L("Color")
                        );

                    AddObjects(
                        sheet, opportunityStages,
                        _ => _.OpportunityStage.Description
                        );

                });
        }
    }
}