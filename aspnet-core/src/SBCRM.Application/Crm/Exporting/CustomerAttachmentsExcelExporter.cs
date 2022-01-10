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
    /// Exports a customer attachment list to Excel.
    /// </summary>
    public class CustomerAttachmentsExcelExporter : NpoiExcelExporterBase, ICustomerAttachmentsExcelExporter
    {

        private readonly ITimeZoneConverter _timeZoneConverter;
        private readonly IAbpSession _abpSession;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="timeZoneConverter"></param>
        /// <param name="abpSession"></param>
        /// <param name="tempFileCacheManager"></param>
        public CustomerAttachmentsExcelExporter(
            ITimeZoneConverter timeZoneConverter,
            IAbpSession abpSession,
            ITempFileCacheManager tempFileCacheManager) :
    base(tempFileCacheManager)
        {
            _timeZoneConverter = timeZoneConverter;
            _abpSession = abpSession;
        }

        /// <summary>
        /// Exports attachments to Excel.
        /// </summary>
        /// <param name="customerAttachments">A list of customer attachments to be exported.</param>
        /// <returns>The Excel file.</returns>
        public FileDto ExportToFile(List<GetCustomerAttachmentForViewDto> customerAttachments)
        {
            return CreateExcelPackage(
                "CustomerAttachments.xlsx",
                excelPackage =>
                {

                    var sheet = excelPackage.CreateSheet(L("CustomerAttachments"));

                    AddHeader(
                        sheet,
                        L("Name"),
                        L("FilePath")
                        );

                    AddObjects(
                        sheet, customerAttachments,
                        _ => _.CustomerAttachment.Name,
                        _ => _.CustomerAttachment.FilePath
                        );

                });
        }
    }
}