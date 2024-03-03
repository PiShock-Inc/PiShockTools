namespace StreamTools.Components.Models
{
    public sealed class User
    {
        public int Id { get; set; }
        public string twitchAccessToken { get; set; }
        public string googleAccessToken { get; set; }
        public string googleRefreshToken { get; set; }
        public string pishockApiToken { get; set; }

        public User(string twitchAccessToken, string googleAccessToken, string googleRefreshToken, string pishockApiToken)
        {
            this.twitchAccessToken = twitchAccessToken;
            this.googleAccessToken = googleAccessToken;
            this.googleRefreshToken = googleRefreshToken;
            this.pishockApiToken = pishockApiToken;
        }
    }
}
