using System;

namespace Fahrzeug;

public class Fahrer : Person
{
    public bool HatFuehrerschein { get; set; }

    public Fahrer(string vorname, string nachname, bool hatFuehrerschein)
    {
        Vorname = vorname;
        Nachname = nachname;
        HatFuehrerschein = hatFuehrerschein;
    }

    public void FahrerInfo()
    {
         Console.WriteLine($"Fahrer: {Vorname} {Nachname} (Führerschein: {HatFuehrerschein})");
    }
}
