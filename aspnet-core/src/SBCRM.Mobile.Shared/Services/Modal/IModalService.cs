using System.Threading.Tasks;
using SBCRM.Views;
using Xamarin.Forms;

namespace SBCRM.Services.Modal
{
    public interface IModalService
    {
        Task ShowModalAsync(Page page);

        Task ShowModalAsync<TView>(object navigationParameter) where TView : IXamarinView;

        Task<Page> CloseModalAsync();
    }
}
