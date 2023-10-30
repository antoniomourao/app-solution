using AppShared.NavMenu;

namespace AppShared.Domain;

public interface IDomainModule
{
    /// <summary>
    /// Domain Menu Title
    /// </summary>
    string MenuTitle { get; }

    /// <summary>
    /// Domain Menu Items
    /// </summary>
    List<INavMenuItem>? NavMenuItems { get; }
}
