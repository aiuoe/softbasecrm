using SBCRM.Crm;

using System;
using System.Linq;
using System.Linq.Dynamic.Core;
using Abp.Linq.Extensions;
using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Domain.Repositories;
using SBCRM.Legacy.Exporting;
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
    [AbpAuthorize(AppPermissions.Pages_Customer)]
    public class CustomerAppService : SBCRMAppServiceBase, ICustomerAppService
    {
        private readonly Base.IRepository<Customer> _customerRepository;
        private readonly ICustomerExcelExporter _customerExcelExporter;
        private readonly Base.IRepository<AccountType> _lookup_accountTypeRepository;

        public CustomerAppService(
            Base.IRepository<Customer> customerRepository,
            ICustomerExcelExporter customerExcelExporter,
            Base.IRepository<AccountType> lookup_accountTypeRepository)
        {
            _customerRepository = customerRepository;
            _customerExcelExporter = customerExcelExporter;
            _lookup_accountTypeRepository = lookup_accountTypeRepository;

        }

        public async Task<PagedResultDto<GetCustomerForViewDto>> GetAll(GetAllCustomerInput input)
        {

            var filteredCustomer = _customerRepository.GetAll()
                        .Include(e => e.AccountTypeFk)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.Filter), e => false || e.Number.Contains(input.Filter) || e.BillTo.Contains(input.Filter) || e.Name.Contains(input.Filter) || e.SearchName.Contains(input.Filter) || e.SubName.Contains(input.Filter) || e.POBox.Contains(input.Filter) || e.Address.Contains(input.Filter) || e.City.Contains(input.Filter) || e.State.Contains(input.Filter) || e.ZipCode.Contains(input.Filter) || e.Country.Contains(input.Filter) || e.Salutation.Contains(input.Filter) || e.Phone.Contains(input.Filter) || e.Extention.Contains(input.Filter) || e.Phone2.Contains(input.Filter) || e.Cellular.Contains(input.Filter) || e.Beeper.Contains(input.Filter) || e.HomePhone.Contains(input.Filter) || e.Fax.Contains(input.Filter) || e.ResaleNo.Contains(input.Filter) || e.EMail.Contains(input.Filter) || e.WWWAddress.Contains(input.Filter) || e.ParentCompany.Contains(input.Filter) || e.MapLocation.Contains(input.Filter) || e.Salesman1.Contains(input.Filter) || e.Salesman2.Contains(input.Filter) || e.Salesman3.Contains(input.Filter) || e.Salesman4.Contains(input.Filter) || e.Salesman5.Contains(input.Filter) || e.Salesman6.Contains(input.Filter) || e.Terms.Contains(input.Filter) || e.FiscalEnd.Contains(input.Filter) || e.DunsCode.Contains(input.Filter) || e.SICCode.Contains(input.Filter) || e.MailingGroup.Contains(input.Filter) || e.Makes.Contains(input.Filter) || e.TaxCode.Contains(input.Filter) || e.LaborRate.Contains(input.Filter) || e.ShopLaborRate.Contains(input.Filter) || e.RentalRate.Contains(input.Filter) || e.PartsRate.Contains(input.Filter) || e.AddedBy.Contains(input.Filter) || e.ChangedBy.Contains(input.Filter) || e.SalesContact.Contains(input.Filter) || e.CSContact.Contains(input.Filter) || e.AccountingContact.Contains(input.Filter) || e.Comments.Contains(input.Filter) || e.ARComments.Contains(input.Filter) || e.CompanyComments.Contains(input.Filter) || e.CompanyCommentsBy.Contains(input.Filter) || e.BusinessCategory.Contains(input.Filter) || e.BusinessDescription.Contains(input.Filter) || e.SICCode2.Contains(input.Filter) || e.SICCode3.Contains(input.Filter) || e.SICCode4.Contains(input.Filter) || e.Category.Contains(input.Filter) || e.DeliveryInfo.Contains(input.Filter) || e.CustomerTerritory.Contains(input.Filter) || e.CreditRating1.Contains(input.Filter) || e.CreditRating2.Contains(input.Filter) || e.StateTaxCode.Contains(input.Filter) || e.CountyTaxCode.Contains(input.Filter) || e.CityTaxCode.Contains(input.Filter) || e.MFGPermitNo.Contains(input.Filter) || e.VendorNo.Contains(input.Filter) || e.LocalTaxCode.Contains(input.Filter) || e.CurrencyType.Contains(input.Filter) || e.CreditCardNo.Contains(input.Filter) || e.CreditCardCVV.Contains(input.Filter) || e.CreditCardExpDate.Contains(input.Filter) || e.CreditCardType.Contains(input.Filter) || e.NameOnCreditCard.Contains(input.Filter) || e.RFC.Contains(input.Filter) || e.OldNumber.Contains(input.Filter) || e.ServiceChargeDescription.Contains(input.Filter) || e.InsuranceNo.Contains(input.Filter) || e.CreditCardAddress.Contains(input.Filter) || e.CreditCardPOBox.Contains(input.Filter) || e.CreditCardCity.Contains(input.Filter) || e.CreditCardState.Contains(input.Filter) || e.CreditCardZipCode.Contains(input.Filter) || e.CreditCardCountry.Contains(input.Filter) || e.PMLaborRate.Contains(input.Filter) || e.ReferenceNo1.Contains(input.Filter) || e.ReferenceNo2.Contains(input.Filter) || e.OB10No.Contains(input.Filter) || e.OldName.Contains(input.Filter) || e.ShipVia.Contains(input.Filter) || e.LaborDiscount.Contains(input.Filter) || e.TaxRate.Contains(input.Filter) || e.TMHUNo.Contains(input.Filter) || e.TaxCodeImport.Contains(input.Filter) || e.ShippingComments.Contains(input.Filter) || e.ShippingCompany.Contains(input.Filter) || e.ShippingAccount.Contains(input.Filter) || e.EMailInvoiceAddress.Contains(input.Filter) || e.EMailInvoiceAttention.Contains(input.Filter) || e.OldSalesman1.Contains(input.Filter) || e.OldSalesman2.Contains(input.Filter) || e.OldSalesman3.Contains(input.Filter) || e.OldSalesman4.Contains(input.Filter) || e.OldSalesman5.Contains(input.Filter) || e.OldSalesman6.Contains(input.Filter) || e.InvoiceLanguage.Contains(input.Filter) || e.PSCompany.Contains(input.Filter) || e.PSAccount.Contains(input.Filter) || e.PSLocation.Contains(input.Filter) || e.PSDept.Contains(input.Filter) || e.PSProduct.Contains(input.Filter) || e.AltCustomerNo.Contains(input.Filter) || e.MarketingSource.Contains(input.Filter) || e.EmailRoadService.Contains(input.Filter) || e.EmailShopService.Contains(input.Filter) || e.EmailPMService.Contains(input.Filter) || e.EmailRentalPMService.Contains(input.Filter) || e.EmailPartsCounter.Contains(input.Filter) || e.EmailEquipmentSales.Contains(input.Filter) || e.EmailRentals.Contains(input.Filter) || e.ARStatementsEmailAddress.Contains(input.Filter))
                        .WhereIf(!string.IsNullOrWhiteSpace(input.NumberFilter), e => e.Number == input.NumberFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.BillToFilter), e => e.BillTo == input.BillToFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.NameFilter), e => e.Name == input.NameFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.SearchNameFilter), e => e.SearchName == input.SearchNameFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.SubNameFilter), e => e.SubName == input.SubNameFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.POBoxFilter), e => e.POBox == input.POBoxFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.AddressFilter), e => e.Address == input.AddressFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.CityFilter), e => e.City == input.CityFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.StateFilter), e => e.State == input.StateFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.ZipCodeFilter), e => e.ZipCode == input.ZipCodeFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.CountryFilter), e => e.Country == input.CountryFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.SalutationFilter), e => e.Salutation == input.SalutationFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.PhoneFilter), e => e.Phone == input.PhoneFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.ExtentionFilter), e => e.Extention == input.ExtentionFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.Phone2Filter), e => e.Phone2 == input.Phone2Filter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.CellularFilter), e => e.Cellular == input.CellularFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.BeeperFilter), e => e.Beeper == input.BeeperFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.HomePhoneFilter), e => e.HomePhone == input.HomePhoneFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.FaxFilter), e => e.Fax == input.FaxFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.ResaleNoFilter), e => e.ResaleNo == input.ResaleNoFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.EMailFilter), e => e.EMail == input.EMailFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.WWWAddressFilter), e => e.WWWAddress == input.WWWAddressFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.ParentCompanyFilter), e => e.ParentCompany == input.ParentCompanyFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.MapLocationFilter), e => e.MapLocation == input.MapLocationFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.Salesman1Filter), e => e.Salesman1 == input.Salesman1Filter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.Salesman2Filter), e => e.Salesman2 == input.Salesman2Filter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.Salesman3Filter), e => e.Salesman3 == input.Salesman3Filter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.Salesman4Filter), e => e.Salesman4 == input.Salesman4Filter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.Salesman5Filter), e => e.Salesman5 == input.Salesman5Filter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.Salesman6Filter), e => e.Salesman6 == input.Salesman6Filter)
                        .WhereIf(input.MinLockAPR1Filter != null, e => e.LockAPR1 >= input.MinLockAPR1Filter)
                        .WhereIf(input.MaxLockAPR1Filter != null, e => e.LockAPR1 <= input.MaxLockAPR1Filter)
                        .WhereIf(input.MinLockAPR2Filter != null, e => e.LockAPR2 >= input.MinLockAPR2Filter)
                        .WhereIf(input.MaxLockAPR2Filter != null, e => e.LockAPR2 <= input.MaxLockAPR2Filter)
                        .WhereIf(input.MinLockAPR3Filter != null, e => e.LockAPR3 >= input.MinLockAPR3Filter)
                        .WhereIf(input.MaxLockAPR3Filter != null, e => e.LockAPR3 <= input.MaxLockAPR3Filter)
                        .WhereIf(input.MinLockAPR4Filter != null, e => e.LockAPR4 >= input.MinLockAPR4Filter)
                        .WhereIf(input.MaxLockAPR4Filter != null, e => e.LockAPR4 <= input.MaxLockAPR4Filter)
                        .WhereIf(input.MinLockAPR5Filter != null, e => e.LockAPR5 >= input.MinLockAPR5Filter)
                        .WhereIf(input.MaxLockAPR5Filter != null, e => e.LockAPR5 <= input.MaxLockAPR5Filter)
                        .WhereIf(input.MinLockAPR6Filter != null, e => e.LockAPR6 >= input.MinLockAPR6Filter)
                        .WhereIf(input.MaxLockAPR6Filter != null, e => e.LockAPR6 <= input.MaxLockAPR6Filter)
                        .WhereIf(input.MinSalesGroup1Filter != null, e => e.SalesGroup1 >= input.MinSalesGroup1Filter)
                        .WhereIf(input.MaxSalesGroup1Filter != null, e => e.SalesGroup1 <= input.MaxSalesGroup1Filter)
                        .WhereIf(input.MinSalesGroup2Filter != null, e => e.SalesGroup2 >= input.MinSalesGroup2Filter)
                        .WhereIf(input.MaxSalesGroup2Filter != null, e => e.SalesGroup2 <= input.MaxSalesGroup2Filter)
                        .WhereIf(input.MinSalesGroup3Filter != null, e => e.SalesGroup3 >= input.MinSalesGroup3Filter)
                        .WhereIf(input.MaxSalesGroup3Filter != null, e => e.SalesGroup3 <= input.MaxSalesGroup3Filter)
                        .WhereIf(input.MinSalesGroup4Filter != null, e => e.SalesGroup4 >= input.MinSalesGroup4Filter)
                        .WhereIf(input.MaxSalesGroup4Filter != null, e => e.SalesGroup4 <= input.MaxSalesGroup4Filter)
                        .WhereIf(input.MinSalesGroup5Filter != null, e => e.SalesGroup5 >= input.MinSalesGroup5Filter)
                        .WhereIf(input.MaxSalesGroup5Filter != null, e => e.SalesGroup5 <= input.MaxSalesGroup5Filter)
                        .WhereIf(input.MinSalesGroup6Filter != null, e => e.SalesGroup6 >= input.MinSalesGroup6Filter)
                        .WhereIf(input.MaxSalesGroup6Filter != null, e => e.SalesGroup6 <= input.MaxSalesGroup6Filter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.TermsFilter), e => e.Terms == input.TermsFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.FiscalEndFilter), e => e.FiscalEnd == input.FiscalEndFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.DunsCodeFilter), e => e.DunsCode == input.DunsCodeFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.SICCodeFilter), e => e.SICCode == input.SICCodeFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.MailingGroupFilter), e => e.MailingGroup == input.MailingGroupFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.MakesFilter), e => e.Makes == input.MakesFilter)
                        .WhereIf(input.MinPOReqFilter != null, e => e.POReq >= input.MinPOReqFilter)
                        .WhereIf(input.MaxPOReqFilter != null, e => e.POReq <= input.MaxPOReqFilter)
                        .WhereIf(input.MinPrevShipFilter != null, e => e.PrevShip >= input.MinPrevShipFilter)
                        .WhereIf(input.MaxPrevShipFilter != null, e => e.PrevShip <= input.MaxPrevShipFilter)
                        .WhereIf(input.MinTaxableFilter != null, e => e.Taxable >= input.MinTaxableFilter)
                        .WhereIf(input.MaxTaxableFilter != null, e => e.Taxable <= input.MaxTaxableFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.TaxCodeFilter), e => e.TaxCode == input.TaxCodeFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.LaborRateFilter), e => e.LaborRate == input.LaborRateFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.ShopLaborRateFilter), e => e.ShopLaborRate == input.ShopLaborRateFilter)
                        .WhereIf(input.MinShowLaborRateFilter != null, e => e.ShowLaborRate >= input.MinShowLaborRateFilter)
                        .WhereIf(input.MaxShowLaborRateFilter != null, e => e.ShowLaborRate <= input.MaxShowLaborRateFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.RentalRateFilter), e => e.RentalRate == input.RentalRateFilter)
                        .WhereIf(input.MinShowPartNoAliasFilter != null, e => e.ShowPartNoAlias >= input.MinShowPartNoAliasFilter)
                        .WhereIf(input.MaxShowPartNoAliasFilter != null, e => e.ShowPartNoAlias <= input.MaxShowPartNoAliasFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.PartsRateFilter), e => e.PartsRate == input.PartsRateFilter)
                        .WhereIf(input.MinPartsRateDiscountFilter != null, e => e.PartsRateDiscount >= input.MinPartsRateDiscountFilter)
                        .WhereIf(input.MaxPartsRateDiscountFilter != null, e => e.PartsRateDiscount <= input.MaxPartsRateDiscountFilter)
                        .WhereIf(input.MinAddedFilter != null, e => e.Added >= input.MinAddedFilter)
                        .WhereIf(input.MaxAddedFilter != null, e => e.Added <= input.MaxAddedFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.AddedByFilter), e => e.AddedBy == input.AddedByFilter)
                        .WhereIf(input.MinChangedFilter != null, e => e.Changed >= input.MinChangedFilter)
                        .WhereIf(input.MaxChangedFilter != null, e => e.Changed <= input.MaxChangedFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.ChangedByFilter), e => e.ChangedBy == input.ChangedByFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.SalesContactFilter), e => e.SalesContact == input.SalesContactFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.CSContactFilter), e => e.CSContact == input.CSContactFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.AccountingContactFilter), e => e.AccountingContact == input.AccountingContactFilter)
                        .WhereIf(input.MinInternalCustomerFilter != null, e => e.InternalCustomer >= input.MinInternalCustomerFilter)
                        .WhereIf(input.MaxInternalCustomerFilter != null, e => e.InternalCustomer <= input.MaxInternalCustomerFilter)
                        .WhereIf(input.MinEquipmentBidFilter != null, e => e.EquipmentBid >= input.MinEquipmentBidFilter)
                        .WhereIf(input.MaxEquipmentBidFilter != null, e => e.EquipmentBid <= input.MaxEquipmentBidFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.CommentsFilter), e => e.Comments == input.CommentsFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.ARCommentsFilter), e => e.ARComments == input.ARCommentsFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.CompanyCommentsFilter), e => e.CompanyComments == input.CompanyCommentsFilter)
                        .WhereIf(input.MinCompanyCommentsDateFilter != null, e => e.CompanyCommentsDate >= input.MinCompanyCommentsDateFilter)
                        .WhereIf(input.MaxCompanyCommentsDateFilter != null, e => e.CompanyCommentsDate <= input.MaxCompanyCommentsDateFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.CompanyCommentsByFilter), e => e.CompanyCommentsBy == input.CompanyCommentsByFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.BusinessCategoryFilter), e => e.BusinessCategory == input.BusinessCategoryFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.BusinessDescriptionFilter), e => e.BusinessDescription == input.BusinessDescriptionFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.SICCode2Filter), e => e.SICCode2 == input.SICCode2Filter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.SICCode3Filter), e => e.SICCode3 == input.SICCode3Filter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.SICCode4Filter), e => e.SICCode4 == input.SICCode4Filter)
                        .WhereIf(input.MinShiftsFilter != null, e => e.Shifts >= input.MinShiftsFilter)
                        .WhereIf(input.MaxShiftsFilter != null, e => e.Shifts <= input.MaxShiftsFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.CategoryFilter), e => e.Category == input.CategoryFilter)
                        .WhereIf(input.MinHoursOfOpStartFilter != null, e => e.HoursOfOpStart >= input.MinHoursOfOpStartFilter)
                        .WhereIf(input.MaxHoursOfOpStartFilter != null, e => e.HoursOfOpStart <= input.MaxHoursOfOpStartFilter)
                        .WhereIf(input.MinHoursOfOpEndFilter != null, e => e.HoursOfOpEnd >= input.MinHoursOfOpEndFilter)
                        .WhereIf(input.MaxHoursOfOpEndFilter != null, e => e.HoursOfOpEnd <= input.MaxHoursOfOpEndFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.DeliveryInfoFilter), e => e.DeliveryInfo == input.DeliveryInfoFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.CustomerTerritoryFilter), e => e.CustomerTerritory == input.CustomerTerritoryFilter)
                        .WhereIf(input.MinCreditHoldFlagFilter != null, e => e.CreditHoldFlag >= input.MinCreditHoldFlagFilter)
                        .WhereIf(input.MaxCreditHoldFlagFilter != null, e => e.CreditHoldFlag <= input.MaxCreditHoldFlagFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.CreditRating1Filter), e => e.CreditRating1 == input.CreditRating1Filter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.CreditRating2Filter), e => e.CreditRating2 == input.CreditRating2Filter)
                        .WhereIf(input.MinStatementsFilter != null, e => e.Statements >= input.MinStatementsFilter)
                        .WhereIf(input.MaxStatementsFilter != null, e => e.Statements <= input.MaxStatementsFilter)
                        .WhereIf(input.MinCreditHoldDaysFilter != null, e => e.CreditHoldDays >= input.MinCreditHoldDaysFilter)
                        .WhereIf(input.MaxCreditHoldDaysFilter != null, e => e.CreditHoldDays <= input.MaxCreditHoldDaysFilter)
                        .WhereIf(input.MinFinanceChargeFilter != null, e => e.FinanceCharge >= input.MinFinanceChargeFilter)
                        .WhereIf(input.MaxFinanceChargeFilter != null, e => e.FinanceCharge <= input.MaxFinanceChargeFilter)
                        .WhereIf(input.MinResaleExpDateFilter != null, e => e.ResaleExpDate >= input.MinResaleExpDateFilter)
                        .WhereIf(input.MaxResaleExpDateFilter != null, e => e.ResaleExpDate <= input.MaxResaleExpDateFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.StateTaxCodeFilter), e => e.StateTaxCode == input.StateTaxCodeFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.CountyTaxCodeFilter), e => e.CountyTaxCode == input.CountyTaxCodeFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.CityTaxCodeFilter), e => e.CityTaxCode == input.CityTaxCodeFilter)
                        .WhereIf(input.MinAbsoluteTaxCodesFilter != null, e => e.AbsoluteTaxCodes >= input.MinAbsoluteTaxCodesFilter)
                        .WhereIf(input.MaxAbsoluteTaxCodesFilter != null, e => e.AbsoluteTaxCodes <= input.MaxAbsoluteTaxCodesFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.MFGPermitNoFilter), e => e.MFGPermitNo == input.MFGPermitNoFilter)
                        .WhereIf(input.MinMFGPermitExpDateFilter != null, e => e.MFGPermitExpDate >= input.MinMFGPermitExpDateFilter)
                        .WhereIf(input.MaxMFGPermitExpDateFilter != null, e => e.MFGPermitExpDate <= input.MaxMFGPermitExpDateFilter)
                        .WhereIf(input.MinBranchFilter != null, e => e.Branch >= input.MinBranchFilter)
                        .WhereIf(input.MaxBranchFilter != null, e => e.Branch <= input.MaxBranchFilter)
                        .WhereIf(input.MinShowLaborHoursFilter != null, e => e.ShowLaborHours >= input.MinShowLaborHoursFilter)
                        .WhereIf(input.MaxShowLaborHoursFilter != null, e => e.ShowLaborHours <= input.MaxShowLaborHoursFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.VendorNoFilter), e => e.VendorNo == input.VendorNoFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.LocalTaxCodeFilter), e => e.LocalTaxCode == input.LocalTaxCodeFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.CurrencyTypeFilter), e => e.CurrencyType == input.CurrencyTypeFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.CreditCardNoFilter), e => e.CreditCardNo == input.CreditCardNoFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.CreditCardCVVFilter), e => e.CreditCardCVV == input.CreditCardCVVFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.CreditCardExpDateFilter), e => e.CreditCardExpDate == input.CreditCardExpDateFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.CreditCardTypeFilter), e => e.CreditCardType == input.CreditCardTypeFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.NameOnCreditCardFilter), e => e.NameOnCreditCard == input.NameOnCreditCardFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.RFCFilter), e => e.RFC == input.RFCFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.OldNumberFilter), e => e.OldNumber == input.OldNumberFilter)
                        .WhereIf(input.MinSuppressPartsPricingFilter != null, e => e.SuppressPartsPricing >= input.MinSuppressPartsPricingFilter)
                        .WhereIf(input.MaxSuppressPartsPricingFilter != null, e => e.SuppressPartsPricing <= input.MaxSuppressPartsPricingFilter)
                        .WhereIf(input.MinServiceChargeFilter != null, e => e.ServiceCharge >= input.MinServiceChargeFilter)
                        .WhereIf(input.MaxServiceChargeFilter != null, e => e.ServiceCharge <= input.MaxServiceChargeFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.ServiceChargeDescriptionFilter), e => e.ServiceChargeDescription == input.ServiceChargeDescriptionFilter)
                        .WhereIf(input.MinFinalCopiesFilter != null, e => e.FinalCopies >= input.MinFinalCopiesFilter)
                        .WhereIf(input.MaxFinalCopiesFilter != null, e => e.FinalCopies <= input.MaxFinalCopiesFilter)
                        .WhereIf(input.MinPOBoxAndAddressFilter != null, e => e.POBoxAndAddress >= input.MinPOBoxAndAddressFilter)
                        .WhereIf(input.MaxPOBoxAndAddressFilter != null, e => e.POBoxAndAddress <= input.MaxPOBoxAndAddressFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.InsuranceNoFilter), e => e.InsuranceNo == input.InsuranceNoFilter)
                        .WhereIf(input.MinInsuranceNoDateFilter != null, e => e.InsuranceNoDate >= input.MinInsuranceNoDateFilter)
                        .WhereIf(input.MaxInsuranceNoDateFilter != null, e => e.InsuranceNoDate <= input.MaxInsuranceNoDateFilter)
                        .WhereIf(input.MinInsuranceNoRecvDateFilter != null, e => e.InsuranceNoRecvDate >= input.MinInsuranceNoRecvDateFilter)
                        .WhereIf(input.MaxInsuranceNoRecvDateFilter != null, e => e.InsuranceNoRecvDate <= input.MaxInsuranceNoRecvDateFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.CreditCardAddressFilter), e => e.CreditCardAddress == input.CreditCardAddressFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.CreditCardPOBoxFilter), e => e.CreditCardPOBox == input.CreditCardPOBoxFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.CreditCardCityFilter), e => e.CreditCardCity == input.CreditCardCityFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.CreditCardStateFilter), e => e.CreditCardState == input.CreditCardStateFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.CreditCardZipCodeFilter), e => e.CreditCardZipCode == input.CreditCardZipCodeFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.CreditCardCountryFilter), e => e.CreditCardCountry == input.CreditCardCountryFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.PMLaborRateFilter), e => e.PMLaborRate == input.PMLaborRateFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.ReferenceNo1Filter), e => e.ReferenceNo1 == input.ReferenceNo1Filter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.ReferenceNo2Filter), e => e.ReferenceNo2 == input.ReferenceNo2Filter)
                        .WhereIf(input.MinGMSummaryFilter != null, e => e.GMSummary >= input.MinGMSummaryFilter)
                        .WhereIf(input.MaxGMSummaryFilter != null, e => e.GMSummary <= input.MaxGMSummaryFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.OB10NoFilter), e => e.OB10No == input.OB10NoFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.OldNameFilter), e => e.OldName == input.OldNameFilter)
                        .WhereIf(input.MinCustomerBillToFilter != null, e => e.CustomerBillTo >= input.MinCustomerBillToFilter)
                        .WhereIf(input.MaxCustomerBillToFilter != null, e => e.CustomerBillTo <= input.MaxCustomerBillToFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.ShipViaFilter), e => e.ShipVia == input.ShipViaFilter)
                        .WhereIf(input.MinNoAddMiscFilter != null, e => e.NoAddMisc >= input.MinNoAddMiscFilter)
                        .WhereIf(input.MaxNoAddMiscFilter != null, e => e.NoAddMisc <= input.MaxNoAddMiscFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.LaborDiscountFilter), e => e.LaborDiscount == input.LaborDiscountFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.TaxRateFilter), e => e.TaxRate == input.TaxRateFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.TMHUNoFilter), e => e.TMHUNo == input.TMHUNoFilter)
                        .WhereIf(input.MinLockTaxCodeFilter != null, e => e.LockTaxCode >= input.MinLockTaxCodeFilter)
                        .WhereIf(input.MaxLockTaxCodeFilter != null, e => e.LockTaxCode <= input.MaxLockTaxCodeFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.TaxCodeImportFilter), e => e.TaxCodeImport == input.TaxCodeImportFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.ShippingCommentsFilter), e => e.ShippingComments == input.ShippingCommentsFilter)
                        .WhereIf(input.MinNoShippingChargeFilter != null, e => e.NoShippingCharge >= input.MinNoShippingChargeFilter)
                        .WhereIf(input.MaxNoShippingChargeFilter != null, e => e.NoShippingCharge <= input.MaxNoShippingChargeFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.ShippingCompanyFilter), e => e.ShippingCompany == input.ShippingCompanyFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.ShippingAccountFilter), e => e.ShippingAccount == input.ShippingAccountFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.EMailInvoiceAddressFilter), e => e.EMailInvoiceAddress == input.EMailInvoiceAddressFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.EMailInvoiceAttentionFilter), e => e.EMailInvoiceAttention == input.EMailInvoiceAttentionFilter)
                        .WhereIf(input.MinEMailInvoiceFilter != null, e => e.EMailInvoice >= input.MinEMailInvoiceFilter)
                        .WhereIf(input.MaxEMailInvoiceFilter != null, e => e.EMailInvoice <= input.MaxEMailInvoiceFilter)
                        .WhereIf(input.MinNoPrintInvoiceFilter != null, e => e.NoPrintInvoice >= input.MinNoPrintInvoiceFilter)
                        .WhereIf(input.MaxNoPrintInvoiceFilter != null, e => e.NoPrintInvoice <= input.MaxNoPrintInvoiceFilter)
                        .WhereIf(input.MinBackupRequiredFilter != null, e => e.BackupRequired >= input.MinBackupRequiredFilter)
                        .WhereIf(input.MaxBackupRequiredFilter != null, e => e.BackupRequired <= input.MaxBackupRequiredFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.OldSalesman1Filter), e => e.OldSalesman1 == input.OldSalesman1Filter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.OldSalesman2Filter), e => e.OldSalesman2 == input.OldSalesman2Filter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.OldSalesman3Filter), e => e.OldSalesman3 == input.OldSalesman3Filter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.OldSalesman4Filter), e => e.OldSalesman4 == input.OldSalesman4Filter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.OldSalesman5Filter), e => e.OldSalesman5 == input.OldSalesman5Filter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.OldSalesman6Filter), e => e.OldSalesman6 == input.OldSalesman6Filter)
                        .WhereIf(input.MinLastAutoSalesmanUpdateFilter != null, e => e.LastAutoSalesmanUpdate >= input.MinLastAutoSalesmanUpdateFilter)
                        .WhereIf(input.MaxLastAutoSalesmanUpdateFilter != null, e => e.LastAutoSalesmanUpdate <= input.MaxLastAutoSalesmanUpdateFilter)
                        .WhereIf(input.MinLastAutoSalesmanUpdate1Filter != null, e => e.LastAutoSalesmanUpdate1 >= input.MinLastAutoSalesmanUpdate1Filter)
                        .WhereIf(input.MaxLastAutoSalesmanUpdate1Filter != null, e => e.LastAutoSalesmanUpdate1 <= input.MaxLastAutoSalesmanUpdate1Filter)
                        .WhereIf(input.MinLastAutoSalesmanUpdate2Filter != null, e => e.LastAutoSalesmanUpdate2 >= input.MinLastAutoSalesmanUpdate2Filter)
                        .WhereIf(input.MaxLastAutoSalesmanUpdate2Filter != null, e => e.LastAutoSalesmanUpdate2 <= input.MaxLastAutoSalesmanUpdate2Filter)
                        .WhereIf(input.MinLastAutoSalesmanUpdate3Filter != null, e => e.LastAutoSalesmanUpdate3 >= input.MinLastAutoSalesmanUpdate3Filter)
                        .WhereIf(input.MaxLastAutoSalesmanUpdate3Filter != null, e => e.LastAutoSalesmanUpdate3 <= input.MaxLastAutoSalesmanUpdate3Filter)
                        .WhereIf(input.MinLastAutoSalesmanUpdate4Filter != null, e => e.LastAutoSalesmanUpdate4 >= input.MinLastAutoSalesmanUpdate4Filter)
                        .WhereIf(input.MaxLastAutoSalesmanUpdate4Filter != null, e => e.LastAutoSalesmanUpdate4 <= input.MaxLastAutoSalesmanUpdate4Filter)
                        .WhereIf(input.MinLastAutoSalesmanUpdate5Filter != null, e => e.LastAutoSalesmanUpdate5 >= input.MinLastAutoSalesmanUpdate5Filter)
                        .WhereIf(input.MaxLastAutoSalesmanUpdate5Filter != null, e => e.LastAutoSalesmanUpdate5 <= input.MaxLastAutoSalesmanUpdate5Filter)
                        .WhereIf(input.MinLastAutoSalesmanUpdate6Filter != null, e => e.LastAutoSalesmanUpdate6 >= input.MinLastAutoSalesmanUpdate6Filter)
                        .WhereIf(input.MaxLastAutoSalesmanUpdate6Filter != null, e => e.LastAutoSalesmanUpdate6 <= input.MaxLastAutoSalesmanUpdate6Filter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.InvoiceLanguageFilter), e => e.InvoiceLanguage == input.InvoiceLanguageFilter)
                        .WhereIf(input.PeopleSoftFilter.HasValue && input.PeopleSoftFilter > -1, e => (input.PeopleSoftFilter == 1 && e.PeopleSoft) || (input.PeopleSoftFilter == 0 && !e.PeopleSoft))
                        .WhereIf(!string.IsNullOrWhiteSpace(input.PSCompanyFilter), e => e.PSCompany == input.PSCompanyFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.PSAccountFilter), e => e.PSAccount == input.PSAccountFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.PSLocationFilter), e => e.PSLocation == input.PSLocationFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.PSDeptFilter), e => e.PSDept == input.PSDeptFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.PSProductFilter), e => e.PSProduct == input.PSProductFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.AltCustomerNoFilter), e => e.AltCustomerNo == input.AltCustomerNoFilter)
                        .WhereIf(input.MinOverRideShipToFilter != null, e => e.OverRideShipTo >= input.MinOverRideShipToFilter)
                        .WhereIf(input.MaxOverRideShipToFilter != null, e => e.OverRideShipTo <= input.MaxOverRideShipToFilter)
                        .WhereIf(input.MinOnFileResaleFilter != null, e => e.OnFileResale >= input.MinOnFileResaleFilter)
                        .WhereIf(input.MaxOnFileResaleFilter != null, e => e.OnFileResale <= input.MaxOnFileResaleFilter)
                        .WhereIf(input.MinOnFileMFGPermitFilter != null, e => e.OnFileMFGPermit >= input.MinOnFileMFGPermitFilter)
                        .WhereIf(input.MaxOnFileMFGPermitFilter != null, e => e.OnFileMFGPermit <= input.MaxOnFileMFGPermitFilter)
                        .WhereIf(input.MinOnFileInsuranceFilter != null, e => e.OnFileInsurance >= input.MinOnFileInsuranceFilter)
                        .WhereIf(input.MaxOnFileInsuranceFilter != null, e => e.OnFileInsurance <= input.MaxOnFileInsuranceFilter)
                        .WhereIf(input.MinInactiveFilter != null, e => e.Inactive >= input.MinInactiveFilter)
                        .WhereIf(input.MaxInactiveFilter != null, e => e.Inactive <= input.MaxInactiveFilter)
                        .WhereIf(input.MinOverRideShipToRatesFilter != null, e => e.OverRideShipToRates >= input.MinOverRideShipToRatesFilter)
                        .WhereIf(input.MaxOverRideShipToRatesFilter != null, e => e.OverRideShipToRates <= input.MaxOverRideShipToRatesFilter)
                        .WhereIf(input.MinSuppressPartsListFilter != null, e => e.SuppressPartsList >= input.MinSuppressPartsListFilter)
                        .WhereIf(input.MaxSuppressPartsListFilter != null, e => e.SuppressPartsList <= input.MaxSuppressPartsListFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.MarketingSourceFilter), e => e.MarketingSource == input.MarketingSourceFilter)
                        .WhereIf(input.MinCreditCardLastTransIDFilter != null, e => e.CreditCardLastTransID >= input.MinCreditCardLastTransIDFilter)
                        .WhereIf(input.MaxCreditCardLastTransIDFilter != null, e => e.CreditCardLastTransID <= input.MaxCreditCardLastTransIDFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.EmailRoadServiceFilter), e => e.EmailRoadService == input.EmailRoadServiceFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.EmailShopServiceFilter), e => e.EmailShopService == input.EmailShopServiceFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.EmailPMServiceFilter), e => e.EmailPMService == input.EmailPMServiceFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.EmailRentalPMServiceFilter), e => e.EmailRentalPMService == input.EmailRentalPMServiceFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.EmailPartsCounterFilter), e => e.EmailPartsCounter == input.EmailPartsCounterFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.EmailEquipmentSalesFilter), e => e.EmailEquipmentSales == input.EmailEquipmentSalesFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.EmailRentalsFilter), e => e.EmailRentals == input.EmailRentalsFilter)
                        .WhereIf(input.MinIDFilter != null, e => e.Id >= input.MinIDFilter)
                        .WhereIf(input.MaxIDFilter != null, e => e.Id <= input.MaxIDFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.ARStatementsEmailAddressFilter), e => e.ARStatementsEmailAddress == input.ARStatementsEmailAddressFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.AccountTypeDescriptionFilter), e => e.AccountTypeFk != null && e.AccountTypeFk.Description == input.AccountTypeDescriptionFilter);

            var pagedAndFilteredCustomer = filteredCustomer
                .OrderBy(input.Sorting ?? "id asc")
                .PageBy(input);

            var customer = from o in pagedAndFilteredCustomer
                           join o1 in _lookup_accountTypeRepository.GetAll() on o.AccountTypeId equals o1.Id into j1
                           from s1 in j1.DefaultIfEmpty()

                           select new
                           {

                               o.Number,
                               o.BillTo,
                               o.Name,
                               o.SearchName,
                               o.SubName,
                               o.POBox,
                               o.Address,
                               o.City,
                               o.State,
                               o.ZipCode,
                               o.Country,
                               o.Salutation,
                               o.Phone,
                               o.Extention,
                               o.Phone2,
                               o.Cellular,
                               o.Beeper,
                               o.HomePhone,
                               o.Fax,
                               o.ResaleNo,
                               o.EMail,
                               o.WWWAddress,
                               o.ParentCompany,
                               o.MapLocation,
                               o.Salesman1,
                               o.Salesman2,
                               o.Salesman3,
                               o.Salesman4,
                               o.Salesman5,
                               o.Salesman6,
                               o.LockAPR1,
                               o.LockAPR2,
                               o.LockAPR3,
                               o.LockAPR4,
                               o.LockAPR5,
                               o.LockAPR6,
                               o.SalesGroup1,
                               o.SalesGroup2,
                               o.SalesGroup3,
                               o.SalesGroup4,
                               o.SalesGroup5,
                               o.SalesGroup6,
                               o.Terms,
                               o.FiscalEnd,
                               o.DunsCode,
                               o.SICCode,
                               o.MailingGroup,
                               o.Makes,
                               o.POReq,
                               o.PrevShip,
                               o.Taxable,
                               o.TaxCode,
                               o.LaborRate,
                               o.ShopLaborRate,
                               o.ShowLaborRate,
                               o.RentalRate,
                               o.ShowPartNoAlias,
                               o.PartsRate,
                               o.PartsRateDiscount,
                               o.Added,
                               o.AddedBy,
                               o.Changed,
                               o.ChangedBy,
                               o.SalesContact,
                               o.CSContact,
                               o.AccountingContact,
                               o.InternalCustomer,
                               o.EquipmentBid,
                               o.Comments,
                               o.ARComments,
                               o.CompanyComments,
                               o.CompanyCommentsDate,
                               o.CompanyCommentsBy,
                               o.BusinessCategory,
                               o.BusinessDescription,
                               o.SICCode2,
                               o.SICCode3,
                               o.SICCode4,
                               o.Shifts,
                               o.Category,
                               o.HoursOfOpStart,
                               o.HoursOfOpEnd,
                               o.DeliveryInfo,
                               o.CustomerTerritory,
                               o.CreditHoldFlag,
                               o.CreditRating1,
                               o.CreditRating2,
                               o.Statements,
                               o.CreditHoldDays,
                               o.FinanceCharge,
                               o.ResaleExpDate,
                               o.StateTaxCode,
                               o.CountyTaxCode,
                               o.CityTaxCode,
                               o.AbsoluteTaxCodes,
                               o.MFGPermitNo,
                               o.MFGPermitExpDate,
                               o.Branch,
                               o.ShowLaborHours,
                               o.VendorNo,
                               o.LocalTaxCode,
                               o.CurrencyType,
                               o.CreditCardNo,
                               o.CreditCardCVV,
                               o.CreditCardExpDate,
                               o.CreditCardType,
                               o.NameOnCreditCard,
                               o.RFC,
                               o.OldNumber,
                               o.SuppressPartsPricing,
                               o.ServiceCharge,
                               o.ServiceChargeDescription,
                               o.FinalCopies,
                               o.POBoxAndAddress,
                               o.InsuranceNo,
                               o.InsuranceNoDate,
                               o.InsuranceNoRecvDate,
                               o.CreditCardAddress,
                               o.CreditCardPOBox,
                               o.CreditCardCity,
                               o.CreditCardState,
                               o.CreditCardZipCode,
                               o.CreditCardCountry,
                               o.PMLaborRate,
                               o.ReferenceNo1,
                               o.ReferenceNo2,
                               o.GMSummary,
                               o.OB10No,
                               o.OldName,
                               o.CustomerBillTo,
                               o.ShipVia,
                               o.NoAddMisc,
                               o.LaborDiscount,
                               o.TaxRate,
                               o.TMHUNo,
                               o.LockTaxCode,
                               o.TaxCodeImport,
                               o.ShippingComments,
                               o.NoShippingCharge,
                               o.ShippingCompany,
                               o.ShippingAccount,
                               o.EMailInvoiceAddress,
                               o.EMailInvoiceAttention,
                               o.EMailInvoice,
                               o.NoPrintInvoice,
                               o.BackupRequired,
                               o.OldSalesman1,
                               o.OldSalesman2,
                               o.OldSalesman3,
                               o.OldSalesman4,
                               o.OldSalesman5,
                               o.OldSalesman6,
                               o.LastAutoSalesmanUpdate,
                               o.LastAutoSalesmanUpdate1,
                               o.LastAutoSalesmanUpdate2,
                               o.LastAutoSalesmanUpdate3,
                               o.LastAutoSalesmanUpdate4,
                               o.LastAutoSalesmanUpdate5,
                               o.LastAutoSalesmanUpdate6,
                               o.InvoiceLanguage,
                               o.PeopleSoft,
                               o.PSCompany,
                               o.PSAccount,
                               o.PSLocation,
                               o.PSDept,
                               o.PSProduct,
                               o.AltCustomerNo,
                               o.OverRideShipTo,
                               o.OnFileResale,
                               o.OnFileMFGPermit,
                               o.OnFileInsurance,
                               o.Inactive,
                               o.OverRideShipToRates,
                               o.SuppressPartsList,
                               o.MarketingSource,
                               o.CreditCardLastTransID,
                               o.EmailRoadService,
                               o.EmailShopService,
                               o.EmailPMService,
                               o.EmailRentalPMService,
                               o.EmailPartsCounter,
                               o.EmailEquipmentSales,
                               o.EmailRentals,
                               o.ARStatementsEmailAddress,
                               Id = o.Id,
                               AccountTypeDescription = s1 == null || s1.Description == null ? "" : s1.Description.ToString()
                           };

            var totalCount = await filteredCustomer.CountAsync();

            var dbList = await customer.ToListAsync();
            var results = new List<GetCustomerForViewDto>();

            foreach (var o in dbList)
            {
                var res = new GetCustomerForViewDto()
                {
                    Customer = new CustomerDto
                    {

                        Number = o.Number,
                        BillTo = o.BillTo,
                        Name = o.Name,
                        //SearchName = o.SearchName,
                        //SubName = o.SubName,
                        //POBox = o.POBox,
                        Address = o.Address,
                        //City = o.City,
                        //State = o.State,
                        //ZipCode = o.ZipCode,
                        //Country = o.Country,
                        //Salutation = o.Salutation,
                        Phone = o.Phone,
                        //Extention = o.Extention,
                        //Phone2 = o.Phone2,
                        //Cellular = o.Cellular,
                        //Beeper = o.Beeper,
                        //HomePhone = o.HomePhone,
                        //Fax = o.Fax,
                        //ResaleNo = o.ResaleNo,
                        //EMail = o.EMail,
                        //WWWAddress = o.WWWAddress,
                        //ParentCompany = o.ParentCompany,
                        //MapLocation = o.MapLocation,
                        //Salesman1 = o.Salesman1,
                        //Salesman2 = o.Salesman2,
                        //Salesman3 = o.Salesman3,
                        //Salesman4 = o.Salesman4,
                        //Salesman5 = o.Salesman5,
                        //Salesman6 = o.Salesman6,
                        //LockAPR1 = o.LockAPR1,
                        //LockAPR2 = o.LockAPR2,
                        //LockAPR3 = o.LockAPR3,
                        //LockAPR4 = o.LockAPR4,
                        //LockAPR5 = o.LockAPR5,
                        //LockAPR6 = o.LockAPR6,
                        //SalesGroup1 = o.SalesGroup1,
                        //SalesGroup2 = o.SalesGroup2,
                        //SalesGroup3 = o.SalesGroup3,
                        //SalesGroup4 = o.SalesGroup4,
                        //SalesGroup5 = o.SalesGroup5,
                        //SalesGroup6 = o.SalesGroup6,
                        //Terms = o.Terms,
                        //FiscalEnd = o.FiscalEnd,
                        //DunsCode = o.DunsCode,
                        //SICCode = o.SICCode,
                        //MailingGroup = o.MailingGroup,
                        //Makes = o.Makes,
                        //POReq = o.POReq,
                        //PrevShip = o.PrevShip,
                        //Taxable = o.Taxable,
                        //TaxCode = o.TaxCode,
                        //LaborRate = o.LaborRate,
                        //ShopLaborRate = o.ShopLaborRate,
                        //ShowLaborRate = o.ShowLaborRate,
                        //RentalRate = o.RentalRate,
                        //ShowPartNoAlias = o.ShowPartNoAlias,
                        //PartsRate = o.PartsRate,
                        //PartsRateDiscount = o.PartsRateDiscount,
                        //Added = o.Added,
                        //AddedBy = o.AddedBy,
                        //Changed = o.Changed,
                        //ChangedBy = o.ChangedBy,
                        //SalesContact = o.SalesContact,
                        //CSContact = o.CSContact,
                        //AccountingContact = o.AccountingContact,
                        //InternalCustomer = o.InternalCustomer,
                        //EquipmentBid = o.EquipmentBid,
                        //Comments = o.Comments,
                        //ARComments = o.ARComments,
                        //CompanyComments = o.CompanyComments,
                        //CompanyCommentsDate = o.CompanyCommentsDate,
                        //CompanyCommentsBy = o.CompanyCommentsBy,
                        //BusinessCategory = o.BusinessCategory,
                        //BusinessDescription = o.BusinessDescription,
                        //SICCode2 = o.SICCode2,
                        //SICCode3 = o.SICCode3,
                        //SICCode4 = o.SICCode4,
                        //Shifts = o.Shifts,
                        //Category = o.Category,
                        //HoursOfOpStart = o.HoursOfOpStart,
                        //HoursOfOpEnd = o.HoursOfOpEnd,
                        //DeliveryInfo = o.DeliveryInfo,
                        //CustomerTerritory = o.CustomerTerritory,
                        //CreditHoldFlag = o.CreditHoldFlag,
                        //CreditRating1 = o.CreditRating1,
                        //CreditRating2 = o.CreditRating2,
                        //Statements = o.Statements,
                        //CreditHoldDays = o.CreditHoldDays,
                        //FinanceCharge = o.FinanceCharge,
                        //ResaleExpDate = o.ResaleExpDate,
                        //StateTaxCode = o.StateTaxCode,
                        //CountyTaxCode = o.CountyTaxCode,
                        //CityTaxCode = o.CityTaxCode,
                        //AbsoluteTaxCodes = o.AbsoluteTaxCodes,
                        //MFGPermitNo = o.MFGPermitNo,
                        //MFGPermitExpDate = o.MFGPermitExpDate,
                        //Branch = o.Branch,
                        //ShowLaborHours = o.ShowLaborHours,
                        //VendorNo = o.VendorNo,
                        //LocalTaxCode = o.LocalTaxCode,
                        //CurrencyType = o.CurrencyType,
                        //CreditCardNo = o.CreditCardNo,
                        //CreditCardCVV = o.CreditCardCVV,
                        //CreditCardExpDate = o.CreditCardExpDate,
                        //CreditCardType = o.CreditCardType,
                        //NameOnCreditCard = o.NameOnCreditCard,
                        //RFC = o.RFC,
                        //OldNumber = o.OldNumber,
                        //SuppressPartsPricing = o.SuppressPartsPricing,
                        //ServiceCharge = o.ServiceCharge,
                        //ServiceChargeDescription = o.ServiceChargeDescription,
                        //FinalCopies = o.FinalCopies,
                        //POBoxAndAddress = o.POBoxAndAddress,
                        //InsuranceNo = o.InsuranceNo,
                        //InsuranceNoDate = o.InsuranceNoDate,
                        //InsuranceNoRecvDate = o.InsuranceNoRecvDate,
                        //CreditCardAddress = o.CreditCardAddress,
                        //CreditCardPOBox = o.CreditCardPOBox,
                        //CreditCardCity = o.CreditCardCity,
                        //CreditCardState = o.CreditCardState,
                        //CreditCardZipCode = o.CreditCardZipCode,
                        //CreditCardCountry = o.CreditCardCountry,
                        //PMLaborRate = o.PMLaborRate,
                        //ReferenceNo1 = o.ReferenceNo1,
                        //ReferenceNo2 = o.ReferenceNo2,
                        //GMSummary = o.GMSummary,
                        //OB10No = o.OB10No,
                        //OldName = o.OldName,
                        //CustomerBillTo = o.CustomerBillTo,
                        //ShipVia = o.ShipVia,
                        //NoAddMisc = o.NoAddMisc,
                        //LaborDiscount = o.LaborDiscount,
                        //TaxRate = o.TaxRate,
                        //TMHUNo = o.TMHUNo,
                        //LockTaxCode = o.LockTaxCode,
                        //TaxCodeImport = o.TaxCodeImport,
                        //ShippingComments = o.ShippingComments,
                        //NoShippingCharge = o.NoShippingCharge,
                        //ShippingCompany = o.ShippingCompany,
                        //ShippingAccount = o.ShippingAccount,
                        //EMailInvoiceAddress = o.EMailInvoiceAddress,
                        //EMailInvoiceAttention = o.EMailInvoiceAttention,
                        //EMailInvoice = o.EMailInvoice,
                        //NoPrintInvoice = o.NoPrintInvoice,
                        //BackupRequired = o.BackupRequired,
                        //OldSalesman1 = o.OldSalesman1,
                        //OldSalesman2 = o.OldSalesman2,
                        //OldSalesman3 = o.OldSalesman3,
                        //OldSalesman4 = o.OldSalesman4,
                        //OldSalesman5 = o.OldSalesman5,
                        //OldSalesman6 = o.OldSalesman6,
                        //LastAutoSalesmanUpdate = o.LastAutoSalesmanUpdate,
                        //LastAutoSalesmanUpdate1 = o.LastAutoSalesmanUpdate1,
                        //LastAutoSalesmanUpdate2 = o.LastAutoSalesmanUpdate2,
                        //LastAutoSalesmanUpdate3 = o.LastAutoSalesmanUpdate3,
                        //LastAutoSalesmanUpdate4 = o.LastAutoSalesmanUpdate4,
                        //LastAutoSalesmanUpdate5 = o.LastAutoSalesmanUpdate5,
                        //LastAutoSalesmanUpdate6 = o.LastAutoSalesmanUpdate6,
                        //InvoiceLanguage = o.InvoiceLanguage,
                        //PeopleSoft = o.PeopleSoft,
                        //PSCompany = o.PSCompany,
                        //PSAccount = o.PSAccount,
                        //PSLocation = o.PSLocation,
                        //PSDept = o.PSDept,
                        //PSProduct = o.PSProduct,
                        //AltCustomerNo = o.AltCustomerNo,
                        //OverRideShipTo = o.OverRideShipTo,
                        //OnFileResale = o.OnFileResale,
                        //OnFileMFGPermit = o.OnFileMFGPermit,
                        //OnFileInsurance = o.OnFileInsurance,
                        //Inactive = o.Inactive,
                        //OverRideShipToRates = o.OverRideShipToRates,
                        //SuppressPartsList = o.SuppressPartsList,
                        //MarketingSource = o.MarketingSource,
                        //CreditCardLastTransID = o.CreditCardLastTransID,
                        //EmailRoadService = o.EmailRoadService,
                        //EmailShopService = o.EmailShopService,
                        //EmailPMService = o.EmailPMService,
                        //EmailRentalPMService = o.EmailRentalPMService,
                        //EmailPartsCounter = o.EmailPartsCounter,
                        //EmailEquipmentSales = o.EmailEquipmentSales,
                        //EmailRentals = o.EmailRentals,
                        //ARStatementsEmailAddress = o.ARStatementsEmailAddress,
                        Id = o.Id,
                    },
                    AccountTypeDescription = o.AccountTypeDescription
                };

                results.Add(res);
            }

            return new PagedResultDto<GetCustomerForViewDto>(
                totalCount,
                results
            );

        }

        public async Task<GetCustomerForViewDto> GetCustomerForView(string customerNumber)
        {
            var customer = await _customerRepository.FirstOrDefaultAsync(x => x.Number.Equals(customerNumber));

            var output = new GetCustomerForViewDto { Customer = ObjectMapper.Map<CustomerDto>(customer) };

            //if (output.Customer.AccountTypeId != null)
            //{
            //    var _lookupAccountType = await _lookup_accountTypeRepository.FirstOrDefaultAsync((int)output.Customer.AccountTypeId);
            //    output.AccountTypeDescription = _lookupAccountType?.Description?.ToString();
            //}

            return output;
        }

        [AbpAuthorize(AppPermissions.Pages_Customer_Edit)]
        public async Task<GetCustomerForEditOutput> GetCustomerForEdit(GetCustomerForEditInput input)
        {
            var customer = await _customerRepository.FirstOrDefaultAsync(x => x.Number.Equals(input.CustomerNumber));

            var output = new GetCustomerForEditOutput { Customer = ObjectMapper.Map<CreateOrEditCustomerDto>(customer) };

            //if (output.Customer.AccountTypeId != null)
            //{
            //    var _lookupAccountType = await _lookup_accountTypeRepository.FirstOrDefaultAsync((int)output.Customer.AccountTypeId);
            //    output.AccountTypeDescription = _lookupAccountType?.Description?.ToString();
            //}

            return output;
        }

        public async Task CreateOrEdit(CreateOrEditCustomerDto input)
        {
            if (string.IsNullOrEmpty(input.Number))
            {
                await Create(input);
            }
            else
            {
                await Update(input);
            }
        }

        [AbpAuthorize(AppPermissions.Pages_Customer_Create)]
        protected virtual async Task Create(CreateOrEditCustomerDto input)
        {
            var customer = ObjectMapper.Map<Customer>(input);

            await _customerRepository.InsertAsync(customer);

        }

        [AbpAuthorize(AppPermissions.Pages_Customer_Edit)]
        protected virtual async Task Update(CreateOrEditCustomerDto input)
        {
            var customer = await _customerRepository.FirstOrDefaultAsync(x => x.Number.Equals(input.Number));
            ObjectMapper.Map(input, customer);

        }

        [AbpAuthorize(AppPermissions.Pages_Customer_Delete)]
        public async Task Delete(DeleteCustomerInput input)
        {
            var customer = await _customerRepository.FirstOrDefaultAsync(x => x.Number.Equals(input.CustomerNumber));
            await _customerRepository.DeleteAsync(customer);
        }

        public async Task<FileDto> GetCustomerToExcel(GetAllCustomerForExcelInput input)
        {

            var filteredCustomer = _customerRepository.GetAll()
                        .Include(e => e.AccountTypeFk)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.Filter), e => false || e.Number.Contains(input.Filter) || e.BillTo.Contains(input.Filter) || e.Name.Contains(input.Filter) || e.SearchName.Contains(input.Filter) || e.SubName.Contains(input.Filter) || e.POBox.Contains(input.Filter) || e.Address.Contains(input.Filter) || e.City.Contains(input.Filter) || e.State.Contains(input.Filter) || e.ZipCode.Contains(input.Filter) || e.Country.Contains(input.Filter) || e.Salutation.Contains(input.Filter) || e.Phone.Contains(input.Filter) || e.Extention.Contains(input.Filter) || e.Phone2.Contains(input.Filter) || e.Cellular.Contains(input.Filter) || e.Beeper.Contains(input.Filter) || e.HomePhone.Contains(input.Filter) || e.Fax.Contains(input.Filter) || e.ResaleNo.Contains(input.Filter) || e.EMail.Contains(input.Filter) || e.WWWAddress.Contains(input.Filter) || e.ParentCompany.Contains(input.Filter) || e.MapLocation.Contains(input.Filter) || e.Salesman1.Contains(input.Filter) || e.Salesman2.Contains(input.Filter) || e.Salesman3.Contains(input.Filter) || e.Salesman4.Contains(input.Filter) || e.Salesman5.Contains(input.Filter) || e.Salesman6.Contains(input.Filter) || e.Terms.Contains(input.Filter) || e.FiscalEnd.Contains(input.Filter) || e.DunsCode.Contains(input.Filter) || e.SICCode.Contains(input.Filter) || e.MailingGroup.Contains(input.Filter) || e.Makes.Contains(input.Filter) || e.TaxCode.Contains(input.Filter) || e.LaborRate.Contains(input.Filter) || e.ShopLaborRate.Contains(input.Filter) || e.RentalRate.Contains(input.Filter) || e.PartsRate.Contains(input.Filter) || e.AddedBy.Contains(input.Filter) || e.ChangedBy.Contains(input.Filter) || e.SalesContact.Contains(input.Filter) || e.CSContact.Contains(input.Filter) || e.AccountingContact.Contains(input.Filter) || e.Comments.Contains(input.Filter) || e.ARComments.Contains(input.Filter) || e.CompanyComments.Contains(input.Filter) || e.CompanyCommentsBy.Contains(input.Filter) || e.BusinessCategory.Contains(input.Filter) || e.BusinessDescription.Contains(input.Filter) || e.SICCode2.Contains(input.Filter) || e.SICCode3.Contains(input.Filter) || e.SICCode4.Contains(input.Filter) || e.Category.Contains(input.Filter) || e.DeliveryInfo.Contains(input.Filter) || e.CustomerTerritory.Contains(input.Filter) || e.CreditRating1.Contains(input.Filter) || e.CreditRating2.Contains(input.Filter) || e.StateTaxCode.Contains(input.Filter) || e.CountyTaxCode.Contains(input.Filter) || e.CityTaxCode.Contains(input.Filter) || e.MFGPermitNo.Contains(input.Filter) || e.VendorNo.Contains(input.Filter) || e.LocalTaxCode.Contains(input.Filter) || e.CurrencyType.Contains(input.Filter) || e.CreditCardNo.Contains(input.Filter) || e.CreditCardCVV.Contains(input.Filter) || e.CreditCardExpDate.Contains(input.Filter) || e.CreditCardType.Contains(input.Filter) || e.NameOnCreditCard.Contains(input.Filter) || e.RFC.Contains(input.Filter) || e.OldNumber.Contains(input.Filter) || e.ServiceChargeDescription.Contains(input.Filter) || e.InsuranceNo.Contains(input.Filter) || e.CreditCardAddress.Contains(input.Filter) || e.CreditCardPOBox.Contains(input.Filter) || e.CreditCardCity.Contains(input.Filter) || e.CreditCardState.Contains(input.Filter) || e.CreditCardZipCode.Contains(input.Filter) || e.CreditCardCountry.Contains(input.Filter) || e.PMLaborRate.Contains(input.Filter) || e.ReferenceNo1.Contains(input.Filter) || e.ReferenceNo2.Contains(input.Filter) || e.OB10No.Contains(input.Filter) || e.OldName.Contains(input.Filter) || e.ShipVia.Contains(input.Filter) || e.LaborDiscount.Contains(input.Filter) || e.TaxRate.Contains(input.Filter) || e.TMHUNo.Contains(input.Filter) || e.TaxCodeImport.Contains(input.Filter) || e.ShippingComments.Contains(input.Filter) || e.ShippingCompany.Contains(input.Filter) || e.ShippingAccount.Contains(input.Filter) || e.EMailInvoiceAddress.Contains(input.Filter) || e.EMailInvoiceAttention.Contains(input.Filter) || e.OldSalesman1.Contains(input.Filter) || e.OldSalesman2.Contains(input.Filter) || e.OldSalesman3.Contains(input.Filter) || e.OldSalesman4.Contains(input.Filter) || e.OldSalesman5.Contains(input.Filter) || e.OldSalesman6.Contains(input.Filter) || e.InvoiceLanguage.Contains(input.Filter) || e.PSCompany.Contains(input.Filter) || e.PSAccount.Contains(input.Filter) || e.PSLocation.Contains(input.Filter) || e.PSDept.Contains(input.Filter) || e.PSProduct.Contains(input.Filter) || e.AltCustomerNo.Contains(input.Filter) || e.MarketingSource.Contains(input.Filter) || e.EmailRoadService.Contains(input.Filter) || e.EmailShopService.Contains(input.Filter) || e.EmailPMService.Contains(input.Filter) || e.EmailRentalPMService.Contains(input.Filter) || e.EmailPartsCounter.Contains(input.Filter) || e.EmailEquipmentSales.Contains(input.Filter) || e.EmailRentals.Contains(input.Filter) || e.ARStatementsEmailAddress.Contains(input.Filter))
                        .WhereIf(!string.IsNullOrWhiteSpace(input.NumberFilter), e => e.Number == input.NumberFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.BillToFilter), e => e.BillTo == input.BillToFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.NameFilter), e => e.Name == input.NameFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.SearchNameFilter), e => e.SearchName == input.SearchNameFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.SubNameFilter), e => e.SubName == input.SubNameFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.POBoxFilter), e => e.POBox == input.POBoxFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.AddressFilter), e => e.Address == input.AddressFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.CityFilter), e => e.City == input.CityFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.StateFilter), e => e.State == input.StateFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.ZipCodeFilter), e => e.ZipCode == input.ZipCodeFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.CountryFilter), e => e.Country == input.CountryFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.SalutationFilter), e => e.Salutation == input.SalutationFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.PhoneFilter), e => e.Phone == input.PhoneFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.ExtentionFilter), e => e.Extention == input.ExtentionFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.Phone2Filter), e => e.Phone2 == input.Phone2Filter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.CellularFilter), e => e.Cellular == input.CellularFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.BeeperFilter), e => e.Beeper == input.BeeperFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.HomePhoneFilter), e => e.HomePhone == input.HomePhoneFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.FaxFilter), e => e.Fax == input.FaxFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.ResaleNoFilter), e => e.ResaleNo == input.ResaleNoFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.EMailFilter), e => e.EMail == input.EMailFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.WWWAddressFilter), e => e.WWWAddress == input.WWWAddressFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.ParentCompanyFilter), e => e.ParentCompany == input.ParentCompanyFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.MapLocationFilter), e => e.MapLocation == input.MapLocationFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.Salesman1Filter), e => e.Salesman1 == input.Salesman1Filter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.Salesman2Filter), e => e.Salesman2 == input.Salesman2Filter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.Salesman3Filter), e => e.Salesman3 == input.Salesman3Filter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.Salesman4Filter), e => e.Salesman4 == input.Salesman4Filter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.Salesman5Filter), e => e.Salesman5 == input.Salesman5Filter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.Salesman6Filter), e => e.Salesman6 == input.Salesman6Filter)
                        .WhereIf(input.MinLockAPR1Filter != null, e => e.LockAPR1 >= input.MinLockAPR1Filter)
                        .WhereIf(input.MaxLockAPR1Filter != null, e => e.LockAPR1 <= input.MaxLockAPR1Filter)
                        .WhereIf(input.MinLockAPR2Filter != null, e => e.LockAPR2 >= input.MinLockAPR2Filter)
                        .WhereIf(input.MaxLockAPR2Filter != null, e => e.LockAPR2 <= input.MaxLockAPR2Filter)
                        .WhereIf(input.MinLockAPR3Filter != null, e => e.LockAPR3 >= input.MinLockAPR3Filter)
                        .WhereIf(input.MaxLockAPR3Filter != null, e => e.LockAPR3 <= input.MaxLockAPR3Filter)
                        .WhereIf(input.MinLockAPR4Filter != null, e => e.LockAPR4 >= input.MinLockAPR4Filter)
                        .WhereIf(input.MaxLockAPR4Filter != null, e => e.LockAPR4 <= input.MaxLockAPR4Filter)
                        .WhereIf(input.MinLockAPR5Filter != null, e => e.LockAPR5 >= input.MinLockAPR5Filter)
                        .WhereIf(input.MaxLockAPR5Filter != null, e => e.LockAPR5 <= input.MaxLockAPR5Filter)
                        .WhereIf(input.MinLockAPR6Filter != null, e => e.LockAPR6 >= input.MinLockAPR6Filter)
                        .WhereIf(input.MaxLockAPR6Filter != null, e => e.LockAPR6 <= input.MaxLockAPR6Filter)
                        .WhereIf(input.MinSalesGroup1Filter != null, e => e.SalesGroup1 >= input.MinSalesGroup1Filter)
                        .WhereIf(input.MaxSalesGroup1Filter != null, e => e.SalesGroup1 <= input.MaxSalesGroup1Filter)
                        .WhereIf(input.MinSalesGroup2Filter != null, e => e.SalesGroup2 >= input.MinSalesGroup2Filter)
                        .WhereIf(input.MaxSalesGroup2Filter != null, e => e.SalesGroup2 <= input.MaxSalesGroup2Filter)
                        .WhereIf(input.MinSalesGroup3Filter != null, e => e.SalesGroup3 >= input.MinSalesGroup3Filter)
                        .WhereIf(input.MaxSalesGroup3Filter != null, e => e.SalesGroup3 <= input.MaxSalesGroup3Filter)
                        .WhereIf(input.MinSalesGroup4Filter != null, e => e.SalesGroup4 >= input.MinSalesGroup4Filter)
                        .WhereIf(input.MaxSalesGroup4Filter != null, e => e.SalesGroup4 <= input.MaxSalesGroup4Filter)
                        .WhereIf(input.MinSalesGroup5Filter != null, e => e.SalesGroup5 >= input.MinSalesGroup5Filter)
                        .WhereIf(input.MaxSalesGroup5Filter != null, e => e.SalesGroup5 <= input.MaxSalesGroup5Filter)
                        .WhereIf(input.MinSalesGroup6Filter != null, e => e.SalesGroup6 >= input.MinSalesGroup6Filter)
                        .WhereIf(input.MaxSalesGroup6Filter != null, e => e.SalesGroup6 <= input.MaxSalesGroup6Filter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.TermsFilter), e => e.Terms == input.TermsFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.FiscalEndFilter), e => e.FiscalEnd == input.FiscalEndFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.DunsCodeFilter), e => e.DunsCode == input.DunsCodeFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.SICCodeFilter), e => e.SICCode == input.SICCodeFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.MailingGroupFilter), e => e.MailingGroup == input.MailingGroupFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.MakesFilter), e => e.Makes == input.MakesFilter)
                        .WhereIf(input.MinPOReqFilter != null, e => e.POReq >= input.MinPOReqFilter)
                        .WhereIf(input.MaxPOReqFilter != null, e => e.POReq <= input.MaxPOReqFilter)
                        .WhereIf(input.MinPrevShipFilter != null, e => e.PrevShip >= input.MinPrevShipFilter)
                        .WhereIf(input.MaxPrevShipFilter != null, e => e.PrevShip <= input.MaxPrevShipFilter)
                        .WhereIf(input.MinTaxableFilter != null, e => e.Taxable >= input.MinTaxableFilter)
                        .WhereIf(input.MaxTaxableFilter != null, e => e.Taxable <= input.MaxTaxableFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.TaxCodeFilter), e => e.TaxCode == input.TaxCodeFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.LaborRateFilter), e => e.LaborRate == input.LaborRateFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.ShopLaborRateFilter), e => e.ShopLaborRate == input.ShopLaborRateFilter)
                        .WhereIf(input.MinShowLaborRateFilter != null, e => e.ShowLaborRate >= input.MinShowLaborRateFilter)
                        .WhereIf(input.MaxShowLaborRateFilter != null, e => e.ShowLaborRate <= input.MaxShowLaborRateFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.RentalRateFilter), e => e.RentalRate == input.RentalRateFilter)
                        .WhereIf(input.MinShowPartNoAliasFilter != null, e => e.ShowPartNoAlias >= input.MinShowPartNoAliasFilter)
                        .WhereIf(input.MaxShowPartNoAliasFilter != null, e => e.ShowPartNoAlias <= input.MaxShowPartNoAliasFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.PartsRateFilter), e => e.PartsRate == input.PartsRateFilter)
                        .WhereIf(input.MinPartsRateDiscountFilter != null, e => e.PartsRateDiscount >= input.MinPartsRateDiscountFilter)
                        .WhereIf(input.MaxPartsRateDiscountFilter != null, e => e.PartsRateDiscount <= input.MaxPartsRateDiscountFilter)
                        .WhereIf(input.MinAddedFilter != null, e => e.Added >= input.MinAddedFilter)
                        .WhereIf(input.MaxAddedFilter != null, e => e.Added <= input.MaxAddedFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.AddedByFilter), e => e.AddedBy == input.AddedByFilter)
                        .WhereIf(input.MinChangedFilter != null, e => e.Changed >= input.MinChangedFilter)
                        .WhereIf(input.MaxChangedFilter != null, e => e.Changed <= input.MaxChangedFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.ChangedByFilter), e => e.ChangedBy == input.ChangedByFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.SalesContactFilter), e => e.SalesContact == input.SalesContactFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.CSContactFilter), e => e.CSContact == input.CSContactFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.AccountingContactFilter), e => e.AccountingContact == input.AccountingContactFilter)
                        .WhereIf(input.MinInternalCustomerFilter != null, e => e.InternalCustomer >= input.MinInternalCustomerFilter)
                        .WhereIf(input.MaxInternalCustomerFilter != null, e => e.InternalCustomer <= input.MaxInternalCustomerFilter)
                        .WhereIf(input.MinEquipmentBidFilter != null, e => e.EquipmentBid >= input.MinEquipmentBidFilter)
                        .WhereIf(input.MaxEquipmentBidFilter != null, e => e.EquipmentBid <= input.MaxEquipmentBidFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.CommentsFilter), e => e.Comments == input.CommentsFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.ARCommentsFilter), e => e.ARComments == input.ARCommentsFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.CompanyCommentsFilter), e => e.CompanyComments == input.CompanyCommentsFilter)
                        .WhereIf(input.MinCompanyCommentsDateFilter != null, e => e.CompanyCommentsDate >= input.MinCompanyCommentsDateFilter)
                        .WhereIf(input.MaxCompanyCommentsDateFilter != null, e => e.CompanyCommentsDate <= input.MaxCompanyCommentsDateFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.CompanyCommentsByFilter), e => e.CompanyCommentsBy == input.CompanyCommentsByFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.BusinessCategoryFilter), e => e.BusinessCategory == input.BusinessCategoryFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.BusinessDescriptionFilter), e => e.BusinessDescription == input.BusinessDescriptionFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.SICCode2Filter), e => e.SICCode2 == input.SICCode2Filter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.SICCode3Filter), e => e.SICCode3 == input.SICCode3Filter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.SICCode4Filter), e => e.SICCode4 == input.SICCode4Filter)
                        .WhereIf(input.MinShiftsFilter != null, e => e.Shifts >= input.MinShiftsFilter)
                        .WhereIf(input.MaxShiftsFilter != null, e => e.Shifts <= input.MaxShiftsFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.CategoryFilter), e => e.Category == input.CategoryFilter)
                        .WhereIf(input.MinHoursOfOpStartFilter != null, e => e.HoursOfOpStart >= input.MinHoursOfOpStartFilter)
                        .WhereIf(input.MaxHoursOfOpStartFilter != null, e => e.HoursOfOpStart <= input.MaxHoursOfOpStartFilter)
                        .WhereIf(input.MinHoursOfOpEndFilter != null, e => e.HoursOfOpEnd >= input.MinHoursOfOpEndFilter)
                        .WhereIf(input.MaxHoursOfOpEndFilter != null, e => e.HoursOfOpEnd <= input.MaxHoursOfOpEndFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.DeliveryInfoFilter), e => e.DeliveryInfo == input.DeliveryInfoFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.CustomerTerritoryFilter), e => e.CustomerTerritory == input.CustomerTerritoryFilter)
                        .WhereIf(input.MinCreditHoldFlagFilter != null, e => e.CreditHoldFlag >= input.MinCreditHoldFlagFilter)
                        .WhereIf(input.MaxCreditHoldFlagFilter != null, e => e.CreditHoldFlag <= input.MaxCreditHoldFlagFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.CreditRating1Filter), e => e.CreditRating1 == input.CreditRating1Filter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.CreditRating2Filter), e => e.CreditRating2 == input.CreditRating2Filter)
                        .WhereIf(input.MinStatementsFilter != null, e => e.Statements >= input.MinStatementsFilter)
                        .WhereIf(input.MaxStatementsFilter != null, e => e.Statements <= input.MaxStatementsFilter)
                        .WhereIf(input.MinCreditHoldDaysFilter != null, e => e.CreditHoldDays >= input.MinCreditHoldDaysFilter)
                        .WhereIf(input.MaxCreditHoldDaysFilter != null, e => e.CreditHoldDays <= input.MaxCreditHoldDaysFilter)
                        .WhereIf(input.MinFinanceChargeFilter != null, e => e.FinanceCharge >= input.MinFinanceChargeFilter)
                        .WhereIf(input.MaxFinanceChargeFilter != null, e => e.FinanceCharge <= input.MaxFinanceChargeFilter)
                        .WhereIf(input.MinResaleExpDateFilter != null, e => e.ResaleExpDate >= input.MinResaleExpDateFilter)
                        .WhereIf(input.MaxResaleExpDateFilter != null, e => e.ResaleExpDate <= input.MaxResaleExpDateFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.StateTaxCodeFilter), e => e.StateTaxCode == input.StateTaxCodeFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.CountyTaxCodeFilter), e => e.CountyTaxCode == input.CountyTaxCodeFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.CityTaxCodeFilter), e => e.CityTaxCode == input.CityTaxCodeFilter)
                        .WhereIf(input.MinAbsoluteTaxCodesFilter != null, e => e.AbsoluteTaxCodes >= input.MinAbsoluteTaxCodesFilter)
                        .WhereIf(input.MaxAbsoluteTaxCodesFilter != null, e => e.AbsoluteTaxCodes <= input.MaxAbsoluteTaxCodesFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.MFGPermitNoFilter), e => e.MFGPermitNo == input.MFGPermitNoFilter)
                        .WhereIf(input.MinMFGPermitExpDateFilter != null, e => e.MFGPermitExpDate >= input.MinMFGPermitExpDateFilter)
                        .WhereIf(input.MaxMFGPermitExpDateFilter != null, e => e.MFGPermitExpDate <= input.MaxMFGPermitExpDateFilter)
                        .WhereIf(input.MinBranchFilter != null, e => e.Branch >= input.MinBranchFilter)
                        .WhereIf(input.MaxBranchFilter != null, e => e.Branch <= input.MaxBranchFilter)
                        .WhereIf(input.MinShowLaborHoursFilter != null, e => e.ShowLaborHours >= input.MinShowLaborHoursFilter)
                        .WhereIf(input.MaxShowLaborHoursFilter != null, e => e.ShowLaborHours <= input.MaxShowLaborHoursFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.VendorNoFilter), e => e.VendorNo == input.VendorNoFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.LocalTaxCodeFilter), e => e.LocalTaxCode == input.LocalTaxCodeFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.CurrencyTypeFilter), e => e.CurrencyType == input.CurrencyTypeFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.CreditCardNoFilter), e => e.CreditCardNo == input.CreditCardNoFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.CreditCardCVVFilter), e => e.CreditCardCVV == input.CreditCardCVVFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.CreditCardExpDateFilter), e => e.CreditCardExpDate == input.CreditCardExpDateFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.CreditCardTypeFilter), e => e.CreditCardType == input.CreditCardTypeFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.NameOnCreditCardFilter), e => e.NameOnCreditCard == input.NameOnCreditCardFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.RFCFilter), e => e.RFC == input.RFCFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.OldNumberFilter), e => e.OldNumber == input.OldNumberFilter)
                        .WhereIf(input.MinSuppressPartsPricingFilter != null, e => e.SuppressPartsPricing >= input.MinSuppressPartsPricingFilter)
                        .WhereIf(input.MaxSuppressPartsPricingFilter != null, e => e.SuppressPartsPricing <= input.MaxSuppressPartsPricingFilter)
                        .WhereIf(input.MinServiceChargeFilter != null, e => e.ServiceCharge >= input.MinServiceChargeFilter)
                        .WhereIf(input.MaxServiceChargeFilter != null, e => e.ServiceCharge <= input.MaxServiceChargeFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.ServiceChargeDescriptionFilter), e => e.ServiceChargeDescription == input.ServiceChargeDescriptionFilter)
                        .WhereIf(input.MinFinalCopiesFilter != null, e => e.FinalCopies >= input.MinFinalCopiesFilter)
                        .WhereIf(input.MaxFinalCopiesFilter != null, e => e.FinalCopies <= input.MaxFinalCopiesFilter)
                        .WhereIf(input.MinPOBoxAndAddressFilter != null, e => e.POBoxAndAddress >= input.MinPOBoxAndAddressFilter)
                        .WhereIf(input.MaxPOBoxAndAddressFilter != null, e => e.POBoxAndAddress <= input.MaxPOBoxAndAddressFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.InsuranceNoFilter), e => e.InsuranceNo == input.InsuranceNoFilter)
                        .WhereIf(input.MinInsuranceNoDateFilter != null, e => e.InsuranceNoDate >= input.MinInsuranceNoDateFilter)
                        .WhereIf(input.MaxInsuranceNoDateFilter != null, e => e.InsuranceNoDate <= input.MaxInsuranceNoDateFilter)
                        .WhereIf(input.MinInsuranceNoRecvDateFilter != null, e => e.InsuranceNoRecvDate >= input.MinInsuranceNoRecvDateFilter)
                        .WhereIf(input.MaxInsuranceNoRecvDateFilter != null, e => e.InsuranceNoRecvDate <= input.MaxInsuranceNoRecvDateFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.CreditCardAddressFilter), e => e.CreditCardAddress == input.CreditCardAddressFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.CreditCardPOBoxFilter), e => e.CreditCardPOBox == input.CreditCardPOBoxFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.CreditCardCityFilter), e => e.CreditCardCity == input.CreditCardCityFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.CreditCardStateFilter), e => e.CreditCardState == input.CreditCardStateFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.CreditCardZipCodeFilter), e => e.CreditCardZipCode == input.CreditCardZipCodeFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.CreditCardCountryFilter), e => e.CreditCardCountry == input.CreditCardCountryFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.PMLaborRateFilter), e => e.PMLaborRate == input.PMLaborRateFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.ReferenceNo1Filter), e => e.ReferenceNo1 == input.ReferenceNo1Filter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.ReferenceNo2Filter), e => e.ReferenceNo2 == input.ReferenceNo2Filter)
                        .WhereIf(input.MinGMSummaryFilter != null, e => e.GMSummary >= input.MinGMSummaryFilter)
                        .WhereIf(input.MaxGMSummaryFilter != null, e => e.GMSummary <= input.MaxGMSummaryFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.OB10NoFilter), e => e.OB10No == input.OB10NoFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.OldNameFilter), e => e.OldName == input.OldNameFilter)
                        .WhereIf(input.MinCustomerBillToFilter != null, e => e.CustomerBillTo >= input.MinCustomerBillToFilter)
                        .WhereIf(input.MaxCustomerBillToFilter != null, e => e.CustomerBillTo <= input.MaxCustomerBillToFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.ShipViaFilter), e => e.ShipVia == input.ShipViaFilter)
                        .WhereIf(input.MinNoAddMiscFilter != null, e => e.NoAddMisc >= input.MinNoAddMiscFilter)
                        .WhereIf(input.MaxNoAddMiscFilter != null, e => e.NoAddMisc <= input.MaxNoAddMiscFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.LaborDiscountFilter), e => e.LaborDiscount == input.LaborDiscountFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.TaxRateFilter), e => e.TaxRate == input.TaxRateFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.TMHUNoFilter), e => e.TMHUNo == input.TMHUNoFilter)
                        .WhereIf(input.MinLockTaxCodeFilter != null, e => e.LockTaxCode >= input.MinLockTaxCodeFilter)
                        .WhereIf(input.MaxLockTaxCodeFilter != null, e => e.LockTaxCode <= input.MaxLockTaxCodeFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.TaxCodeImportFilter), e => e.TaxCodeImport == input.TaxCodeImportFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.ShippingCommentsFilter), e => e.ShippingComments == input.ShippingCommentsFilter)
                        .WhereIf(input.MinNoShippingChargeFilter != null, e => e.NoShippingCharge >= input.MinNoShippingChargeFilter)
                        .WhereIf(input.MaxNoShippingChargeFilter != null, e => e.NoShippingCharge <= input.MaxNoShippingChargeFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.ShippingCompanyFilter), e => e.ShippingCompany == input.ShippingCompanyFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.ShippingAccountFilter), e => e.ShippingAccount == input.ShippingAccountFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.EMailInvoiceAddressFilter), e => e.EMailInvoiceAddress == input.EMailInvoiceAddressFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.EMailInvoiceAttentionFilter), e => e.EMailInvoiceAttention == input.EMailInvoiceAttentionFilter)
                        .WhereIf(input.MinEMailInvoiceFilter != null, e => e.EMailInvoice >= input.MinEMailInvoiceFilter)
                        .WhereIf(input.MaxEMailInvoiceFilter != null, e => e.EMailInvoice <= input.MaxEMailInvoiceFilter)
                        .WhereIf(input.MinNoPrintInvoiceFilter != null, e => e.NoPrintInvoice >= input.MinNoPrintInvoiceFilter)
                        .WhereIf(input.MaxNoPrintInvoiceFilter != null, e => e.NoPrintInvoice <= input.MaxNoPrintInvoiceFilter)
                        .WhereIf(input.MinBackupRequiredFilter != null, e => e.BackupRequired >= input.MinBackupRequiredFilter)
                        .WhereIf(input.MaxBackupRequiredFilter != null, e => e.BackupRequired <= input.MaxBackupRequiredFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.OldSalesman1Filter), e => e.OldSalesman1 == input.OldSalesman1Filter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.OldSalesman2Filter), e => e.OldSalesman2 == input.OldSalesman2Filter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.OldSalesman3Filter), e => e.OldSalesman3 == input.OldSalesman3Filter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.OldSalesman4Filter), e => e.OldSalesman4 == input.OldSalesman4Filter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.OldSalesman5Filter), e => e.OldSalesman5 == input.OldSalesman5Filter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.OldSalesman6Filter), e => e.OldSalesman6 == input.OldSalesman6Filter)
                        .WhereIf(input.MinLastAutoSalesmanUpdateFilter != null, e => e.LastAutoSalesmanUpdate >= input.MinLastAutoSalesmanUpdateFilter)
                        .WhereIf(input.MaxLastAutoSalesmanUpdateFilter != null, e => e.LastAutoSalesmanUpdate <= input.MaxLastAutoSalesmanUpdateFilter)
                        .WhereIf(input.MinLastAutoSalesmanUpdate1Filter != null, e => e.LastAutoSalesmanUpdate1 >= input.MinLastAutoSalesmanUpdate1Filter)
                        .WhereIf(input.MaxLastAutoSalesmanUpdate1Filter != null, e => e.LastAutoSalesmanUpdate1 <= input.MaxLastAutoSalesmanUpdate1Filter)
                        .WhereIf(input.MinLastAutoSalesmanUpdate2Filter != null, e => e.LastAutoSalesmanUpdate2 >= input.MinLastAutoSalesmanUpdate2Filter)
                        .WhereIf(input.MaxLastAutoSalesmanUpdate2Filter != null, e => e.LastAutoSalesmanUpdate2 <= input.MaxLastAutoSalesmanUpdate2Filter)
                        .WhereIf(input.MinLastAutoSalesmanUpdate3Filter != null, e => e.LastAutoSalesmanUpdate3 >= input.MinLastAutoSalesmanUpdate3Filter)
                        .WhereIf(input.MaxLastAutoSalesmanUpdate3Filter != null, e => e.LastAutoSalesmanUpdate3 <= input.MaxLastAutoSalesmanUpdate3Filter)
                        .WhereIf(input.MinLastAutoSalesmanUpdate4Filter != null, e => e.LastAutoSalesmanUpdate4 >= input.MinLastAutoSalesmanUpdate4Filter)
                        .WhereIf(input.MaxLastAutoSalesmanUpdate4Filter != null, e => e.LastAutoSalesmanUpdate4 <= input.MaxLastAutoSalesmanUpdate4Filter)
                        .WhereIf(input.MinLastAutoSalesmanUpdate5Filter != null, e => e.LastAutoSalesmanUpdate5 >= input.MinLastAutoSalesmanUpdate5Filter)
                        .WhereIf(input.MaxLastAutoSalesmanUpdate5Filter != null, e => e.LastAutoSalesmanUpdate5 <= input.MaxLastAutoSalesmanUpdate5Filter)
                        .WhereIf(input.MinLastAutoSalesmanUpdate6Filter != null, e => e.LastAutoSalesmanUpdate6 >= input.MinLastAutoSalesmanUpdate6Filter)
                        .WhereIf(input.MaxLastAutoSalesmanUpdate6Filter != null, e => e.LastAutoSalesmanUpdate6 <= input.MaxLastAutoSalesmanUpdate6Filter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.InvoiceLanguageFilter), e => e.InvoiceLanguage == input.InvoiceLanguageFilter)
                        .WhereIf(input.PeopleSoftFilter.HasValue && input.PeopleSoftFilter > -1, e => (input.PeopleSoftFilter == 1 && e.PeopleSoft) || (input.PeopleSoftFilter == 0 && !e.PeopleSoft))
                        .WhereIf(!string.IsNullOrWhiteSpace(input.PSCompanyFilter), e => e.PSCompany == input.PSCompanyFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.PSAccountFilter), e => e.PSAccount == input.PSAccountFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.PSLocationFilter), e => e.PSLocation == input.PSLocationFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.PSDeptFilter), e => e.PSDept == input.PSDeptFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.PSProductFilter), e => e.PSProduct == input.PSProductFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.AltCustomerNoFilter), e => e.AltCustomerNo == input.AltCustomerNoFilter)
                        .WhereIf(input.MinOverRideShipToFilter != null, e => e.OverRideShipTo >= input.MinOverRideShipToFilter)
                        .WhereIf(input.MaxOverRideShipToFilter != null, e => e.OverRideShipTo <= input.MaxOverRideShipToFilter)
                        .WhereIf(input.MinOnFileResaleFilter != null, e => e.OnFileResale >= input.MinOnFileResaleFilter)
                        .WhereIf(input.MaxOnFileResaleFilter != null, e => e.OnFileResale <= input.MaxOnFileResaleFilter)
                        .WhereIf(input.MinOnFileMFGPermitFilter != null, e => e.OnFileMFGPermit >= input.MinOnFileMFGPermitFilter)
                        .WhereIf(input.MaxOnFileMFGPermitFilter != null, e => e.OnFileMFGPermit <= input.MaxOnFileMFGPermitFilter)
                        .WhereIf(input.MinOnFileInsuranceFilter != null, e => e.OnFileInsurance >= input.MinOnFileInsuranceFilter)
                        .WhereIf(input.MaxOnFileInsuranceFilter != null, e => e.OnFileInsurance <= input.MaxOnFileInsuranceFilter)
                        .WhereIf(input.MinInactiveFilter != null, e => e.Inactive >= input.MinInactiveFilter)
                        .WhereIf(input.MaxInactiveFilter != null, e => e.Inactive <= input.MaxInactiveFilter)
                        .WhereIf(input.MinOverRideShipToRatesFilter != null, e => e.OverRideShipToRates >= input.MinOverRideShipToRatesFilter)
                        .WhereIf(input.MaxOverRideShipToRatesFilter != null, e => e.OverRideShipToRates <= input.MaxOverRideShipToRatesFilter)
                        .WhereIf(input.MinSuppressPartsListFilter != null, e => e.SuppressPartsList >= input.MinSuppressPartsListFilter)
                        .WhereIf(input.MaxSuppressPartsListFilter != null, e => e.SuppressPartsList <= input.MaxSuppressPartsListFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.MarketingSourceFilter), e => e.MarketingSource == input.MarketingSourceFilter)
                        .WhereIf(input.MinCreditCardLastTransIDFilter != null, e => e.CreditCardLastTransID >= input.MinCreditCardLastTransIDFilter)
                        .WhereIf(input.MaxCreditCardLastTransIDFilter != null, e => e.CreditCardLastTransID <= input.MaxCreditCardLastTransIDFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.EmailRoadServiceFilter), e => e.EmailRoadService == input.EmailRoadServiceFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.EmailShopServiceFilter), e => e.EmailShopService == input.EmailShopServiceFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.EmailPMServiceFilter), e => e.EmailPMService == input.EmailPMServiceFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.EmailRentalPMServiceFilter), e => e.EmailRentalPMService == input.EmailRentalPMServiceFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.EmailPartsCounterFilter), e => e.EmailPartsCounter == input.EmailPartsCounterFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.EmailEquipmentSalesFilter), e => e.EmailEquipmentSales == input.EmailEquipmentSalesFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.EmailRentalsFilter), e => e.EmailRentals == input.EmailRentalsFilter)
                        .WhereIf(input.MinIDFilter != null, e => e.Id >= input.MinIDFilter)
                        .WhereIf(input.MaxIDFilter != null, e => e.Id <= input.MaxIDFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.ARStatementsEmailAddressFilter), e => e.ARStatementsEmailAddress == input.ARStatementsEmailAddressFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.AccountTypeDescriptionFilter), e => e.AccountTypeFk != null && e.AccountTypeFk.Description == input.AccountTypeDescriptionFilter);

            var query = (from o in filteredCustomer
                         join o1 in _lookup_accountTypeRepository.GetAll() on o.AccountTypeId equals o1.Id into j1
                         from s1 in j1.DefaultIfEmpty()

                         select new GetCustomerForViewDto()
                         {
                             Customer = new CustomerDto
                             {
                                 Number = o.Number,
                                 BillTo = o.BillTo,
                                 Name = o.Name,
                                 //SearchName = o.SearchName,
                                 //SubName = o.SubName,
                                 //POBox = o.POBox,
                                 Address = o.Address,
                                 //City = o.City,
                                 //State = o.State,
                                 //ZipCode = o.ZipCode,
                                 //Country = o.Country,
                                 //Salutation = o.Salutation,
                                 Phone = o.Phone,
                                 //Extention = o.Extention,
                                 //Phone2 = o.Phone2,
                                 //Cellular = o.Cellular,
                                 //Beeper = o.Beeper,
                                 //HomePhone = o.HomePhone,
                                 //Fax = o.Fax,
                                 //ResaleNo = o.ResaleNo,
                                 //EMail = o.EMail,
                                 //WWWAddress = o.WWWAddress,
                                 //ParentCompany = o.ParentCompany,
                                 //MapLocation = o.MapLocation,
                                 //Salesman1 = o.Salesman1,
                                 //Salesman2 = o.Salesman2,
                                 //Salesman3 = o.Salesman3,
                                 //Salesman4 = o.Salesman4,
                                 //Salesman5 = o.Salesman5,
                                 //Salesman6 = o.Salesman6,
                                 //LockAPR1 = o.LockAPR1,
                                 //LockAPR2 = o.LockAPR2,
                                 //LockAPR3 = o.LockAPR3,
                                 //LockAPR4 = o.LockAPR4,
                                 //LockAPR5 = o.LockAPR5,
                                 //LockAPR6 = o.LockAPR6,
                                 //SalesGroup1 = o.SalesGroup1,
                                 //SalesGroup2 = o.SalesGroup2,
                                 //SalesGroup3 = o.SalesGroup3,
                                 //SalesGroup4 = o.SalesGroup4,
                                 //SalesGroup5 = o.SalesGroup5,
                                 //SalesGroup6 = o.SalesGroup6,
                                 //Terms = o.Terms,
                                 //FiscalEnd = o.FiscalEnd,
                                 //DunsCode = o.DunsCode,
                                 //SICCode = o.SICCode,
                                 //MailingGroup = o.MailingGroup,
                                 //Makes = o.Makes,
                                 //POReq = o.POReq,
                                 //PrevShip = o.PrevShip,
                                 //Taxable = o.Taxable,
                                 //TaxCode = o.TaxCode,
                                 //LaborRate = o.LaborRate,
                                 //ShopLaborRate = o.ShopLaborRate,
                                 //ShowLaborRate = o.ShowLaborRate,
                                 //RentalRate = o.RentalRate,
                                 //ShowPartNoAlias = o.ShowPartNoAlias,
                                 //PartsRate = o.PartsRate,
                                 //PartsRateDiscount = o.PartsRateDiscount,
                                 //Added = o.Added,
                                 //AddedBy = o.AddedBy,
                                 //Changed = o.Changed,
                                 //ChangedBy = o.ChangedBy,
                                 //SalesContact = o.SalesContact,
                                 //CSContact = o.CSContact,
                                 //AccountingContact = o.AccountingContact,
                                 //InternalCustomer = o.InternalCustomer,
                                 //EquipmentBid = o.EquipmentBid,
                                 //Comments = o.Comments,
                                 //ARComments = o.ARComments,
                                 //CompanyComments = o.CompanyComments,
                                 //CompanyCommentsDate = o.CompanyCommentsDate,
                                 //CompanyCommentsBy = o.CompanyCommentsBy,
                                 //BusinessCategory = o.BusinessCategory,
                                 //BusinessDescription = o.BusinessDescription,
                                 //SICCode2 = o.SICCode2,
                                 //SICCode3 = o.SICCode3,
                                 //SICCode4 = o.SICCode4,
                                 //Shifts = o.Shifts,
                                 //Category = o.Category,
                                 //HoursOfOpStart = o.HoursOfOpStart,
                                 //HoursOfOpEnd = o.HoursOfOpEnd,
                                 //DeliveryInfo = o.DeliveryInfo,
                                 //CustomerTerritory = o.CustomerTerritory,
                                 //CreditHoldFlag = o.CreditHoldFlag,
                                 //CreditRating1 = o.CreditRating1,
                                 //CreditRating2 = o.CreditRating2,
                                 //Statements = o.Statements,
                                 //CreditHoldDays = o.CreditHoldDays,
                                 //FinanceCharge = o.FinanceCharge,
                                 //ResaleExpDate = o.ResaleExpDate,
                                 //StateTaxCode = o.StateTaxCode,
                                 //CountyTaxCode = o.CountyTaxCode,
                                 //CityTaxCode = o.CityTaxCode,
                                 //AbsoluteTaxCodes = o.AbsoluteTaxCodes,
                                 //MFGPermitNo = o.MFGPermitNo,
                                 //MFGPermitExpDate = o.MFGPermitExpDate,
                                 //Branch = o.Branch,
                                 //ShowLaborHours = o.ShowLaborHours,
                                 //VendorNo = o.VendorNo,
                                 //LocalTaxCode = o.LocalTaxCode,
                                 //CurrencyType = o.CurrencyType,
                                 //CreditCardNo = o.CreditCardNo,
                                 //CreditCardCVV = o.CreditCardCVV,
                                 //CreditCardExpDate = o.CreditCardExpDate,
                                 //CreditCardType = o.CreditCardType,
                                 //NameOnCreditCard = o.NameOnCreditCard,
                                 //RFC = o.RFC,
                                 //OldNumber = o.OldNumber,
                                 //SuppressPartsPricing = o.SuppressPartsPricing,
                                 //ServiceCharge = o.ServiceCharge,
                                 //ServiceChargeDescription = o.ServiceChargeDescription,
                                 //FinalCopies = o.FinalCopies,
                                 //POBoxAndAddress = o.POBoxAndAddress,
                                 //InsuranceNo = o.InsuranceNo,
                                 //InsuranceNoDate = o.InsuranceNoDate,
                                 //InsuranceNoRecvDate = o.InsuranceNoRecvDate,
                                 //CreditCardAddress = o.CreditCardAddress,
                                 //CreditCardPOBox = o.CreditCardPOBox,
                                 //CreditCardCity = o.CreditCardCity,
                                 //CreditCardState = o.CreditCardState,
                                 //CreditCardZipCode = o.CreditCardZipCode,
                                 //CreditCardCountry = o.CreditCardCountry,
                                 //PMLaborRate = o.PMLaborRate,
                                 //ReferenceNo1 = o.ReferenceNo1,
                                 //ReferenceNo2 = o.ReferenceNo2,
                                 //GMSummary = o.GMSummary,
                                 //OB10No = o.OB10No,
                                 //OldName = o.OldName,
                                 //CustomerBillTo = o.CustomerBillTo,
                                 //ShipVia = o.ShipVia,
                                 //NoAddMisc = o.NoAddMisc,
                                 //LaborDiscount = o.LaborDiscount,
                                 //TaxRate = o.TaxRate,
                                 //TMHUNo = o.TMHUNo,
                                 //LockTaxCode = o.LockTaxCode,
                                 //TaxCodeImport = o.TaxCodeImport,
                                 //ShippingComments = o.ShippingComments,
                                 //NoShippingCharge = o.NoShippingCharge,
                                 //ShippingCompany = o.ShippingCompany,
                                 //ShippingAccount = o.ShippingAccount,
                                 //EMailInvoiceAddress = o.EMailInvoiceAddress,
                                 //EMailInvoiceAttention = o.EMailInvoiceAttention,
                                 //EMailInvoice = o.EMailInvoice,
                                 //NoPrintInvoice = o.NoPrintInvoice,
                                 //BackupRequired = o.BackupRequired,
                                 //OldSalesman1 = o.OldSalesman1,
                                 //OldSalesman2 = o.OldSalesman2,
                                 //OldSalesman3 = o.OldSalesman3,
                                 //OldSalesman4 = o.OldSalesman4,
                                 //OldSalesman5 = o.OldSalesman5,
                                 //OldSalesman6 = o.OldSalesman6,
                                 //LastAutoSalesmanUpdate = o.LastAutoSalesmanUpdate,
                                 //LastAutoSalesmanUpdate1 = o.LastAutoSalesmanUpdate1,
                                 //LastAutoSalesmanUpdate2 = o.LastAutoSalesmanUpdate2,
                                 //LastAutoSalesmanUpdate3 = o.LastAutoSalesmanUpdate3,
                                 //LastAutoSalesmanUpdate4 = o.LastAutoSalesmanUpdate4,
                                 //LastAutoSalesmanUpdate5 = o.LastAutoSalesmanUpdate5,
                                 //LastAutoSalesmanUpdate6 = o.LastAutoSalesmanUpdate6,
                                 //InvoiceLanguage = o.InvoiceLanguage,
                                 //PeopleSoft = o.PeopleSoft,
                                 //PSCompany = o.PSCompany,
                                 //PSAccount = o.PSAccount,
                                 //PSLocation = o.PSLocation,
                                 //PSDept = o.PSDept,
                                 //PSProduct = o.PSProduct,
                                 //AltCustomerNo = o.AltCustomerNo,
                                 //OverRideShipTo = o.OverRideShipTo,
                                 //OnFileResale = o.OnFileResale,
                                 //OnFileMFGPermit = o.OnFileMFGPermit,
                                 //OnFileInsurance = o.OnFileInsurance,
                                 //Inactive = o.Inactive,
                                 //OverRideShipToRates = o.OverRideShipToRates,
                                 //SuppressPartsList = o.SuppressPartsList,
                                 //MarketingSource = o.MarketingSource,
                                 //CreditCardLastTransID = o.CreditCardLastTransID,
                                 //EmailRoadService = o.EmailRoadService,
                                 //EmailShopService = o.EmailShopService,
                                 //EmailPMService = o.EmailPMService,
                                 //EmailRentalPMService = o.EmailRentalPMService,
                                 //EmailPartsCounter = o.EmailPartsCounter,
                                 //EmailEquipmentSales = o.EmailEquipmentSales,
                                 //EmailRentals = o.EmailRentals,
                                 ID = o.Id,
                                 //ARStatementsEmailAddress = o.ARStatementsEmailAddress,
                                 Id = o.Id
                             },
                             AccountTypeDescription = s1 == null || s1.Description == null ? "" : s1.Description.ToString()
                         });

            var customerListDtos = await query.ToListAsync();

            return _customerExcelExporter.ExportToFile(customerListDtos);
        }

        [AbpAuthorize(AppPermissions.Pages_Customer)]
        public async Task<List<CustomerAccountTypeLookupTableDto>> GetAllAccountTypeForTableDropdown()
        {
            return await _lookup_accountTypeRepository.GetAll()
                .Select(accountType => new CustomerAccountTypeLookupTableDto
                {
                    Id = accountType.Id,
                    DisplayName = accountType == null || accountType.Description == null ? "" : accountType.Description.ToString()
                }).ToListAsync();
        }

    }
}