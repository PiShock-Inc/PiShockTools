using EmbedIO;
using EmbedIO.Actions;
using Microsoft.Extensions.Hosting;
using System.Text;

namespace StreamTools.Services
{
    public sealed class HTTPService : IAsyncDisposable
    {
        WebServer webServer;
        private readonly string _url = "http://localhost:4765";
        public event Action<string> AuthCodeRecieved;
        public string stateCode;

        public HTTPService()
        {
            webServer = new WebServer(o => o.WithUrlPrefix(_url).WithMode(HttpListenerMode.EmbedIO));
            webServer.WithModule(new ActionModule("/twitch", HttpVerbs.Get, async ctx =>
            {
                var code = ctx.Request.QueryString["access_token"];
                var state = ctx.Request.QueryString["state"];
                if (!string.IsNullOrEmpty(code))
                {
                    if (state == stateCode)
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
                    //Redirecting user because fuck twitch :eyeroll:
                    string html = "<!DOCTYPE html>\r\n<html lang=\"en\">\r\n<head>\r\n    <meta charset=\"UTF-8\">\r\n    <meta http-equiv=\"X-UA-Compatible\" content=\"IE=edge\">\r\n    <meta name=\"viewport\" content=\"width=device-width, initial-scale=1.0\">\r\n    <title>Redirecting...</title>\r\n</head>\r\n<body>\r\n    <h1>Please wait, you are being redirected...</h1>\r\n    <script>\r\n        document.addEventListener(\"DOMContentLoaded\", function() {\r\n            if (window.location.hash) {\r\n                // Extract the hash fragment without the '#'\r\n                const hashParams = window.location.hash.substring(1);\r\n                // Construct a new URL with the hashParams as a query string\r\n                const newUrl = `${window.location.pathname}?${hashParams}`;\r\n                // Display a message or perform any action before redirecting\r\n                console.log(\"Redirecting to: \", newUrl);\r\n                // Redirect to the new URL after a short delay\r\n                setTimeout(() => {\r\n                    window.location.href = newUrl;\r\n                }, 1); // Adjust the delay as needed\r\n            }\r\n        });\r\n    </script>\r\n</body>\r\n</html>\r\n";
                    ctx.Response.ContentType = "text/html";
                    await ctx.SendStringAsync(html, "text/html", Encoding.UTF8);
                }
            }));
        }

        public async Task StartWebServer()
        {
            await webServer.RunAsync();
        }

        public ValueTask DisposeAsync()
        {
            webServer?.Dispose();
            return ValueTask.CompletedTask;
        }
    }
}
