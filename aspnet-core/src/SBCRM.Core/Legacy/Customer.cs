using SBCRM.Crm;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SBCRM.Legacy
{
    /// <summary>
    /// Customer(Account) entity
    /// </summary>
    [Table("Customer", Schema = "dbo")]
    public class Customer
    {
        [Key]
        [Required]
        [StringLength(CustomerConsts.MaxNumberLength, MinimumLength = CustomerConsts.MinNumberLength)]
        public virtual string Number { get; set; }

        [StringLength(CustomerConsts.MaxBillToLength, MinimumLength = CustomerConsts.MinBillToLength)]
        public virtual string BillTo { get; set; }

        [StringLength(CustomerConsts.MaxNameLength, MinimumLength = CustomerConsts.MinNameLength)]
        public virtual string Name { get; set; }

        [StringLength(CustomerConsts.MaxPhoneLength, MinimumLength = CustomerConsts.MinPhoneLength)]
        public virtual string Phone { get; set; }

        [StringLength(CustomerConsts.MaxEMailLength, MinimumLength = CustomerConsts.MinEMailLength)]
        public virtual string EMail { get; set; }

        [StringLength(CustomerConsts.MaxWWWAddressLength, MinimumLength = CustomerConsts.MinWWWAddressLength)]
        public virtual string WWWAddress { get; set; }

        [StringLength(CustomerConsts.MaxAddressLength, MinimumLength = CustomerConsts.MinAddressLength)]
        public virtual string Address { get; set; }

        [StringLength(CustomerConsts.MaxPOBoxLength, MinimumLength = CustomerConsts.MinPOBoxLength)]
        public virtual string POBox { get; set; }

        [StringLength(CustomerConsts.MaxCountryLength, MinimumLength = CustomerConsts.MinCountryLength)]
        public virtual string Country { get; set; }

        [StringLength(CustomerConsts.MaxStateLength, MinimumLength = CustomerConsts.MinStateLength)]
        public virtual string State { get; set; }

        [StringLength(CustomerConsts.MaxCityLength, MinimumLength = CustomerConsts.MinCityLength)]
        public virtual string City { get; set; }

        [StringLength(CustomerConsts.MaxZipCodeLength, MinimumLength = CustomerConsts.MinZipCodeLength)]
        public virtual string ZipCode { get; set; }

        public virtual int? AccountTypeId { get; set; }

        [ForeignKey("AccountTypeId")]
        public AccountType AccountTypeFk { get; set; }

        public virtual int? LeadSourceId { get; set; }

        [ForeignKey("LeadSourceId")]
        public LeadSource LeadSourceDk { get; set; }



        [StringLength(CustomerConsts.MaxDunsCodeLength, MinimumLength = CustomerConsts.MinDunsCodeLength)]
        public virtual string DunsCode { get; set; }

        [StringLength(CustomerConsts.MaxSICCodeLength, MinimumLength = CustomerConsts.MinSICCodeLength)]
        public virtual string SICCode { get; set; }

        [StringLength(CustomerConsts.MaxSICCode2Length, MinimumLength = CustomerConsts.MinSICCode2Length)]
        public virtual string SICCode2 { get; set; }

        [StringLength(CustomerConsts.MaxSICCode3Length, MinimumLength = CustomerConsts.MinSICCode3Length)]
        public virtual string SICCode3 { get; set; }

        [StringLength(CustomerConsts.MaxSICCode4Length, MinimumLength = CustomerConsts.MinSICCode4Length)]
        public virtual string SICCode4 { get; set; }

        public virtual string BusinessDescription { get; set; }

        public virtual bool IsCreatedFromWebCrm { get; set; }


        public virtual DateTime? Added { get; set; }

        [StringLength(CustomerConsts.MaxAddedByLength, MinimumLength = CustomerConsts.MinAddedByLength)]
        public virtual string AddedBy { get; set; }

        public virtual DateTime? Changed { get; set; }

        [StringLength(CustomerConsts.MaxChangedByLength, MinimumLength = CustomerConsts.MinChangedByLength)]
        public virtual string ChangedBy { get; set; }
    }
}