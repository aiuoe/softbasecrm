using Abp;

namespace SBCRM.Common
{
    public class GuardHelper
    {
        public static void ThrowIf(bool condition, AbpException exception)
        {
            if (condition)
            {
                throw exception;
            }
        } 
    }
}