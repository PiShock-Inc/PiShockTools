using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Logging;
using MudBlazor.Services;
using Serilog;
using Serilog.Formatting.Compact;
using Serilog.Sinks.SystemConsole.Themes;
using StreamTools.Data;

namespace StreamTools;
public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {

        Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Debug()
            .Enrich.FromLogContext()
            .Enrich.WithThreadName()
            .Enrich.WithThreadId()
            .Enrich.WithProcessId()
            .Enrich.WithProcessName()
            .Enrich.WithEnvironmentName()
            .Enrich.WithMachineName()
            .Enrich.WithMemoryUsage()
            .WriteTo.Async(a =>
            {
                a.Console(theme: AnsiConsoleTheme.Code);
                a.Debug(new CompactJsonFormatter());
            })
            .CreateLogger();

        try
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts => fonts.AddFont("Roboto-Regular.ttf", "RobotoRegular"));

            builder.Services.AddLogging(x => x.AddSerilog(dispose: true));
            builder.Services.AddDbContextFactory<StreamToolsContext>();
            builder.Services.AddMauiBlazorWebView();
            builder.Services.AddMudServices();
            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddTwitch(options =>
                {
                    options.ClientId = "pi2igbk4suy7h9sbyv7wj6m3cs0ght"; //TODO Do not put this here in release (dumb dumb)
                    options.Scope.Add("channel:read:redemptions");
                    options.Scope.Add("channel:manage:redemptions");
                    options.Scope.Add("bits:read");
                    options.Scope.Add("channel:read:subscriptions");
                    options.Scope.Add("channel:read:hype_train");
                });
#if DEBUG
            builder.Services.AddBlazorWebViewDeveloperTools();
            builder.Logging.AddDebug();
#endif
            return builder.Build();
        }
        catch (Exception ex)
        {
            Log.Fatal(ex, "An error occurred while building the app");
            throw;
        }
        finally
        {
            Log.CloseAndFlush();
        }
    }
}
