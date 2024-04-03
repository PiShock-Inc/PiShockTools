using StreamTools.Components.Models.Enums;

namespace StreamTools.Components.Models;

public sealed class Redeem
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }
    public List<Shocker> Shockers { get; set; } = [];
    public OperationMethod Method { get; set; }
    public int Intensity { get; set; }
    public int Duration { get; set; }
    public bool Warning { get; set; }

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