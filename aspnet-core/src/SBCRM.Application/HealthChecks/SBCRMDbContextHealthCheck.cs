using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using SBCRM.EntityFrameworkCore;

namespace SBCRM.HealthChecks
{
    public class SBCRMDbContextHealthCheck : IHealthCheck
    {
        private readonly DatabaseCheckHelper _checkHelper;

        public SBCRMDbContextHealthCheck(DatabaseCheckHelper checkHelper)
        {
            _checkHelper = checkHelper;
        }

        public Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = new CancellationToken())
        {
            if (_checkHelper.Exist("db"))
            {
                return Task.FromResult(HealthCheckResult.Healthy("SBCRMDbContext connected to database."));
            }

            return Task.FromResult(HealthCheckResult.Unhealthy("SBCRMDbContext could not connect to database"));
        }
    }
}
