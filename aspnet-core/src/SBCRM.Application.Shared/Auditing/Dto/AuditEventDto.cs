using System;
using Abp.Events.Bus.Entities;

namespace SBCRM.Auditing.Dto
{
    /// <summary>
    /// DTO to map audit event information
    /// </summary>
    public class AuditEventDto
    {
        public Type EntityType { get; set; }
        public string EntityId { get; set; }
        public string Message { get; set; }
        public EntityChangeType ChangeType { get; set; }

        /// <summary>
        /// Base constructor
        /// </summary>
        /// <param name="entityType"></param>
        /// <param name="entityId"></param>
        /// <param name="message"></param>
        public AuditEventDto(Type entityType, string entityId, string message)
        {
            EntityType = entityType;
            EntityId = entityId;
            Message = message;
        }

        /// <summary>
        /// Factory for creation
        /// </summary>
        /// <param name="entityType"></param>
        /// <param name="entityId"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public static AuditEventDto ForCreate(Type entityType, string entityId, string message)
        {
            return new AuditEventDto(entityType, entityId, message)
            {
                ChangeType = EntityChangeType.Created
            };
        }

        /// <summary>
        /// Factory for update
        /// </summary>
        /// <param name="entityType"></param>
        /// <param name="entityId"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public static AuditEventDto ForUpdate(Type entityType, string entityId, string message)
        {
            return new AuditEventDto(entityType, entityId, message)
            {
                ChangeType = EntityChangeType.Updated
            };
        }

        /// <summary>
        /// Factory for delete
        /// </summary>
        /// <param name="entityType"></param>
        /// <param name="entityId"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public static AuditEventDto ForDelete(Type entityType, string entityId, string message)
        {
            return new AuditEventDto(entityType, entityId, message)
            {
                ChangeType = EntityChangeType.Deleted
            };
        }
    }
}
