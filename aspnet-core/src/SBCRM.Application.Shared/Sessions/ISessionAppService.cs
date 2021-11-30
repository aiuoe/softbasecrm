using System.Threading.Tasks;
using Abp.Application.Services;
using SBCRM.Sessions.Dto;

namespace SBCRM.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();

        Task<UpdateUserSignInTokenOutput> UpdateUserSignInToken();
    }
}
