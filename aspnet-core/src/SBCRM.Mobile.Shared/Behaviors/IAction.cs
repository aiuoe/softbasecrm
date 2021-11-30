using Xamarin.Forms.Internals;

namespace SBCRM.Behaviors
{
    [Preserve(AllMembers = true)]
    public interface IAction
    {
        bool Execute(object sender, object parameter);
    }
}