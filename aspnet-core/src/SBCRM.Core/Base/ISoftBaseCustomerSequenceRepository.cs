using System.Threading.Tasks;

namespace SBCRM.Base
{
    /// <summary>
    /// Repository to manage the customer sequence information
    /// </summary>
    public interface ISoftBaseCustomerSequenceRepository
    {
        /// <summary>
        /// Get next customer sequence
        /// </summary>
        /// <returns></returns>
        public Task<int> GetNextSequence();
    }
}