using SBCRM.Crm;

namespace SBCRM.Legacy.Factory
{
    public class CustomerFactory
    {
        public static Customer GetCustomer(Customer c, AccountType accountType)
        {
            c.AccountTypeFk = accountType;
            return c;
        }
    }
}
