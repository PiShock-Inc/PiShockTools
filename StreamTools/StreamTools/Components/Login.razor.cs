using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Logging;
using Microsoft.JSInterop;
using Microsoft.UI.Xaml.Controls.Primitives;
using MudBlazor;
using Serilog;

namespace StreamTools.Components;
public partial class Login : ComponentBase
{
    [Inject] private ILogger<Login> Logger { get; init; }

    [Inject] private NavigationManager navigationManager { get; init; }
    

    [CascadingParameter] MudDialogInstance DialogInstance { get; set; }

    private string iframeUrl = "";
    private void Close()
    {
        DialogInstance.Close();
    }


    [JSInvokable]
    public static Task ReceiveMessage(string message)
    {
        Log.Debug(message);
        return Task.CompletedTask;
    }

    protected override async Task OnInitializedAsync()
    {
        iframeUrl = "https://pishock.com/#/login?openerOrigin=" + navigationManager.Uri;
        Log.Debug("IFrame URL is " + iframeUrl);
        Application.Current.OpenWindow(new PopupIframe(iframeUrl));
    }
}