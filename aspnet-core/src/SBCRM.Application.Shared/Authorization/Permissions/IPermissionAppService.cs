using Abp.Application.Services;
using Abp.Application.Services.Dto;
using SBCRM.Authorization.Permissions.Dto;

namespace SBCRM.Authorization.Permissions
{
    public interface IPermissionAppService : IApplicationService
    {
        ListResultDto<FlatPermissionWithLevelDto> GetAllPermissions();
    }
}
