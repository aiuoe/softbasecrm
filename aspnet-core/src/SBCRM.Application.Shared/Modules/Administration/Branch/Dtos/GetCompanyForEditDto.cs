namespace SBCRM.Modules.Administration.Dtos
{
    /// <summary>
    /// Extended DTO fro company edition
    /// </summary>
    public class GetCompanyForEditDto
    {
        public CompanyDto Company { get; set; }
        public string AdditionalPropertyA { get; set; }
        public string AdditionalPropertyB { get; set; }
    }
}