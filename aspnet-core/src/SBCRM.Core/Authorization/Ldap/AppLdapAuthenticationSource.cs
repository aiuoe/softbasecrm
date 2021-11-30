using Abp.Zero.Ldap.Authentication;
using Abp.Zero.Ldap.Configuration;
using SBCRM.Authorization.Users;
using SBCRM.MultiTenancy;

namespace SBCRM.Authorization.Ldap
{
    public class AppLdapAuthenticationSource : LdapAuthenticationSource<Tenant, User>
    {
        public AppLdapAuthenticationSource(ILdapSettings settings, IAbpZeroLdapModuleConfig ldapModuleConfig)
            : base(settings, ldapModuleConfig)
        {
        }
    }
}