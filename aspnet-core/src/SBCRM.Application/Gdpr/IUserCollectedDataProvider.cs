using System.Collections.Generic;
using System.Threading.Tasks;
using Abp;
using SBCRM.Dto;

namespace SBCRM.Gdpr
{
    public interface IUserCollectedDataProvider
    {
        Task<List<FileDto>> GetFiles(UserIdentifier user);
    }
}
