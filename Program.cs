using System;
using System.Windows.Forms;

namespace Fahrzeug;

internal static class Program
{
    [STAThread]
    static void Main()
    {
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);

        // Deine grafische View (Fenster) starten
        Application.Run(new MainForm());
    }
}


