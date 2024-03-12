using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace StreamTools.Components.Layout;
public partial class MainLayout : LayoutComponentBase
{
    [Inject] public IDialogService DialogService { get; set; }


    private Task OpenLoginModalAsync()
    => DialogService.ShowAsync<Login>();

    bool open = false;
    void ToggleDrawer()
    {
        open = !open;
    }
}