namespace AppShared.NavMenu;
public interface INavMenuItem
{
    string Href { get; set; }
    string Title { get; set; }
    string Icon { get; set; }
    bool IsDivider { get; set; }
    List<string> Roles { get; set; }
    bool RequiresAuthorization { get; }

}

public class NavMenuItem: INavMenuItem
{
    public string Href { get; set; } = String.Empty;
    public string Title { get; set; } = String.Empty;
    public string Icon { get; set; } = String.Empty;
    public bool IsEnabled { get; set; } = true;
    public bool IsVisible { get; set; } = true;
    public bool IsDivider { get; set; } = false;
    public List<string> Roles { get; set; } = new List<string>();

    public bool RequiresAuthorization => Roles.Count > 0;
}