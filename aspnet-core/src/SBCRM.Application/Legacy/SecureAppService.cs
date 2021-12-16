using System;
using System.Linq;
using System.Linq.Dynamic.Core;
using Abp.Linq.Extensions;
using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Domain.Repositories;
using SBCRM.Legacy.Dtos;
using SBCRM.Dto;
using Abp.Application.Services.Dto;
using SBCRM.Authorization;
using Abp.Extensions;
using Abp.Authorization;
using Microsoft.EntityFrameworkCore;
using Abp.UI;
using SBCRM.Storage;

namespace SBCRM.Legacy
{
    /// <summary>
    /// Service to interact with the repository for dbo.Secure table
    /// </summary>
    [AbpAuthorize(AppPermissions.Pages_Secure)]
    public class SecureAppService : SBCRMAppServiceBase, ISecureAppService
    {
        private readonly IRepository<Secure> _secureRepository;
        /// <summary>
        /// Main Constructor
        /// </summary>
        /// <param name="secureRepository"></param>
        public SecureAppService(IRepository<Secure> secureRepository)
        {
            _secureRepository = secureRepository;

        }

        /// <summary>
        /// Gets all the secure records and applies filters if needed
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<PagedResultDto<GetSecureForViewDto>> GetAll(GetAllSecureInput input)
        {

            var filteredSecure = _secureRepository.GetAll()
                        .WhereIf(!string.IsNullOrWhiteSpace(input.Filter), e => false || e.Password.Contains(input.Filter) || e.WebCustomerNo.Contains(input.Filter) || e.WebUserID.Contains(input.Filter) || e.WebWarehouse.Contains(input.Filter) || e.AddedBy.Contains(input.Filter) || e.ChangedBy.Contains(input.Filter) || e.DispatchName.Contains(input.Filter))
                        .WhereIf(!string.IsNullOrWhiteSpace(input.PasswordFilter), e => e.Password == input.PasswordFilter)
                        .WhereIf(input.MinEmployeeNoFilter != null, e => e.EmployeeNo >= input.MinEmployeeNoFilter)
                        .WhereIf(input.MaxEmployeeNoFilter != null, e => e.EmployeeNo <= input.MaxEmployeeNoFilter)
                        .WhereIf(input.MinAdminProgramFilter != null, e => e.AdminProgram >= input.MinAdminProgramFilter)
                        .WhereIf(input.MaxAdminProgramFilter != null, e => e.AdminProgram <= input.MaxAdminProgramFilter)
                        .WhereIf(input.MinSaleExpenseCodesFilter != null, e => e.SaleExpenseCodes >= input.MinSaleExpenseCodesFilter)
                        .WhereIf(input.MaxSaleExpenseCodesFilter != null, e => e.SaleExpenseCodes <= input.MaxSaleExpenseCodesFilter)
                        .WhereIf(input.MinCompanyFilter != null, e => e.Company >= input.MinCompanyFilter)
                        .WhereIf(input.MaxCompanyFilter != null, e => e.Company <= input.MaxCompanyFilter)
                        .WhereIf(input.MinBranchFilter != null, e => e.Branch >= input.MinBranchFilter)
                        .WhereIf(input.MaxBranchFilter != null, e => e.Branch <= input.MaxBranchFilter)
                        .WhereIf(input.MinDepartmentFilter != null, e => e.Department >= input.MinDepartmentFilter)
                        .WhereIf(input.MaxDepartmentFilter != null, e => e.Department <= input.MaxDepartmentFilter)
                        .WhereIf(input.MinPersonnelFilter != null, e => e.Personnel >= input.MinPersonnelFilter)
                        .WhereIf(input.MaxPersonnelFilter != null, e => e.Personnel <= input.MaxPersonnelFilter)
                        .WhereIf(input.MinSecurityFilter != null, e => e.Security >= input.MinSecurityFilter)
                        .WhereIf(input.MaxSecurityFilter != null, e => e.Security <= input.MaxSecurityFilter)
                        .WhereIf(input.MinLaborRatesFilter != null, e => e.LaborRates >= input.MinLaborRatesFilter)
                        .WhereIf(input.MaxLaborRatesFilter != null, e => e.LaborRates <= input.MaxLaborRatesFilter)
                        .WhereIf(input.MinSDIAccountingFilter != null, e => e.SDIAccounting >= input.MinSDIAccountingFilter)
                        .WhereIf(input.MaxSDIAccountingFilter != null, e => e.SDIAccounting <= input.MaxSDIAccountingFilter)
                        .WhereIf(input.MinCustomerProgramFilter != null, e => e.CustomerProgram >= input.MinCustomerProgramFilter)
                        .WhereIf(input.MaxCustomerProgramFilter != null, e => e.CustomerProgram <= input.MaxCustomerProgramFilter)
                        .WhereIf(input.MinCustomerChangeFilter != null, e => e.CustomerChange >= input.MinCustomerChangeFilter)
                        .WhereIf(input.MaxCustomerChangeFilter != null, e => e.CustomerChange <= input.MaxCustomerChangeFilter)
                        .WhereIf(input.MinCustomerAddFilter != null, e => e.CustomerAdd >= input.MinCustomerAddFilter)
                        .WhereIf(input.MaxCustomerAddFilter != null, e => e.CustomerAdd <= input.MaxCustomerAddFilter)
                        .WhereIf(input.MinCustomerDeleteFilter != null, e => e.CustomerDelete >= input.MinCustomerDeleteFilter)
                        .WhereIf(input.MaxCustomerDeleteFilter != null, e => e.CustomerDelete <= input.MaxCustomerDeleteFilter)
                        .WhereIf(input.MinEquipmentProgramFilter != null, e => e.EquipmentProgram >= input.MinEquipmentProgramFilter)
                        .WhereIf(input.MaxEquipmentProgramFilter != null, e => e.EquipmentProgram <= input.MaxEquipmentProgramFilter)
                        .WhereIf(input.MinEquipmentChangeFilter != null, e => e.EquipmentChange >= input.MinEquipmentChangeFilter)
                        .WhereIf(input.MaxEquipmentChangeFilter != null, e => e.EquipmentChange <= input.MaxEquipmentChangeFilter)
                        .WhereIf(input.MinEquipmentAddFilter != null, e => e.EquipmentAdd >= input.MinEquipmentAddFilter)
                        .WhereIf(input.MaxEquipmentAddFilter != null, e => e.EquipmentAdd <= input.MaxEquipmentAddFilter)
                        .WhereIf(input.MinEquipmentDeleteFilter != null, e => e.EquipmentDelete >= input.MinEquipmentDeleteFilter)
                        .WhereIf(input.MaxEquipmentDeleteFilter != null, e => e.EquipmentDelete <= input.MaxEquipmentDeleteFilter)
                        .WhereIf(input.MinEquipmentPMFilter != null, e => e.EquipmentPM >= input.MinEquipmentPMFilter)
                        .WhereIf(input.MaxEquipmentPMFilter != null, e => e.EquipmentPM <= input.MaxEquipmentPMFilter)
                        .WhereIf(input.MinEquipmentCostFilter != null, e => e.EquipmentCost >= input.MinEquipmentCostFilter)
                        .WhereIf(input.MaxEquipmentCostFilter != null, e => e.EquipmentCost <= input.MaxEquipmentCostFilter)
                        .WhereIf(input.MinEquipmentAdminFilter != null, e => e.EquipmentAdmin >= input.MinEquipmentAdminFilter)
                        .WhereIf(input.MaxEquipmentAdminFilter != null, e => e.EquipmentAdmin <= input.MaxEquipmentAdminFilter)
                        .WhereIf(input.MinEquipmentAddAsFilter != null, e => e.EquipmentAddAs >= input.MinEquipmentAddAsFilter)
                        .WhereIf(input.MaxEquipmentAddAsFilter != null, e => e.EquipmentAddAs <= input.MaxEquipmentAddAsFilter)
                        .WhereIf(input.MinInvoiceProgramFilter != null, e => e.InvoiceProgram >= input.MinInvoiceProgramFilter)
                        .WhereIf(input.MaxInvoiceProgramFilter != null, e => e.InvoiceProgram <= input.MaxInvoiceProgramFilter)
                        .WhereIf(input.MinInvoiceUpdateFilter != null, e => e.InvoiceUpdate >= input.MinInvoiceUpdateFilter)
                        .WhereIf(input.MaxInvoiceUpdateFilter != null, e => e.InvoiceUpdate <= input.MaxInvoiceUpdateFilter)
                        .WhereIf(input.MinInvoiceOpenFilter != null, e => e.InvoiceOpen >= input.MinInvoiceOpenFilter)
                        .WhereIf(input.MaxInvoiceOpenFilter != null, e => e.InvoiceOpen <= input.MaxInvoiceOpenFilter)
                        .WhereIf(input.MinInvoiceCloseFilter != null, e => e.InvoiceClose >= input.MinInvoiceCloseFilter)
                        .WhereIf(input.MaxInvoiceCloseFilter != null, e => e.InvoiceClose <= input.MaxInvoiceCloseFilter)
                        .WhereIf(input.MinInvoiceOpenPMFilter != null, e => e.InvoiceOpenPM >= input.MinInvoiceOpenPMFilter)
                        .WhereIf(input.MaxInvoiceOpenPMFilter != null, e => e.InvoiceOpenPM <= input.MaxInvoiceOpenPMFilter)
                        .WhereIf(input.MinInvoicePrintFinalFilter != null, e => e.InvoicePrintFinal >= input.MinInvoicePrintFinalFilter)
                        .WhereIf(input.MaxInvoicePrintFinalFilter != null, e => e.InvoicePrintFinal <= input.MaxInvoicePrintFinalFilter)
                        .WhereIf(input.MinInvoiceLaborTicketFilter != null, e => e.InvoiceLaborTicket >= input.MinInvoiceLaborTicketFilter)
                        .WhereIf(input.MaxInvoiceLaborTicketFilter != null, e => e.InvoiceLaborTicket <= input.MaxInvoiceLaborTicketFilter)
                        .WhereIf(input.MinInvoiceCommentsFilter != null, e => e.InvoiceComments >= input.MinInvoiceCommentsFilter)
                        .WhereIf(input.MaxInvoiceCommentsFilter != null, e => e.InvoiceComments <= input.MaxInvoiceCommentsFilter)
                        .WhereIf(input.MinInvoicePartsChangeFilter != null, e => e.InvoicePartsChange >= input.MinInvoicePartsChangeFilter)
                        .WhereIf(input.MaxInvoicePartsChangeFilter != null, e => e.InvoicePartsChange <= input.MaxInvoicePartsChangeFilter)
                        .WhereIf(input.MinInvoicePartsAddFilter != null, e => e.InvoicePartsAdd >= input.MinInvoicePartsAddFilter)
                        .WhereIf(input.MaxInvoicePartsAddFilter != null, e => e.InvoicePartsAdd <= input.MaxInvoicePartsAddFilter)
                        .WhereIf(input.MinInvoicePartsDeleteFilter != null, e => e.InvoicePartsDelete >= input.MinInvoicePartsDeleteFilter)
                        .WhereIf(input.MaxInvoicePartsDeleteFilter != null, e => e.InvoicePartsDelete <= input.MaxInvoicePartsDeleteFilter)
                        .WhereIf(input.MinInvoicePartsTransferFilter != null, e => e.InvoicePartsTransfer >= input.MinInvoicePartsTransferFilter)
                        .WhereIf(input.MaxInvoicePartsTransferFilter != null, e => e.InvoicePartsTransfer <= input.MaxInvoicePartsTransferFilter)
                        .WhereIf(input.MinInvoiceLaborChangeFilter != null, e => e.InvoiceLaborChange >= input.MinInvoiceLaborChangeFilter)
                        .WhereIf(input.MaxInvoiceLaborChangeFilter != null, e => e.InvoiceLaborChange <= input.MaxInvoiceLaborChangeFilter)
                        .WhereIf(input.MinInvoiceLaborAddFilter != null, e => e.InvoiceLaborAdd >= input.MinInvoiceLaborAddFilter)
                        .WhereIf(input.MaxInvoiceLaborAddFilter != null, e => e.InvoiceLaborAdd <= input.MaxInvoiceLaborAddFilter)
                        .WhereIf(input.MinInvoiceLaborDeleteFilter != null, e => e.InvoiceLaborDelete >= input.MinInvoiceLaborDeleteFilter)
                        .WhereIf(input.MaxInvoiceLaborDeleteFilter != null, e => e.InvoiceLaborDelete <= input.MaxInvoiceLaborDeleteFilter)
                        .WhereIf(input.MinInvoiceLaborTransferFilter != null, e => e.InvoiceLaborTransfer >= input.MinInvoiceLaborTransferFilter)
                        .WhereIf(input.MaxInvoiceLaborTransferFilter != null, e => e.InvoiceLaborTransfer <= input.MaxInvoiceLaborTransferFilter)
                        .WhereIf(input.MinInvoiceMiscChangeFilter != null, e => e.InvoiceMiscChange >= input.MinInvoiceMiscChangeFilter)
                        .WhereIf(input.MaxInvoiceMiscChangeFilter != null, e => e.InvoiceMiscChange <= input.MaxInvoiceMiscChangeFilter)
                        .WhereIf(input.MinInvoiceMiscAddFilter != null, e => e.InvoiceMiscAdd >= input.MinInvoiceMiscAddFilter)
                        .WhereIf(input.MaxInvoiceMiscAddFilter != null, e => e.InvoiceMiscAdd <= input.MaxInvoiceMiscAddFilter)
                        .WhereIf(input.MinInvoiceMiscDeleteFilter != null, e => e.InvoiceMiscDelete >= input.MinInvoiceMiscDeleteFilter)
                        .WhereIf(input.MaxInvoiceMiscDeleteFilter != null, e => e.InvoiceMiscDelete <= input.MaxInvoiceMiscDeleteFilter)
                        .WhereIf(input.MinInvoiceMiscTransferFilter != null, e => e.InvoiceMiscTransfer >= input.MinInvoiceMiscTransferFilter)
                        .WhereIf(input.MaxInvoiceMiscTransferFilter != null, e => e.InvoiceMiscTransfer <= input.MaxInvoiceMiscTransferFilter)
                        .WhereIf(input.MinInvoiceRentalChangeFilter != null, e => e.InvoiceRentalChange >= input.MinInvoiceRentalChangeFilter)
                        .WhereIf(input.MaxInvoiceRentalChangeFilter != null, e => e.InvoiceRentalChange <= input.MaxInvoiceRentalChangeFilter)
                        .WhereIf(input.MinInvoiceRentalAddFilter != null, e => e.InvoiceRentalAdd >= input.MinInvoiceRentalAddFilter)
                        .WhereIf(input.MaxInvoiceRentalAddFilter != null, e => e.InvoiceRentalAdd <= input.MaxInvoiceRentalAddFilter)
                        .WhereIf(input.MinInvoiceRentalDeleteFilter != null, e => e.InvoiceRentalDelete >= input.MinInvoiceRentalDeleteFilter)
                        .WhereIf(input.MaxInvoiceRentalDeleteFilter != null, e => e.InvoiceRentalDelete <= input.MaxInvoiceRentalDeleteFilter)
                        .WhereIf(input.MinInvoiceRentalTransferFilter != null, e => e.InvoiceRentalTransfer >= input.MinInvoiceRentalTransferFilter)
                        .WhereIf(input.MaxInvoiceRentalTransferFilter != null, e => e.InvoiceRentalTransfer <= input.MaxInvoiceRentalTransferFilter)
                        .WhereIf(input.MinInvoiceEquipmentChangeFilter != null, e => e.InvoiceEquipmentChange >= input.MinInvoiceEquipmentChangeFilter)
                        .WhereIf(input.MaxInvoiceEquipmentChangeFilter != null, e => e.InvoiceEquipmentChange <= input.MaxInvoiceEquipmentChangeFilter)
                        .WhereIf(input.MinInvoiceEquipmentAddFilter != null, e => e.InvoiceEquipmentAdd >= input.MinInvoiceEquipmentAddFilter)
                        .WhereIf(input.MaxInvoiceEquipmentAddFilter != null, e => e.InvoiceEquipmentAdd <= input.MaxInvoiceEquipmentAddFilter)
                        .WhereIf(input.MinInvoiceEquipmentDeleteFilter != null, e => e.InvoiceEquipmentDelete >= input.MinInvoiceEquipmentDeleteFilter)
                        .WhereIf(input.MaxInvoiceEquipmentDeleteFilter != null, e => e.InvoiceEquipmentDelete <= input.MaxInvoiceEquipmentDeleteFilter)
                        .WhereIf(input.MinInvoiceEquipmentTransferFilter != null, e => e.InvoiceEquipmentTransfer >= input.MinInvoiceEquipmentTransferFilter)
                        .WhereIf(input.MaxInvoiceEquipmentTransferFilter != null, e => e.InvoiceEquipmentTransfer <= input.MaxInvoiceEquipmentTransferFilter)
                        .WhereIf(input.MinInvoiceWIPFilter != null, e => e.InvoiceWIP >= input.MinInvoiceWIPFilter)
                        .WhereIf(input.MaxInvoiceWIPFilter != null, e => e.InvoiceWIP <= input.MaxInvoiceWIPFilter)
                        .WhereIf(input.MinInvoiceRegisterFilter != null, e => e.InvoiceRegister >= input.MinInvoiceRegisterFilter)
                        .WhereIf(input.MaxInvoiceRegisterFilter != null, e => e.InvoiceRegister <= input.MaxInvoiceRegisterFilter)
                        .WhereIf(input.MinInvoiceReOpenFilter != null, e => e.InvoiceReOpen >= input.MinInvoiceReOpenFilter)
                        .WhereIf(input.MaxInvoiceReOpenFilter != null, e => e.InvoiceReOpen <= input.MaxInvoiceReOpenFilter)
                        .WhereIf(input.MinCreditMemosFilter != null, e => e.CreditMemos >= input.MinCreditMemosFilter)
                        .WhereIf(input.MaxCreditMemosFilter != null, e => e.CreditMemos <= input.MaxCreditMemosFilter)
                        .WhereIf(input.MinPartsProgramFilter != null, e => e.PartsProgram >= input.MinPartsProgramFilter)
                        .WhereIf(input.MaxPartsProgramFilter != null, e => e.PartsProgram <= input.MaxPartsProgramFilter)
                        .WhereIf(input.MinPartsChangeFilter != null, e => e.PartsChange >= input.MinPartsChangeFilter)
                        .WhereIf(input.MaxPartsChangeFilter != null, e => e.PartsChange <= input.MaxPartsChangeFilter)
                        .WhereIf(input.MinPartsAddFilter != null, e => e.PartsAdd >= input.MinPartsAddFilter)
                        .WhereIf(input.MaxPartsAddFilter != null, e => e.PartsAdd <= input.MaxPartsAddFilter)
                        .WhereIf(input.MinPartsDeleteFilter != null, e => e.PartsDelete >= input.MinPartsDeleteFilter)
                        .WhereIf(input.MaxPartsDeleteFilter != null, e => e.PartsDelete <= input.MaxPartsDeleteFilter)
                        .WhereIf(input.MinPartsInquiryFilter != null, e => e.PartsInquiry >= input.MinPartsInquiryFilter)
                        .WhereIf(input.MaxPartsInquiryFilter != null, e => e.PartsInquiry <= input.MaxPartsInquiryFilter)
                        .WhereIf(input.MinPartsTransferFilter != null, e => e.PartsTransfer >= input.MinPartsTransferFilter)
                        .WhereIf(input.MaxPartsTransferFilter != null, e => e.PartsTransfer <= input.MaxPartsTransferFilter)
                        .WhereIf(input.MinPartsGroupFilter != null, e => e.PartsGroup >= input.MinPartsGroupFilter)
                        .WhereIf(input.MaxPartsGroupFilter != null, e => e.PartsGroup <= input.MaxPartsGroupFilter)
                        .WhereIf(input.MinPartsWarehouseFilter != null, e => e.PartsWarehouse >= input.MinPartsWarehouseFilter)
                        .WhereIf(input.MaxPartsWarehouseFilter != null, e => e.PartsWarehouse <= input.MaxPartsWarehouseFilter)
                        .WhereIf(input.MinPartsCostFilter != null, e => e.PartsCost >= input.MinPartsCostFilter)
                        .WhereIf(input.MaxPartsCostFilter != null, e => e.PartsCost <= input.MaxPartsCostFilter)
                        .WhereIf(input.MinPartsAdminFilter != null, e => e.PartsAdmin >= input.MinPartsAdminFilter)
                        .WhereIf(input.MaxPartsAdminFilter != null, e => e.PartsAdmin <= input.MaxPartsAdminFilter)
                        .WhereIf(input.MinPartsOrderingFilter != null, e => e.PartsOrdering >= input.MinPartsOrderingFilter)
                        .WhereIf(input.MaxPartsOrderingFilter != null, e => e.PartsOrdering <= input.MaxPartsOrderingFilter)
                        .WhereIf(input.MinPartsInventoryFilter != null, e => e.PartsInventory >= input.MinPartsInventoryFilter)
                        .WhereIf(input.MaxPartsInventoryFilter != null, e => e.PartsInventory <= input.MaxPartsInventoryFilter)
                        .WhereIf(input.MinPartsOnHandFilter != null, e => e.PartsOnHand >= input.MinPartsOnHandFilter)
                        .WhereIf(input.MaxPartsOnHandFilter != null, e => e.PartsOnHand <= input.MaxPartsOnHandFilter)
                        .WhereIf(input.MinPartsPartNoAliasFilter != null, e => e.PartsPartNoAlias >= input.MinPartsPartNoAliasFilter)
                        .WhereIf(input.MaxPartsPartNoAliasFilter != null, e => e.PartsPartNoAlias <= input.MaxPartsPartNoAliasFilter)
                        .WhereIf(input.MinInvoiceDeptLimitFilter != null, e => e.InvoiceDeptLimit >= input.MinInvoiceDeptLimitFilter)
                        .WhereIf(input.MaxInvoiceDeptLimitFilter != null, e => e.InvoiceDeptLimit <= input.MaxInvoiceDeptLimitFilter)
                        .WhereIf(input.MinCustomerCreditApprovalFilter != null, e => e.CustomerCreditApproval >= input.MinCustomerCreditApprovalFilter)
                        .WhereIf(input.MaxCustomerCreditApprovalFilter != null, e => e.CustomerCreditApproval <= input.MaxCustomerCreditApprovalFilter)
                        .WhereIf(input.MinAPVoucherFilter != null, e => e.APVoucher >= input.MinAPVoucherFilter)
                        .WhereIf(input.MaxAPVoucherFilter != null, e => e.APVoucher <= input.MaxAPVoucherFilter)
                        .WhereIf(input.MinAPChecksFilter != null, e => e.APChecks >= input.MinAPChecksFilter)
                        .WhereIf(input.MaxAPChecksFilter != null, e => e.APChecks <= input.MaxAPChecksFilter)
                        .WhereIf(input.MinAPChecksApprovalFilter != null, e => e.APChecksApproval >= input.MinAPChecksApprovalFilter)
                        .WhereIf(input.MaxAPChecksApprovalFilter != null, e => e.APChecksApproval <= input.MaxAPChecksApprovalFilter)
                        .WhereIf(input.MinAPChecksAutoChecksFilter != null, e => e.APChecksAutoChecks >= input.MinAPChecksAutoChecksFilter)
                        .WhereIf(input.MaxAPChecksAutoChecksFilter != null, e => e.APChecksAutoChecks <= input.MaxAPChecksAutoChecksFilter)
                        .WhereIf(input.MinAPChecksHandTypedFilter != null, e => e.APChecksHandTyped >= input.MinAPChecksHandTypedFilter)
                        .WhereIf(input.MaxAPChecksHandTypedFilter != null, e => e.APChecksHandTyped <= input.MaxAPChecksHandTypedFilter)
                        .WhereIf(input.MinAPChecksRegisterFilter != null, e => e.APChecksRegister >= input.MinAPChecksRegisterFilter)
                        .WhereIf(input.MaxAPChecksRegisterFilter != null, e => e.APChecksRegister <= input.MaxAPChecksRegisterFilter)
                        .WhereIf(input.MinAPChecksVoidFilter != null, e => e.APChecksVoid >= input.MinAPChecksVoidFilter)
                        .WhereIf(input.MaxAPChecksVoidFilter != null, e => e.APChecksVoid <= input.MaxAPChecksVoidFilter)
                        .WhereIf(input.MinAPInquiryFilter != null, e => e.APInquiry >= input.MinAPInquiryFilter)
                        .WhereIf(input.MaxAPInquiryFilter != null, e => e.APInquiry <= input.MaxAPInquiryFilter)
                        .WhereIf(input.MinARInquiryFilter != null, e => e.ARInquiry >= input.MinARInquiryFilter)
                        .WhereIf(input.MaxARInquiryFilter != null, e => e.ARInquiry <= input.MaxARInquiryFilter)
                        .WhereIf(input.MinARCashFilter != null, e => e.ARCash >= input.MinARCashFilter)
                        .WhereIf(input.MaxARCashFilter != null, e => e.ARCash <= input.MaxARCashFilter)
                        .WhereIf(input.MinCOAFilter != null, e => e.COA >= input.MinCOAFilter)
                        .WhereIf(input.MaxCOAFilter != null, e => e.COA <= input.MaxCOAFilter)
                        .WhereIf(input.MinGJFilter != null, e => e.GJ >= input.MinGJFilter)
                        .WhereIf(input.MaxGJFilter != null, e => e.GJ <= input.MaxGJFilter)
                        .WhereIf(input.MinGLInquiryFilter != null, e => e.GLInquiry >= input.MinGLInquiryFilter)
                        .WhereIf(input.MaxGLInquiryFilter != null, e => e.GLInquiry <= input.MaxGLInquiryFilter)
                        .WhereIf(input.MinVendorFilter != null, e => e.Vendor >= input.MinVendorFilter)
                        .WhereIf(input.MaxVendorFilter != null, e => e.Vendor <= input.MaxVendorFilter)
                        .WhereIf(input.MinInvoiceAccountingDistFilter != null, e => e.InvoiceAccountingDist >= input.MinInvoiceAccountingDistFilter)
                        .WhereIf(input.MaxInvoiceAccountingDistFilter != null, e => e.InvoiceAccountingDist <= input.MaxInvoiceAccountingDistFilter)
                        .WhereIf(input.MinEquipmentUnitNoFilter != null, e => e.EquipmentUnitNo >= input.MinEquipmentUnitNoFilter)
                        .WhereIf(input.MaxEquipmentUnitNoFilter != null, e => e.EquipmentUnitNo <= input.MaxEquipmentUnitNoFilter)
                        .WhereIf(input.WebAccessFilter.HasValue && input.WebAccessFilter > -1, e => (input.WebAccessFilter == 1 && e.WebAccess) || (input.WebAccessFilter == 0 && !e.WebAccess))
                        .WhereIf(input.WebCustomerFilter.HasValue && input.WebCustomerFilter > -1, e => (input.WebCustomerFilter == 1 && e.WebCustomer) || (input.WebCustomerFilter == 0 && !e.WebCustomer))
                        .WhereIf(!string.IsNullOrWhiteSpace(input.WebCustomerNoFilter), e => e.WebCustomerNo == input.WebCustomerNoFilter)
                        .WhereIf(input.WebWIPFilter.HasValue && input.WebWIPFilter > -1, e => (input.WebWIPFilter == 1 && e.WebWIP) || (input.WebWIPFilter == 0 && !e.WebWIP))
                        .WhereIf(input.WebCustWIPFilter.HasValue && input.WebCustWIPFilter > -1, e => (input.WebCustWIPFilter == 1 && e.WebCustWIP) || (input.WebCustWIPFilter == 0 && !e.WebCustWIP))
                        .WhereIf(input.WebCustFleetFilter.HasValue && input.WebCustFleetFilter > -1, e => (input.WebCustFleetFilter == 1 && e.WebCustFleet) || (input.WebCustFleetFilter == 0 && !e.WebCustFleet))
                        .WhereIf(input.WebContactsFilter.HasValue && input.WebContactsFilter > -1, e => (input.WebContactsFilter == 1 && e.WebContacts) || (input.WebContactsFilter == 0 && !e.WebContacts))
                        .WhereIf(input.WebCallReportsFilter.HasValue && input.WebCallReportsFilter > -1, e => (input.WebCallReportsFilter == 1 && e.WebCallReports) || (input.WebCallReportsFilter == 0 && !e.WebCallReports))
                        .WhereIf(input.WebEquipmentSummaryFilter.HasValue && input.WebEquipmentSummaryFilter > -1, e => (input.WebEquipmentSummaryFilter == 1 && e.WebEquipmentSummary) || (input.WebEquipmentSummaryFilter == 0 && !e.WebEquipmentSummary))
                        .WhereIf(input.WebCustARFilter.HasValue && input.WebCustARFilter > -1, e => (input.WebCustARFilter == 1 && e.WebCustAR) || (input.WebCustARFilter == 0 && !e.WebCustAR))
                        .WhereIf(input.InvoiceGPPartsFilter.HasValue && input.InvoiceGPPartsFilter > -1, e => (input.InvoiceGPPartsFilter == 1 && e.InvoiceGPParts) || (input.InvoiceGPPartsFilter == 0 && !e.InvoiceGPParts))
                        .WhereIf(input.InvoiceGPLaborFilter.HasValue && input.InvoiceGPLaborFilter > -1, e => (input.InvoiceGPLaborFilter == 1 && e.InvoiceGPLabor) || (input.InvoiceGPLaborFilter == 0 && !e.InvoiceGPLabor))
                        .WhereIf(input.InvoiceGPMiscFilter.HasValue && input.InvoiceGPMiscFilter > -1, e => (input.InvoiceGPMiscFilter == 1 && e.InvoiceGPMisc) || (input.InvoiceGPMiscFilter == 0 && !e.InvoiceGPMisc))
                        .WhereIf(input.InvoiceGPRentalFilter.HasValue && input.InvoiceGPRentalFilter > -1, e => (input.InvoiceGPRentalFilter == 1 && e.InvoiceGPRental) || (input.InvoiceGPRentalFilter == 0 && !e.InvoiceGPRental))
                        .WhereIf(input.InvoiceGPEquipmentFilter.HasValue && input.InvoiceGPEquipmentFilter > -1, e => (input.InvoiceGPEquipmentFilter == 1 && e.InvoiceGPEquipment) || (input.InvoiceGPEquipmentFilter == 0 && !e.InvoiceGPEquipment))
                        .WhereIf(input.InvoiceGPTotalFilter.HasValue && input.InvoiceGPTotalFilter > -1, e => (input.InvoiceGPTotalFilter == 1 && e.InvoiceGPTotal) || (input.InvoiceGPTotalFilter == 0 && !e.InvoiceGPTotal))
                        .WhereIf(input.InvoiceAccountingFormatFilter.HasValue && input.InvoiceAccountingFormatFilter > -1, e => (input.InvoiceAccountingFormatFilter == 1 && e.InvoiceAccountingFormat) || (input.InvoiceAccountingFormatFilter == 0 && !e.InvoiceAccountingFormat))
                        .WhereIf(input.EquipmentControlNoFilter.HasValue && input.EquipmentControlNoFilter > -1, e => (input.EquipmentControlNoFilter == 1 && e.EquipmentControlNo) || (input.EquipmentControlNoFilter == 0 && !e.EquipmentControlNo))
                        .WhereIf(input.ARCommentsFilter.HasValue && input.ARCommentsFilter > -1, e => (input.ARCommentsFilter == 1 && e.ARComments) || (input.ARCommentsFilter == 0 && !e.ARComments))
                        .WhereIf(input.CustomerCommissionFilter.HasValue && input.CustomerCommissionFilter > -1, e => (input.CustomerCommissionFilter == 1 && e.CustomerCommission) || (input.CustomerCommissionFilter == 0 && !e.CustomerCommission))
                        .WhereIf(input.InvoiceNewEquipmentFilter.HasValue && input.InvoiceNewEquipmentFilter > -1, e => (input.InvoiceNewEquipmentFilter == 1 && e.InvoiceNewEquipment) || (input.InvoiceNewEquipmentFilter == 0 && !e.InvoiceNewEquipment))
                        .WhereIf(input.InvoiceRatesFilter.HasValue && input.InvoiceRatesFilter > -1, e => (input.InvoiceRatesFilter == 1 && e.InvoiceRates) || (input.InvoiceRatesFilter == 0 && !e.InvoiceRates))
                        .WhereIf(input.InvoiceFlatRateLaborFilter.HasValue && input.InvoiceFlatRateLaborFilter > -1, e => (input.InvoiceFlatRateLaborFilter == 1 && e.InvoiceFlatRateLabor) || (input.InvoiceFlatRateLaborFilter == 0 && !e.InvoiceFlatRateLabor))
                        .WhereIf(input.InvoiceFlatRatePartsFilter.HasValue && input.InvoiceFlatRatePartsFilter > -1, e => (input.InvoiceFlatRatePartsFilter == 1 && e.InvoiceFlatRateParts) || (input.InvoiceFlatRatePartsFilter == 0 && !e.InvoiceFlatRateParts))
                        .WhereIf(input.InvoiceFlatRateMiscFilter.HasValue && input.InvoiceFlatRateMiscFilter > -1, e => (input.InvoiceFlatRateMiscFilter == 1 && e.InvoiceFlatRateMisc) || (input.InvoiceFlatRateMiscFilter == 0 && !e.InvoiceFlatRateMisc))
                        .WhereIf(input.InvoiceFlatRateRentalFilter.HasValue && input.InvoiceFlatRateRentalFilter > -1, e => (input.InvoiceFlatRateRentalFilter == 1 && e.InvoiceFlatRateRental) || (input.InvoiceFlatRateRentalFilter == 0 && !e.InvoiceFlatRateRental))
                        .WhereIf(input.InvoiceFlatRateEquipmentFilter.HasValue && input.InvoiceFlatRateEquipmentFilter > -1, e => (input.InvoiceFlatRateEquipmentFilter == 1 && e.InvoiceFlatRateEquipment) || (input.InvoiceFlatRateEquipmentFilter == 0 && !e.InvoiceFlatRateEquipment))
                        .WhereIf(input.EquipmentInventoryFilter.HasValue && input.EquipmentInventoryFilter > -1, e => (input.EquipmentInventoryFilter == 1 && e.EquipmentInventory) || (input.EquipmentInventoryFilter == 0 && !e.EquipmentInventory))
                        .WhereIf(input.CustomerRatesFilter.HasValue && input.CustomerRatesFilter > -1, e => (input.CustomerRatesFilter == 1 && e.CustomerRates) || (input.CustomerRatesFilter == 0 && !e.CustomerRates))
                        .WhereIf(input.ProfileARCommentsFilter.HasValue && input.ProfileARCommentsFilter > -1, e => (input.ProfileARCommentsFilter == 1 && e.ProfileARComments) || (input.ProfileARCommentsFilter == 0 && !e.ProfileARComments))
                        .WhereIf(!string.IsNullOrWhiteSpace(input.WebUserIDFilter), e => e.WebUserID == input.WebUserIDFilter)
                        .WhereIf(input.ManagementInformationFilter.HasValue && input.ManagementInformationFilter > -1, e => (input.ManagementInformationFilter == 1 && e.ManagementInformation) || (input.ManagementInformationFilter == 0 && !e.ManagementInformation))
                        .WhereIf(input.EquipmentRentalRatesFilter.HasValue && input.EquipmentRentalRatesFilter > -1, e => (input.EquipmentRentalRatesFilter == 1 && e.EquipmentRentalRates) || (input.EquipmentRentalRatesFilter == 0 && !e.EquipmentRentalRates))
                        .WhereIf(input.EquipmentGLInfoFilter.HasValue && input.EquipmentGLInfoFilter > -1, e => (input.EquipmentGLInfoFilter == 1 && e.EquipmentGLInfo) || (input.EquipmentGLInfoFilter == 0 && !e.EquipmentGLInfo))
                        .WhereIf(input.PartsApproveOrdersFilter.HasValue && input.PartsApproveOrdersFilter > -1, e => (input.PartsApproveOrdersFilter == 1 && e.PartsApproveOrders) || (input.PartsApproveOrdersFilter == 0 && !e.PartsApproveOrders))
                        .WhereIf(input.PartsLostSaleFilter.HasValue && input.PartsLostSaleFilter > -1, e => (input.PartsLostSaleFilter == 1 && e.PartsLostSale) || (input.PartsLostSaleFilter == 0 && !e.PartsLostSale))
                        .WhereIf(input.PartsGroupBinChangeFilter.HasValue && input.PartsGroupBinChangeFilter > -1, e => (input.PartsGroupBinChangeFilter == 1 && e.PartsGroupBinChange) || (input.PartsGroupBinChangeFilter == 0 && !e.PartsGroupBinChange))
                        .WhereIf(input.InvoiceAddShipToFilter.HasValue && input.InvoiceAddShipToFilter > -1, e => (input.InvoiceAddShipToFilter == 1 && e.InvoiceAddShipTo) || (input.InvoiceAddShipToFilter == 0 && !e.InvoiceAddShipTo))
                        .WhereIf(input.PartsToyotaNoAutoDashFilter.HasValue && input.PartsToyotaNoAutoDashFilter > -1, e => (input.PartsToyotaNoAutoDashFilter == 1 && e.PartsToyotaNoAutoDash) || (input.PartsToyotaNoAutoDashFilter == 0 && !e.PartsToyotaNoAutoDash))
                        .WhereIf(input.PartsWarehouseLimitFilter.HasValue && input.PartsWarehouseLimitFilter > -1, e => (input.PartsWarehouseLimitFilter == 1 && e.PartsWarehouseLimit) || (input.PartsWarehouseLimitFilter == 0 && !e.PartsWarehouseLimit))
                        .WhereIf(input.InvoiceOverRideCurrencyRateFilter.HasValue && input.InvoiceOverRideCurrencyRateFilter > -1, e => (input.InvoiceOverRideCurrencyRateFilter == 1 && e.InvoiceOverRideCurrencyRate) || (input.InvoiceOverRideCurrencyRateFilter == 0 && !e.InvoiceOverRideCurrencyRate))
                        .WhereIf(input.InvoicePartsBelowCostFilter.HasValue && input.InvoicePartsBelowCostFilter > -1, e => (input.InvoicePartsBelowCostFilter == 1 && e.InvoicePartsBelowCost) || (input.InvoicePartsBelowCostFilter == 0 && !e.InvoicePartsBelowCost))
                        .WhereIf(!string.IsNullOrWhiteSpace(input.WebWarehouseFilter), e => e.WebWarehouse == input.WebWarehouseFilter)
                        .WhereIf(input.WebPartsInquiryFilter.HasValue && input.WebPartsInquiryFilter > -1, e => (input.WebPartsInquiryFilter == 1 && e.WebPartsInquiry) || (input.WebPartsInquiryFilter == 0 && !e.WebPartsInquiry))
                        .WhereIf(input.WebPartsOrderFilter.HasValue && input.WebPartsOrderFilter > -1, e => (input.WebPartsOrderFilter == 1 && e.WebPartsOrder) || (input.WebPartsOrderFilter == 0 && !e.WebPartsOrder))
                        .WhereIf(input.InvoiceSalesmanFilter.HasValue && input.InvoiceSalesmanFilter > -1, e => (input.InvoiceSalesmanFilter == 1 && e.InvoiceSalesman) || (input.InvoiceSalesmanFilter == 0 && !e.InvoiceSalesman))
                        .WhereIf(input.EquipmentLocationFilter.HasValue && input.EquipmentLocationFilter > -1, e => (input.EquipmentLocationFilter == 1 && e.EquipmentLocation) || (input.EquipmentLocationFilter == 0 && !e.EquipmentLocation))
                        .WhereIf(input.CustomerTermsFilter.HasValue && input.CustomerTermsFilter > -1, e => (input.CustomerTermsFilter == 1 && e.CustomerTerms) || (input.CustomerTermsFilter == 0 && !e.CustomerTerms))
                        .WhereIf(input.InvoiceAutoOpenPMsFilter.HasValue && input.InvoiceAutoOpenPMsFilter > -1, e => (input.InvoiceAutoOpenPMsFilter == 1 && e.InvoiceAutoOpenPMs) || (input.InvoiceAutoOpenPMsFilter == 0 && !e.InvoiceAutoOpenPMs))
                        .WhereIf(input.EquipmentTab0Filter.HasValue && input.EquipmentTab0Filter > -1, e => (input.EquipmentTab0Filter == 1 && e.EquipmentTab0) || (input.EquipmentTab0Filter == 0 && !e.EquipmentTab0))
                        .WhereIf(input.EquipmentTab1Filter.HasValue && input.EquipmentTab1Filter > -1, e => (input.EquipmentTab1Filter == 1 && e.EquipmentTab1) || (input.EquipmentTab1Filter == 0 && !e.EquipmentTab1))
                        .WhereIf(input.EquipmentTab2Filter.HasValue && input.EquipmentTab2Filter > -1, e => (input.EquipmentTab2Filter == 1 && e.EquipmentTab2) || (input.EquipmentTab2Filter == 0 && !e.EquipmentTab2))
                        .WhereIf(input.EquipmentTab3Filter.HasValue && input.EquipmentTab3Filter > -1, e => (input.EquipmentTab3Filter == 1 && e.EquipmentTab3) || (input.EquipmentTab3Filter == 0 && !e.EquipmentTab3))
                        .WhereIf(input.EquipmentTab4Filter.HasValue && input.EquipmentTab4Filter > -1, e => (input.EquipmentTab4Filter == 1 && e.EquipmentTab4) || (input.EquipmentTab4Filter == 0 && !e.EquipmentTab4))
                        .WhereIf(input.EquipmentTab5Filter.HasValue && input.EquipmentTab5Filter > -1, e => (input.EquipmentTab5Filter == 1 && e.EquipmentTab5) || (input.EquipmentTab5Filter == 0 && !e.EquipmentTab5))
                        .WhereIf(input.EquipmentTab6Filter.HasValue && input.EquipmentTab6Filter > -1, e => (input.EquipmentTab6Filter == 1 && e.EquipmentTab6) || (input.EquipmentTab6Filter == 0 && !e.EquipmentTab6))
                        .WhereIf(input.EquipmentTab7Filter.HasValue && input.EquipmentTab7Filter > -1, e => (input.EquipmentTab7Filter == 1 && e.EquipmentTab7) || (input.EquipmentTab7Filter == 0 && !e.EquipmentTab7))
                        .WhereIf(input.EquipmentTab8Filter.HasValue && input.EquipmentTab8Filter > -1, e => (input.EquipmentTab8Filter == 1 && e.EquipmentTab8) || (input.EquipmentTab8Filter == 0 && !e.EquipmentTab8))
                        .WhereIf(input.EquipmentTab9Filter.HasValue && input.EquipmentTab9Filter > -1, e => (input.EquipmentTab9Filter == 1 && e.EquipmentTab9) || (input.EquipmentTab9Filter == 0 && !e.EquipmentTab9))
                        .WhereIf(input.CustomerCreditInfoFilter.HasValue && input.CustomerCreditInfoFilter > -1, e => (input.CustomerCreditInfoFilter == 1 && e.CustomerCreditInfo) || (input.CustomerCreditInfoFilter == 0 && !e.CustomerCreditInfo))
                        .WhereIf(input.InvoiceFixPONoFilter.HasValue && input.InvoiceFixPONoFilter > -1, e => (input.InvoiceFixPONoFilter == 1 && e.InvoiceFixPONo) || (input.InvoiceFixPONoFilter == 0 && !e.InvoiceFixPONo))
                        .WhereIf(input.InvoiceFixSalesmanFilter.HasValue && input.InvoiceFixSalesmanFilter > -1, e => (input.InvoiceFixSalesmanFilter == 1 && e.InvoiceFixSalesman) || (input.InvoiceFixSalesmanFilter == 0 && !e.InvoiceFixSalesman))
                        .WhereIf(input.InvoiceFixWriterFilter.HasValue && input.InvoiceFixWriterFilter > -1, e => (input.InvoiceFixWriterFilter == 1 && e.InvoiceFixWriter) || (input.InvoiceFixWriterFilter == 0 && !e.InvoiceFixWriter))
                        .WhereIf(input.InvoiceFixShipViaFilter.HasValue && input.InvoiceFixShipViaFilter > -1, e => (input.InvoiceFixShipViaFilter == 1 && e.InvoiceFixShipVia) || (input.InvoiceFixShipViaFilter == 0 && !e.InvoiceFixShipVia))
                        .WhereIf(input.InvoiceFixFOBFilter.HasValue && input.InvoiceFixFOBFilter > -1, e => (input.InvoiceFixFOBFilter == 1 && e.InvoiceFixFOB) || (input.InvoiceFixFOBFilter == 0 && !e.InvoiceFixFOB))
                        .WhereIf(input.EquipmentChangeSerialNoFilter.HasValue && input.EquipmentChangeSerialNoFilter > -1, e => (input.EquipmentChangeSerialNoFilter == 1 && e.EquipmentChangeSerialNo) || (input.EquipmentChangeSerialNoFilter == 0 && !e.EquipmentChangeSerialNo))
                        .WhereIf(input.CustomerCCFilter.HasValue && input.CustomerCCFilter > -1, e => (input.CustomerCCFilter == 1 && e.CustomerCC) || (input.CustomerCCFilter == 0 && !e.CustomerCC))
                        .WhereIf(input.EquipmentTab10Filter.HasValue && input.EquipmentTab10Filter > -1, e => (input.EquipmentTab10Filter == 1 && e.EquipmentTab10) || (input.EquipmentTab10Filter == 0 && !e.EquipmentTab10))
                        .WhereIf(input.InvoiceMechLimitFlagFilter.HasValue && input.InvoiceMechLimitFlagFilter > -1, e => (input.InvoiceMechLimitFlagFilter == 1 && e.InvoiceMechLimitFlag) || (input.InvoiceMechLimitFlagFilter == 0 && !e.InvoiceMechLimitFlag))
                        .WhereIf(input.MinInvoiceMechNoFilter != null, e => e.InvoiceMechNo >= input.MinInvoiceMechNoFilter)
                        .WhereIf(input.MaxInvoiceMechNoFilter != null, e => e.InvoiceMechNo <= input.MaxInvoiceMechNoFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.AddedByFilter), e => e.AddedBy == input.AddedByFilter)
                        .WhereIf(input.MinDateAddedFilter != null, e => e.DateAdded >= input.MinDateAddedFilter)
                        .WhereIf(input.MaxDateAddedFilter != null, e => e.DateAdded <= input.MaxDateAddedFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.ChangedByFilter), e => e.ChangedBy == input.ChangedByFilter)
                        .WhereIf(input.MinDateChangedFilter != null, e => e.DateChanged >= input.MinDateChangedFilter)
                        .WhereIf(input.MaxDateChangedFilter != null, e => e.DateChanged <= input.MaxDateChangedFilter)
                        .WhereIf(input.InvoiceFixFilter.HasValue && input.InvoiceFixFilter > -1, e => (input.InvoiceFixFilter == 1 && e.InvoiceFix) || (input.InvoiceFixFilter == 0 && !e.InvoiceFix))
                        .WhereIf(input.InvoiceFixHourMeterFilter.HasValue && input.InvoiceFixHourMeterFilter > -1, e => (input.InvoiceFixHourMeterFilter == 1 && e.InvoiceFixHourMeter) || (input.InvoiceFixHourMeterFilter == 0 && !e.InvoiceFixHourMeter))
                        .WhereIf(input.TransportationFilter.HasValue && input.TransportationFilter > -1, e => (input.TransportationFilter == 1 && e.Transportation) || (input.TransportationFilter == 0 && !e.Transportation))
                        .WhereIf(input.TransportationHeaderFilter.HasValue && input.TransportationHeaderFilter > -1, e => (input.TransportationHeaderFilter == 1 && e.TransportationHeader) || (input.TransportationHeaderFilter == 0 && !e.TransportationHeader))
                        .WhereIf(input.TransportationDetailFilter.HasValue && input.TransportationDetailFilter > -1, e => (input.TransportationDetailFilter == 1 && e.TransportationDetail) || (input.TransportationDetailFilter == 0 && !e.TransportationDetail))
                        .WhereIf(input.DocumentCenterFilter.HasValue && input.DocumentCenterFilter > -1, e => (input.DocumentCenterFilter == 1 && e.DocumentCenter) || (input.DocumentCenterFilter == 0 && !e.DocumentCenter))
                        .WhereIf(input.DocumentCenterWOAddFilter.HasValue && input.DocumentCenterWOAddFilter > -1, e => (input.DocumentCenterWOAddFilter == 1 && e.DocumentCenterWOAdd) || (input.DocumentCenterWOAddFilter == 0 && !e.DocumentCenterWOAdd))
                        .WhereIf(input.DocumentCenterWODeleteFilter.HasValue && input.DocumentCenterWODeleteFilter > -1, e => (input.DocumentCenterWODeleteFilter == 1 && e.DocumentCenterWODelete) || (input.DocumentCenterWODeleteFilter == 0 && !e.DocumentCenterWODelete))
                        .WhereIf(input.DocumentCenterRentalAddFilter.HasValue && input.DocumentCenterRentalAddFilter > -1, e => (input.DocumentCenterRentalAddFilter == 1 && e.DocumentCenterRentalAdd) || (input.DocumentCenterRentalAddFilter == 0 && !e.DocumentCenterRentalAdd))
                        .WhereIf(input.DocumentCenterRentalDeleteFilter.HasValue && input.DocumentCenterRentalDeleteFilter > -1, e => (input.DocumentCenterRentalDeleteFilter == 1 && e.DocumentCenterRentalDelete) || (input.DocumentCenterRentalDeleteFilter == 0 && !e.DocumentCenterRentalDelete))
                        .WhereIf(input.DocumentCenterMechanicAddFilter.HasValue && input.DocumentCenterMechanicAddFilter > -1, e => (input.DocumentCenterMechanicAddFilter == 1 && e.DocumentCenterMechanicAdd) || (input.DocumentCenterMechanicAddFilter == 0 && !e.DocumentCenterMechanicAdd))
                        .WhereIf(input.DocumentCenterMechanicDeleteFilter.HasValue && input.DocumentCenterMechanicDeleteFilter > -1, e => (input.DocumentCenterMechanicDeleteFilter == 1 && e.DocumentCenterMechanicDelete) || (input.DocumentCenterMechanicDeleteFilter == 0 && !e.DocumentCenterMechanicDelete))
                        .WhereIf(input.DocumentCenterCustomerAddFilter.HasValue && input.DocumentCenterCustomerAddFilter > -1, e => (input.DocumentCenterCustomerAddFilter == 1 && e.DocumentCenterCustomerAdd) || (input.DocumentCenterCustomerAddFilter == 0 && !e.DocumentCenterCustomerAdd))
                        .WhereIf(input.DocumentCenterCustomerDeleteFilter.HasValue && input.DocumentCenterCustomerDeleteFilter > -1, e => (input.DocumentCenterCustomerDeleteFilter == 1 && e.DocumentCenterCustomerDelete) || (input.DocumentCenterCustomerDeleteFilter == 0 && !e.DocumentCenterCustomerDelete))
                        .WhereIf(input.DocumentCenterEQAddFilter.HasValue && input.DocumentCenterEQAddFilter > -1, e => (input.DocumentCenterEQAddFilter == 1 && e.DocumentCenterEQAdd) || (input.DocumentCenterEQAddFilter == 0 && !e.DocumentCenterEQAdd))
                        .WhereIf(input.DocumentCenterEQDeleteFilter.HasValue && input.DocumentCenterEQDeleteFilter > -1, e => (input.DocumentCenterEQDeleteFilter == 1 && e.DocumentCenterEQDelete) || (input.DocumentCenterEQDeleteFilter == 0 && !e.DocumentCenterEQDelete))
                        .WhereIf(input.DocumentCenterVendorAddFilter.HasValue && input.DocumentCenterVendorAddFilter > -1, e => (input.DocumentCenterVendorAddFilter == 1 && e.DocumentCenterVendorAdd) || (input.DocumentCenterVendorAddFilter == 0 && !e.DocumentCenterVendorAdd))
                        .WhereIf(input.DocumentCenterVendorDeleteFilter.HasValue && input.DocumentCenterVendorDeleteFilter > -1, e => (input.DocumentCenterVendorDeleteFilter == 1 && e.DocumentCenterVendorDelete) || (input.DocumentCenterVendorDeleteFilter == 0 && !e.DocumentCenterVendorDelete))
                        .WhereIf(input.DocumentCenterAPInvoiceAddFilter.HasValue && input.DocumentCenterAPInvoiceAddFilter > -1, e => (input.DocumentCenterAPInvoiceAddFilter == 1 && e.DocumentCenterAPInvoiceAdd) || (input.DocumentCenterAPInvoiceAddFilter == 0 && !e.DocumentCenterAPInvoiceAdd))
                        .WhereIf(input.DocumentCenterAPInvoiceDeleteFilter.HasValue && input.DocumentCenterAPInvoiceDeleteFilter > -1, e => (input.DocumentCenterAPInvoiceDeleteFilter == 1 && e.DocumentCenterAPInvoiceDelete) || (input.DocumentCenterAPInvoiceDeleteFilter == 0 && !e.DocumentCenterAPInvoiceDelete))
                        .WhereIf(input.DocumentCenterPOAddFilter.HasValue && input.DocumentCenterPOAddFilter > -1, e => (input.DocumentCenterPOAddFilter == 1 && e.DocumentCenterPOAdd) || (input.DocumentCenterPOAddFilter == 0 && !e.DocumentCenterPOAdd))
                        .WhereIf(input.DocumentCenterPODeleteFilter.HasValue && input.DocumentCenterPODeleteFilter > -1, e => (input.DocumentCenterPODeleteFilter == 1 && e.DocumentCenterPODelete) || (input.DocumentCenterPODeleteFilter == 0 && !e.DocumentCenterPODelete))
                        .WhereIf(input.InvoiceFixCommentsFilter.HasValue && input.InvoiceFixCommentsFilter > -1, e => (input.InvoiceFixCommentsFilter == 1 && e.InvoiceFixComments) || (input.InvoiceFixCommentsFilter == 0 && !e.InvoiceFixComments))
                        .WhereIf(!string.IsNullOrWhiteSpace(input.DispatchNameFilter), e => e.DispatchName == input.DispatchNameFilter)
                        .WhereIf(input.SDIFilter.HasValue && input.SDIFilter > -1, e => (input.SDIFilter == 1 && e.SDI) || (input.SDIFilter == 0 && !e.SDI))
                        .WhereIf(input.AdminInspectionSetupFilter.HasValue && input.AdminInspectionSetupFilter > -1, e => (input.AdminInspectionSetupFilter == 1 && e.AdminInspectionSetup) || (input.AdminInspectionSetupFilter == 0 && !e.AdminInspectionSetup))
                        .WhereIf(input.AdminDisableSSNFilter.HasValue && input.AdminDisableSSNFilter > -1, e => (input.AdminDisableSSNFilter == 1 && e.AdminDisableSSN) || (input.AdminDisableSSNFilter == 0 && !e.AdminDisableSSN))
                        .WhereIf(input.AdminDisableDLNFilter.HasValue && input.AdminDisableDLNFilter > -1, e => (input.AdminDisableDLNFilter == 1 && e.AdminDisableDLN) || (input.AdminDisableDLNFilter == 0 && !e.AdminDisableDLN))
                        .WhereIf(input.WebServiceDispatchFilter.HasValue && input.WebServiceDispatchFilter > -1, e => (input.WebServiceDispatchFilter == 1 && e.WebServiceDispatch) || (input.WebServiceDispatchFilter == 0 && !e.WebServiceDispatch))
                        .WhereIf(input.WebTransportationDispatchFilter.HasValue && input.WebTransportationDispatchFilter > -1, e => (input.WebTransportationDispatchFilter == 1 && e.WebTransportationDispatch) || (input.WebTransportationDispatchFilter == 0 && !e.WebTransportationDispatch))
                        .WhereIf(input.WebMobileAdminFilter.HasValue && input.WebMobileAdminFilter > -1, e => (input.WebMobileAdminFilter == 1 && e.WebMobileAdmin) || (input.WebMobileAdminFilter == 0 && !e.WebMobileAdmin))
                        .WhereIf(input.WebMobileSalesmanFilter.HasValue && input.WebMobileSalesmanFilter > -1, e => (input.WebMobileSalesmanFilter == 1 && e.WebMobileSalesman) || (input.WebMobileSalesmanFilter == 0 && !e.WebMobileSalesman))
                        .WhereIf(input.WebMobileNoSelfPMDispatchFilter.HasValue && input.WebMobileNoSelfPMDispatchFilter > -1, e => (input.WebMobileNoSelfPMDispatchFilter == 1 && e.WebMobileNoSelfPMDispatch) || (input.WebMobileNoSelfPMDispatchFilter == 0 && !e.WebMobileNoSelfPMDispatch))
                        .WhereIf(input.InvoiceDesignOptionsFilter.HasValue && input.InvoiceDesignOptionsFilter > -1, e => (input.InvoiceDesignOptionsFilter == 1 && e.InvoiceDesignOptions) || (input.InvoiceDesignOptionsFilter == 0 && !e.InvoiceDesignOptions))
                        .WhereIf(input.PartsUserCrossSetupFilter.HasValue && input.PartsUserCrossSetupFilter > -1, e => (input.PartsUserCrossSetupFilter == 1 && e.PartsUserCrossSetup) || (input.PartsUserCrossSetupFilter == 0 && !e.PartsUserCrossSetup))
                        .WhereIf(input.InvoiceFixRentalDatesFilter.HasValue && input.InvoiceFixRentalDatesFilter > -1, e => (input.InvoiceFixRentalDatesFilter == 1 && e.InvoiceFixRentalDates) || (input.InvoiceFixRentalDatesFilter == 0 && !e.InvoiceFixRentalDates))
                        .WhereIf(input.PartsReceivingFilter.HasValue && input.PartsReceivingFilter > -1, e => (input.PartsReceivingFilter == 1 && e.PartsReceiving) || (input.PartsReceivingFilter == 0 && !e.PartsReceiving))
                        .WhereIf(input.AdminDisableHourlyRateFilter.HasValue && input.AdminDisableHourlyRateFilter > -1, e => (input.AdminDisableHourlyRateFilter == 1 && e.AdminDisableHourlyRate) || (input.AdminDisableHourlyRateFilter == 0 && !e.AdminDisableHourlyRate))
                        .WhereIf(input.WebMobileNoLaborEditFilter.HasValue && input.WebMobileNoLaborEditFilter > -1, e => (input.WebMobileNoLaborEditFilter == 1 && e.WebMobileNoLaborEdit) || (input.WebMobileNoLaborEditFilter == 0 && !e.WebMobileNoLaborEdit))
                        .WhereIf(input.MechanicClockInFilter.HasValue && input.MechanicClockInFilter > -1, e => (input.MechanicClockInFilter == 1 && e.MechanicClockIn) || (input.MechanicClockInFilter == 0 && !e.MechanicClockIn))
                        .WhereIf(input.PartsDisallowBOCostChangeFilter.HasValue && input.PartsDisallowBOCostChangeFilter > -1, e => (input.PartsDisallowBOCostChangeFilter == 1 && e.PartsDisallowBOCostChange) || (input.PartsDisallowBOCostChangeFilter == 0 && !e.PartsDisallowBOCostChange));

