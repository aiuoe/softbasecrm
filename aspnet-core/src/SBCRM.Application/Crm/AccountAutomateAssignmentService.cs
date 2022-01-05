using Abp.Domain.Repositories;
using Abp.Domain.Uow;
using Abp.EntityHistory;
using SBCRM.Crm.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SBCRM.Crm
{
    /// <summary>
    /// Class containing the service that implements auto-assignment
    /// </summary>
    public class AccountAutomateAssignmentService : SBCRMAppServiceBase, IAccountAutomateAssignmentService
    {
        private readonly IRepository<AccountUser> _accountUserRepository;
        private readonly IEntityChangeSetReasonProvider _reasonProvider;
        private readonly IUnitOfWorkManager _unitOfWorkManager;

        /// <summary>
        /// Class constructor
        /// </summary>
        /// <param name="reasonProvider"></param>
        /// <param name="accountUserRepository"></param>
        /// <param name="unitOfWorkManager"></param>
        public AccountAutomateAssignmentService(IEntityChangeSetReasonProvider reasonProvider,
            IRepository<AccountUser> accountUserRepository,
            IUnitOfWorkManager unitOfWorkManager)
        {
            _reasonProvider = reasonProvider;
            _accountUserRepository = accountUserRepository;
            _unitOfWorkManager = unitOfWorkManager;
        }

        /// <summary>
        /// Method that assigns a user to an account
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task AssignAccountUsersAsync(List<CreateOrEditAccountUserDto> input)
        {
            using (_reasonProvider.Use("User wa assigned to Account"))
            {
                foreach (CreateOrEditAccountUserDto item in input)
                {
                    AccountUser accountUserExists = await _accountUserRepository.FirstOrDefaultAsync(p => p.UserId == item.UserId
                        && p.CustomerNumber == item.CustomerNumber
                        && p.IsDeleted);

                    if (accountUserExists == null)
                    {
                        AccountUser accountUser = ObjectMapper.Map<AccountUser>(item);

                        accountUser.TenantId = GetTenantId();

                        await _accountUserRepository.InsertAsync(accountUser);
                    }
                    else
                    {
                        accountUserExists.IsDeleted = false;
                        CreateOrEditAccountUserDto accountUserInDatabase = ObjectMapper.Map<CreateOrEditAccountUserDto>(accountUserExists);
                        AccountUser accountUser =
                            await _accountUserRepository.FirstOrDefaultAsync(accountUserInDatabase.Id.Value);
                        ObjectMapper.Map(input, accountUser);
                    }
                }

                await _unitOfWorkManager.Current.SaveChangesAsync();
            }
        }
    }
}