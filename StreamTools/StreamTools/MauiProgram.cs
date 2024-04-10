using Microsoft.Extensions.Logging;
using MudBlazor.Services;
using Serilog;
using Serilog.Formatting.Compact;
using Serilog.Sinks.SystemConsole.Themes;
using StreamTools.Data;
using StreamTools.Services;
using TwitchLib.EventSub.Websockets.Extensions;

namespace StreamTools;
public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        if (WinUIEx.WebAuthenticator.CheckOAuthRedirectionActivation())
        {
            throw new InvalidOperationException("Application was started twice?!");
        }
        Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Debug()
            .MinimumLevel.Override("Microsoft", Serilog.Events.LogEventLevel.Warning)
            .MinimumLevel.Override("System", Serilog.Events.LogEventLevel.Warning)
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
            Log.Information("Initalizing application");
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts => fonts.AddFont("Roboto-Regular.ttf", "RobotoRegular"));

            builder.Services.AddLogging(x => x.AddSerilog(dispose: true));
            builder.Services.AddDbContextFactory<StreamToolsContext>();
            builder.Services.AddMauiBlazorWebView();
            builder.Services.AddMudServices();
            builder.Services.AddScoped<ISettingsService, SettingsService>();
#if WINDOWS
            builder.Services.AddTwitchLibEventSubWebsockets();
            builder.Services.AddSingleton<HTTPService>();
            builder.Services.AddSingleton<TwitchService>();
            builder.Services.AddSingleton<PiShockService>();
#endif

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
