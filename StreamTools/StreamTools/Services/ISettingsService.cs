using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreamTools.Services
{
    public interface ISettingsService
    {
        string twitchAccessToken { get; set; }
        string googleAccessToken { get; set; }
        string googleRefreshToken { get; set; }
        string streamlootsToken { get; set; }
        bool hypeTrainEnabled { get; set; }
        int hypeTrainIntensityPerLevel { get; set; }
        int hypeTrainDurationPerLevel { get; set; }
        bool hypeTrainWarning { get; set; }

    }
}
