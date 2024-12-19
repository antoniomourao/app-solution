# Domains
The domains are created all inside the **Domains** folder of the solution. The solution name should follow this convention **Domain[name]**. Example for a ToDo project:
- DomainToDo

To Create a Domain class lib
    

    dotnet new razorclasslib -o <domain name>
    

The Domain module should implement:
- IDomainModule
- Add[DomainName]Services

###IDomainModule
To implement this interface it is required to reference **AppShared** project.
```dos
dotnet add reference ..\..\AppShared\AppShared.csproj
```
Should implement **IDomainModule** interface. Example for a ToDo project:
(DomainModule.cs)
```csharp 
using AppShared.Domain;
using AppShared.NavMenu;

namespace DomainTodo;

public class DomainModule: IDomainModule
{
    public string MenuTitle => "ToDo List";

    public List<INavMenuItem>? NavMenuItems  {
        get {
            List<INavMenuItem> navMenuItems = new List<INavMenuItem>();

            navMenuItems.Add(new NavMenuItem() {
                Href = "/todo/home",
                Title = "ToDo",
                Icon = "bi bi-home",
                Roles = new List<string>()
            });

            return navMenuItems;
        }

    }
}
```

###Add Domain name Services
Should havean extensions method to register services and what have you. Example for a ToDo project:
(DomainExtensions.cs)
```csharp 
using AppShared.Domain;
using Microsoft.Extensions.DependencyInjection;

namespace DomainTodo;

public static class DomainExtensions
{
    public static IServiceCollection AddDomainTodoServices(this IServiceCollection services)
    {
        services.AddSingleton<IDomainModule, DomainModule>();
        return services;
    }
}
```	