namespace SBCRM.Crm.Dtos
{
    /// <summary>
    /// DTO that containing the information on the conversion of
    /// a Lead to an Account from an Account perspective.
    /// </summary>
    public class ConvertLeadToAccountDto
    {
        public LeadDto Lead { get; set; }

        public int ConversionAccountTypeId { get; set; }

        /// <summary>
        /// Main constructor
        /// </summary>
        /// <param name="lead"></param>
        /// <param name="conversionAccountTypeId"></param>
        public ConvertLeadToAccountDto(LeadDto lead, int conversionAccountTypeId)
        {
            Lead = lead;
            ConversionAccountTypeId = conversionAccountTypeId;
        }
    }
}