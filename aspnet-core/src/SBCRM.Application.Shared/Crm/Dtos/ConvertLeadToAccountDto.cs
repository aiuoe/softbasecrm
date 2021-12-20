namespace SBCRM.Crm.Dtos
{
    public class ConvertLeadToAccountDto
    {
        public LeadDto Lead { get; set; }

        public int ConversionAccountTypeId { get; set; }

        public ConvertLeadToAccountDto(LeadDto lead, int conversionAccountTypeId)
        {
            Lead = lead;
            ConversionAccountTypeId = conversionAccountTypeId;
        }
    }
}