using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace StreamTools.Components.Models;

public static class EnumExtensions
{
    public static string GetName(this Enum enumval)
    {
        try
        {
#pragma warning disable CS8603 // Possible null reference return.
            return enumval
                .GetType()
                .GetMember(enumval.ToString())
                .FirstOrDefault()
                ?.GetCustomAttribute<DisplayAttribute>()
                ?.GetName();
#pragma warning restore CS8603 // Possible null reference return.
        }
        catch (Exception)
        {
            return "";
        }
    }
}
