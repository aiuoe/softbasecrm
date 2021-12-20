using Abp;

namespace SBCRM.Common
{
    /// <summary>
    /// Helper class to handle the ABP exceptions
    /// </summary>
    public class GuardHelper
    {
        /// <summary>
        /// Throw an exception by condition
        /// </summary>
        /// <param name="condition"></param>
        /// <param name="exception"></param>
        public static void ThrowIf(bool condition, AbpException exception)
        {
            if (condition)
            {
                throw exception;
            }
        } 
    }
}