using MediatR;

namespace SBCRM.Modules.Common.AdditionalCharges.Commands
{
    public class DeleteAdditionalChargesCommand : IRequest<Unit>
    {
        public DeleteAdditionalChargesCommand(long id)
        {
            Id = id;
        }

        public long Id { get; set; }    
    }
}
