using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace StreamTools.Components.Models
{
	public static class EnumExtensions
	{
		public static string GetName(this Enum enumval)
		{
			try
			{
#pragma warning disable CS8603 // Possible null reference return.
				return enumval.GetType().GetMember(enumval.ToString()).FirstOrDefault()?.GetCustomAttribute<DisplayAttribute>()?.GetName();
#pragma warning restore CS8603 // Possible null reference return.
			} catch( Exception e)
			{
				return "";
			}
		}
	}
}
