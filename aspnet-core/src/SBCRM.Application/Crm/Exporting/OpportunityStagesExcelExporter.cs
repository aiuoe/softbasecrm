using Abp.Runtime.Session;
using Abp.Timing.Timezone;
using SBCRM.Crm.Dtos;
using SBCRM.DataExporting.Excel.NPOI;
using SBCRM.Dto;
using SBCRM.Storage;
using System.Collections.Generic;

namespace SBCRM.Crm.Exporting
{
    /// <summary>
    /// class that handles exporting data from opportunity stages to an excel file
    /// </summary>
    public class OpportunityStagesExcelExporter : NpoiExcelExporterBase, IOpportunityStagesExcelExporter
    {
        private readonly ITimeZoneConverter _timeZoneConverter;
        private readonly IAbpSession _abpSession;

        /// <summary>
        /// Class Constructor
        /// </summary>
        /// <param name="timeZoneConverter"></param>
        /// <param name="abpSession"></param>
        /// <param name="tempFileCacheManager"></param>
        public OpportunityStagesExcelExporter(
            ITimeZoneConverter timeZoneConverter,
            IAbpSession abpSession,
            ITempFileCacheManager tempFileCacheManager) : base(tempFileCacheManager)
        {
            _timeZoneConverter = timeZoneConverter;
            _abpSession = abpSession;
        }

        /// <summary>
        /// Method that export data to excel
        /// </summary>
        /// <param name="opportunityStages"></param>
        /// <returns></returns>
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
                        _ => _.OpportunityStage.Description,
                        _ => _.OpportunityStage.Order,
                        _ => _.OpportunityStage.Color
                        );
                });
        }
    }
}