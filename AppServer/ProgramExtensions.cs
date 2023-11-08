using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

public static class ProgramExtensions
{
    /// <summary>
    /// Add additional endpoints required by the Identity /Account Razor components.
    /// </summary>
    /// <param name="services"></param>
    /// <param name="configuration"></param>
    /// <exception cref="InvalidOperationException"></exception>
    public static void AddIdentityServices(
        this IServiceCollection services,
        IConfiguration configuration
    )
    {
        services.AddCascadingAuthenticationState();
        services.AddScoped<UserAccessor>();
        services.AddScoped<IdentityRedirectManager>();
        services.AddScoped<
            AuthenticationStateProvider,
            PersistingRevalidatingAuthenticationStateProvider
        >();

        services.AddAuthentication(IdentityConstants.ApplicationScheme).AddIdentityCookies();

        var connectionString =
            configuration.GetConnectionString("IdentityConnection")
            ?? throw new InvalidOperationException(
                "Connection string 'DefaultConnection' not found."
            );
        services.AddDbContext<ApplicationDbContext>(options => options.UseSqlite(connectionString));
        services.AddDatabaseDeveloperPageExceptionFilter();

        services
            .AddIdentityCore<ApplicationUser>(
                options => options.SignIn.RequireConfirmedAccount = true
            )
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddSignInManager()
            .AddDefaultTokenProviders();
    }

    /// <summary>
    /// Add Email Sender Service
    /// </summary>
    /// <param name="services"></param>
    /// <param name="configuration"></param>
    public static void AddAppServerServices(
        this IServiceCollection services,
        IConfiguration configuration
    )
    {
        // Setup EmailSenderService for authentication
        services
            .AddOptions<EmailSenderServiceSmtpSettings>()
            .Bind(configuration.GetSection("SmtpSettings"))
            .ValidateDataAnnotations();

        var instance = services
            .BuildServiceProvider()
            .GetRequiredService<IOptionsMonitor<EmailSenderServiceSmtpSettings>>()
            .CurrentValue;
        services.AddSingleton(_ => instance);

        services.AddScoped<EmailService>();
        services.AddScoped<IEmailSender, EmailSenderUtil>();

        // Setup Domain Services
        services.AddScoped<IDomainModuleServices, DomainModuleServices>();

    }

    /// <summary>
    /// Load required Domain assemblies
    /// </summary>
    /// <returns></returns>
    public static Assembly[] GetAssembliesToLoad()
    {
        // Load all assemblies in the current directory
        var basePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)!;
        var files = Directory.GetFiles(basePath, "Domain*.dll");
        List<Assembly> assemblies = new List<Assembly>();
        assemblies.Add(Assembly.LoadFrom("AppServer.Client.dll"));
        foreach (var file in files)
        {
            try
            {
                Console.WriteLine($"Loading assembly {file}...");
                assemblies.Add(Assembly.LoadFrom(file));
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading assembly {file}: {ex.Message}");
            }
        }

        return assemblies.ToArray();
    }
}
