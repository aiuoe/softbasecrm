using System;

namespace SBCRM.Legacy
{
    /// <summary>
    /// DTO to manage the customer wip result
    /// </summary>
    public class CustomerWipViewDto
    {
        public int? DocumentNumber { get; set; }
        public string PoNumber { get; set; }
        public string Serial { get; set; }
        public string UnitNo { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public string Salesman { get; set; }

        public int? AssociatedWONo { get; set; }
        public int? RentalContractNo { get; set; }
        public DateTime? Opened { get; set; }
        public short? CustomerFlag { get; set; }
        public short? Disposition { get; set; }
        public string BillTo { get; set; }
    }
}
