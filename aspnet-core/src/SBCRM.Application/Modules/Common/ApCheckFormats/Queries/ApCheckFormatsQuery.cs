using MediatR;
using SBCRM.Modules.Common.ApCheckFormats.Dto;
using System.Collections.Generic;

namespace SBCRM.Modules.Common.ApCheckFormats.Queries
{
    /// <summary>
    /// Contains the Query parameters and return type for the GetApCheckFormats method
    /// </summary>
    public class ApCheckFormatsQuery : IRequest<List<ApCheckFormatDto>>
    {
    }
}
