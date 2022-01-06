using Abp.Application.Services.Dto;

namespace SBCRM.Crm.Dtos
{
    /// <summary>
    /// DTO to manage the opportunity - branch lookup object
    /// </summary>
    public class OpportunityDepartmentLookupTableDto
    {
        public int? Id { get; set; }//just and incremental number for the dropdown

        public string Name { get; set; }
    }
}
