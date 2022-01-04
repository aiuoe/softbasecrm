namespace SBCRM.Crm.Support
{
    /// <summary>
    /// Explicit interface that indicates that an entity has the TenantId field but it will have no value,
    /// the idea is to leave the infrastructure ready to be able to use it in the near future.
    /// </summary>
    public interface ISilentTenant
    {
    }
}