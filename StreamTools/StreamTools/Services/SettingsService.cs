namespace StreamTools.Services
{
    public sealed class SettingsService : ISettingsService
    {
        private const string TwitchAccessToken = "twitch_access_token";
        private const string GoogleAccessToken = "google_access_token";
        private const string GoogleRefreshToken = "google_refresh_token";
        private const string StreamLootsToken = "streamloots_access_token";
        private const string HypeTrainEnabled = "hypetrain_enabled";
        private const string HypeTrainIntensity = "hypetrain_intensity";
        private const string HypeTrainDuration = "hypetrain_duration";
        public string twitchAccessToken { get => Preferences.Get(TwitchAccessToken, ""); set => Preferences.Set(TwitchAccessToken, value); }
        public string googleAccessToken { get => Preferences.Get(GoogleAccessToken, ""); set => Preferences.Set(GoogleAccessToken, value); }
        public string googleRefreshToken { get => Preferences.Get(GoogleRefreshToken, ""); set => Preferences.Set(GoogleRefreshToken, value); }
        public string streamlootsToken { get => Preferences.Get(StreamLootsToken, ""); set => Preferences.Set(StreamLootsToken, value); }
        public bool hypeTrainEnabled { get => Preferences.Get(HypeTrainEnabled, false); set => Preferences.Set(HypeTrainEnabled, value); }
        public int hypeTrainIntensityPerLevel { get => Preferences.Get(HypeTrainIntensity, 0); set => Preferences.Set(HypeTrainIntensity, value); }
        public int hypeTrainDurationPerLevel { get => Preferences.Get(HypeTrainDuration, 0); set => Preferences.Set(HypeTrainDuration, value); }
    }
}
