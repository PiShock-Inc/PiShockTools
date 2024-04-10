using Microsoft.AspNetCore.Components;
using MudBlazor;
using StreamTools.Components.Models;
using StreamTools.Components.Models.Enums;

namespace StreamTools.Components.Pages
{
    public partial class Youtube : ComponentBase
    {
        private bool[] isActive = [true, false];

        private void Previous()
        {
            if (isActive[0]) return;

            if (isActive[1])
            {
                SetActive("1");
                return;
            }
        }

        private void Next()
        {
            if (isActive[0])
            {
                SetActive("2");
                return;
            }

            if (isActive[1])
            {
                return;
            }
        }

        private void SetActive(string idx)
        {
            switch (idx)
            {
                case "1":
                    isActive[0] = true;
                    isActive[1] = false;
                    break;
                case "2":
                    isActive[0] = false;
                    isActive[1] = true;
                    break;
                default:
                    break;
            }
        }
        private bool IsNotActive(int id)
        {
            return !isActive[id];
        }

        private MudDataGrid<SuperChat> superChatDatagrid;

        private async Task SuperchatCreateRow()
        {
            await superChatDatagrid.SetEditingItemAsync(new SuperChat());
        }

        public static List<Shocker> TestShockers =
        [
        new("Shocker 1", "1"),
        new("Shocker 2", "2"),
        new("Shocker 3", "3"),
        new("Shocker 4", "4")
        ];

        private void OnShockerSelectItemsChanged(SuperChat item, IEnumerable<Shocker> newValues)
        {
            item.Shockers = newValues.ToList();
        }

        public List<SuperChat> TestData = new()
        {
        new("", [TestShockers[1],TestShockers[0]], 100, OperationMethod.Vibrate, 69,10, true),
        new("shock", [TestShockers[2], TestShockers[3]], 500, OperationMethod.Shock, 25, 1, false)
        };
    }
}
