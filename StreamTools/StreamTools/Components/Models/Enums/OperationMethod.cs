using System.ComponentModel.DataAnnotations;

namespace StreamTools.Components.Models.Enums;

public enum OperationMethod
{
    [Display(Name = "Shock")]
    Shock,
    [Display(Name = "Vibration")]
    Vibrate,
    [Display(Name = "Sound")]
    Beep
}