            var pagedAndFilteredSecure = filteredSecure
                .OrderBy(input.Sorting ?? "id asc")
                .PageBy(input);

            var secure = from o in pagedAndFilteredSecure
                         select new
                         {

                             o.Password,
                             o.EmployeeNo,
                             o.AdminProgram,
                             o.SaleExpenseCodes,
                             o.Company,
                             o.Branch,
                             o.Department,
                             o.Personnel,
                             o.Security,
                             o.LaborRates,
                             o.SDIAccounting,
                             o.CustomerProgram,
                             o.CustomerChange,
                             o.CustomerAdd,
                             o.CustomerDelete,
                             o.EquipmentProgram,
                             o.EquipmentChange,
                             o.EquipmentAdd,
                             o.EquipmentDelete,
                             o.EquipmentPM,
                             o.EquipmentCost,
                             o.EquipmentAdmin,
                             o.EquipmentAddAs,
                             o.InvoiceProgram,
                             o.InvoiceUpdate,
                             o.InvoiceOpen,
                             o.InvoiceClose,
                             o.InvoiceOpenPM,
                             o.InvoicePrintFinal,
                             o.InvoiceLaborTicket,
                             o.InvoiceComments,
                             o.InvoicePartsChange,
                             o.InvoicePartsAdd,
                             o.InvoicePartsDelete,
                             o.InvoicePartsTransfer,
                             o.InvoiceLaborChange,
                             o.InvoiceLaborAdd,
                             o.InvoiceLaborDelete,
                             o.InvoiceLaborTransfer,
                             o.InvoiceMiscChange,
                             o.InvoiceMiscAdd,
                             o.InvoiceMiscDelete,
                             o.InvoiceMiscTransfer,
                             o.InvoiceRentalChange,
                             o.InvoiceRentalAdd,
                             o.InvoiceRentalDelete,
                             o.InvoiceRentalTransfer,
                             o.InvoiceEquipmentChange,
                             o.InvoiceEquipmentAdd,
                             o.InvoiceEquipmentDelete,
                             o.InvoiceEquipmentTransfer,
                             o.InvoiceWIP,
                             o.InvoiceRegister,
                             o.InvoiceReOpen,
                             o.CreditMemos,
                             o.PartsProgram,
                             o.PartsChange,
                             o.PartsAdd,
                             o.PartsDelete,
                             o.PartsInquiry,
                             o.PartsTransfer,
                             o.PartsGroup,
                             o.PartsWarehouse,
                             o.PartsCost,
                             o.PartsAdmin,
                             o.PartsOrdering,
                             o.PartsInventory,
                             o.PartsOnHand,
                             o.PartsPartNoAlias,
                             o.InvoiceDeptLimit,
                             o.CustomerCreditApproval,
                             o.APVoucher,
                             o.APChecks,
                             o.APChecksApproval,
                             o.APChecksAutoChecks,
                             o.APChecksHandTyped,
                             o.APChecksRegister,
                             o.APChecksVoid,
                             o.APInquiry,
                             o.ARInquiry,
                             o.ARCash,
                             o.COA,
                             o.GJ,
                             o.GLInquiry,
                             o.Vendor,
                             o.InvoiceAccountingDist,
                             o.EquipmentUnitNo,
                             o.WebAccess,
                             o.WebCustomer,
                             o.WebCustomerNo,
                             o.WebWIP,
                             o.WebCustWIP,
                             o.WebCustFleet,
                             o.WebContacts,
                             o.WebCallReports,
                             o.WebEquipmentSummary,
                             o.WebCustAR,
                             o.InvoiceGPParts,
                             o.InvoiceGPLabor,
                             o.InvoiceGPMisc,
                             o.InvoiceGPRental,
                             o.InvoiceGPEquipment,
                             o.InvoiceGPTotal,
                             o.InvoiceAccountingFormat,
                             o.EquipmentControlNo,
                             o.ARComments,
                             o.CustomerCommission,
                             o.InvoiceNewEquipment,
                             o.InvoiceRates,
                             o.InvoiceFlatRateLabor,
                             o.InvoiceFlatRateParts,
                             o.InvoiceFlatRateMisc,
                             o.InvoiceFlatRateRental,
                             o.InvoiceFlatRateEquipment,
                             o.EquipmentInventory,
                             o.CustomerRates,
                             o.ProfileARComments,
                             o.WebUserID,
                             o.ManagementInformation,
                             o.EquipmentRentalRates,
                             o.EquipmentGLInfo,
                             o.PartsApproveOrders,
                             o.PartsLostSale,
                             o.PartsGroupBinChange,
                             o.InvoiceAddShipTo,
                             o.PartsToyotaNoAutoDash,
                             o.PartsWarehouseLimit,
                             o.InvoiceOverRideCurrencyRate,
                             o.InvoicePartsBelowCost,
                             o.WebWarehouse,
                             o.WebPartsInquiry,
                             o.WebPartsOrder,
                             o.InvoiceSalesman,
                             o.EquipmentLocation,
                             o.CustomerTerms,
                             o.InvoiceAutoOpenPMs,
                             o.EquipmentTab0,
                             o.EquipmentTab1,
                             o.EquipmentTab2,
                             o.EquipmentTab3,
                             o.EquipmentTab4,
                             o.EquipmentTab5,
                             o.EquipmentTab6,
                             o.EquipmentTab7,
                             o.EquipmentTab8,
                             o.EquipmentTab9,
                             o.CustomerCreditInfo,
                             o.InvoiceFixPONo,
                             o.InvoiceFixSalesman,
                             o.InvoiceFixWriter,
                             o.InvoiceFixShipVia,
                             o.InvoiceFixFOB,
                             o.EquipmentChangeSerialNo,
                             o.CustomerCC,
                             o.EquipmentTab10,
                             o.InvoiceMechLimitFlag,
                             o.InvoiceMechNo,
                             o.AddedBy,
                             o.DateAdded,
                             o.ChangedBy,
                             o.DateChanged,
                             o.InvoiceFix,
                             o.InvoiceFixHourMeter,
                             o.Transportation,
                             o.TransportationHeader,
                             o.TransportationDetail,
                             o.DocumentCenter,
                             o.DocumentCenterWOAdd,
                             o.DocumentCenterWODelete,
                             o.DocumentCenterRentalAdd,
                             o.DocumentCenterRentalDelete,
                             o.DocumentCenterMechanicAdd,
                             o.DocumentCenterMechanicDelete,
                             o.DocumentCenterCustomerAdd,
                             o.DocumentCenterCustomerDelete,
                             o.DocumentCenterEQAdd,
                             o.DocumentCenterEQDelete,
                             o.DocumentCenterVendorAdd,
                             o.DocumentCenterVendorDelete,
                             o.DocumentCenterAPInvoiceAdd,
                             o.DocumentCenterAPInvoiceDelete,
                             o.DocumentCenterPOAdd,
                             o.DocumentCenterPODelete,
                             o.InvoiceFixComments,
                             o.DispatchName,
                             o.SDI,
                             o.AdminInspectionSetup,
                             o.AdminDisableSSN,
                             o.AdminDisableDLN,
                             o.WebServiceDispatch,
                             o.WebTransportationDispatch,
                             o.WebMobileAdmin,
                             o.WebMobileSalesman,
                             o.WebMobileNoSelfPMDispatch,
                             o.InvoiceDesignOptions,
                             o.PartsUserCrossSetup,
                             o.InvoiceFixRentalDates,
                             o.PartsReceiving,
                             o.AdminDisableHourlyRate,
                             o.WebMobileNoLaborEdit,
                             o.MechanicClockIn,
                             o.PartsDisallowBOCostChange,
                             Id = o.Id
                         };

