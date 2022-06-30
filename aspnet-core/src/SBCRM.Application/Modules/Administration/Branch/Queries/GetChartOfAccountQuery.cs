using MediatR;
using SBCRM.Modules.Administration.Branch.Dtos;


namespace SBCRM.Modules.Administration.Branch.Queries
{
    /// <summary>
    /// Get ChartOfAccount by account no query
    /// </summary>
    public class GetChartOfAccountQuery : IRequest<GetChartOfAccountDetailsDto>
    {
        public string AccountNo { get; set; }

        /// <summary>
        /// Base constructor
        /// </summary>
        /// <param name="accountNo"></param>
        public GetChartOfAccountQuery(string accountNo)
        {
            AccountNo = accountNo;
        }
    }
}
