using System;

namespace Fahrzeug;

public class Controller
{
    // Variante mit festen Daten (falls du sie noch brauchst)
    public ViewModel ErstelleStandardView()
    {
        var fahrer = new Fahrer("Mazlum", "Sevim", true);
        var kunde  = new Kunde("Anna", "Schmidt");
        var auto   = new Auto("Mercedes",
                              $"{fahrer.Vorname} {fahrer.Nachname}",
                              $"{fahrer.Vorname} {fahrer.Nachname}");

        return new ViewModel
        {
            Marke    = auto.autoMarke,
            Fahrer   = auto.fahrer,
            Besitzer = auto.besitzer
        };
    }

    // Diese Methode benutzen wir gleich in der GUI
    public ViewModel ErstelleView(Fahrer fahrer, Auto auto)
    {
        return new ViewModel
        {
            Marke    = auto.autoMarke,
            Fahrer   = $"{fahrer.Vorname} {fahrer.Nachname}",
            Besitzer = auto.besitzer
        };
    }
}