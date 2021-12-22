using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.Dependency;
using SBCRM.Auditing.Dto;

namespace SBCRM.Auditing
{
    /// <summary>
    /// Service to manage the WRITABLE audit events in the system
    /// </summary>
    public interface IAuditEventsService : ITransientDependency
    {
        /// <summary>
        /// Create event in the audit log
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task AddEvent(AuditEventDto input);


        /// <summary>
        /// Get entity type changes
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<PagedResultDto<EntityChangeListDto>> GetEntityTypeChanges(GetEntityTypeChangeInput input);
    }
}
