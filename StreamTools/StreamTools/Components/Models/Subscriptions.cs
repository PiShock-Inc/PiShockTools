using StreamTools.Components.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreamTools.Components.Models
{

    public class Subscriptions
    {
        public int Id { get; set; }
        public int Amount { get; set; }

        public SubscriptionTiers Tier { get; set; }
        public List<Shocker> shockers { get; set; }
        public OperationMethod Method { get; set; }
        public int Intensity { get; set; }
        public int Duration { get; set; }
        public bool Warning { get; set; }
    }
}
