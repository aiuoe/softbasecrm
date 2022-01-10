using System.Collections.Generic;
using Abp.Runtime.Session;
using Abp.Timing.Timezone;
using SBCRM.DataExporting.Excel.NPOI;
using SBCRM.Crm.Dtos;
using SBCRM.Dto;
using SBCRM.Storage;

namespace SBCRM.Crm.Exporting
{
    public class LeadAttachmentsExcelExporter : NpoiExcelExporterBase, ILeadAttachmentsExcelExporter
    {

        private readonly ITimeZoneConverter _timeZoneConverter;
        private readonly IAbpSession _abpSession;

        public LeadAttachmentsExcelExporter(
            ITimeZoneConverter timeZoneConverter,
            IAbpSession abpSession,
            ITempFileCacheManager tempFileCacheManager) :
    base(tempFileCacheManager)
        {
            _timeZoneConverter = timeZoneConverter;
            _abpSession = abpSession;
        }

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
                        L("FilePath"),
                        (L("Lead")) + L("CompanyName")
                        );

                    AddObjects(
                        sheet, leadAttachments,
                        _ => _.LeadAttachment.Name,
                        _ => _.LeadAttachment.FilePath,
                        _ => _.LeadCompanyName
                        );

                });
        }
    }
}