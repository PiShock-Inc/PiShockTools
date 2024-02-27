using StreamTools.Components.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreamTools.Components.Models
{

    public class Cheer
    {
        public string Keyword;
        public List<Shocker> Shockers;
        public int MinimumCheer;
        public OperationMethod Method;
        public int Intensity;
        public int Duration;
		public bool Warning;

		public Cheer() { }

		public Cheer(string keyword, List<Shocker> shockers, int minimumCheer, OperationMethod method, int intensity, int duration, bool warning)
		{
			Keyword = keyword;
			Shockers = shockers;
			MinimumCheer = minimumCheer;
			Method = method;
			Intensity = intensity;
			Duration = duration;
			Warning = warning;
		}
	}
}
