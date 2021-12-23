using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities.Auditing;
using Abp.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace SBCRM.Legacy
{
    /// <summary>
    /// dbo.Secure table from legacy database
    /// </summary>
    [Table("Secure", Schema = "dbo")]
    public class Secure
    {
        [Key]
        public virtual string Password { get; set; }

        public virtual int? EmployeeNo { get; set; }

        public virtual short? AdminProgram { get; set; }

        public virtual short? SaleExpenseCodes { get; set; }

        public virtual short? Company { get; set; }

        public virtual short? Branch { get; set; }

        public virtual short? Department { get; set; }

        public virtual short? Personnel { get; set; }

        public virtual short? Security { get; set; }

        public virtual short? LaborRates { get; set; }

        public virtual short? SDIAccounting { get; set; }

        public virtual short? CustomerProgram { get; set; }

        public virtual short? CustomerChange { get; set; }

        public virtual short? CustomerAdd { get; set; }

        public virtual short? CustomerDelete { get; set; }

        public virtual short? EquipmentProgram { get; set; }

        public virtual short? EquipmentChange { get; set; }

        public virtual short? EquipmentAdd { get; set; }

        public virtual short? EquipmentDelete { get; set; }

        public virtual short? EquipmentPM { get; set; }

        public virtual short? EquipmentCost { get; set; }

        public virtual short? EquipmentAdmin { get; set; }

        public virtual short? EquipmentAddAs { get; set; }

        public virtual short? InvoiceProgram { get; set; }

        public virtual short? InvoiceUpdate { get; set; }

        public virtual short? InvoiceOpen { get; set; }

        public virtual short? InvoiceClose { get; set; }

        public virtual short? InvoiceOpenPM { get; set; }

        public virtual short? InvoicePrintFinal { get; set; }

        public virtual short? InvoiceLaborTicket { get; set; }

        public virtual short? InvoiceComments { get; set; }

        public virtual short? InvoicePartsChange { get; set; }

        public virtual short? InvoicePartsAdd { get; set; }

        public virtual short? InvoicePartsDelete { get; set; }

        public virtual short? InvoicePartsTransfer { get; set; }

        public virtual short? InvoiceLaborChange { get; set; }

        public virtual short? InvoiceLaborAdd { get; set; }

        public virtual short? InvoiceLaborDelete { get; set; }

        public virtual short? InvoiceLaborTransfer { get; set; }

        public virtual short? InvoiceMiscChange { get; set; }

        public virtual short? InvoiceMiscAdd { get; set; }

        public virtual short? InvoiceMiscDelete { get; set; }

        public virtual short? InvoiceMiscTransfer { get; set; }

        public virtual short? InvoiceRentalChange { get; set; }

        public virtual short? InvoiceRentalAdd { get; set; }

        public virtual short? InvoiceRentalDelete { get; set; }

        public virtual short? InvoiceRentalTransfer { get; set; }

        public virtual short? InvoiceEquipmentChange { get; set; }

        public virtual short? InvoiceEquipmentAdd { get; set; }

        public virtual short? InvoiceEquipmentDelete { get; set; }

        public virtual short? InvoiceEquipmentTransfer { get; set; }

        public virtual short? InvoiceWIP { get; set; }

        public virtual short? InvoiceRegister { get; set; }

        public virtual short? InvoiceReOpen { get; set; }

        public virtual short? CreditMemos { get; set; }

        public virtual short? PartsProgram { get; set; }

        public virtual short? PartsChange { get; set; }

        public virtual short? PartsAdd { get; set; }

        public virtual short? PartsDelete { get; set; }

        public virtual short? PartsInquiry { get; set; }

        public virtual short? PartsTransfer { get; set; }

        public virtual short? PartsGroup { get; set; }

        public virtual short? PartsWarehouse { get; set; }

        public virtual short? PartsCost { get; set; }

        public virtual short? PartsAdmin { get; set; }

        public virtual short? PartsOrdering { get; set; }

        public virtual short? PartsInventory { get; set; }

        public virtual short? PartsOnHand { get; set; }

        public virtual short? PartsPartNoAlias { get; set; }

        public virtual short? InvoiceDeptLimit { get; set; }

        public virtual short? CustomerCreditApproval { get; set; }

        public virtual short? APVoucher { get; set; }

        public virtual short? APChecks { get; set; }

        public virtual short? APChecksApproval { get; set; }

        public virtual short? APChecksAutoChecks { get; set; }

        public virtual short? APChecksHandTyped { get; set; }

        public virtual short? APChecksRegister { get; set; }

        public virtual short? APChecksVoid { get; set; }

        public virtual short? APInquiry { get; set; }

        public virtual short? ARInquiry { get; set; }

        public virtual short? ARCash { get; set; }

        public virtual short? COA { get; set; }

        public virtual short? GJ { get; set; }

        public virtual short? GLInquiry { get; set; }

        public virtual short? Vendor { get; set; }

        public virtual short? InvoiceAccountingDist { get; set; }

        public virtual short? EquipmentUnitNo { get; set; }

        public virtual bool? WebAccess { get; set; }

        public virtual bool? WebCustomer { get; set; }

        public virtual string WebCustomerNo { get; set; }

        public virtual bool? WebWIP { get; set; }

        public virtual bool? WebCustWIP { get; set; }

        public virtual bool? WebCustFleet { get; set; }

        public virtual bool? WebContacts { get; set; }

        public virtual bool? WebCallReports { get; set; }

        public virtual bool? WebEquipmentSummary { get; set; }

        public virtual bool? WebCustAR { get; set; }

        public virtual bool? InvoiceGPParts { get; set; }

        public virtual bool? InvoiceGPLabor { get; set; }

        public virtual bool? InvoiceGPMisc { get; set; }

        public virtual bool? InvoiceGPRental { get; set; }

        public virtual bool? InvoiceGPEquipment { get; set; }

        public virtual bool? InvoiceGPTotal { get; set; }

        public virtual bool? InvoiceAccountingFormat { get; set; }

        public virtual bool? EquipmentControlNo { get; set; }

        public virtual bool? ARComments { get; set; }

        public virtual bool? CustomerCommission { get; set; }

        public virtual bool? InvoiceNewEquipment { get; set; }

        public virtual bool? InvoiceRates { get; set; }

        public virtual bool? InvoiceFlatRateLabor { get; set; }

        public virtual bool? InvoiceFlatRateParts { get; set; }

        public virtual bool? InvoiceFlatRateMisc { get; set; }

        public virtual bool? InvoiceFlatRateRental { get; set; }

        public virtual bool? InvoiceFlatRateEquipment { get; set; }

        public virtual bool? EquipmentInventory { get; set; }

        public virtual bool? CustomerRates { get; set; }

        public virtual bool? ProfileARComments { get; set; }

        public virtual string WebUserID { get; set; }

        public virtual bool? ManagementInformation { get; set; }

        public virtual bool? EquipmentRentalRates { get; set; }

        public virtual bool? EquipmentGLInfo { get; set; }

        public virtual bool? PartsApproveOrders { get; set; }

        public virtual bool? PartsLostSale { get; set; }

        public virtual bool? PartsGroupBinChange { get; set; }

        public virtual bool? InvoiceAddShipTo { get; set; }

        public virtual bool? PartsToyotaNoAutoDash { get; set; }

        public virtual bool? PartsWarehouseLimit { get; set; }

        public virtual bool? InvoiceOverRideCurrencyRate { get; set; }

        public virtual bool? InvoicePartsBelowCost { get; set; }
        public virtual string WebWarehouse { get; set; }

        public virtual bool? WebPartsInquiry { get; set; }

        public virtual bool? WebPartsOrder { get; set; }

        public virtual bool? InvoiceSalesman { get; set; }

        public virtual bool? EquipmentLocation { get; set; }

        public virtual bool? CustomerTerms { get; set; }

        public virtual bool? InvoiceAutoOpenPMs { get; set; }

        public virtual bool? EquipmentTab0 { get; set; }

        public virtual bool? EquipmentTab1 { get; set; }

        public virtual bool? EquipmentTab2 { get; set; }

        public virtual bool? EquipmentTab3 { get; set; }

        public virtual bool? EquipmentTab4 { get; set; }

        public virtual bool? EquipmentTab5 { get; set; }

        public virtual bool? EquipmentTab6 { get; set; }

        public virtual bool? EquipmentTab7 { get; set; }

        public virtual bool? EquipmentTab8 { get; set; }

        public virtual bool? EquipmentTab9 { get; set; }

        public virtual bool? CustomerCreditInfo { get; set; }

        public virtual bool? InvoiceFixPONo { get; set; }

        public virtual bool? InvoiceFixSalesman { get; set; }

        public virtual bool? InvoiceFixWriter { get; set; }

        public virtual bool? InvoiceFixShipVia { get; set; }

        public virtual bool? InvoiceFixFOB { get; set; }

        public virtual bool? EquipmentChangeSerialNo { get; set; }

        public virtual bool? CustomerCC { get; set; }

        public virtual bool? EquipmentTab10 { get; set; }

        public virtual bool? InvoiceMechLimitFlag { get; set; }

        public virtual int? InvoiceMechNo { get; set; }

        public virtual string AddedBy { get; set; }

        public virtual DateTime? DateAdded { get; set; }

        public virtual string ChangedBy { get; set; }

        public virtual DateTime? DateChanged { get; set; }

        public virtual bool? InvoiceFix { get; set; }

        public virtual bool? InvoiceFixHourMeter { get; set; }

        public virtual bool? Transportation { get; set; }

        public virtual bool? TransportationHeader { get; set; }

        public virtual bool? TransportationDetail { get; set; }

        public virtual bool? DocumentCenter { get; set; }

        public virtual bool? DocumentCenterWOAdd { get; set; }

        public virtual bool? DocumentCenterWODelete { get; set; }

        public virtual bool? DocumentCenterRentalAdd { get; set; }

        public virtual bool? DocumentCenterRentalDelete { get; set; }

        public virtual bool? DocumentCenterMechanicAdd { get; set; }

        public virtual bool? DocumentCenterMechanicDelete { get; set; }

        public virtual bool? DocumentCenterCustomerAdd { get; set; }

        public virtual bool? DocumentCenterCustomerDelete { get; set; }

        public virtual bool? DocumentCenterEQAdd { get; set; }

        public virtual bool? DocumentCenterEQDelete { get; set; }

        public virtual bool? DocumentCenterVendorAdd { get; set; }

        public virtual bool? DocumentCenterVendorDelete { get; set; }

        public virtual bool? DocumentCenterAPInvoiceAdd { get; set; }

        public virtual bool? DocumentCenterAPInvoiceDelete { get; set; }

        public virtual bool? DocumentCenterPOAdd { get; set; }

        public virtual bool? DocumentCenterPODelete { get; set; }

        public virtual bool? InvoiceFixComments { get; set; }

        public virtual string DispatchName { get; set; }

        public virtual bool? SDI { get; set; }

        public virtual bool? AdminInspectionSetup { get; set; }

        public virtual bool? AdminDisableSSN { get; set; }

        public virtual bool? AdminDisableDLN { get; set; }

        public virtual bool? WebServiceDispatch { get; set; }

        public virtual bool? WebTransportationDispatch { get; set; }

        public virtual bool? WebMobileAdmin { get; set; }

        public virtual bool? WebMobileSalesman { get; set; }

        public virtual bool? WebMobileNoSelfPMDispatch { get; set; }

        public virtual bool? InvoiceDesignOptions { get; set; }

        public virtual bool? PartsUserCrossSetup { get; set; }

        public virtual bool? InvoiceFixRentalDates { get; set; }

        public virtual bool? PartsReceiving { get; set; }

        public virtual bool? AdminDisableHourlyRate { get; set; }

        public virtual bool? WebMobileNoLaborEdit { get; set; }

        public virtual bool? MechanicClockIn { get; set; }

        public virtual bool? PartsDisallowBOCostChange { get; set; }

    }
}