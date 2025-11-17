using System;
using System.Windows.Forms;

namespace Fahrzeug;

public class MainForm : Form
{
    // Eingabe-Felder Fahrer
    private TextBox txtFahrerVorname;
    private TextBox txtFahrerNachname;
    private CheckBox chkHatFuehrerschein;

    // Eingabe-Felder Kunde
    private TextBox txtKundeVorname;
    private TextBox txtKundeNachname;

    // Eingabe-Felder Auto / Besitzer
    private TextBox txtAutoMarke;
    private TextBox txtBesitzer;

    // Button + Ausgabe
    private Button btnAnzeigen;
    private TextBox txtAusgabe;

    public MainForm()
    {
        Text = "Fahrzeug / Fahrer / Kunde";
        Width = 600;
        Height = 450;
        StartPosition = FormStartPosition.CenterScreen;

        InitControls();
    }

    private void InitControls()
    {
        // ======= Fahrer-Bereich =======
        var lblFahrerTitel = new Label
        {
            Text = "Fahrer",
            Left = 20,
            Top = 10,
            AutoSize = true
        };

        var lblFahrerVorname = new Label
        {
            Text = "Vorname:",
            Left = 20,
            Top = 40,
            AutoSize = true
        };

        txtFahrerVorname = new TextBox
        {
            Left = 120,
            Top = 38,
            Width = 150
        };

        var lblFahrerNachname = new Label
        {
            Text = "Nachname:",
            Left = 20,
            Top = 70,
            AutoSize = true
        };

        txtFahrerNachname = new TextBox
        {
            Left = 120,
            Top = 68,
            Width = 150
        };

        chkHatFuehrerschein = new CheckBox
        {
            Text = "Hat Führerschein",
            Left = 120,
            Top = 100,
            AutoSize = true
        };

        // ======= Kunde-Bereich =======
        var lblKundeTitel = new Label
        {
            Text = "Kunde",
            Left = 320,
            Top = 10,
            AutoSize = true
        };

        var lblKundeVorname = new Label
        {
            Text = "Vorname:",
            Left = 320,
            Top = 40,
            AutoSize = true
        };

        txtKundeVorname = new TextBox
        {
            Left = 420,
            Top = 38,
            Width = 150
        };

        var lblKundeNachname = new Label
        {
            Text = "Nachname:",
            Left = 320,
            Top = 70,
            AutoSize = true
        };

        txtKundeNachname = new TextBox
        {
            Left = 420,
            Top = 68,
            Width = 150
        };

        // ======= Auto-Bereich =======
        var lblAutoTitel = new Label
        {
            Text = "Auto",
            Left = 20,
            Top = 150,
            AutoSize = true
        };

        var lblAutoMarke = new Label
        {
            Text = "Marke:",
            Left = 20,
            Top = 180,
            AutoSize = true
        };

        txtAutoMarke = new TextBox
        {
            Left = 120,
            Top = 178,
            Width = 150
        };

        var lblBesitzer = new Label
        {
            Text = "Besitzer:",
            Left = 20,
            Top = 210,
            AutoSize = true
        };

        txtBesitzer = new TextBox
        {
            Left = 120,
            Top = 208,
            Width = 150
        };

        // ======= Button =======
        btnAnzeigen = new Button
        {
            Text = "Daten anzeigen",
            Left = 20,
            Top = 250,
            Width = 250
        };
        btnAnzeigen.Click += BtnAnzeigen_Click;

        // ======= Ausgabe-Bereich =======
        var lblAusgabe = new Label
        {
            Text = "Zusammenfassung:",
            Left = 20,
            Top = 290,
            AutoSize = true
        };

        txtAusgabe = new TextBox
        {
            Left = 20,
            Top = 320,
            Width = 550,
            Height = 80,
            Multiline = true,
            ReadOnly = true,
            ScrollBars = ScrollBars.Vertical
        };

        // Controls hinzufügen
        Controls.Add(lblFahrerTitel);
        Controls.Add(lblFahrerVorname);
        Controls.Add(txtFahrerVorname);
        Controls.Add(lblFahrerNachname);
        Controls.Add(txtFahrerNachname);
        Controls.Add(chkHatFuehrerschein);

        Controls.Add(lblKundeTitel);
        Controls.Add(lblKundeVorname);
        Controls.Add(txtKundeVorname);
        Controls.Add(lblKundeNachname);
        Controls.Add(txtKundeNachname);

        Controls.Add(lblAutoTitel);
        Controls.Add(lblAutoMarke);
        Controls.Add(txtAutoMarke);
        Controls.Add(lblBesitzer);
        Controls.Add(txtBesitzer);

        Controls.Add(btnAnzeigen);
        Controls.Add(lblAusgabe);
        Controls.Add(txtAusgabe);
    }

    private void BtnAnzeigen_Click(object? sender, EventArgs e)
    {
        // Simple Pflichtfelder-Prüfung
        if (string.IsNullOrWhiteSpace(txtFahrerVorname.Text) ||
            string.IsNullOrWhiteSpace(txtFahrerNachname.Text) ||
            string.IsNullOrWhiteSpace(txtAutoMarke.Text))
        {
            MessageBox.Show(
                "Bitte mindestens Fahrer (Vor- und Nachname) und Auto-Marke eingeben.",
                "Eingabe fehlt",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);
            return;
        }

        // Wenn Besitzer leer ist, nehmen wir den Fahrer als Besitzer
        var besitzerName = string.IsNullOrWhiteSpace(txtBesitzer.Text)
            ? $"{txtFahrerVorname.Text} {txtFahrerNachname.Text}"
            : txtBesitzer.Text;

        // ==== Deine bestehenden Klassen benutzen ====
        var fahrer = new Fahrer(txtFahrerVorname.Text,
                                txtFahrerNachname.Text,
                                chkHatFuehrerschein.Checked);

        var kunde = new Kunde(txtKundeVorname.Text,
                              txtKundeNachname.Text);

        var auto = new Auto(txtAutoMarke.Text,
                            $"{fahrer.Vorname} {fahrer.Nachname}",
                            besitzerName);

        // Controller + ViewModel einbinden
        var controller = new Controller();
        var vm = controller.ErstelleView(fahrer, auto);

        var fuehrerscheinText = fahrer.HatFuehrerschein ? "Ja" : "Nein";

        var info =
            $"Fahrer: {fahrer.Vorname} {fahrer.Nachname} (Führerschein: {fuehrerscheinText}){Environment.NewLine}" +
            $"Kunde : {kunde.Vorname} {kunde.Nachname}{Environment.NewLine}" +
            $"Auto  : {vm.Marke}{Environment.NewLine}" +
            $"Besitzer : {vm.Besitzer}";

        txtAusgabe.Text = info;
    }
}