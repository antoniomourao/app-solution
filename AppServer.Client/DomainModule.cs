using AppShared.Domain;
using AppShared.NavMenu;

namespace AppServer.Client;

public class DomainModule: IDomainModule
{
    public string MenuTitle => "Server Client";

    public List<INavMenuItem>? NavMenuItems  {
        get {
            List<INavMenuItem> navMenuItems = new List<INavMenuItem>();

            navMenuItems.Add(new NavMenuItem() {
                Href = "/counter",
                Title = "Counter",
                Icon = "bi bi-plus-square-fill",
                Roles = new List<string>() { "Admin", "User" }
            });

            return navMenuItems;
        }

    }
}

