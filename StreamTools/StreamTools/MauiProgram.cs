using Microsoft.Extensions.Logging;
using Blazorise;
using Blazorise.Icons.Material;
using Blazorise.Material;
using Serilog;
using Serilog.Formatting.Compact;
using Blazorise.Icons.FontAwesome;
using Serilog.Sinks.SystemConsole.Themes;

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

            builder.Services.AddMauiBlazorWebView();
            builder.Services.AddBlazorise(options => options.Immediate = true)
                .AddMaterialProviders()
                .AddMaterialIcons();
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
