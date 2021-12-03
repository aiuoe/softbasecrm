using System.Collections.Generic;
using Abp.Runtime.Session;
using Abp.Timing.Timezone;
using SBCRM.DataExporting.Excel.NPOI;
using SBCRM.Legacy.Dtos;
using SBCRM.Dto;
using SBCRM.Storage;

namespace SBCRM.Legacy.Exporting
{
    public class CustomerExcelExporter : NpoiExcelExporterBase, ICustomerExcelExporter
    {

        private readonly ITimeZoneConverter _timeZoneConverter;
        private readonly IAbpSession _abpSession;

        public CustomerExcelExporter(
            ITimeZoneConverter timeZoneConverter,
            IAbpSession abpSession,
            ITempFileCacheManager tempFileCacheManager) :
    base(tempFileCacheManager)
        {
            _timeZoneConverter = timeZoneConverter;
            _abpSession = abpSession;
        }

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
                        L("SearchName"),
                        L("SubName"),
                        L("POBox"),
                        L("Address"),
                        L("City"),
                        L("State"),
                        L("ZipCode"),
                        L("Country"),
                        L("Salutation"),
                        L("Phone"),
                        L("Extention"),
                        L("Phone2"),
                        L("Cellular"),
                        L("Beeper"),
                        L("HomePhone"),
                        L("Fax"),
                        L("ResaleNo"),
                        L("EMail"),
                        L("WWWAddress"),
                        L("ParentCompany"),
                        L("MapLocation"),
                        L("Salesman1"),
                        L("Salesman2"),
                        L("Salesman3"),
                        L("Salesman4"),
                        L("Salesman5"),
                        L("Salesman6"),
                        L("LockAPR1"),
                        L("LockAPR2"),
                        L("LockAPR3"),
                        L("LockAPR4"),
                        L("LockAPR5"),
                        L("LockAPR6"),
                        L("SalesGroup1"),
                        L("SalesGroup2"),
                        L("SalesGroup3"),
                        L("SalesGroup4"),
                        L("SalesGroup5"),
                        L("SalesGroup6"),
                        L("Terms"),
                        L("FiscalEnd"),
                        L("DunsCode"),
                        L("SICCode"),
                        L("MailingGroup"),
                        L("Makes"),
                        L("POReq"),
                        L("PrevShip"),
                        L("Taxable"),
                        L("TaxCode"),
                        L("LaborRate"),
                        L("ShopLaborRate"),
                        L("ShowLaborRate"),
                        L("RentalRate"),
                        L("ShowPartNoAlias"),
                        L("PartsRate"),
                        L("PartsRateDiscount"),
                        L("Added"),
                        L("AddedBy"),
                        L("Changed"),
                        L("ChangedBy"),
                        L("SalesContact"),
                        L("CSContact"),
                        L("AccountingContact"),
                        L("InternalCustomer"),
                        L("EquipmentBid"),
                        L("Comments"),
                        L("ARComments"),
                        L("CompanyComments"),
                        L("CompanyCommentsDate"),
                        L("CompanyCommentsBy"),
                        L("BusinessCategory"),
                        L("BusinessDescription"),
                        L("SICCode2"),
                        L("SICCode3"),
                        L("SICCode4"),
                        L("Shifts"),
                        L("Category"),
                        L("HoursOfOpStart"),
                        L("HoursOfOpEnd"),
                        L("DeliveryInfo"),
                        L("CustomerTerritory"),
                        L("CreditHoldFlag"),
                        L("CreditRating1"),
                        L("CreditRating2"),
                        L("Statements"),
                        L("CreditHoldDays"),
                        L("FinanceCharge"),
                        L("ResaleExpDate"),
                        L("StateTaxCode"),
                        L("CountyTaxCode"),
                        L("CityTaxCode"),
                        L("AbsoluteTaxCodes"),
                        L("MFGPermitNo"),
                        L("MFGPermitExpDate"),
                        L("Branch"),
                        L("ShowLaborHours"),
                        L("VendorNo"),
                        L("LocalTaxCode"),
                        L("CurrencyType"),
                        L("CreditCardNo"),
                        L("CreditCardCVV"),
                        L("CreditCardExpDate"),
                        L("CreditCardType"),
                        L("NameOnCreditCard"),
                        L("RFC"),
                        L("OldNumber"),
                        L("SuppressPartsPricing"),
                        L("ServiceCharge"),
                        L("ServiceChargeDescription"),
                        L("FinalCopies"),
                        L("POBoxAndAddress"),
                        L("InsuranceNo"),
                        L("InsuranceNoDate"),
                        L("InsuranceNoRecvDate"),
                        L("CreditCardAddress"),
                        L("CreditCardPOBox"),
                        L("CreditCardCity"),
                        L("CreditCardState"),
                        L("CreditCardZipCode"),
                        L("CreditCardCountry"),
                        L("PMLaborRate"),
                        L("ReferenceNo1"),
                        L("ReferenceNo2"),
                        L("GMSummary"),
                        L("OB10No"),
                        L("OldName"),
                        L("CustomerBillTo"),
                        L("ShipVia"),
                        L("NoAddMisc"),
                        L("LaborDiscount"),
                        L("TaxRate"),
                        L("TMHUNo"),
                        L("LockTaxCode"),
                        L("TaxCodeImport"),
                        L("ShippingComments"),
                        L("NoShippingCharge"),
                        L("ShippingCompany"),
                        L("ShippingAccount"),
                        L("EMailInvoiceAddress"),
                        L("EMailInvoiceAttention"),
                        L("EMailInvoice"),
                        L("NoPrintInvoice"),
                        L("BackupRequired"),
                        L("OldSalesman1"),
                        L("OldSalesman2"),
                        L("OldSalesman3"),
                        L("OldSalesman4"),
                        L("OldSalesman5"),
                        L("OldSalesman6"),
                        L("LastAutoSalesmanUpdate"),
                        L("LastAutoSalesmanUpdate1"),
                        L("LastAutoSalesmanUpdate2"),
                        L("LastAutoSalesmanUpdate3"),
                        L("LastAutoSalesmanUpdate4"),
                        L("LastAutoSalesmanUpdate5"),
                        L("LastAutoSalesmanUpdate6"),
                        L("InvoiceLanguage"),
                        L("PeopleSoft"),
                        L("PSCompany"),
                        L("PSAccount"),
                        L("PSLocation"),
                        L("PSDept"),
                        L("PSProduct"),
                        L("AltCustomerNo"),
                        L("OverRideShipTo"),
                        L("OnFileResale"),
                        L("OnFileMFGPermit"),
                        L("OnFileInsurance"),
                        L("Inactive"),
                        L("OverRideShipToRates"),
                        L("SuppressPartsList"),
                        L("MarketingSource"),
                        L("CreditCardLastTransID"),
                        L("EmailRoadService"),
                        L("EmailShopService"),
                        L("EmailPMService"),
                        L("EmailRentalPMService"),
                        L("EmailPartsCounter"),
                        L("EmailEquipmentSales"),
                        L("EmailRentals"),
                        L("ID"),
                        L("ARStatementsEmailAddress"),
                        (L("AccountType")) + L("Description")
                        );

