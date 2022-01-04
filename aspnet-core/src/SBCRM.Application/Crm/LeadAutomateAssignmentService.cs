using Abp.Domain.Repositories;
using Abp.Domain.Uow;
using Abp.EntityHistory;
using SBCRM.Crm.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SBCRM.Crm
{
    /// <summary>
    /// Class containing the service that implements auto-assignment for a lead
    /// </summary>
    public class LeadAutomateAssignmentService : SBCRMAppServiceBase, ILeadAutomateAssignment
    {
        private readonly IEntityChangeSetReasonProvider _reasonProvider;
        private readonly IRepository<LeadUser> _leadUserRepository;
        private readonly IUnitOfWorkManager _unitOfWorkManager;

        /// <summary>
        /// Class constructor
        /// </summary>
        /// <param name="reasonProvider"></param>
        /// <param name="leadUserRepository"></param>
        /// <param name="unitOfWorkManager"></param>
        public LeadAutomateAssignmentService(IEntityChangeSetReasonProvider reasonProvider,
            IRepository<LeadUser> leadUserRepository,
            IUnitOfWorkManager unitOfWorkManager)
        {
            _reasonProvider = reasonProvider;
            _leadUserRepository = leadUserRepository;
            _unitOfWorkManager = unitOfWorkManager;
        }

        /// <summary>
        /// Method that assigns a user to a lead
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task AssignLeadUsersAsync(List<CreateOrEditLeadUserDto> input)
        {
            using (_reasonProvider.Use("User was assigned to Lead"))
            {
                foreach (var item in input)
                {
                    var leadUserExists = _leadUserRepository.FirstOrDefault(p => p.UserId == item.UserId
                        && p.LeadId == item.LeadId
                        && p.IsDeleted);

                    if (leadUserExists == null)
                    {
                        var leadUser = ObjectMapper.Map<LeadUser>(item);

                        await _leadUserRepository.InsertAsync(leadUser);
                    }
                    else
                    {
                        leadUserExists.IsDeleted = false;
                        var leadUserInDatabase = ObjectMapper.Map<CreateOrEditLeadUserDto>(leadUserExists);
                        var accountUser = await _leadUserRepository.FirstOrDefaultAsync(leadUserInDatabase.Id.Value);
                        ObjectMapper.Map(input, accountUser);
                    }
                }

                await _unitOfWorkManager.Current.SaveChangesAsync();
            }
        }
    }
}