using System;
using Abp.Application.Services.Dto;

namespace SBCRM.Legacy.Dtos
{
    public class SecureDto : EntityDto
    {
        public string Password { get; set; }

        public int? EmployeeNo { get; set; }

        public short? AdminProgram { get; set; }

        public short? SaleExpenseCodes { get; set; }

        public short? Company { get; set; }

        public short? Branch { get; set; }

        public short? Department { get; set; }

        public short? Personnel { get; set; }

        public short? Security { get; set; }

        public short? LaborRates { get; set; }

        public short? SDIAccounting { get; set; }

        public short? CustomerProgram { get; set; }

        public short? CustomerChange { get; set; }

        public short? CustomerAdd { get; set; }

        public short? CustomerDelete { get; set; }

        public short? EquipmentProgram { get; set; }

        public short? EquipmentChange { get; set; }

        public short? EquipmentAdd { get; set; }

        public short? EquipmentDelete { get; set; }

        public short? EquipmentPM { get; set; }

        public short? EquipmentCost { get; set; }

        public short? EquipmentAdmin { get; set; }

        public short? EquipmentAddAs { get; set; }

        public short? InvoiceProgram { get; set; }

        public short? InvoiceUpdate { get; set; }

        public short? InvoiceOpen { get; set; }

        public short? InvoiceClose { get; set; }

        public short? InvoiceOpenPM { get; set; }

        public short? InvoicePrintFinal { get; set; }

        public short? InvoiceLaborTicket { get; set; }

        public short? InvoiceComments { get; set; }

        public short? InvoicePartsChange { get; set; }

        public short? InvoicePartsAdd { get; set; }

        public short? InvoicePartsDelete { get; set; }

        public short? InvoicePartsTransfer { get; set; }

        public short? InvoiceLaborChange { get; set; }

        public short? InvoiceLaborAdd { get; set; }

        public short? InvoiceLaborDelete { get; set; }

        public short? InvoiceLaborTransfer { get; set; }

        public short? InvoiceMiscChange { get; set; }

        public short? InvoiceMiscAdd { get; set; }

        public short? InvoiceMiscDelete { get; set; }

        public short? InvoiceMiscTransfer { get; set; }

        public short? InvoiceRentalChange { get; set; }

        public short? InvoiceRentalAdd { get; set; }

        public short? InvoiceRentalDelete { get; set; }

        public short? InvoiceRentalTransfer { get; set; }

        public short? InvoiceEquipmentChange { get; set; }

        public short? InvoiceEquipmentAdd { get; set; }

        public short? InvoiceEquipmentDelete { get; set; }

        public short? InvoiceEquipmentTransfer { get; set; }

        public short? InvoiceWIP { get; set; }

        public short? InvoiceRegister { get; set; }

        public short? InvoiceReOpen { get; set; }

        public short? CreditMemos { get; set; }

        public short? PartsProgram { get; set; }

        public short? PartsChange { get; set; }

        public short? PartsAdd { get; set; }

        public short? PartsDelete { get; set; }

        public short? PartsInquiry { get; set; }

        public short? PartsTransfer { get; set; }

        public short? PartsGroup { get; set; }

        public short? PartsWarehouse { get; set; }

        public short? PartsCost { get; set; }

        public short? PartsAdmin { get; set; }

        public short? PartsOrdering { get; set; }

        public short? PartsInventory { get; set; }

        public short? PartsOnHand { get; set; }

        public short? PartsPartNoAlias { get; set; }

        public short? InvoiceDeptLimit { get; set; }

        public short? CustomerCreditApproval { get; set; }

        public short? APVoucher { get; set; }

        public short? APChecks { get; set; }

        public short? APChecksApproval { get; set; }

        public short? APChecksAutoChecks { get; set; }

        public short? APChecksHandTyped { get; set; }

        public short? APChecksRegister { get; set; }

        public short? APChecksVoid { get; set; }

        public short? APInquiry { get; set; }

        public short? ARInquiry { get; set; }

        public short? ARCash { get; set; }

        public short? COA { get; set; }

        public short? GJ { get; set; }

        public short? GLInquiry { get; set; }

        public short? Vendor { get; set; }

        public short? InvoiceAccountingDist { get; set; }

        public short? EquipmentUnitNo { get; set; }

        public bool WebAccess { get; set; }

        public bool WebCustomer { get; set; }

        public string WebCustomerNo { get; set; }

        public bool WebWIP { get; set; }

        public bool WebCustWIP { get; set; }

        public bool WebCustFleet { get; set; }

        public bool WebContacts { get; set; }

        public bool WebCallReports { get; set; }

        public bool WebEquipmentSummary { get; set; }

        public bool WebCustAR { get; set; }

        public bool InvoiceGPParts { get; set; }

        public bool InvoiceGPLabor { get; set; }

        public bool InvoiceGPMisc { get; set; }

        public bool InvoiceGPRental { get; set; }

        public bool InvoiceGPEquipment { get; set; }

        public bool InvoiceGPTotal { get; set; }

        public bool InvoiceAccountingFormat { get; set; }

        public bool EquipmentControlNo { get; set; }

