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
                Href = "/weathernet/home",
                Title = "Weather",
                Icon = "bi bi-cloud-sun-fill",
                Roles = new List<string>()
            });

            return navMenuItems;
        }

    }
}

