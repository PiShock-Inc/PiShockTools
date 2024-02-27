using StreamTools.Components.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreamTools.Components.Models
{

	public class Redeem
	{
		string Name;
		string Description;
		List<Shocker> Shockers;
		OperationMethod Method;
		int Intensity;
		int Duration;
		bool Warning;

		public Redeem()
		{
		}

		public Redeem(string name, string description, List<Shocker> shockers, OperationMethod method, int intensity, int duration, bool warning)
		{
			Name = name;
			Description = description;
			Shockers = shockers;
			Method = method;
			Intensity = intensity;
			Duration = duration;
			Warning = warning;
		}
	}
}
