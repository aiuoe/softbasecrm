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
using Abp.IdentityFramework;
using System;
using Abp.Localization;
using Abp.ObjectMapping;

namespace SBCRM.Authorization
{
    public class LogInManager : AbpLogInManager<Tenant, Role, User>
    {
        private readonly UserManager userManager;
        private readonly LegacyRepositories.ISoftBaseSecureRepository _secureRepository;
        private readonly LegacyRepositories.ISoftBasePersonRepository _personRepository;
        private readonly IPasswordHasher<User> _passwordHasher;
        private readonly ILocalizationManager _L;
        private readonly IObjectMapper _mapper;
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
            LegacyRepositories.ISoftBaseSecureRepository secureRepository,
            LegacyRepositories.ISoftBasePersonRepository personRepository,
            ILocalizationManager localizationManager,
            IObjectMapper mapper)
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
            this._passwordHasher = passwordHasher;
            this._personRepository = personRepository;
            this._L = localizationManager;
            this._mapper = mapper;
        }


        /// <summary>
        /// Custom login method, will check against the legacy users table
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
                var isEmployeeNumber = int.TryParse(userNameOrEmailAddress, out int employeeNumber);

                Legacy.Secure legacyUser = null;

                if (isEmployeeNumber)
                    legacyUser = await _secureRepository.GetLegacyUserByEmployeNumber(employeeNumber);

                var isLegacyUser = legacyUser is not null && legacyUser.Password == plainPassword;

                //IF USER IS NOT IN AbpUsers but it does on dbo.secure 
                if (user is null && isLegacyUser)
                {
                    //we get the person object, this has all the contact information
                    //TODO: We could try to create a view of something instead of getting to separate entities
                    var person = await _personRepository.GetPersonByEmployeeNumberAsync(employeeNumber);
                    if (person is null)
                    {
                        var noPersonMesssage = string.Format(this._L.GetString(SBCRMConsts.LocalizationSourceName, "EmployeeNumberDoesNotHaveRecord{0}"), employeeNumber);
                        throw new ArgumentException(noPersonMesssage);
                    }

                    //it is the first time, so we need to create him a crm user
                    var createUser = _mapper.Map<User>(person);
                    createUser.UserName = employeeNumber.ToString();
                    createUser.Password = _passwordHasher.HashPassword(createUser, plainPassword);
                    (await UserManager.CreateAsync(createUser)).CheckErrors();
                }
                else if (isLegacyUser && !await userManager.CheckPasswordAsync(user, plainPassword))//password does not match from secure to the one we have on AbpUsers
                {
                    await userManager.UpdateSecurityStampAsync(user);//security stamp is required to hash the password
                    user.Password = _passwordHasher.HashPassword(user, plainPassword);
                    await userManager.UpdateAsync(user);
                }

                //get the user again
                user ??= await userManager.FindByNameAsync(userNameOrEmailAddress);

                if (!await userManager.CheckPasswordAsync(user, plainPassword))
                {
                    return new AbpLoginResult<Tenant, User>(AbpLoginResultType.InvalidPassword, null, user);
                }

                var result = await CreateLoginResultAsync(user, null);

                await SaveLoginAttemptAsync(result, tenancyName, userNameOrEmailAddress);
                return result;
            });
        }
    }
}