            var totalCount = await filteredSecure.CountAsync();

            var dbList = await secure.ToListAsync();
            var results = new List<GetSecureForViewDto>();

            foreach (var o in dbList)
            {
                var res = new GetSecureForViewDto()
                {
                    Secure = new SecureDto
                    {

                        Password = o.Password,
                        EmployeeNo = o.EmployeeNo,
                        AdminProgram = o.AdminProgram,
                        SaleExpenseCodes = o.SaleExpenseCodes,
                        Company = o.Company,
                        Branch = o.Branch,
                        Department = o.Department,
                        Personnel = o.Personnel,
                        Security = o.Security,
                        LaborRates = o.LaborRates,
                        SDIAccounting = o.SDIAccounting,
                        CustomerProgram = o.CustomerProgram,
                        CustomerChange = o.CustomerChange,
                        CustomerAdd = o.CustomerAdd,
                        CustomerDelete = o.CustomerDelete,
                        EquipmentProgram = o.EquipmentProgram,
                        EquipmentChange = o.EquipmentChange,
                        EquipmentAdd = o.EquipmentAdd,
                        EquipmentDelete = o.EquipmentDelete,
                        EquipmentPM = o.EquipmentPM,
                        EquipmentCost = o.EquipmentCost,
                        EquipmentAdmin = o.EquipmentAdmin,
                        EquipmentAddAs = o.EquipmentAddAs,
                        InvoiceProgram = o.InvoiceProgram,
                        InvoiceUpdate = o.InvoiceUpdate,
                        InvoiceOpen = o.InvoiceOpen,
                        InvoiceClose = o.InvoiceClose,
                        InvoiceOpenPM = o.InvoiceOpenPM,
                        InvoicePrintFinal = o.InvoicePrintFinal,
                        InvoiceLaborTicket = o.InvoiceLaborTicket,
                        InvoiceComments = o.InvoiceComments,
                        InvoicePartsChange = o.InvoicePartsChange,
                        InvoicePartsAdd = o.InvoicePartsAdd,
                        InvoicePartsDelete = o.InvoicePartsDelete,
                        InvoicePartsTransfer = o.InvoicePartsTransfer,
                        InvoiceLaborChange = o.InvoiceLaborChange,
                        InvoiceLaborAdd = o.InvoiceLaborAdd,
                        InvoiceLaborDelete = o.InvoiceLaborDelete,
                        InvoiceLaborTransfer = o.InvoiceLaborTransfer,
                        InvoiceMiscChange = o.InvoiceMiscChange,
                        InvoiceMiscAdd = o.InvoiceMiscAdd,
                        InvoiceMiscDelete = o.InvoiceMiscDelete,
                        InvoiceMiscTransfer = o.InvoiceMiscTransfer,
                        InvoiceRentalChange = o.InvoiceRentalChange,
                        InvoiceRentalAdd = o.InvoiceRentalAdd,
                        InvoiceRentalDelete = o.InvoiceRentalDelete,
                        InvoiceRentalTransfer = o.InvoiceRentalTransfer,
                        InvoiceEquipmentChange = o.InvoiceEquipmentChange,
                        InvoiceEquipmentAdd = o.InvoiceEquipmentAdd,
                        InvoiceEquipmentDelete = o.InvoiceEquipmentDelete,
                        InvoiceEquipmentTransfer = o.InvoiceEquipmentTransfer,
                        InvoiceWIP = o.InvoiceWIP,
                        InvoiceRegister = o.InvoiceRegister,
                        InvoiceReOpen = o.InvoiceReOpen,
                        CreditMemos = o.CreditMemos,
                        PartsProgram = o.PartsProgram,
                        PartsChange = o.PartsChange,
                        PartsAdd = o.PartsAdd,
                        PartsDelete = o.PartsDelete,
                        PartsInquiry = o.PartsInquiry,
                        PartsTransfer = o.PartsTransfer,
                        PartsGroup = o.PartsGroup,
                        PartsWarehouse = o.PartsWarehouse,
                        PartsCost = o.PartsCost,
                        PartsAdmin = o.PartsAdmin,
                        PartsOrdering = o.PartsOrdering,
                        PartsInventory = o.PartsInventory,
                        PartsOnHand = o.PartsOnHand,
                        PartsPartNoAlias = o.PartsPartNoAlias,
                        InvoiceDeptLimit = o.InvoiceDeptLimit,
                        CustomerCreditApproval = o.CustomerCreditApproval,
                        APVoucher = o.APVoucher,
                        APChecks = o.APChecks,
                        APChecksApproval = o.APChecksApproval,
                        APChecksAutoChecks = o.APChecksAutoChecks,
                        APChecksHandTyped = o.APChecksHandTyped,
                        APChecksRegister = o.APChecksRegister,
                        APChecksVoid = o.APChecksVoid,
                        APInquiry = o.APInquiry,
                        ARInquiry = o.ARInquiry,
                        ARCash = o.ARCash,
                        COA = o.COA,
                        GJ = o.GJ,
                        GLInquiry = o.GLInquiry,
                        Vendor = o.Vendor,
                        InvoiceAccountingDist = o.InvoiceAccountingDist,
                        EquipmentUnitNo = o.EquipmentUnitNo,
                        WebAccess = o.WebAccess,
                        WebCustomer = o.WebCustomer,
                        WebCustomerNo = o.WebCustomerNo,
                        WebWIP = o.WebWIP,
                        WebCustWIP = o.WebCustWIP,
                        WebCustFleet = o.WebCustFleet,
                        WebContacts = o.WebContacts,
                        WebCallReports = o.WebCallReports,
                        WebEquipmentSummary = o.WebEquipmentSummary,
                        WebCustAR = o.WebCustAR,
                        InvoiceGPParts = o.InvoiceGPParts,
                        InvoiceGPLabor = o.InvoiceGPLabor,
                        InvoiceGPMisc = o.InvoiceGPMisc,
                        InvoiceGPRental = o.InvoiceGPRental,
                        InvoiceGPEquipment = o.InvoiceGPEquipment,
                        InvoiceGPTotal = o.InvoiceGPTotal,
                        InvoiceAccountingFormat = o.InvoiceAccountingFormat,
                        EquipmentControlNo = o.EquipmentControlNo,
                        ARComments = o.ARComments,
                        CustomerCommission = o.CustomerCommission,
                        InvoiceNewEquipment = o.InvoiceNewEquipment,
                        InvoiceRates = o.InvoiceRates,
                        InvoiceFlatRateLabor = o.InvoiceFlatRateLabor,
                        InvoiceFlatRateParts = o.InvoiceFlatRateParts,
                        InvoiceFlatRateMisc = o.InvoiceFlatRateMisc,
                        InvoiceFlatRateRental = o.InvoiceFlatRateRental,
                        InvoiceFlatRateEquipment = o.InvoiceFlatRateEquipment,
                        EquipmentInventory = o.EquipmentInventory,
                        CustomerRates = o.CustomerRates,
                        ProfileARComments = o.ProfileARComments,
                        WebUserID = o.WebUserID,
                        ManagementInformation = o.ManagementInformation,
                        EquipmentRentalRates = o.EquipmentRentalRates,
                        EquipmentGLInfo = o.EquipmentGLInfo,
                        PartsApproveOrders = o.PartsApproveOrders,
                        PartsLostSale = o.PartsLostSale,
                        PartsGroupBinChange = o.PartsGroupBinChange,
                        InvoiceAddShipTo = o.InvoiceAddShipTo,
                        PartsToyotaNoAutoDash = o.PartsToyotaNoAutoDash,
                        PartsWarehouseLimit = o.PartsWarehouseLimit,
                        InvoiceOverRideCurrencyRate = o.InvoiceOverRideCurrencyRate,
                        InvoicePartsBelowCost = o.InvoicePartsBelowCost,
                        WebWarehouse = o.WebWarehouse,
                        WebPartsInquiry = o.WebPartsInquiry,
                        WebPartsOrder = o.WebPartsOrder,
                        InvoiceSalesman = o.InvoiceSalesman,
                        EquipmentLocation = o.EquipmentLocation,
                        CustomerTerms = o.CustomerTerms,
                        InvoiceAutoOpenPMs = o.InvoiceAutoOpenPMs,
                        EquipmentTab0 = o.EquipmentTab0,
                        EquipmentTab1 = o.EquipmentTab1,
                        EquipmentTab2 = o.EquipmentTab2,
                        EquipmentTab3 = o.EquipmentTab3,
                        EquipmentTab4 = o.EquipmentTab4,
                        EquipmentTab5 = o.EquipmentTab5,
                        EquipmentTab6 = o.EquipmentTab6,
                        EquipmentTab7 = o.EquipmentTab7,
                        EquipmentTab8 = o.EquipmentTab8,
                        EquipmentTab9 = o.EquipmentTab9,
                        CustomerCreditInfo = o.CustomerCreditInfo,
                        InvoiceFixPONo = o.InvoiceFixPONo,
                        InvoiceFixSalesman = o.InvoiceFixSalesman,
                        InvoiceFixWriter = o.InvoiceFixWriter,
                        InvoiceFixShipVia = o.InvoiceFixShipVia,
                        InvoiceFixFOB = o.InvoiceFixFOB,
                        EquipmentChangeSerialNo = o.EquipmentChangeSerialNo,
                        CustomerCC = o.CustomerCC,
                        EquipmentTab10 = o.EquipmentTab10,
                        InvoiceMechLimitFlag = o.InvoiceMechLimitFlag,
                        InvoiceMechNo = o.InvoiceMechNo,
                        AddedBy = o.AddedBy,
                        DateAdded = o.DateAdded,
                        ChangedBy = o.ChangedBy,
                        DateChanged = o.DateChanged,
                        InvoiceFix = o.InvoiceFix,
                        InvoiceFixHourMeter = o.InvoiceFixHourMeter,
                        Transportation = o.Transportation,
                        TransportationHeader = o.TransportationHeader,
                        TransportationDetail = o.TransportationDetail,
                        DocumentCenter = o.DocumentCenter,
                        DocumentCenterWOAdd = o.DocumentCenterWOAdd,
                        DocumentCenterWODelete = o.DocumentCenterWODelete,
                        DocumentCenterRentalAdd = o.DocumentCenterRentalAdd,
                        DocumentCenterRentalDelete = o.DocumentCenterRentalDelete,
                        DocumentCenterMechanicAdd = o.DocumentCenterMechanicAdd,
                        DocumentCenterMechanicDelete = o.DocumentCenterMechanicDelete,
                        DocumentCenterCustomerAdd = o.DocumentCenterCustomerAdd,
                        DocumentCenterCustomerDelete = o.DocumentCenterCustomerDelete,
                        DocumentCenterEQAdd = o.DocumentCenterEQAdd,
                        DocumentCenterEQDelete = o.DocumentCenterEQDelete,
                        DocumentCenterVendorAdd = o.DocumentCenterVendorAdd,
                        DocumentCenterVendorDelete = o.DocumentCenterVendorDelete,
                        DocumentCenterAPInvoiceAdd = o.DocumentCenterAPInvoiceAdd,
                        DocumentCenterAPInvoiceDelete = o.DocumentCenterAPInvoiceDelete,
                        DocumentCenterPOAdd = o.DocumentCenterPOAdd,
                        DocumentCenterPODelete = o.DocumentCenterPODelete,
                        InvoiceFixComments = o.InvoiceFixComments,
                        DispatchName = o.DispatchName,
                        SDI = o.SDI,
                        AdminInspectionSetup = o.AdminInspectionSetup,
                        AdminDisableSSN = o.AdminDisableSSN,
                        AdminDisableDLN = o.AdminDisableDLN,
                        WebServiceDispatch = o.WebServiceDispatch,
                        WebTransportationDispatch = o.WebTransportationDispatch,
                        WebMobileAdmin = o.WebMobileAdmin,
                        WebMobileSalesman = o.WebMobileSalesman,
                        WebMobileNoSelfPMDispatch = o.WebMobileNoSelfPMDispatch,
                        InvoiceDesignOptions = o.InvoiceDesignOptions,
                        PartsUserCrossSetup = o.PartsUserCrossSetup,
                        InvoiceFixRentalDates = o.InvoiceFixRentalDates,
                        PartsReceiving = o.PartsReceiving,
                        AdminDisableHourlyRate = o.AdminDisableHourlyRate,
                        WebMobileNoLaborEdit = o.WebMobileNoLaborEdit,
                        MechanicClockIn = o.MechanicClockIn,
                        PartsDisallowBOCostChange = o.PartsDisallowBOCostChange,
                        Id = o.Id,
                    }
                };

                results.Add(res);
            }

