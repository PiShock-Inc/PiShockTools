using StreamTools.Components.Models.Enums;

namespace StreamTools.Components.Models;
public sealed class SuperChat
{
    public int Id { get; set; }
    public string Keyword { get; set; }
    public List<Shocker> Shockers { get; set; } = [];
    public int MinimumAmount { get; set; }
    public OperationMethod Method { get; set; }
    public int Intensity { get; set; }
    public int Duration { get; set; }
    public bool Warning { get; set; }

    public SuperChat(string keyword, List<Shocker> shockers, int minimumAmount, OperationMethod method, int intensity, int duration, bool warning)
    {
        Keyword = keyword;
        Shockers = shockers;
        MinimumAmount = minimumAmount;
        Method = method;
        Intensity = intensity;
        Duration = duration;
        Warning = warning;
    }
}