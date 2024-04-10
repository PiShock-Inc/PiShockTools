using StreamTools.Services;

namespace StreamTools;

public partial class MainPage : ContentPage
{

    private readonly HTTPService _httpService;

    public MainPage(HTTPService service, TwitchService twitch)
    {
        InitializeComponent();
        _httpService = service;
        Task.Run(() => _httpService.StartWebServer());

    }
}
