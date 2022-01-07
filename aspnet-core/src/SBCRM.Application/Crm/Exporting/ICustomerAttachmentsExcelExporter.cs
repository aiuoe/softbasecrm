using System.Collections.Generic;
using SBCRM.Crm.Dtos;
using SBCRM.Dto;

namespace SBCRM.Crm.Exporting
{
    /// <summary>
    /// Exports a customer attachment list to Excel.
    /// </summary>
    public interface ICustomerAttachmentsExcelExporter
    {
        /// <summary>
        /// Exports attachments to Excel.
        /// </summary>
        /// <param name="customerAttachments">A list of customer attachments to be exported.</param>
        /// <returns>The Excel file.</returns>
        FileDto ExportToFile(List<GetCustomerAttachmentForViewDto> customerAttachments);
    }
}