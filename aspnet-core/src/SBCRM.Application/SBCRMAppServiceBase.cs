using System;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Domain.Entities;
using Abp.IdentityFramework;
using Abp.Runtime.Session;
using Abp.Threading;
using Microsoft.AspNetCore.Identity;
using SBCRM.Authorization.Users;
using SBCRM.MultiTenancy;

namespace SBCRM
{
    /// <summary>
    /// Derive your application services from this class.
    /// </summary>
    public abstract class SBCRMAppServiceBase : ApplicationService
    {
        public TenantManager TenantManager { get; set; }

        public UserManager UserManager { get; set; }

        protected SBCRMAppServiceBase()
        {
            LocalizationSourceName = SBCRMConsts.LocalizationSourceName;
        }

        protected virtual int? GetTenantId()
        {
            return AbpSession?.TenantId;
        }

        protected virtual void SetTenant(IMustHaveTenant entity)
        {
            if (SBCRMConsts.MultiTenancyEnabled)
            {
                entity.TenantId = GetTenantId().Value;
            }
        }

        protected virtual async Task<User> GetCurrentUserAsync()
        {
            var user = await UserManager.FindByIdAsync(AbpSession.GetUserId().ToString());
            if (user == null)
            {
                throw new Exception("There is no current user!");
            }

            return user;
        }

        protected virtual User GetCurrentUser()
        {
            return AsyncHelper.RunSync(GetCurrentUserAsync);
        }

        protected virtual Task<Tenant> GetCurrentTenantAsync()
        {
            using (CurrentUnitOfWork.SetTenantId(null))
            {
                return TenantManager.GetByIdAsync(AbpSession.GetTenantId());
            }
        }

        protected virtual Tenant GetCurrentTenant()
        {
            using (CurrentUnitOfWork.SetTenantId(null))
            {
                return TenantManager.GetById(AbpSession.GetTenantId());
            }
        }

        protected virtual void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}