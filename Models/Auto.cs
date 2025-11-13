using System;

namespace Fahrzeug;

public class Auto
{
    public string autoMarke { get; set; }
    public string fahrer { get; set; }
    public string besitzer { get; set; }

    public Auto(string autoMarke, string fahrer, string besitzer)
    {
        this.autoMarke = autoMarke;
        this.fahrer = fahrer;
        this.besitzer = besitzer;
    }

    public void autoInfo()
    {
        Console.WriteLine($"Auto Marke: {autoMarke}");
        Console.WriteLine($"Besitzer: {besitzer}");
    }
}