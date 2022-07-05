
using SBCRM.Dto;
using System.Threading.Tasks;

namespace SBCRM.Avalara
{
    /// <summary>
    /// Interface to provide avalara services
    /// </summary>
    public interface IAvalaraService
    {
        void VerifyAddress(AvalaraConnectionDataDto avalaraConnectionData, AddressDto address);
    }
}
