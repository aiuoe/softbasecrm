using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.EntityHistory;
using Abp.Linq.Extensions;
using Abp.Runtime.Session;
using Abp.Timing;
using Microsoft.EntityFrameworkCore;
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
        private readonly IRepository<User, long> _userRepository;

        /// <summary>
        /// Base constructor
        /// </summary>
        /// <param name="entityChangeSetRepository"></param>
        /// <param name="entityChangeRepository"></param>
        /// <param name="userRepository"></param>
        public AuditEventsService(
            IRepository<EntityChangeSet, long> entityChangeSetRepository,
            IRepository<EntityChange, long> entityChangeRepository,
            IRepository<User, long> userRepository)
        {
            _entityChangeSetRepository = entityChangeSetRepository;
            _entityChangeRepository = entityChangeRepository;
            _userRepository = userRepository;
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
                ChangeTime = Clock.Now,
                EntityTypeFullName = input.EntityType.FullName,
                EntityChangeSetId = entityChangeSetId,
                EntityId = input.EntityId,
                ChangeType = input.ChangeType
            };
            await _entityChangeRepository.InsertAsync(entityChange);
        }

        /// <summary>
        /// Get entity type changes
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<PagedResultDto<EntityChangeListDto>> GetEntityTypeChanges(GetEntityTypeChangeInput input)
        {
            var entityId = "\"" + input.EntityId + "\"";

            var query = from entityChangeSet in _entityChangeSetRepository.GetAll()
                join entityChange in _entityChangeRepository.GetAll() on entityChangeSet.Id equals entityChange.EntityChangeSetId
                join user in _userRepository.GetAll() on entityChangeSet.UserId equals user.Id
                where entityChange.EntityTypeFullName == input.EntityTypeFullName &&
                      (entityChange.EntityId == input.EntityId || entityChange.EntityId == entityId)
                select new EntityChangeAndUser
                {
                    EntityChange = entityChange,
                    EntityChangeSet = entityChangeSet,
                    User = user
                };

            var resultCount = await query.CountAsync();
            var results = await query
                .OrderBy(input.Sorting)
                .PageBy(input)
                .ToListAsync();

            var entityChangeListDtos = ConvertToEntityChangeListDtos(results);

            return new PagedResultDto<EntityChangeListDto>(resultCount, entityChangeListDtos);
        }

        private List<EntityChangeListDto> ConvertToEntityChangeListDtos(List<EntityChangeAndUser> results)
        {
            return results.Select(
                result =>
                {
                    var entityChangeListDto = ObjectMapper.Map<EntityChangeListDto>(result.EntityChange);
                    entityChangeListDto.UserName = result.User?.FullName;
                    entityChangeListDto.Reason = result.EntityChangeSet?.Reason;
                    return entityChangeListDto;
                }).ToList();
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
