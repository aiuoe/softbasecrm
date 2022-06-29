using MediatR;
using SBCRM.Modules.Administration.Branch.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBCRM.Modules.Administration.Branch.Queries
{
    /// <summary>
    /// Get Credit card account no query
    /// </summary>
    public class GetCreditCardAccountQuery : IRequest<GetChartOfAccountDetailsDto>
    {
        public string AccountNo { get; set; }

        /// <summary>
        /// Base constructor
        /// </summary>
        /// <param name="accountNo"></param>
        public GetCreditCardAccountQuery(string accountNo)
        {
            AccountNo = accountNo;
        }
    }
}
