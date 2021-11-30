using Abp.Application.Services;
using SBCRM.Dto;
using SBCRM.Logging.Dto;

namespace SBCRM.Logging
{
    public interface IWebLogAppService : IApplicationService
    {
        GetLatestWebLogsOutput GetLatestWebLogs();

        FileDto DownloadWebLogs();
    }
}
