using System.Collections.Generic;
using SBCRM.DataExporting.Excel.NPOI;
using SBCRM.Legacy.Dtos;
using SBCRM.Dto;
using SBCRM.Storage;

namespace SBCRM.Legacy.Exporting
{
    /// <summary>
    /// Customer Excel exporter
    /// </summary>
    public class CustomerExcelExporter : NpoiExcelExporterBase, ICustomerExcelExporter
    {
        /// <summary>
        /// Base constructor
        /// </summary>
        /// <param name="tempFileCacheManager"></param>
        public CustomerExcelExporter(ITempFileCacheManager tempFileCacheManager) : base(tempFileCacheManager)
        {
        }

        /// <summary>
        /// Export customers to file
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        public FileDto ExportToFile(List<GetCustomerForViewDto> customer)
        {
            return CreateExcelPackage(
                "Customer.xlsx",
                excelPackage =>
                {
                    var sheet = excelPackage.CreateSheet(L("Customer"));

                    AddHeader(
                        sheet,
                        L("Number"),
                        L("BillTo"),
                        L("Name"),
                        L("Address"),
                        L("Phone"),
                        L("AccountType")
                    );

                    AddObjects(
                        sheet, customer,
                        _ => _.Customer.Number,
                        _ => _.Customer.BillTo,
                        _ => _.Customer.Name,
                        _ => _.Customer.Address,
                        _ => _.Customer.Phone,
                        _ => _.AccountTypeDescription
                    );
                    sheet.AutoSizeColumn(159);
                });
        }
    }
}