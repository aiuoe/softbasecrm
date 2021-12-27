using System;

namespace SBCRM.Crm.Dtos
{
    /// <summary>
    /// DTO to manage the object customer opportunity for view purposes
    /// </summary>
    public class CustomerOpportunityViewDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Stage { get; set; }
        public string StageColor { get; set; }
        public DateTime? CloseDate { get; set; }
        public decimal? Amount { get; set; }
    }
}
