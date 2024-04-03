using StreamTools.Services;

namespace StreamTools;

public partial class App : Application
{
    public App(HTTPService service, TwitchService twitch)
    {
        InitializeComponent();

        MainPage = new MainPage(service, twitch);
    }

    protected override Window CreateWindow(IActivationState activationState)
    {
        var window = base.CreateWindow(activationState);
        if (window != null)
        {
            window.Title = "PiShock Stream Tools";
        }

        return window;
    }
}
