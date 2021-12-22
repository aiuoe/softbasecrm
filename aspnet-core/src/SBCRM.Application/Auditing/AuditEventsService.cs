using System;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Domain.Repositories;
using Abp.EntityHistory;
using Abp.Runtime.Session;
using SBCRM.Auditing.Dto;
using SBCRM.Authorization.Users;
using SBCRM.MultiTenancy;

namespace SBCRM.Auditing
{
    /// <summary>
    /// Service to manage the WRITABLE audit events in the system
    /// </summary>
    public class AuditEventsService : ApplicationService, IAuditEventsService
    {
        // Auto inject managers
        public TenantManager TenantManager { get; set; }
        public UserManager _userManager { get; set; }

        // Injected repositories
        private readonly IRepository<EntityChange, long> _entityChangeRepository;
        private readonly IRepository<EntityChangeSet, long> _entityChangeSetRepository;

        /// <summary>
        /// Base constructor
        /// </summary>
        /// <param name="entityChangeSetRepository"></param>
        /// <param name="entityChangeRepository"></param>
        public AuditEventsService(
            IRepository<EntityChangeSet, long> entityChangeSetRepository,
            IRepository<EntityChange, long> entityChangeRepository)
        {
            _entityChangeSetRepository = entityChangeSetRepository;
            _entityChangeRepository = entityChangeRepository;
        }

        /// <summary>
        /// Create event in the audit log
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task AddEvent(AuditEventDto input)
        {
            var currentUser = await GetCurrentUserAsync();
            var currentTenant = GetCurrentTenant();

            var entityChangeSet = new EntityChangeSet
            {
                TenantId = currentTenant.Id,
                UserId = currentUser.Id,
                Reason = input.Message
            };
            var entityChangeSetId = await _entityChangeSetRepository.InsertAndGetIdAsync(entityChangeSet);

            var entityChange = new EntityChange
            {
                TenantId = currentTenant.Id,
                ChangeTime = DateTime.Now,
                EntityTypeFullName = input.EntityType.FullName,
                EntityChangeSetId = entityChangeSetId,
                EntityId = input.EntityId,
                ChangeType = input.ChangeType
            };
            await _entityChangeRepository.InsertAsync(entityChange);
        }

        /// <summary>
        /// Get current session user
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        protected virtual async Task<User> GetCurrentUserAsync()
        {
            var user = await _userManager.FindByIdAsync(AbpSession.GetUserId().ToString());
            if (user == null)
            {
                throw new Exception("There is no current user!");
            }

            return user;
        }

        /// <summary>
        /// Get current session tenant
        /// </summary>
        /// <returns></returns>
        protected virtual Tenant GetCurrentTenant()
        {
            using (CurrentUnitOfWork.SetTenantId(null))
            {
                return TenantManager.GetById(AbpSession.GetTenantId());
            }
        }
    }
}
