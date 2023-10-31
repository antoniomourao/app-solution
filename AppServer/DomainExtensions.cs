using DomainTodo;
using AppServer.Client;

public static class DomainExtensions
{
    /// <summary>
    ///  Add Domain Services
    /// </summary>
    /// <param name="services"></param>
    public static void AddDomainServices(this IServiceCollection services)
    {
        // AppServer Client Domain
        services.AddDomainClientServices();
        // Solution ToDo Domain
        services.AddDomainTodoServices();
    }
}
