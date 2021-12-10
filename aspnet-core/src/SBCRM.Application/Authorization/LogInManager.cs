using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Authorization.Users;
using Abp.Configuration;
using Abp.Configuration.Startup;
using Abp.Dependency;
using Abp.Domain.Repositories;
using Abp.Domain.Uow;
using Abp.Zero.Configuration;
using Microsoft.AspNetCore.Identity;
using SBCRM.Authorization.Roles;
using SBCRM.Authorization.Users;
using SBCRM.MultiTenancy;

namespace SBCRM.Authorization
{
    public class LogInManager : AbpLogInManager<Tenant, Role, User>
    {
        private UserManager userManager;

        public LogInManager(
            UserManager userManager,
            IMultiTenancyConfig multiTenancyConfig,
            IRepository<Tenant> tenantRepository,
            IUnitOfWorkManager unitOfWorkManager,
            ISettingManager settingManager,
            IRepository<UserLoginAttempt, long> userLoginAttemptRepository,
            IUserManagementConfig userManagementConfig,
            IIocResolver iocResolver,
            RoleManager roleManager,
            IPasswordHasher<User> passwordHasher,
            UserClaimsPrincipalFactory claimsPrincipalFactory)
            : base(
                  userManager,
                  multiTenancyConfig,
                  tenantRepository,
                  unitOfWorkManager,
                  settingManager,
                  userLoginAttemptRepository,
                  userManagementConfig,
                  iocResolver,
                  passwordHasher,
                  roleManager,
                  claimsPrincipalFactory)
        {
            this.userManager = userManager;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userNameOrEmailAddress"></param>
        /// <param name="plainPassword"></param>
        /// <param name="tenancyName"></param>
        /// <param name="shouldLockout"></param>
        /// <returns></returns>
        public override async Task<AbpLoginResult<Tenant, User>> LoginAsync(
            string userNameOrEmailAddress,
            string plainPassword,
            string tenancyName = null,
            bool shouldLockout = true)
        {
            return await UnitOfWorkManager.WithUnitOfWorkAsync(async () =>
            {

                var user = await userManager.FindByNameAsync(userNameOrEmailAddress);
                var result = await CreateLoginResultAsync(user, null);

                //userManager.PasswordHasher.HashPassword()

                await SaveLoginAttemptAsync(result, tenancyName, userNameOrEmailAddress);
                return result;
            });
        }
    }
}