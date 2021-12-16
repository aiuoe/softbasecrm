using System.Collections.Generic;
using Abp.Runtime.Session;
using Abp.Timing.Timezone;
using SBCRM.DataExporting.Excel.NPOI;
using SBCRM.Crm.Dtos;
using SBCRM.Dto;
using SBCRM.Storage;

namespace SBCRM.Crm.Exporting
{
    /// <summary>
    /// Opportunity Excel exporter
    /// </summary>
    public class OpportunitiesExcelExporter : NpoiExcelExporterBase, IOpportunitiesExcelExporter
    {
        /// <summary>
        /// Base constructor
        /// </summary>
        /// <param name="tempFileCacheManager"></param>
        public OpportunitiesExcelExporter(
            ITempFileCacheManager tempFileCacheManager) : base(tempFileCacheManager)
        {

        }

        /// <summary>
        /// Export opportunities to file
        /// </summary>
        /// <param name="opportunities"></param>
        /// <returns></returns>
        public FileDto ExportToFile(List<GetOpportunityForViewDto> opportunities)
        {
            return CreateExcelPackage(
                "Opportunities.xlsx",
                excelPackage =>
                {

                    var sheet = excelPackage.CreateSheet(L("Opportunities"));

                    AddHeader(
                        sheet,
                        L("Name"),
                        L("Stage"),
                        L("CloseDate"),
                        L("Amount"),
                        L("Probability"),
                        L("Branch"),
                        L("Department")
                        );

                    AddObjects(
                        sheet, opportunities,
                        _ => _.Opportunity.Name,
                        _ => _.OpportunityStageDescription,
                        _ => _.Opportunity.CloseDate.Value.ToString("MM/dd/yyyy"),
                        _ => _.Opportunity.Amount,
                        _ => _.Opportunity.Probability,
                        _ => _.Opportunity.Branch,
                        _ => _.Opportunity.Department
                        );

                    int numberOfColumns = sheet.GetRow(0).LastCellNum;
                    for (int column = 0; column < numberOfColumns; column++)
                        sheet.AutoSizeColumn(column);
                });
        }
    }
}