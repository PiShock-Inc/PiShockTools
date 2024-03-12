using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Logging;
using MudBlazor;

namespace StreamTools.Components;
public partial class Login : ComponentBase
{
    [Inject] private ILogger<Login> Logger { get; init; }

    [CascadingParameter] MudDialogInstance DialogInstance { get; set; }

    private string email = string.Empty;
    private string password = string.Empty;

    private void Close()
    {
        DialogInstance.Close();
    }
}