                    AddObjects(
                        sheet, customer,
                        _ => _.Customer.Number,
                        _ => _.Customer.BillTo,
                        _ => _.Customer.Name,
                        //_ => _.Customer.SearchName,
                        //_ => _.Customer.SubName,
                        //_ => _.Customer.POBox,
                        _ => _.Customer.Address,
                        //_ => _.Customer.City,
                        //_ => _.Customer.State,
                        //_ => _.Customer.ZipCode,
                        //_ => _.Customer.Country,
                        //_ => _.Customer.Salutation,
                        _ => _.Customer.Phone,
                        //_ => _.Customer.Extention,
                        //_ => _.Customer.Phone2,
                        //_ => _.Customer.Cellular,
                        //_ => _.Customer.Beeper,
                        //_ => _.Customer.HomePhone,
                        //_ => _.Customer.Fax,
                        //_ => _.Customer.ResaleNo,
                        //_ => _.Customer.EMail,
                        //_ => _.Customer.WWWAddress,
                        //_ => _.Customer.ParentCompany,
                        //_ => _.Customer.MapLocation,
                        //_ => _.Customer.Salesman1,
                        //_ => _.Customer.Salesman2,
                        //_ => _.Customer.Salesman3,
                        //_ => _.Customer.Salesman4,
                        //_ => _.Customer.Salesman5,
                        //_ => _.Customer.Salesman6,
                        //_ => _.Customer.LockAPR1,
                        //_ => _.Customer.LockAPR2,
                        //_ => _.Customer.LockAPR3,
                        //_ => _.Customer.LockAPR4,
                        //_ => _.Customer.LockAPR5,
                        //_ => _.Customer.LockAPR6,
                        //_ => _.Customer.SalesGroup1,
                        //_ => _.Customer.SalesGroup2,
                        //_ => _.Customer.SalesGroup3,
                        //_ => _.Customer.SalesGroup4,
                        //_ => _.Customer.SalesGroup5,
                        //_ => _.Customer.SalesGroup6,
                        //_ => _.Customer.Terms,
                        //_ => _.Customer.FiscalEnd,
                        //_ => _.Customer.DunsCode,
                        //_ => _.Customer.SICCode,
                        //_ => _.Customer.MailingGroup,
                        //_ => _.Customer.Makes,
                        //_ => _.Customer.POReq,
                        //_ => _.Customer.PrevShip,
                        //_ => _.Customer.Taxable,
                        //_ => _.Customer.TaxCode,
                        //_ => _.Customer.LaborRate,
                        //_ => _.Customer.ShopLaborRate,
                        //_ => _.Customer.ShowLaborRate,
                        //_ => _.Customer.RentalRate,
                        //_ => _.Customer.ShowPartNoAlias,
                        //_ => _.Customer.PartsRate,
                        //_ => _.Customer.PartsRateDiscount,
                        //_ => _timeZoneConverter.Convert(_.Customer.Added, _abpSession.TenantId, _abpSession.GetUserId()),
                        //_ => _.Customer.AddedBy,
                        //_ => _timeZoneConverter.Convert(_.Customer.Changed, _abpSession.TenantId, _abpSession.GetUserId()),
                        //_ => _.Customer.ChangedBy,
                        //_ => _.Customer.SalesContact,
                        //_ => _.Customer.CSContact,
                        //_ => _.Customer.AccountingContact,
                        //_ => _.Customer.InternalCustomer,
                        //_ => _.Customer.EquipmentBid,
                        //_ => _.Customer.Comments,
                        //_ => _.Customer.ARComments,
                        //_ => _.Customer.CompanyComments,
                        //_ => _timeZoneConverter.Convert(_.Customer.CompanyCommentsDate, _abpSession.TenantId, _abpSession.GetUserId()),
                        //_ => _.Customer.CompanyCommentsBy,
                        //_ => _.Customer.BusinessCategory,
                        //_ => _.Customer.BusinessDescription,
                        //_ => _.Customer.SICCode2,
                        //_ => _.Customer.SICCode3,
                        //_ => _.Customer.SICCode4,
                        //_ => _.Customer.Shifts,
                        //_ => _.Customer.Category,
                        //_ => _timeZoneConverter.Convert(_.Customer.HoursOfOpStart, _abpSession.TenantId, _abpSession.GetUserId()),
                        //_ => _timeZoneConverter.Convert(_.Customer.HoursOfOpEnd, _abpSession.TenantId, _abpSession.GetUserId()),
                        //_ => _.Customer.DeliveryInfo,
                        //_ => _.Customer.CustomerTerritory,
                        //_ => _.Customer.CreditHoldFlag,
                        //_ => _.Customer.CreditRating1,
                        //_ => _.Customer.CreditRating2,
                        //_ => _.Customer.Statements,
                        //_ => _.Customer.CreditHoldDays,
                        //_ => _.Customer.FinanceCharge,
                        //_ => _timeZoneConverter.Convert(_.Customer.ResaleExpDate, _abpSession.TenantId, _abpSession.GetUserId()),
                        //_ => _.Customer.StateTaxCode,
                        //_ => _.Customer.CountyTaxCode,
                        //_ => _.Customer.CityTaxCode,
                        //_ => _.Customer.AbsoluteTaxCodes,
                        //_ => _.Customer.MFGPermitNo,
                        //_ => _timeZoneConverter.Convert(_.Customer.MFGPermitExpDate, _abpSession.TenantId, _abpSession.GetUserId()),
                        //_ => _.Customer.Branch,
                        //_ => _.Customer.ShowLaborHours,
                        //_ => _.Customer.VendorNo,
                        //_ => _.Customer.LocalTaxCode,
                        //_ => _.Customer.CurrencyType,
                        //_ => _.Customer.CreditCardNo,
                        //_ => _.Customer.CreditCardCVV,
                        //_ => _.Customer.CreditCardExpDate,
                        //_ => _.Customer.CreditCardType,
                        //_ => _.Customer.NameOnCreditCard,
                        //_ => _.Customer.RFC,
                        //_ => _.Customer.OldNumber,
                        //_ => _.Customer.SuppressPartsPricing,
                        //_ => _.Customer.ServiceCharge,
                        //_ => _.Customer.ServiceChargeDescription,
                        //_ => _.Customer.FinalCopies,
                        //_ => _.Customer.POBoxAndAddress,
                        //_ => _.Customer.InsuranceNo,
                        //_ => _timeZoneConverter.Convert(_.Customer.InsuranceNoDate, _abpSession.TenantId, _abpSession.GetUserId()),
                        //_ => _timeZoneConverter.Convert(_.Customer.InsuranceNoRecvDate, _abpSession.TenantId, _abpSession.GetUserId()),
                        //_ => _.Customer.CreditCardAddress,
                        //_ => _.Customer.CreditCardPOBox,
                        //_ => _.Customer.CreditCardCity,
                        //_ => _.Customer.CreditCardState,
                        //_ => _.Customer.CreditCardZipCode,
                        //_ => _.Customer.CreditCardCountry,
                        //_ => _.Customer.PMLaborRate,
                        //_ => _.Customer.ReferenceNo1,
                        //_ => _.Customer.ReferenceNo2,
                        //_ => _.Customer.GMSummary,
                        //_ => _.Customer.OB10No,
                        //_ => _.Customer.OldName,
                        //_ => _.Customer.CustomerBillTo,
                        //_ => _.Customer.ShipVia,
                        //_ => _.Customer.NoAddMisc,
                        //_ => _.Customer.LaborDiscount,
                        //_ => _.Customer.TaxRate,
                        //_ => _.Customer.TMHUNo,
                        //_ => _.Customer.LockTaxCode,
                        //_ => _.Customer.TaxCodeImport,
                        //_ => _.Customer.ShippingComments,
                        //_ => _.Customer.NoShippingCharge,
                        //_ => _.Customer.ShippingCompany,
                        //_ => _.Customer.ShippingAccount,
                        //_ => _.Customer.EMailInvoiceAddress,
                        //_ => _.Customer.EMailInvoiceAttention,
                        //_ => _.Customer.EMailInvoice,
                        //_ => _.Customer.NoPrintInvoice,
                        //_ => _.Customer.BackupRequired,
                        //_ => _.Customer.OldSalesman1,
                        //_ => _.Customer.OldSalesman2,
                        //_ => _.Customer.OldSalesman3,
                        //_ => _.Customer.OldSalesman4,
                        //_ => _.Customer.OldSalesman5,
                        //_ => _.Customer.OldSalesman6,
                        //_ => _timeZoneConverter.Convert(_.Customer.LastAutoSalesmanUpdate, _abpSession.TenantId, _abpSession.GetUserId()),
                        //_ => _timeZoneConverter.Convert(_.Customer.LastAutoSalesmanUpdate1, _abpSession.TenantId, _abpSession.GetUserId()),
                        //_ => _timeZoneConverter.Convert(_.Customer.LastAutoSalesmanUpdate2, _abpSession.TenantId, _abpSession.GetUserId()),
                        //_ => _timeZoneConverter.Convert(_.Customer.LastAutoSalesmanUpdate3, _abpSession.TenantId, _abpSession.GetUserId()),
                        //_ => _timeZoneConverter.Convert(_.Customer.LastAutoSalesmanUpdate4, _abpSession.TenantId, _abpSession.GetUserId()),
                        //_ => _timeZoneConverter.Convert(_.Customer.LastAutoSalesmanUpdate5, _abpSession.TenantId, _abpSession.GetUserId()),
                        //_ => _timeZoneConverter.Convert(_.Customer.LastAutoSalesmanUpdate6, _abpSession.TenantId, _abpSession.GetUserId()),
                        //_ => _.Customer.InvoiceLanguage,
                        //_ => _.Customer.PeopleSoft,
                        //_ => _.Customer.PSCompany,
                        //_ => _.Customer.PSAccount,
                        //_ => _.Customer.PSLocation,
                        //_ => _.Customer.PSDept,
                        //_ => _.Customer.PSProduct,
                        //_ => _.Customer.AltCustomerNo,
                        //_ => _.Customer.OverRideShipTo,
                        //_ => _.Customer.OnFileResale,
                        //_ => _.Customer.OnFileMFGPermit,
                        //_ => _.Customer.OnFileInsurance,
                        //_ => _.Customer.Inactive,
                        //_ => _.Customer.OverRideShipToRates,
                        //_ => _.Customer.SuppressPartsList,
                        //_ => _.Customer.MarketingSource,
                        //_ => _.Customer.CreditCardLastTransID,
                        //_ => _.Customer.EmailRoadService,
                        //_ => _.Customer.EmailShopService,
                        //_ => _.Customer.EmailPMService,
                        //_ => _.Customer.EmailRentalPMService,
                        //_ => _.Customer.EmailPartsCounter,
                        //_ => _.Customer.EmailEquipmentSales,
                        //_ => _.Customer.EmailRentals,
                        _ => _.Customer.ID,
                        //_ => _.Customer.ARStatementsEmailAddress,
                        _ => _.AccountTypeDescription
                        );

