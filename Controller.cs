using Microsoft.AspNetCore.Mvc;
using System;

namespace Fahrzeug;

public class Controller
{
    public IActionResult Index()
    {
        // Deine Daten-Erzeugung 1:1 wie in deinem Controller.start()
        var fahrer = new Fahrer("Mazlum", "Sevim", true);
        var kunde  = new Kunde("Anna", "Schmidt");
        var auto   = new Auto("Mercedes",
                              $"{fahrer.Vorname} {fahrer.Nachname}",
                              $"{fahrer.Vorname} {fahrer.Nachname}");

        // ViewModel befüllen (für die View)
        var vm = new ViewModel
        {
            Marke    = auto.autoMarke,
            Fahrer   = auto.fahrer,
            Besitzer = auto.besitzer
        };

        // (Optional) deinen Console-Controller ausführen – Ausgabe erscheint nur in der Konsole:
        // Controller.start();

        return View(vm);
    }
}