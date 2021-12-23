using Abp.Application.Services.Dto;

namespace SBCRM.Crm.Dtos
{
    /// <summary>
    /// DTO to manage the opportunity - customer lookup object
    /// </summary>
    public class OpportunityCustomerLookupTableDto
    {
        public string Number { get; set; }

        public string Name { get; set; }
    }
}
