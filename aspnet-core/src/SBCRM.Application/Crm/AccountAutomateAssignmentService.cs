using Abp.Domain.Repositories;
using Abp.EntityHistory;
using SBCRM.Crm.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Domain.Uow;

namespace SBCRM.Crm
{
    public class AccountAutomateAssignmentService : SBCRMAppServiceBase, IAccountAutomateAssignment
    {
        private readonly IRepository<AccountUser> _accountUserRepository;
        private readonly IEntityChangeSetReasonProvider _reasonProvider;
        private readonly IUnitOfWorkManager _unitOfWorkManager;

        public AccountAutomateAssignmentService(IEntityChangeSetReasonProvider reasonProvider,
            IRepository<AccountUser> accountUserRepository,
            IUnitOfWorkManager unitOfWorkManager)
        {
            _reasonProvider = reasonProvider;
            _accountUserRepository = accountUserRepository;
            _unitOfWorkManager = unitOfWorkManager;
        }

        public async Task AssignAccountUsersAsync(List<CreateOrEditAccountUserDto> input)
        {
            using (_reasonProvider.Use("User wa assigned to Account"))
            {
                foreach (var item in input)
                {
                    var accountUserExists = await _accountUserRepository.FirstOrDefaultAsync(p => p.UserId == item.UserId
                        && p.CustomerNumber == item.CustomerNumber
                        && p.IsDeleted);

                    if (accountUserExists == null)
                    {
                        var accountUser = ObjectMapper.Map<AccountUser>(item);

                        accountUser.TenantId = GetTenantId();

                        await _accountUserRepository.InsertAsync(accountUser);
                    }
                    else
                    {
                        accountUserExists.IsDeleted = false;
                        var accountUserInDatabase = ObjectMapper.Map<CreateOrEditAccountUserDto>(accountUserExists);
                        var accountUser =
                            await _accountUserRepository.FirstOrDefaultAsync(accountUserInDatabase.Id.Value);
                        ObjectMapper.Map(input, accountUser);
                    }
                }

                await _unitOfWorkManager.Current.SaveChangesAsync();
            }
        }
    }
}