using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Abp.Runtime.Validation;
using MediatR;
using SBCRM.Modules.Administration.Dtos;

namespace SBCRM.Modules.Administration.Branch.Queries
{
    /// <summary>
    /// Get branch dropdown query
    /// </summary>
    public class GetBranchDropdownQuery : IRequest<List<GetBranchForDropdownDto>>
    {
    }
}
