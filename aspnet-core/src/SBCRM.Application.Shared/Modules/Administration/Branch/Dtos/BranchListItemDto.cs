using System;

namespace SBCRM.Modules.Administration.Branch.Dtos
{
    /// <summary>
    /// DTO for branch list item
    /// </summary>
    public class BranchListItemDto
    {
        public long Id { get; set; }
        public short Number { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Receivable { get; set; }
        public string DefaultWarehouse { get; set; }
        public string CurrencyType { get; set; }
        public DateTime CreationTime { get; set; }
    }
}
