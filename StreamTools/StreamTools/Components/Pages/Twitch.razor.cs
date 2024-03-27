﻿
using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;
using MudBlazor;
using StreamTools.Components.Models;
using StreamTools.Components.Models.Enums;
using StreamTools.Data;
using StreamTools.Services;

namespace StreamTools.Components.Pages;

public partial class Twitch : ComponentBase
{

    [Inject]
    private StreamToolsContext dbContext { get; set; } 

    private bool[] isActive = [true, false, false];

    private bool _processing = false;

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

    private void OnShockerSelectItemsChanged(Cheer item, IEnumerable<Shocker> newValues)
    {
        item.Shockers = newValues.ToList();
    }
    private void OnShockerSelectItemsChanged(Redeem item, IEnumerable<Shocker> newValues)
    {
        item.Shockers = newValues.ToList();
    }

    private MudDataGrid<Cheer> mudDataGridCheer;
    private MudDataGrid<Redeem> mudDataGridRedeem;

    private async Task CreateNewCheerRow()
    {
        await mudDataGridCheer.SetEditingItemAsync(new());
    }
    private async Task CreateNewRedeemRow()
    {
        await mudDataGridRedeem.SetEditingItemAsync(new());
    }


    //TEMP
    public static List<Shocker> TestShockers = new()
    {
        new("Shocker 1", "1"),
        new("Shocker 2", "2"),
        new("Shocker 3", "3"),
        new("Shocker 4", "4")
    };

    public List<Cheer> DataCheers = new()
    {
        new("", [TestShockers[1],TestShockers[0]], 100, OperationMethod.Vibrate, 69,10, true),
        new("shock", [TestShockers[2], TestShockers[3]], 500, OperationMethod.Shock, 25, 1, false)
    };

    public List<Redeem> DataRedeems = new List<Redeem>
    {
        new("shockme", "Redeem this to shock me", [TestShockers[1], TestShockers[2]], OperationMethod.Shock, 50, 69, true),
        new("vibrate", "Redeem this to vibrate the collar", [TestShockers[3]], OperationMethod.Vibrate, 100, 10, true),
        new("beep", "Rdeem this to make the collar beep", [TestShockers[0], TestShockers[1], TestShockers[2], TestShockers[3]], OperationMethod.Beep, 100, 1, false)
    };

    public bool isLoading = true;

    private async Task twitchConnectButton()
    {
        _processing = true;
        _processing = await TwitchService.LoginTwitch();
        
    }

    protected override async Task OnInitializedAsync()
    {
        DataRedeems = await dbContext.Redeems.ToListAsync();
        DataCheers = await dbContext.Cheers.ToListAsync();
        isLoading = false;
    }
}