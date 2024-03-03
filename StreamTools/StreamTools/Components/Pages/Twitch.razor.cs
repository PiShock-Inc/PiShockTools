using Blazorise.DataGrid;
using Microsoft.AspNetCore.Components;
using StreamTools.Components.Models;
using StreamTools.Components.Models.Enums;

namespace StreamTools.Components.Pages;

public partial class Twitch : ComponentBase
{
    private bool[] isActive = [true, false, false];

    private void Previous()
    {
        if (isActive[0]) return;

        if (isActive[1])
        {
            SetActive("1");
            return;
        }
        if (isActive[2])
        {
            SetActive("2");
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
            SetActive("3");
            return;
        }

        if (isActive[2])
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
                isActive[2] = false;
                break;
            case "2":
                isActive[0] = false;
                isActive[1] = true;
                isActive[2] = false;
                break;
            case "3":
                isActive[0] = false;
                isActive[1] = false;
                isActive[2] = true;
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

    private DataGrid<Cheer> cheerGrid;

    private DataGrid<Redeem> redeemGrid;

    public async Task CheerNewRow()
    {
        await cheerGrid.New();
    }
    public async Task RedeemNewRow()
    {
        await redeemGrid.New();
    }


    //TEMP
    public static List<Shocker> TestShockers = new()
    {
        new("Shocker 1", "1"),
        new("Shocker 2", "2"),
        new("Shocker 3", "3"),
        new("Shocker 4", "4")
    };

    public List<Cheer> TestData = new()
    {
        //new("", [TestShockers[1],TestShockers[0]], 100, OperationMethod.Vibrate, 69,10, true),
        //new("shock", [TestShockers[2], TestShockers[3]], 500, OperationMethod.Shock, 25, 1, false)
    };

    public List<Redeem> TestDataRedeem = new List<Redeem>
    {
        new("shockme", "Redeem this to shock me", [TestShockers[1], TestShockers[2]], OperationMethod.Shock, 50, 69, true),
        new("vibrate", "Redeem this to vibrate the collar", [TestShockers[3]], OperationMethod.Vibrate, 100, 10, true),
        new("beep", "Rdeem this to make the collar beep", [TestShockers[0], TestShockers[1], TestShockers[2], TestShockers[3]], OperationMethod.Beep, 100, 1, false)
    };
    public class CheerData
    {
        public string keyword;
        public string[] shockers;
        public int minimum;
        public OperationMethod method;
        public int intensity;
        public int duration;

        public CheerData()
        {
        }
    }
    public void processListChange(List<string> data)
    {
        Console.WriteLine(string.Join(", ", data));

    }
}