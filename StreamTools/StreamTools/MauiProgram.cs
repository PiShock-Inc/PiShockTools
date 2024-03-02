using Microsoft.Extensions.Logging;
using Blazorise;
using Blazorise.Icons.Material;
using Blazorise.Material;
using Serilog;
using Serilog.Exceptions;
using Serilog.Formatting.Compact;
using Blazorise.Icons.FontAwesome;

namespace StreamTools;
public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {

        Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Debug()
            .Enrich.FromLogContext()
            .Enrich.WithDemystifiedStackTraces()
            .Enrich.WithExceptionDetails()
            .Enrich.WithThreadName()
            .Enrich.WithThreadId()
            .Enrich.WithProcessId()
            .Enrich.WithProcessName()
            .Enrich.WithEnvironmentName()
            .Enrich.WithMachineName()
            .Enrich.WithMemoryUsage()
            .WriteTo.Async(a =>
            {
                a.Console(new CompactJsonFormatter());
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
                .AddMaterialIcons()
                .AddFontAwesomeIcons();
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
