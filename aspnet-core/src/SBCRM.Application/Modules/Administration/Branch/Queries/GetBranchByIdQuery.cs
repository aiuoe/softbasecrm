using MediatR;
using SBCRM.Modules.Administration.Branch.Dtos;

namespace SBCRM.Modules.Administration.Branch.Queries
{
    /// <summary>
    /// Get branch by Id query
    /// </summary>
    public class GetBranchByIdQuery: IRequest<GetBranchDetailsDto>
    {
        public long Id { get; set; }

        /// <summary>
        /// Base constructor
        /// </summary>
        /// <param name="id"></param>
        public GetBranchByIdQuery(long id)
        {
            Id= id;
        }
    }
}