            return new PagedResultDto<GetSecureForViewDto>(
                totalCount,
                results
            );

        }

        /// <summary>
        /// Getts a record to be edited
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [AbpAuthorize(AppPermissions.Pages_Secure_Edit)]
        public async Task<GetSecureForEditOutput> GetSecureForEdit(EntityDto input)
        {
            var secure = await _secureRepository.FirstOrDefaultAsync(input.Id);

            var output = new GetSecureForEditOutput { Secure = ObjectMapper.Map<CreateOrEditSecureDto>(secure) };

            return output;
        }

        /// <summary>
        /// Creates or edits a secure record
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task CreateOrEdit(CreateOrEditSecureDto input)
        {
            if (input.Id == null)
            {
                await Create(input);
            }
            else
            {
                await Update(input);
            }
        }

        /// <summary>
        /// Creates a new record
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [AbpAuthorize(AppPermissions.Pages_Secure_Create)]
        protected virtual async Task Create(CreateOrEditSecureDto input)
        {
            var secure = ObjectMapper.Map<Secure>(input);

            if (AbpSession.TenantId != null)
            {
                secure.TenantId = (int?)AbpSession.TenantId;
            }

            await _secureRepository.InsertAsync(secure);

        }

        /// <summary>
        /// Edits a new record
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [AbpAuthorize(AppPermissions.Pages_Secure_Edit)]
        protected virtual async Task Update(CreateOrEditSecureDto input)
        {
            var secure = await _secureRepository.FirstOrDefaultAsync((int)input.Id);
            ObjectMapper.Map(input, secure);

        }

        /// <summary>
        /// Deletes a secure record
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [AbpAuthorize(AppPermissions.Pages_Secure_Delete)]
        public async Task Delete(EntityDto input)
        {
            await _secureRepository.DeleteAsync(input.Id);
        }

    }
}