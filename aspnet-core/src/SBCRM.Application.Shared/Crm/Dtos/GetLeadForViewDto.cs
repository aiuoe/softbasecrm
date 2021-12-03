namespace SBCRM.Crm.Dtos
{
    public class GetLeadForViewDto
    {
        public LeadDto Lead { get; set; }

        public string IndustryDescription { get; set; }

        public string LeadSourceDescription { get; set; }

        public string LeadStatusDescription { get; set; }

    }
}