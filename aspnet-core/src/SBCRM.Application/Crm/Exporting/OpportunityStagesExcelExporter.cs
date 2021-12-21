using Abp.Runtime.Session;
using Abp.Timing.Timezone;
using SBCRM.Crm.Dtos;
using SBCRM.DataExporting.Excel.NPOI;
using SBCRM.Dto;
using SBCRM.Storage;
using System.Collections.Generic;

namespace SBCRM.Crm.Exporting;

/// <summary>
/// Class that hanldes Opportunity stage export to excel
/// </summary>
public class OpportunityStagesExcelExporter : NpoiExcelExporterBase, IOpportunityStagesExcelExporter
{
    private readonly IAbpSession _abpSession;
    private readonly ITimeZoneConverter _timeZoneConverter;

    /// <summary>
    /// Class constructor
    /// </summary>
    /// <param name="timeZoneConverter"></param>
    /// <param name="abpSession"></param>
    /// <param name="tempFileCacheManager"></param>
    public OpportunityStagesExcelExporter(
        ITimeZoneConverter timeZoneConverter,
        IAbpSession abpSession,
        ITempFileCacheManager tempFileCacheManager) :
        base(tempFileCacheManager)
    {
        _timeZoneConverter = timeZoneConverter;
        _abpSession = abpSession;
    }

    /// <summary>
    /// Method that export file to excel
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
                    L("Description")
                );

                AddObjects(
                    sheet, opportunityStages,
                    _ => _.OpportunityStage.Description
                );
            });
    }
}