using Abp.Authorization;
using SBCRM.Authorization.Roles;
using SBCRM.Authorization.Users;

namespace SBCRM.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {

        }
    }
}
