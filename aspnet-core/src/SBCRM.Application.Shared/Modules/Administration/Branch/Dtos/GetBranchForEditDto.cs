namespace SBCRM.Modules.Administration.Branch.Dtos
{
    /// <summary>
    /// Extended DTO fro branch edition
    /// </summary>
    public class GetBranchForEditDto
    {
        public BranchDto Branch { get; set; }
        public string AdditionalPropertyA { get; set; }
        public string AdditionalPropertyB { get; set; }
    }
}
