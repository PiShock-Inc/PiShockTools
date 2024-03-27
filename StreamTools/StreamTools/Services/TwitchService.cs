using Microsoft.AspNetCore.Components;
using MudBlazor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TwitchLib.Api;

namespace StreamTools.Services
{
    public class TwitchService
    {
        [Inject]
        static SettingsService settings { get; set; }




        public static async Task<bool> LoginTwitch()
        {
            Guid id = Guid.NewGuid();
            string oauthFlowUrl = new StringBuilder("https://id.twitch.tv/oauth2/authorize?client_id=pi2igbk4suy7h9sbyv7wj6m3cs0ght&redirect_uri=http://localhost:4765/twitch&response_type=token&scope=bits:read+channel:read:subscriptions+channel:read:redemptions+channel:read:hype_train+channel:manage:redemptions&state=").Append(id.ToString()).ToString();
            await Launcher.OpenAsync(oauthFlowUrl);
            CancellationToken cs = new CancellationToken();
            bool failed = false;
            HTTPService.stateCode = id.ToString();
            HTTPService.AuthCodeRecieved += code =>
            {
                settings.twitchAccessToken = code;
                failed = false;
            };

            await Task.Delay(TimeSpan.FromSeconds(60), cs);
            failed = false;
            return failed;
        }

    }
}
