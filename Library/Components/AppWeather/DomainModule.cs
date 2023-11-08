using AppShared.Domain;
using AppShared.NavMenu;

namespace AppWeather;

public class DomainModule: IDomainModule
{
    public string MenuTitle => "ToDo List";

    public List<INavMenuItem>? NavMenuItems  {
        get {
            List<INavMenuItem> navMenuItems = new List<INavMenuItem>();

            navMenuItems.Add(new NavMenuItem() {
                Href = "/todo/home",
                Title = "ToDo",
                Icon = "bi bi-bookmark-check",
                Roles = new List<string>()
            });

            return navMenuItems;
        }

    }
}

