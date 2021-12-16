using Abp.Application.Services.Dto;
using System;

namespace SBCRM.Legacy.Dtos
{
    public class GetAllSecureInput : PagedAndSortedResultRequestDto
    {
        public string Filter { get; set; }

        public string PasswordFilter { get; set; }

        public int? MaxEmployeeNoFilter { get; set; }
        public int? MinEmployeeNoFilter { get; set; }

        public short? MaxAdminProgramFilter { get; set; }
        public short? MinAdminProgramFilter { get; set; }

        public short? MaxSaleExpenseCodesFilter { get; set; }
        public short? MinSaleExpenseCodesFilter { get; set; }

        public short? MaxCompanyFilter { get; set; }
        public short? MinCompanyFilter { get; set; }

        public short? MaxBranchFilter { get; set; }
        public short? MinBranchFilter { get; set; }

        public short? MaxDepartmentFilter { get; set; }
        public short? MinDepartmentFilter { get; set; }

        public short? MaxPersonnelFilter { get; set; }
        public short? MinPersonnelFilter { get; set; }

        public short? MaxSecurityFilter { get; set; }
        public short? MinSecurityFilter { get; set; }

        public short? MaxLaborRatesFilter { get; set; }
        public short? MinLaborRatesFilter { get; set; }

        public short? MaxSDIAccountingFilter { get; set; }
        public short? MinSDIAccountingFilter { get; set; }

        public short? MaxCustomerProgramFilter { get; set; }
        public short? MinCustomerProgramFilter { get; set; }

        public short? MaxCustomerChangeFilter { get; set; }
        public short? MinCustomerChangeFilter { get; set; }

        public short? MaxCustomerAddFilter { get; set; }
        public short? MinCustomerAddFilter { get; set; }

        public short? MaxCustomerDeleteFilter { get; set; }
        public short? MinCustomerDeleteFilter { get; set; }

        public short? MaxEquipmentProgramFilter { get; set; }
        public short? MinEquipmentProgramFilter { get; set; }

        public short? MaxEquipmentChangeFilter { get; set; }
        public short? MinEquipmentChangeFilter { get; set; }

        public short? MaxEquipmentAddFilter { get; set; }
        public short? MinEquipmentAddFilter { get; set; }

        public short? MaxEquipmentDeleteFilter { get; set; }
        public short? MinEquipmentDeleteFilter { get; set; }

        public short? MaxEquipmentPMFilter { get; set; }
        public short? MinEquipmentPMFilter { get; set; }

        public short? MaxEquipmentCostFilter { get; set; }
        public short? MinEquipmentCostFilter { get; set; }

        public short? MaxEquipmentAdminFilter { get; set; }
        public short? MinEquipmentAdminFilter { get; set; }

        public short? MaxEquipmentAddAsFilter { get; set; }
        public short? MinEquipmentAddAsFilter { get; set; }

        public short? MaxInvoiceProgramFilter { get; set; }
        public short? MinInvoiceProgramFilter { get; set; }

        public short? MaxInvoiceUpdateFilter { get; set; }
        public short? MinInvoiceUpdateFilter { get; set; }

        public short? MaxInvoiceOpenFilter { get; set; }
        public short? MinInvoiceOpenFilter { get; set; }

        public short? MaxInvoiceCloseFilter { get; set; }
        public short? MinInvoiceCloseFilter { get; set; }

        public short? MaxInvoiceOpenPMFilter { get; set; }
        public short? MinInvoiceOpenPMFilter { get; set; }

        public short? MaxInvoicePrintFinalFilter { get; set; }
        public short? MinInvoicePrintFinalFilter { get; set; }

        public short? MaxInvoiceLaborTicketFilter { get; set; }
        public short? MinInvoiceLaborTicketFilter { get; set; }

        public short? MaxInvoiceCommentsFilter { get; set; }
        public short? MinInvoiceCommentsFilter { get; set; }

        public short? MaxInvoicePartsChangeFilter { get; set; }
        public short? MinInvoicePartsChangeFilter { get; set; }

        public short? MaxInvoicePartsAddFilter { get; set; }
        public short? MinInvoicePartsAddFilter { get; set; }

        public short? MaxInvoicePartsDeleteFilter { get; set; }
        public short? MinInvoicePartsDeleteFilter { get; set; }

        public short? MaxInvoicePartsTransferFilter { get; set; }
        public short? MinInvoicePartsTransferFilter { get; set; }

        public short? MaxInvoiceLaborChangeFilter { get; set; }
        public short? MinInvoiceLaborChangeFilter { get; set; }

