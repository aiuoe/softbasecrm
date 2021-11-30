using System.Collections.Generic;
using MvvmHelpers;
using SBCRM.Models.NavigationMenu;

namespace SBCRM.Services.Navigation
{
    public interface IMenuProvider
    {
        ObservableRangeCollection<NavigationMenuItem> GetAuthorizedMenuItems(Dictionary<string, string> grantedPermissions);
    }
}