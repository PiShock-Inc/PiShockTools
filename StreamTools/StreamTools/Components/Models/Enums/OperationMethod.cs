using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreamTools.Components.Models.Enums
{
    public enum OperationMethod
    {
        [Display(Name = "Shock")]
        Shock,
        [Display(Name = "Vibration")]
        Vibrate,
        [Display(Name = "Sound")]
        Beep
    }
}
