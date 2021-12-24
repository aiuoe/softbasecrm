using Abp.Application.Services.Dto;

namespace SBCRM.Crm.Dtos
{
    /// <summary>
    /// Dto for the customer lookup table of the Activity
    /// </summary>
    public class ActivityCustomerLookupTableDto
    {
        public string Number { get; set; }

        public string Name { get; set; }
    }
}
