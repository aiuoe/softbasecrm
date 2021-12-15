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
    /// Excel exporter for lead sources
    /// </summary>
    public class LeadSourcesExcelExporter : NpoiExcelExporterBase, ILeadSourcesExcelExporter
    {

        private readonly ITimeZoneConverter _timeZoneConverter;
        private readonly IAbpSession _abpSession;
        /// <summary>
        /// LeadSourcesExcelExporter constructor
        /// </summary>
        /// <param name="timeZoneConverter"></param>
        /// <param name="abpSession"></param>
        /// <param name="tempFileCacheManager"></param>
        public LeadSourcesExcelExporter(
            ITimeZoneConverter timeZoneConverter,
            IAbpSession abpSession,
            ITempFileCacheManager tempFileCacheManager) :
    base(tempFileCacheManager)
        {
            _timeZoneConverter = timeZoneConverter;
            _abpSession = abpSession;
        }

        /// <summary>
        /// Exports a list of leads sources to excel
        /// </summary>
        /// <param name="leadSources">The list of sources to be exported</param>
        /// <returns><see cref="FileDto"/></returns>
        public FileDto ExportToFile(List<GetLeadSourceForViewDto> leadSources)
        {
            return CreateExcelPackage(
                "LeadSources.xlsx",
                excelPackage =>
                {

                    var sheet = excelPackage.CreateSheet(L("LeadSources"));

                    AddHeader(
                        sheet,
                        L("Description"),
                        L("Order"),
                        L("IsDefault")
                        );

                    AddObjects(
                        sheet, leadSources,
                        _ => _.LeadSource.Description,
                        _ => _.LeadSource.Order,
                        _ => _.LeadSource.IsDefault
                        );

                });
        }
    }
}