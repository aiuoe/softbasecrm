using System;
using System.Collections.Generic;
using System.Linq;
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
                $"Accounts_{DateTime.Now:MM_dd_yyyy}.xlsx",
                excelPackage =>
                {
                    var sheet = excelPackage.CreateSheet(L("Customer"));

                    AddHeader(
                        sheet,
                        L("Name"),
                        L("Address"),
                        L("Phone"),
                        L("AccountType"),
                        L("AssignedUsers")
                    );

                    AddObjects(
                        sheet, customer,
                        _ => _.Customer.Name,
                        _ => _.Customer.Address,
                        _ => _.Customer.Phone,
                        _ => _.AccountTypeDescription,
                        _ => _.Customer.Users != null &&_.Customer.Users.Any()
                            ? string.Join(", ",_.Customer.Users.Select(x => x.FullName))
                            : string.Empty
                    );
                    sheet.AutoSizeColumn(159);
                });
        }
    }
}