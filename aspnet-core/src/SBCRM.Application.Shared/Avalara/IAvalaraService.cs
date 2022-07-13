
using SBCRM.Dto;
using SBCRM.Modules.Administration.Dtos;
using System.Threading.Tasks;

namespace SBCRM.Avalara
{
    /// <summary>
    /// Interface to provide avalara services
    /// </summary>
    public interface IAvalaraService
    {
        Task<GetVerifyAddressDto> VerifyAddress(AvalaraConnectionDataDto avalaraConnectionData, AddressDto address);
    }
}