        public short? MaxInvoiceLaborAddFilter { get; set; }
        public short? MinInvoiceLaborAddFilter { get; set; }

        public short? MaxInvoiceLaborDeleteFilter { get; set; }
        public short? MinInvoiceLaborDeleteFilter { get; set; }

        public short? MaxInvoiceLaborTransferFilter { get; set; }
        public short? MinInvoiceLaborTransferFilter { get; set; }

        public short? MaxInvoiceMiscChangeFilter { get; set; }
        public short? MinInvoiceMiscChangeFilter { get; set; }

        public short? MaxInvoiceMiscAddFilter { get; set; }
        public short? MinInvoiceMiscAddFilter { get; set; }

        public short? MaxInvoiceMiscDeleteFilter { get; set; }
        public short? MinInvoiceMiscDeleteFilter { get; set; }

        public short? MaxInvoiceMiscTransferFilter { get; set; }
        public short? MinInvoiceMiscTransferFilter { get; set; }

        public short? MaxInvoiceRentalChangeFilter { get; set; }
        public short? MinInvoiceRentalChangeFilter { get; set; }

        public short? MaxInvoiceRentalAddFilter { get; set; }
        public short? MinInvoiceRentalAddFilter { get; set; }

        public short? MaxInvoiceRentalDeleteFilter { get; set; }
        public short? MinInvoiceRentalDeleteFilter { get; set; }

        public short? MaxInvoiceRentalTransferFilter { get; set; }
        public short? MinInvoiceRentalTransferFilter { get; set; }

        public short? MaxInvoiceEquipmentChangeFilter { get; set; }
        public short? MinInvoiceEquipmentChangeFilter { get; set; }

        public short? MaxInvoiceEquipmentAddFilter { get; set; }
        public short? MinInvoiceEquipmentAddFilter { get; set; }

        public short? MaxInvoiceEquipmentDeleteFilter { get; set; }
        public short? MinInvoiceEquipmentDeleteFilter { get; set; }

        public short? MaxInvoiceEquipmentTransferFilter { get; set; }
        public short? MinInvoiceEquipmentTransferFilter { get; set; }

        public short? MaxInvoiceWIPFilter { get; set; }
        public short? MinInvoiceWIPFilter { get; set; }

        public short? MaxInvoiceRegisterFilter { get; set; }
        public short? MinInvoiceRegisterFilter { get; set; }

        public short? MaxInvoiceReOpenFilter { get; set; }
        public short? MinInvoiceReOpenFilter { get; set; }

        public short? MaxCreditMemosFilter { get; set; }
        public short? MinCreditMemosFilter { get; set; }

        public short? MaxPartsProgramFilter { get; set; }
        public short? MinPartsProgramFilter { get; set; }

        public short? MaxPartsChangeFilter { get; set; }
        public short? MinPartsChangeFilter { get; set; }

        public short? MaxPartsAddFilter { get; set; }
        public short? MinPartsAddFilter { get; set; }

        public short? MaxPartsDeleteFilter { get; set; }
        public short? MinPartsDeleteFilter { get; set; }

        public short? MaxPartsInquiryFilter { get; set; }
        public short? MinPartsInquiryFilter { get; set; }

        public short? MaxPartsTransferFilter { get; set; }
        public short? MinPartsTransferFilter { get; set; }

        public short? MaxPartsGroupFilter { get; set; }
        public short? MinPartsGroupFilter { get; set; }

        public short? MaxPartsWarehouseFilter { get; set; }
        public short? MinPartsWarehouseFilter { get; set; }

        public short? MaxPartsCostFilter { get; set; }
        public short? MinPartsCostFilter { get; set; }

        public short? MaxPartsAdminFilter { get; set; }
        public short? MinPartsAdminFilter { get; set; }

        public short? MaxPartsOrderingFilter { get; set; }
        public short? MinPartsOrderingFilter { get; set; }

        public short? MaxPartsInventoryFilter { get; set; }
        public short? MinPartsInventoryFilter { get; set; }

        public short? MaxPartsOnHandFilter { get; set; }
        public short? MinPartsOnHandFilter { get; set; }

        public short? MaxPartsPartNoAliasFilter { get; set; }
        public short? MinPartsPartNoAliasFilter { get; set; }

        public short? MaxInvoiceDeptLimitFilter { get; set; }
        public short? MinInvoiceDeptLimitFilter { get; set; }

        public short? MaxCustomerCreditApprovalFilter { get; set; }
        public short? MinCustomerCreditApprovalFilter { get; set; }

