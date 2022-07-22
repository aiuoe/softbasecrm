using System;
using System.Linq;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Abp.IdentityFramework;
using Abp.Runtime.Session;
using Abp.Threading;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SBCRM.Authorization.Users;
using SBCRM.Modules.Common.Dto;
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

        /// <summary>
        /// Set the user's full name into the entity DTO's audit fields
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="entityDto"></param>
        /// <returns></returns>
        protected async Task<AuditDto> SetAuditUsers(FullAuditedEntity<long> entity, AuditDto entityDto)
        {
            var auditUsers = await UserManager.Users
                .Where(x => x.Id == entity.CreatorUserId || x.Id == entity.LastModifierUserId)
                .ToListAsync();

            entityDto.CreatorUserName = auditUsers.FirstOrDefault(x => x.Id == entity.CreatorUserId)?.FullName;
            entityDto.LastModifierUserName = auditUsers.FirstOrDefault(x => x.Id == entity.LastModifierUserId)?.FullName;
            return entityDto;
        }
    }
}