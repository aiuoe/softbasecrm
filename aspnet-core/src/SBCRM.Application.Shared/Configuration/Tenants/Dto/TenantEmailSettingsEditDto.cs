using Abp.Auditing;
using SBCRM.Configuration.Dto;

namespace SBCRM.Configuration.Tenants.Dto
{
    public class TenantEmailSettingsEditDto : EmailSettingsEditDto
    {
        public bool UseHostDefaultEmailSettings { get; set; }
    }
}