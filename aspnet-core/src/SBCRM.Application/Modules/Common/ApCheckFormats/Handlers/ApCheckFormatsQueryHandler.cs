using MediatR;
using SBCRM.Base;
using SBCRM.Core.BaseEntities;
using SBCRM.Modules.Common.ApCheckFormats.Dto;
using SBCRM.Modules.Common.ApCheckFormats.Queries;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SBCRM.Modules.Common.ApCheckFormats.Handlers
{
    /// <summary>
    /// Handler for the GetApCheckFormat Method
    /// </summary>
    public class ApCheckFormatsQueryHandler : UseCaseServiceBase, IRequestHandler<ApCheckFormatsQuery, List<ApCheckFormatDto>>
    {
        private readonly IApCheckFormatsRepository _ApCheckFormatsRepository;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="ApCheckFormatsRepository">Injected dependences</param>
        public ApCheckFormatsQueryHandler(IApCheckFormatsRepository ApCheckFormatsRepository)
        {
            _ApCheckFormatsRepository = ApCheckFormatsRepository;
        }

        /// <summary>
        /// Handle Method for the request
        /// </summary>
        /// <param name="request">Query Request</param>
        /// <param name="cancellationToken">Token</param>
        /// <returns>List of ApCheckFormats</returns>
        public async Task<List<ApCheckFormatDto>> Handle(ApCheckFormatsQuery request, CancellationToken cancellationToken)
        {
            List<CheckFormat> checks = new List<CheckFormat>();

            var checkFormats = await _ApCheckFormatsRepository.GetAllListAsync();

            checks = (from check in checkFormats
                       orderby check.FormatName
                       group check by check.FormatName into g                       
                       select new CheckFormat{ FormatName = g.Key, 
                           TenantId = g.FirstOrDefault().TenantId,
                           ElementFormat = g.FirstOrDefault().ElementFormat,
                           Font = g.FirstOrDefault().Font,
                           FontBold = g.FirstOrDefault().FontBold,
                           FontItalic = g.FirstOrDefault().FontItalic,
                           FontSize = g.FirstOrDefault().FontSize,
                           LeftPosition = g.FirstOrDefault().LeftPosition,
                           TopPosition = g.FirstOrDefault().TopPosition,
                           ElementName = g.FirstOrDefault().ElementName,
                           PrintElement = g.FirstOrDefault().PrintElement,
                       }).ToList();

            return ObjectMapper.Map(checks, new List<ApCheckFormatDto>());
        }
    }
}
