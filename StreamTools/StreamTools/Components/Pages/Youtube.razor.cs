using Blazorise;
using Blazorise.DataGrid;
using Microsoft.AspNetCore.Components;
using StreamTools.Components.Models;
using StreamTools.Components.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        private List<object> MethodItems = Enum.GetValues<OperationMethod>().Select(x => (object)x).ToList();

        private DataGrid<SuperChat> superchatGrid;

        public async Task SuperchatCreateRow()
        {
            await superchatGrid.New();
        }

        public static List<Shocker> TestShockers =
        [
        new("Shocker 1", "1"),
        new("Shocker 2", "2"),
        new("Shocker 3", "3"),
        new("Shocker 4", "4")
        ];

        public List<SuperChat> TestData = new()
        {
        new("", [TestShockers[1],TestShockers[0]], 100, OperationMethod.Vibrate, 69,10, true),
        new("shock", [TestShockers[2], TestShockers[3]], 500, OperationMethod.Shock, 25, 1, false)
        };
    }
}
