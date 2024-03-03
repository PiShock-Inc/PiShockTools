using Blazorise;
using Microsoft.AspNetCore.Components;

namespace StreamTools.Components.Layout;
public partial class MainLayout : LayoutComponentBase
{
    [Inject] public IModalService ModalService { get; set; }


    private Task OpenLoginModalAsync()
    => ModalService.Show<Login>("Login To Your Account");
}