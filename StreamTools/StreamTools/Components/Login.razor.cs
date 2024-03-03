using Blazorise;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Logging;

namespace StreamTools.Components;
public partial class Login : ComponentBase
{
    [Inject] private ILogger<Login> Logger { get; init; }

    private Modal lazyReloadModalRef;

    private string email = string.Empty;
    private string password = string.Empty;
}