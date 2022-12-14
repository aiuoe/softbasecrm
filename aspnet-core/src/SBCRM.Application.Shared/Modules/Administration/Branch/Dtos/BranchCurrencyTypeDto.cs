namespace SBCRM.Modules.Administration.Branch.Dtos
{
    /// <summary>
    /// DTO for branch currency type
    /// </summary>
    public class BranchCurrencyTypeDto
    {
        public string ArAccountNo { get; set; }
        public string DebitAccount { get; set; }
        public string CreditAccount { get; set; }
        public string DebitAccountReevaluate { get; set; }
        public string CreditAccountReevaluate { get; set; }
    }
}
