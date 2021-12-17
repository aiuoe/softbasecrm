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
using LegacyRepositories = SBCRM.Base;
using SBCRM.MultiTenancy;

namespace SBCRM.Authorization
{
    public class LogInManager : AbpLogInManager<Tenant, Role, User>
    {
        private UserManager userManager;
        private readonly LegacyRepositories.ISoftBaseSecureRepository _secureRepository;
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
            UserClaimsPrincipalFactory claimsPrincipalFactory,
            LegacyRepositories.ISoftBaseSecureRepository secureRepository)
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
            this._secureRepository = secureRepository;
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
                //SI EXISTE Y NO TIENE PASSWORHASH , HACER EL HASH
          
                if (user is null) 
                {
                    int.TryParse(userNameOrEmailAddress, out int employeNumber);
                    var legacyUser = await _secureRepository.GetLegacyUserByEmployeNumber(employeNumber);
                    //si el password en secure es nulo or empty unauthorized
                   var ss = userManager.PasswordHasher.HashPassword(user, legacyUser.Password);
                }
  
                var result = await CreateLoginResultAsync(user, null);

                
                await SaveLoginAttemptAsync(result, tenancyName, userNameOrEmailAddress);
                return result;
            });
        }
    }
}