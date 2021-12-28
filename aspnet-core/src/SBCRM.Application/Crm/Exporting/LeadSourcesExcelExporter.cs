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
    /// Method that handles the export of data to excel
    /// </summary>
    public class LeadSourcesExcelExporter : NpoiExcelExporterBase, ILeadSourcesExcelExporter
    {
        private readonly ITimeZoneConverter _timeZoneConverter;
        private readonly IAbpSession _abpSession;

        /// <summary>
        /// Class Constructor
        /// </summary>
        /// <param name="timeZoneConverter"></param>
        /// <param name="abpSession"></param>
        /// <param name="tempFileCacheManager"></param>
        public LeadSourcesExcelExporter(
            ITimeZoneConverter timeZoneConverter,
            IAbpSession abpSession,
            ITempFileCacheManager tempFileCacheManager) : base(tempFileCacheManager)
        {
            _timeZoneConverter = timeZoneConverter;
            _abpSession = abpSession;
        }

        /// <summary>
        /// Method that export grid to excel file
        /// </summary>
        /// <param name="leadSources"></param>
        /// <returns></returns>
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
                        L("Order")
                        );

                    AddObjects(
                        sheet, leadSources,
                        _ => _.LeadSource.Description,
                        _ => _.LeadSource.Order
                        );
                });
        }
    }
}