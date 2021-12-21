using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using SBCRM.Base;

namespace SBCRM.EntityFrameworkCore.Repositories
{
    /// <summary>
    /// Repository to manage the customer sequence information
    /// </summary>
    public class SoftBaseCustomerSequenceRepository : ISoftBaseCustomerSequenceRepository
    {
        private readonly SBCRMDbContext _dbContext;

        public SoftBaseCustomerSequenceRepository(SBCRMDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// Get next customer sequence
        /// </summary>
        /// <returns></returns>
        public async Task<int> GetNextSequence()
        {
            var result = new SqlParameter("@result", System.Data.SqlDbType.Int)
            {
                Direction = System.Data.ParameterDirection.Output
            };
            await _dbContext.Database.ExecuteSqlRawAsync("SELECT @result = (NEXT VALUE FOR Web.CustomerNumberSequence)", result);

            return (int) result.Value;
        }
    }
}