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
    /// Excel exporter for priorities
    /// </summary>
    public class PrioritiesExcelExporter : NpoiExcelExporterBase, IPrioritiesExcelExporter
    {

        private readonly ITimeZoneConverter _timeZoneConverter;
        private readonly IAbpSession _abpSession;

        /// <summary>
        /// Constructor for PrioritiesExcelExporter
        /// </summary>
        /// <param name="timeZoneConverter"></param>
        /// <param name="abpSession"></param>
        /// <param name="tempFileCacheManager"></param>
        public PrioritiesExcelExporter(
            ITimeZoneConverter timeZoneConverter,
            IAbpSession abpSession,
            ITempFileCacheManager tempFileCacheManager) :
    base(tempFileCacheManager)
        {
            _timeZoneConverter = timeZoneConverter;
            _abpSession = abpSession;
        }

        /// <summary>
        /// Exports a list of priorities sources to excel
        /// </summary>
        /// <param name="priorities">The list of priorities to be exported<</param>
        /// <returns><see cref="FileDto"/></returns>
        public FileDto ExportToFile(List<GetPriorityForViewDto> priorities)
        {
            return CreateExcelPackage(
                "Priorities.xlsx",
                excelPackage =>
                {

                    var sheet = excelPackage.CreateSheet(L("Priorities"));

                    AddHeader(
                        sheet,
                        L("Description"),
                        L("IsDefault"),
                        L("Color")
                        );

                    AddObjects(
                        sheet, priorities,
                        _ => _.Priority.Description,
                        _ => _.Priority.IsDefault,
                        _ => _.Priority.Color
                        );

                });
        }
    }
}