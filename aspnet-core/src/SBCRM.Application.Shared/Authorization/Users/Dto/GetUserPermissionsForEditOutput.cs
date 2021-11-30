using System.Collections.Generic;
using SBCRM.Authorization.Permissions.Dto;

namespace SBCRM.Authorization.Users.Dto
{
    public class GetUserPermissionsForEditOutput
    {
        public List<FlatPermissionDto> Permissions { get; set; }

        public List<string> GrantedPermissionNames { get; set; }
    }
}