                    for (var i = 1; i <= customer.Count; i++)
                    {
                        SetCellDataFormat(sheet.GetRow(i).Cells[60], "yyyy-mm-dd");
                    }
                    sheet.AutoSizeColumn(60); for (var i = 1; i <= customer.Count; i++)
                    {
                        SetCellDataFormat(sheet.GetRow(i).Cells[62], "yyyy-mm-dd");
                    }
                    sheet.AutoSizeColumn(62); for (var i = 1; i <= customer.Count; i++)
                    {
                        SetCellDataFormat(sheet.GetRow(i).Cells[72], "yyyy-mm-dd");
                    }
                    sheet.AutoSizeColumn(72); for (var i = 1; i <= customer.Count; i++)
                    {
                        SetCellDataFormat(sheet.GetRow(i).Cells[81], "yyyy-mm-dd");
                    }
                    sheet.AutoSizeColumn(81); for (var i = 1; i <= customer.Count; i++)
                    {
                        SetCellDataFormat(sheet.GetRow(i).Cells[82], "yyyy-mm-dd");
                    }
                    sheet.AutoSizeColumn(82); for (var i = 1; i <= customer.Count; i++)
                    {
                        SetCellDataFormat(sheet.GetRow(i).Cells[91], "yyyy-mm-dd");
                    }
                    sheet.AutoSizeColumn(91); for (var i = 1; i <= customer.Count; i++)
                    {
                        SetCellDataFormat(sheet.GetRow(i).Cells[97], "yyyy-mm-dd");
                    }
                    sheet.AutoSizeColumn(97); for (var i = 1; i <= customer.Count; i++)
                    {
                        SetCellDataFormat(sheet.GetRow(i).Cells[116], "yyyy-mm-dd");
                    }
                    sheet.AutoSizeColumn(116); for (var i = 1; i <= customer.Count; i++)
                    {
                        SetCellDataFormat(sheet.GetRow(i).Cells[117], "yyyy-mm-dd");
                    }
                    sheet.AutoSizeColumn(117); for (var i = 1; i <= customer.Count; i++)
                    {
                        SetCellDataFormat(sheet.GetRow(i).Cells[153], "yyyy-mm-dd");
                    }
                    sheet.AutoSizeColumn(153); for (var i = 1; i <= customer.Count; i++)
                    {
                        SetCellDataFormat(sheet.GetRow(i).Cells[154], "yyyy-mm-dd");
                    }
                    sheet.AutoSizeColumn(154); for (var i = 1; i <= customer.Count; i++)
                    {
                        SetCellDataFormat(sheet.GetRow(i).Cells[155], "yyyy-mm-dd");
                    }
                    sheet.AutoSizeColumn(155); for (var i = 1; i <= customer.Count; i++)
                    {
                        SetCellDataFormat(sheet.GetRow(i).Cells[156], "yyyy-mm-dd");
                    }
                    sheet.AutoSizeColumn(156); for (var i = 1; i <= customer.Count; i++)
                    {
                        SetCellDataFormat(sheet.GetRow(i).Cells[157], "yyyy-mm-dd");
                    }
                    sheet.AutoSizeColumn(157); for (var i = 1; i <= customer.Count; i++)
                    {
                        SetCellDataFormat(sheet.GetRow(i).Cells[158], "yyyy-mm-dd");
                    }
                    sheet.AutoSizeColumn(158); for (var i = 1; i <= customer.Count; i++)
                    {
                        SetCellDataFormat(sheet.GetRow(i).Cells[159], "yyyy-mm-dd");
                    }
                    sheet.AutoSizeColumn(159);
                });
        }
    }
}