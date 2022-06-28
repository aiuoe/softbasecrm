namespace SBCRM.Modules.Administration.Dtos
{
    /// <summary>
    /// DTO for branch currency type
    /// </summary>
    public class GetBranchCurrencyTypeDto
    {
        public string AraccountNo { get; set; }
        public string DebitAccount { get; set; }
        public string CreditAccount { get; set; }
        public string DebitAccountReevaluate { get; set; }
        public string CreditAccountReevaluate { get; set; }
    }
}
