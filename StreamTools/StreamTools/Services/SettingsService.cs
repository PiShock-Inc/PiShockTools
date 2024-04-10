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
        private const string HypeTrainWarning = "hypetrain_warning";

        public SettingsService()
        {
        }

        public string twitchAccessToken { get => Preferences.Default.Get(TwitchAccessToken, ""); set => Preferences.Default.Set(TwitchAccessToken, value); }
        public string googleAccessToken { get => Preferences.Default.Get(GoogleAccessToken, ""); set => Preferences.Default.Set(GoogleAccessToken, value); }
        public string googleRefreshToken { get => Preferences.Default.Get(GoogleRefreshToken, ""); set => Preferences.Default.Set(GoogleRefreshToken, value); }
        public string streamlootsToken { get => Preferences.Default.Get(StreamLootsToken, ""); set => Preferences.Default.Set(StreamLootsToken, value); }
        public bool hypeTrainEnabled { get => Preferences.Default.Get(HypeTrainEnabled, false); set => Preferences.Default.Set(HypeTrainEnabled, value); }
        public int hypeTrainIntensityPerLevel { get => Preferences.Default.Get(HypeTrainIntensity, 5); set => Preferences.Default.Set(HypeTrainIntensity, value); }
        public int hypeTrainDurationPerLevel { get => Preferences.Default.Get(HypeTrainDuration, 1); set => Preferences.Default.Set(HypeTrainDuration, value); }
        public bool hypeTrainWarning { get => Preferences.Default.Get(HypeTrainWarning, true); set => Preferences.Default.Set(HypeTrainWarning, value); }
    }
}
