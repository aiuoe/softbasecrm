using MediatR;
using SBCRM.Core.BaseEntities;
using System.Collections.Generic;

namespace SBCRM.Modules.Administration.Comapny.Queries
{
    public record GetCompanyQuery : IRequest<IEnumerable<Company>>;
}
