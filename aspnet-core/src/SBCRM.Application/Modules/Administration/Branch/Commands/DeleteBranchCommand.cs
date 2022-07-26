using MediatR;

namespace SBCRM.Modules.Administration.Branch.Commands
{
    /// <summary>
    /// Delete branch command
    /// </summary>
    public class DeleteBranchCommand : IRequest
    {
        public long BranchId { get; set; }
    }
}
