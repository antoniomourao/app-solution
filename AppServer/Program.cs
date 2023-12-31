using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using AppServer.Client.Pages;
using AppServer.Components;
using AppServer.Data;
using AppServer.Identity;
using NLog;
using NLog.Web;
using System.Reflection;

public class Program
{
    public static void Main(string[] args)
    {
        // Early init of NLog to allow startup and exception logging, before host is built
        var logger = NLog.LogManager
            .Setup()
            .LoadConfigurationFromAppSettings()
            .GetCurrentClassLogger();
        logger.Debug("[App Server] init program...");

        try
        {
            var builder = WebApplication.CreateBuilder(args);

            // Set base directory for nLog
            var basePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)!;
            Directory.SetCurrentDirectory(basePath);
            builder.Configuration
                .SetBasePath(basePath)
                .AddJsonFile("appsettings.json", false, true);

            // Add services to the container.
            builder.Services
                .AddRazorComponents()
                .AddInteractiveServerComponents()
                .AddInteractiveWebAssemblyComponents();

            // Add additional endpoints required by the Identity /Account Razor components.
            builder.Services.AddIdentityServices(builder.Configuration);

            // Add Email Sender Service
            builder.Services.AddEmailServices(builder.Configuration);

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseWebAssemblyDebugging();
            }
            else
            {
                app.UseExceptionHandler("/Error", createScopeForErrors: true);
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();
            app.UseAntiforgery();

            app.MapRazorComponents<App>()
                .AddInteractiveServerRenderMode()
                .AddInteractiveWebAssemblyRenderMode()
                .AddAdditionalAssemblies(typeof(Counter).Assembly);

            // Add additional endpoints required by the Identity /Account Razor components.
            app.MapAdditionalIdentityEndpoints();

            app.Run();
        }
        catch (Exception exception)
        {
            // NLog: catch setup errors
            logger.Error(exception, "Stopped program because of exception");
            throw;
        }
        finally
        {
            // Ensure to flush and stop internal timers/threads before application-exit (Avoid segmentation fault on Linux)
            logger.Debug("[App Server] end program!");
            NLog.LogManager.Shutdown();
        }
    }
}
