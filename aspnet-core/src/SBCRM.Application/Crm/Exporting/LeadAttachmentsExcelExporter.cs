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
    /// Class to manage the exporting to excel 
    /// </summary>
    public class LeadAttachmentsExcelExporter : NpoiExcelExporterBase, ILeadAttachmentsExcelExporter
    {
        private readonly ITimeZoneConverter _timeZoneConverter;
        private readonly IAbpSession _abpSession;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="timeZoneConverter"></param>
        /// <param name="abpSession"></param>
        /// <param name="tempFileCacheManager"></param>
        public LeadAttachmentsExcelExporter(
            ITimeZoneConverter timeZoneConverter,
            IAbpSession abpSession,
            ITempFileCacheManager tempFileCacheManager) :
    base(tempFileCacheManager)
        {
            _timeZoneConverter = timeZoneConverter;
            _abpSession = abpSession;
        }

        /// <summary>
        /// Method to create an excel file to export
        /// </summary>
        /// <param name="leadAttachments"></param>
        /// <returns></returns>
        public FileDto ExportToFile(List<GetLeadAttachmentForViewDto> leadAttachments)
        {
            return CreateExcelPackage(
                "LeadAttachments.xlsx",
                excelPackage =>
                {

                    var sheet = excelPackage.CreateSheet(L("LeadAttachments"));

                    AddHeader(
                        sheet,
                        L("Name"),
                        L("FilePath")
                        );

                    AddObjects(
                        sheet, leadAttachments,
                        _ => _.LeadAttachment.Name,
                        _ => _.LeadAttachment.FilePath
                        );

                });
        }
    }
}