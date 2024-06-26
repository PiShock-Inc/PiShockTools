﻿using StreamTools.Components.Models.Enums;

namespace StreamTools.Components.Models;

public sealed class Cheer
{
    public int Id { get; set; }
    public string Keyword { get; set; }
    public List<Shocker> Shockers { get; set; } = [];
    public int MinimumCheer { get; set; }
    public OperationMethod Method { get; set; }
    public int Intensity { get; set; }
    public int Duration { get; set; }
    public bool Warning { get; set; }

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