        public short? MaxAPVoucherFilter { get; set; }
        public short? MinAPVoucherFilter { get; set; }

        public short? MaxAPChecksFilter { get; set; }
        public short? MinAPChecksFilter { get; set; }

        public short? MaxAPChecksApprovalFilter { get; set; }
        public short? MinAPChecksApprovalFilter { get; set; }

        public short? MaxAPChecksAutoChecksFilter { get; set; }
        public short? MinAPChecksAutoChecksFilter { get; set; }

        public short? MaxAPChecksHandTypedFilter { get; set; }
        public short? MinAPChecksHandTypedFilter { get; set; }

        public short? MaxAPChecksRegisterFilter { get; set; }
        public short? MinAPChecksRegisterFilter { get; set; }

        public short? MaxAPChecksVoidFilter { get; set; }
        public short? MinAPChecksVoidFilter { get; set; }

        public short? MaxAPInquiryFilter { get; set; }
        public short? MinAPInquiryFilter { get; set; }

        public short? MaxARInquiryFilter { get; set; }
        public short? MinARInquiryFilter { get; set; }

        public short? MaxARCashFilter { get; set; }
        public short? MinARCashFilter { get; set; }

        public short? MaxCOAFilter { get; set; }
        public short? MinCOAFilter { get; set; }

        public short? MaxGJFilter { get; set; }
        public short? MinGJFilter { get; set; }

        public short? MaxGLInquiryFilter { get; set; }
        public short? MinGLInquiryFilter { get; set; }

        public short? MaxVendorFilter { get; set; }
        public short? MinVendorFilter { get; set; }

        public short? MaxInvoiceAccountingDistFilter { get; set; }
        public short? MinInvoiceAccountingDistFilter { get; set; }

        public short? MaxEquipmentUnitNoFilter { get; set; }
        public short? MinEquipmentUnitNoFilter { get; set; }

        public int? WebAccessFilter { get; set; }

        public int? WebCustomerFilter { get; set; }

        public string WebCustomerNoFilter { get; set; }

        public int? WebWIPFilter { get; set; }

        public int? WebCustWIPFilter { get; set; }

        public int? WebCustFleetFilter { get; set; }

        public int? WebContactsFilter { get; set; }

        public int? WebCallReportsFilter { get; set; }

        public int? WebEquipmentSummaryFilter { get; set; }

        public int? WebCustARFilter { get; set; }

        public int? InvoiceGPPartsFilter { get; set; }

        public int? InvoiceGPLaborFilter { get; set; }

        public int? InvoiceGPMiscFilter { get; set; }

        public int? InvoiceGPRentalFilter { get; set; }

        public int? InvoiceGPEquipmentFilter { get; set; }

        public int? InvoiceGPTotalFilter { get; set; }

        public int? InvoiceAccountingFormatFilter { get; set; }

        public int? EquipmentControlNoFilter { get; set; }

        public int? ARCommentsFilter { get; set; }

        public int? CustomerCommissionFilter { get; set; }

        public int? InvoiceNewEquipmentFilter { get; set; }

        public int? InvoiceRatesFilter { get; set; }

        public int? InvoiceFlatRateLaborFilter { get; set; }

        public int? InvoiceFlatRatePartsFilter { get; set; }

        public int? InvoiceFlatRateMiscFilter { get; set; }

        public int? InvoiceFlatRateRentalFilter { get; set; }

        public int? InvoiceFlatRateEquipmentFilter { get; set; }

        public int? EquipmentInventoryFilter { get; set; }

        public int? CustomerRatesFilter { get; set; }

        public int? ProfileARCommentsFilter { get; set; }

        public string WebUserIDFilter { get; set; }

        public int? ManagementInformationFilter { get; set; }

        public int? EquipmentRentalRatesFilter { get; set; }

        public int? EquipmentGLInfoFilter { get; set; }

        public int? PartsApproveOrdersFilter { get; set; }

        public int? PartsLostSaleFilter { get; set; }

        public int? PartsGroupBinChangeFilter { get; set; }

        public int? InvoiceAddShipToFilter { get; set; }

        public int? PartsToyotaNoAutoDashFilter { get; set; }

        public int? PartsWarehouseLimitFilter { get; set; }

        public int? InvoiceOverRideCurrencyRateFilter { get; set; }

        public int? InvoicePartsBelowCostFilter { get; set; }

        public string WebWarehouseFilter { get; set; }

        public int? WebPartsInquiryFilter { get; set; }

