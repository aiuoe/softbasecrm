using System.Threading.Tasks;

namespace SBCRM.Net.Sms
{
    public interface ISmsSender
    {
        Task SendAsync(string number, string message);
    }
}