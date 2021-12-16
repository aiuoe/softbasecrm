namespace SBCRM.Legacy
{
    /// <summary>
    /// DTO to manage the customer invoice result
    /// </summary>
    public class CustomerInvoiceViewDto
    {
        public int? InvoiceNumber { get; set; }
        public string PoNumber { get; set; }
        public string UnitNo { get; set; }
        public int? AssociatedWONo { get; set; }
        public int? RentalContractNo { get; set; }
        public decimal? GrandTotal { get; set; }
        public string Serial { get; set; }
        public short? CustomerFlag { get; set; }
    }
}
