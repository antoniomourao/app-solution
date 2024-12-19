using DomainTodo;
using AppServer.Client;
using AppWeather;

public static class DomainExtensions
{
    /// <summary>
    ///  Add Domain Services
    /// </summary>
    /// <param name="services"></param>
    public static void AddDomainServices(this IServiceCollection services)
    {
        // App Weather component
        services.AddAppWeatherServices();
        // AppServer Client Domain
        services.AddDomainClientServices();
        // Solution ToDo Domain
        services.AddDomainTodoServices();
    }
}
