using System.Collections.Generic;
using Abp.Runtime.Session;
using Abp.Timing.Timezone;
using SBCRM.DataExporting.Excel.NPOI;
using SBCRM.Crm.Dtos;
using SBCRM.Dto;
using SBCRM.Storage;
using System;
using System.Linq;

namespace SBCRM.Crm.Exporting
{
    /// <summary>
    /// Opportunity Excel exporter
    /// </summary>
    public class OpportunitiesExcelExporter : NpoiExcelExporterBase, IOpportunitiesExcelExporter
    {

        private readonly ITimeZoneConverter _timeZoneConverter;
        private readonly IAbpSession _abpSession;

        /// <summary>
        /// Base constructor
        /// </summary>
        /// <param name="tempFileCacheManager"></param>
        public OpportunitiesExcelExporter(
            ITimeZoneConverter timeZoneConverter,
            IAbpSession abpSession,
            ITempFileCacheManager tempFileCacheManager) :
            base(tempFileCacheManager)
        {
        }

        /// <summary>
        /// Export customers to file
        /// </summary>
        /// <param name="opportunities"></param>
        /// <returns></returns>
        public FileDto ExportToFile(List<GetOpportunityForViewDto> opportunities)
        {
            return CreateExcelPackage(
                "Opportunities_" + (DateTime.UtcNow.Date).ToString("MM_dd_yyyy") + ".xlsx",
                excelPackage =>
                {

                    var sheet = excelPackage.CreateSheet(L("Opportunities"));

                    AddHeader(
                        sheet,
                        L("Name"),
                        L("Stage"),
                        L("Account"),
                        L("AssignedUser"),
                        L("ProjectClose"),
                        L("Amount"),
                        L("Branch"),
                        L("Department")
                        );

                    AddObjects(
                        sheet, opportunities,
                        _ => _.Opportunity.Name,
                        _ => _.OpportunityStageDescription,
                        _ => _.CustomerName,
                        _ => _.Opportunity.Users != null && _.Opportunity.Users.Any()
                            ? string.Join(", ", _.Opportunity.Users.Select(x => x.FullName))
                            : string.Empty,
                        _ => _.Opportunity.CloseDate.HasValue ? _.Opportunity.CloseDate.Value.ToString("MM/dd/yyyy") : null,
                        _ => _.Opportunity.Amount,
                        _ => _.BranchName,
                        _ => _.DepartmentTitle
                        );

                    int numberOfColumns = sheet.GetRow(0).LastCellNum;
                    for (int column = 0; column < numberOfColumns; column++)
                        sheet.AutoSizeColumn(column);

                });
        }
    }
}