        public bool ARComments { get; set; }

        public bool CustomerCommission { get; set; }

        public bool InvoiceNewEquipment { get; set; }

        public bool InvoiceRates { get; set; }

        public bool InvoiceFlatRateLabor { get; set; }

        public bool InvoiceFlatRateParts { get; set; }

        public bool InvoiceFlatRateMisc { get; set; }

        public bool InvoiceFlatRateRental { get; set; }

        public bool InvoiceFlatRateEquipment { get; set; }

        public bool EquipmentInventory { get; set; }

        public bool CustomerRates { get; set; }

        public bool ProfileARComments { get; set; }

        public string WebUserID { get; set; }

        public bool ManagementInformation { get; set; }

        public bool EquipmentRentalRates { get; set; }

        public bool EquipmentGLInfo { get; set; }

        public bool PartsApproveOrders { get; set; }

        public bool PartsLostSale { get; set; }

        public bool PartsGroupBinChange { get; set; }

        public bool InvoiceAddShipTo { get; set; }

        public bool PartsToyotaNoAutoDash { get; set; }

        public bool PartsWarehouseLimit { get; set; }

        public bool InvoiceOverRideCurrencyRate { get; set; }

        public bool InvoicePartsBelowCost { get; set; }

        public string WebWarehouse { get; set; }

        public bool WebPartsInquiry { get; set; }

        public bool WebPartsOrder { get; set; }

        public bool InvoiceSalesman { get; set; }

        public bool EquipmentLocation { get; set; }

        public bool CustomerTerms { get; set; }

        public bool InvoiceAutoOpenPMs { get; set; }

        public bool EquipmentTab0 { get; set; }

        public bool EquipmentTab1 { get; set; }

        public bool EquipmentTab2 { get; set; }

        public bool EquipmentTab3 { get; set; }

        public bool EquipmentTab4 { get; set; }

        public bool EquipmentTab5 { get; set; }

        public bool EquipmentTab6 { get; set; }

        public bool EquipmentTab7 { get; set; }

        public bool EquipmentTab8 { get; set; }

        public bool EquipmentTab9 { get; set; }

        public bool CustomerCreditInfo { get; set; }

        public bool InvoiceFixPONo { get; set; }

        public bool InvoiceFixSalesman { get; set; }

        public bool InvoiceFixWriter { get; set; }

        public bool InvoiceFixShipVia { get; set; }

        public bool InvoiceFixFOB { get; set; }

        public bool EquipmentChangeSerialNo { get; set; }

        public bool CustomerCC { get; set; }

        public bool EquipmentTab10 { get; set; }

        public bool InvoiceMechLimitFlag { get; set; }

        public int? InvoiceMechNo { get; set; }

        public string AddedBy { get; set; }

        public DateTime? DateAdded { get; set; }

        public string ChangedBy { get; set; }

        public DateTime? DateChanged { get; set; }

        public bool InvoiceFix { get; set; }

        public bool InvoiceFixHourMeter { get; set; }

        public bool Transportation { get; set; }

        public bool TransportationHeader { get; set; }

        public bool TransportationDetail { get; set; }

        public bool DocumentCenter { get; set; }

        public bool DocumentCenterWOAdd { get; set; }

        public bool DocumentCenterWODelete { get; set; }

        public bool DocumentCenterRentalAdd { get; set; }

        public bool DocumentCenterRentalDelete { get; set; }

        public bool DocumentCenterMechanicAdd { get; set; }

        public bool DocumentCenterMechanicDelete { get; set; }

        public bool DocumentCenterCustomerAdd { get; set; }

        public bool DocumentCenterCustomerDelete { get; set; }

        public bool DocumentCenterEQAdd { get; set; }

        public bool DocumentCenterEQDelete { get; set; }

        public bool DocumentCenterVendorAdd { get; set; }

        public bool DocumentCenterVendorDelete { get; set; }

        public bool DocumentCenterAPInvoiceAdd { get; set; }

        public bool DocumentCenterAPInvoiceDelete { get; set; }

        public bool DocumentCenterPOAdd { get; set; }

        public bool DocumentCenterPODelete { get; set; }

        public bool InvoiceFixComments { get; set; }

        public string DispatchName { get; set; }

        public bool SDI { get; set; }

        public bool AdminInspectionSetup { get; set; }

        public bool AdminDisableSSN { get; set; }

        public bool AdminDisableDLN { get; set; }

        public bool WebServiceDispatch { get; set; }

        public bool WebTransportationDispatch { get; set; }

        public bool WebMobileAdmin { get; set; }

        public bool WebMobileSalesman { get; set; }

        public bool WebMobileNoSelfPMDispatch { get; set; }

        public bool InvoiceDesignOptions { get; set; }

        public bool PartsUserCrossSetup { get; set; }

        public bool InvoiceFixRentalDates { get; set; }

        public bool PartsReceiving { get; set; }

        public bool AdminDisableHourlyRate { get; set; }

        public bool WebMobileNoLaborEdit { get; set; }

        public bool MechanicClockIn { get; set; }

        public bool PartsDisallowBOCostChange { get; set; }

    }
}