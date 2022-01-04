using Abp.Domain.Repositories;
using Abp.Domain.Uow;
using Abp.EntityHistory;
using SBCRM.Crm.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SBCRM.Crm
{
    /// <summary>
    /// Class containing the service that implements auto-assignment for an opportunity
    /// </summary>
    public class OpportunityAutomateAssignmentService : SBCRMAppServiceBase, IOpportunityAutomateAssignment
    {
        private readonly IRepository<OpportunityUser> _opportunityUserRepository;
        private readonly IUnitOfWorkManager _unitOfWorkManager;
        private readonly IEntityChangeSetReasonProvider _reasonProvider;

        /// <summary>
        /// Class Constuctor
        /// </summary>
        /// <param name="opportunityUserRepository"></param>
        /// <param name="unitOfWorkManager"></param>
        /// <param name="reasonProvider"></param>
        public OpportunityAutomateAssignmentService(IRepository<OpportunityUser> opportunityUserRepository,
            IUnitOfWorkManager unitOfWorkManager,
            IEntityChangeSetReasonProvider reasonProvider)
        {
            _opportunityUserRepository = opportunityUserRepository;
            _unitOfWorkManager = unitOfWorkManager;
            _reasonProvider = reasonProvider;
        }

        /// <summary>
        /// Method that assigns a user to an Opportunity
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task AssignOpportunityUsersAsync(List<CreateOrEditOpportunityUserDto> input)
        {
            using (_reasonProvider.Use("Users were assigned to Opportunity"))
            {
                foreach (CreateOrEditOpportunityUserDto item in input)
                {
                    OpportunityUser opportunityUserExists = _opportunityUserRepository.FirstOrDefault(p => p.UserId == item.UserId
                        && p.OpportunityId == item.OpportunityId
                        && p.IsDeleted);

                    if (opportunityUserExists == null)
                    {
                        OpportunityUser opportunityUser = ObjectMapper.Map<OpportunityUser>(item);

                        await _opportunityUserRepository.InsertAsync(opportunityUser);
                    }
                    else
                    {
                        opportunityUserExists.IsDeleted = false;
                        CreateOrEditLeadUserDto leadUserInDatabase = ObjectMapper.Map<CreateOrEditLeadUserDto>(opportunityUserExists);
                        OpportunityUser accountUser =
                            await _opportunityUserRepository.FirstOrDefaultAsync(leadUserInDatabase.Id.Value);
                        ObjectMapper.Map(input, accountUser);
                    }
                }

                await _unitOfWorkManager.Current.SaveChangesAsync();
            }
        }
    }
}