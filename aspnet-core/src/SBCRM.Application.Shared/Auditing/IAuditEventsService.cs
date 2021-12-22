using System.Threading.Tasks;
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
    }
}
