using Serilog;
using Serilog.Core;
using StreamTools.Components.Pages;
using System.Text;
using TwitchLib.Api;
using TwitchLib.Api.Auth;
using TwitchLib.Api.Helix.Models.Users.GetUsers;
using TwitchLib.EventSub.Websockets;

namespace StreamTools.Services
{
    public sealed class TwitchService
    {
        private readonly ISettingsService settings;

        private readonly EventSubWebsocketClient eventSubWebsocketClient;

        public event EventHandler<User?> UserChanged;


        public User? TwitchUser { get; set; }

        private TwitchAPI api;

        private readonly string clientID = "pi2igbk4suy7h9sbyv7wj6m3cs0ght";

        private int tokenExpiry = 0;

        private HTTPService httpService;

        public TwitchService(ISettingsService settings, EventSubWebsocketClient client, HTTPService webService)
        {
            if (api != null) return;
            this.settings = settings;
            eventSubWebsocketClient = client;
            if(settings.twitchAccessToken != null)
            {
                Task.Run(CreateApi);
            }
            httpService = webService;
            webService.AuthCodeRecieved += WebService_AuthCodeRecieved;
        }

        private void WebService_AuthCodeRecieved(string code)
        {
            settings.twitchAccessToken = code;
            _ = CreateApi();
        }

        public async Task LoginTwitch()
        {
            Guid id = Guid.NewGuid();
            string oauthFlowUrl = new StringBuilder("https://id.twitch.tv/oauth2/authorize?client_id=").Append(clientID).Append("&redirect_uri=http://localhost:4765/twitch&response_type=token&scope=bits:read+channel:read:subscriptions+channel:read:redemptions+channel:read:hype_train+channel:manage:redemptions&state=").Append(id.ToString()).ToString();
            await Launcher.OpenAsync(oauthFlowUrl);
            CancellationToken cs = new CancellationToken();
            httpService.stateCode = id.ToString();
            await Task.Delay(TimeSpan.FromSeconds(60), cs);
        }

        public Task DisconnectTwitch()
        {
            settings.twitchAccessToken = "";
            TwitchUser = null;
            UserChanged?.Invoke(this, TwitchUser);
            return Task.CompletedTask;
        }

        private async Task CreateApi()
        {
            api = new TwitchAPI();
            api.Settings.ClientId = clientID;
            api.Settings.AccessToken = settings.twitchAccessToken;
            ValidateAccessTokenResponse response = await api.Auth.ValidateAccessTokenAsync();
            if (response != null)
            {
                tokenExpiry = response.ExpiresIn;
                await GetUserInfo();
            }
            else
            {
                Log.Warning("Reponse was null. Invalid token refresh token!");
                
            }
        }
        private async Task GetUserInfo()
        {
            GetUsersResponse response = await api.Helix.Users.GetUsersAsync();
            if (response != null)
            {
                User user = response.Users.First();
                TwitchUser = user;
                UserChanged?.Invoke(this, user);
            }
        }
    }
}
