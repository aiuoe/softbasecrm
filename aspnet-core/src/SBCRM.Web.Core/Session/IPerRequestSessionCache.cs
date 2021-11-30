using System.Threading.Tasks;
using SBCRM.Sessions.Dto;

namespace SBCRM.Web.Session
{
    public interface IPerRequestSessionCache
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformationsAsync();
    }
}
