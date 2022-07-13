using System;
using System.Collections.Generic;
using System.Text;

namespace SBCRM.Modules.Common.SalesTaxIntegration.Dto
{
    public class SalesTaxIntegrationDto
    {
        public long Id { get; set; }
        public int TenantId { get; set; }
        public int? LegacyId { get; set; }
        public string SalesTaxProvider { get; set; }
        public string AccountNumber { get; set; }
        public string LicenseKey { get; set; }
        public string ServiceUrl { get; set; }
        public string CompanyCode { get; set; }
        public int RequestTimeout { get; set; }
        public bool? DisableAddressVerification { get; set; }
        public bool? DisableDocumentRecording { get; set; }
        public bool? EnableLogging { get; set; }
        public bool? EnableAvataxUpc { get; set; }
        public string DefaultTaxCodesParts { get; set; }
        public string DefaultTaxCodesPartsDesc { get; set; }
        public string DefaultTaxCodesLabor { get; set; }
        public string DefaultTaxCodesLaborDesc { get; set; }
        public string DefaultTaxCodesMisc { get; set; }
        public string DefaultTaxCodesMiscDesc { get; set; }
        public string DefaultTaxCodesRental { get; set; }
        public string DefaultTaxCodesRentalDesc { get; set; }
        public string DefaultTaxCodesEquip { get; set; }
        public string DefaultTaxCodesEquipDesc { get; set; }
    }
}