        public int? WebPartsOrderFilter { get; set; }

        public int? InvoiceSalesmanFilter { get; set; }

        public int? EquipmentLocationFilter { get; set; }

        public int? CustomerTermsFilter { get; set; }

        public int? InvoiceAutoOpenPMsFilter { get; set; }

        public int? EquipmentTab0Filter { get; set; }

        public int? EquipmentTab1Filter { get; set; }

        public int? EquipmentTab2Filter { get; set; }

        public int? EquipmentTab3Filter { get; set; }

        public int? EquipmentTab4Filter { get; set; }

        public int? EquipmentTab5Filter { get; set; }

        public int? EquipmentTab6Filter { get; set; }

        public int? EquipmentTab7Filter { get; set; }

        public int? EquipmentTab8Filter { get; set; }

        public int? EquipmentTab9Filter { get; set; }

        public int? CustomerCreditInfoFilter { get; set; }

        public int? InvoiceFixPONoFilter { get; set; }

        public int? InvoiceFixSalesmanFilter { get; set; }

        public int? InvoiceFixWriterFilter { get; set; }

        public int? InvoiceFixShipViaFilter { get; set; }

        public int? InvoiceFixFOBFilter { get; set; }

        public int? EquipmentChangeSerialNoFilter { get; set; }

        public int? CustomerCCFilter { get; set; }

        public int? EquipmentTab10Filter { get; set; }

        public int? InvoiceMechLimitFlagFilter { get; set; }

        public int? MaxInvoiceMechNoFilter { get; set; }
        public int? MinInvoiceMechNoFilter { get; set; }

        public string AddedByFilter { get; set; }

        public DateTime? MaxDateAddedFilter { get; set; }
        public DateTime? MinDateAddedFilter { get; set; }

        public string ChangedByFilter { get; set; }

        public DateTime? MaxDateChangedFilter { get; set; }
        public DateTime? MinDateChangedFilter { get; set; }

        public int? InvoiceFixFilter { get; set; }

        public int? InvoiceFixHourMeterFilter { get; set; }

        public int? TransportationFilter { get; set; }

        public int? TransportationHeaderFilter { get; set; }

        public int? TransportationDetailFilter { get; set; }

        public int? DocumentCenterFilter { get; set; }

        public int? DocumentCenterWOAddFilter { get; set; }

        public int? DocumentCenterWODeleteFilter { get; set; }

        public int? DocumentCenterRentalAddFilter { get; set; }

        public int? DocumentCenterRentalDeleteFilter { get; set; }

        public int? DocumentCenterMechanicAddFilter { get; set; }

        public int? DocumentCenterMechanicDeleteFilter { get; set; }

        public int? DocumentCenterCustomerAddFilter { get; set; }

        public int? DocumentCenterCustomerDeleteFilter { get; set; }

        public int? DocumentCenterEQAddFilter { get; set; }

        public int? DocumentCenterEQDeleteFilter { get; set; }

        public int? DocumentCenterVendorAddFilter { get; set; }

        public int? DocumentCenterVendorDeleteFilter { get; set; }

        public int? DocumentCenterAPInvoiceAddFilter { get; set; }

        public int? DocumentCenterAPInvoiceDeleteFilter { get; set; }

        public int? DocumentCenterPOAddFilter { get; set; }

        public int? DocumentCenterPODeleteFilter { get; set; }

        public int? InvoiceFixCommentsFilter { get; set; }

        public string DispatchNameFilter { get; set; }

        public int? SDIFilter { get; set; }

        public int? AdminInspectionSetupFilter { get; set; }

        public int? AdminDisableSSNFilter { get; set; }

        public int? AdminDisableDLNFilter { get; set; }

        public int? WebServiceDispatchFilter { get; set; }

        public int? WebTransportationDispatchFilter { get; set; }

        public int? WebMobileAdminFilter { get; set; }

        public int? WebMobileSalesmanFilter { get; set; }

        public int? WebMobileNoSelfPMDispatchFilter { get; set; }

        public int? InvoiceDesignOptionsFilter { get; set; }

        public int? PartsUserCrossSetupFilter { get; set; }

        public int? InvoiceFixRentalDatesFilter { get; set; }

        public int? PartsReceivingFilter { get; set; }

        public int? AdminDisableHourlyRateFilter { get; set; }

        public int? WebMobileNoLaborEditFilter { get; set; }

        public int? MechanicClockInFilter { get; set; }

        public int? PartsDisallowBOCostChangeFilter { get; set; }

    }
}