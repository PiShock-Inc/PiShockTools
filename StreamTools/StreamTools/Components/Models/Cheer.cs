using StreamTools.Components.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreamTools.Components.Models
{
    public class Cheer(string keyword, int[] shockers, int minimumCheer, OperationMethod method, int intensity, int duration)
    {
        public string Keyword = keyword;
        public int[] Shockers = shockers;
        public int MinimumCheer = minimumCheer;
        public OperationMethod Method = method;
        public int Intensity = intensity;
        public int Duration = duration;
    }
}
