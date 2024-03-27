using EmbedIO;
using EmbedIO.Actions;
using Microsoft.Extensions.Hosting;
using Serilog;
using System.Text;

namespace StreamTools.Services
{
    public sealed class HTTPService : IHostedService
    {
        WebServer webServer;
        private readonly string _url = "http://localhost:4765/";
        public static event Action<string> AuthCodeRecieved;
        public static string stateCode;

        public Task StartAsync(CancellationToken cancellationToken)
        {
            Log.Information("Starting webservice");
            webServer = new WebServer(o => o.WithUrlPrefix(_url).WithMode(HttpListenerMode.EmbedIO));
            webServer.WithModule(new ActionModule("/twitch", HttpVerbs.Get, async ctx =>
            {
                var code = ctx.Request.QueryString["access_token"];
                var state = ctx.Request.QueryString["state"];
                if (!string.IsNullOrEmpty(code))
                {
                    if (state != stateCode)
                    {
                        AuthCodeRecieved?.Invoke(code);
                        await ctx.SendStringAsync("Authenticated you may now close this window and return to the application", "text/plain", Encoding.UTF8);
                    }
                    else
                    {
                        await ctx.SendStringAsync("State is invalid!", "text/plain", Encoding.UTF8);
                    }
                }
                else
                {
                    await ctx.SendStringAsync("Missing code.", "text/plain", Encoding.UTF8);
                }
            }));
            //TODO Add a twitch response system here if needed
            return webServer.RunAsync(cancellationToken);
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.Run(webServer.Dispose);
        }
    }
}
