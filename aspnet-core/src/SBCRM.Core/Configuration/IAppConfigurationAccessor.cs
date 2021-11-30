using Microsoft.Extensions.Configuration;

namespace SBCRM.Configuration
{
    public interface IAppConfigurationAccessor
    {
        IConfigurationRoot Configuration { get; }
    }
}
