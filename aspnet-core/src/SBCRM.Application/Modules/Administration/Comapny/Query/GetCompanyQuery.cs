using MediatR;
using SBCRM.Core.BaseEntities;
using SBCRM.Modules.Administration.Dtos;
using System.Collections.Generic;

namespace SBCRM.Modules.Administration.Comapny.Queries
{
    /// <summary>
    /// Get company query
    /// </summary>
    public class GetCompanyQuery : IRequest<List<GetCompanyDto>>
    {
    }
}
