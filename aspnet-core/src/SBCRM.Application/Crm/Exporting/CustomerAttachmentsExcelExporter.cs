using System.Collections.Generic;
using Abp.Runtime.Session;
using Abp.Timing.Timezone;
using SBCRM.DataExporting.Excel.NPOI;
using SBCRM.Crm.Dtos;
using SBCRM.Dto;
using SBCRM.Storage;

namespace SBCRM.Crm.Exporting
{
    public class CustomerAttachmentsExcelExporter : NpoiExcelExporterBase, ICustomerAttachmentsExcelExporter
    {

        private readonly ITimeZoneConverter _timeZoneConverter;
        private readonly IAbpSession _abpSession;

        public CustomerAttachmentsExcelExporter(
            ITimeZoneConverter timeZoneConverter,
            IAbpSession abpSession,
            ITempFileCacheManager tempFileCacheManager) :
    base(tempFileCacheManager)
        {
            _timeZoneConverter = timeZoneConverter;
            _abpSession = abpSession;
        }

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