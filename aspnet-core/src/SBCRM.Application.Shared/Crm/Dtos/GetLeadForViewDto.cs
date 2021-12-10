namespace SBCRM.Crm.Dtos
{
    public class GetLeadForViewDto
    {
        public LeadDto Lead { get; set; }

        public string LeadSourceDescription { get; set; }

        public string LeadStatusDescription { get; set; }

        public string LeadStatusColor{ get; set; }

        public string PriorityDescription { get; set; }
        public object City { get; set; }
    }
}