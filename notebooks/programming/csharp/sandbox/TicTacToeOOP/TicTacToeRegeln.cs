using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToeOOP
{
    internal class TicTacToeRegeln
    {
        Spieler aktuellerSpieler = null;
        Spieler Spieler1 { get; set; }
        Spieler Spieler2 { get; set; }
        TTTSpielfeld Feld { get; set; }

        public TicTacToeRegeln( Spieler Spieler1, Spieler Spieler2, TTTSpielfeld Feld)
        {
            this.Spieler2 = Spieler2;
            this.Feld = Feld;  
            this.Spieler1 = Spieler1;
        }

        void eingabeAufforderung()
        {
            // Spielerzug -> öffne Console_ReadLine_Basics.de.html todo: Eingabe als Koordinate z.B. a1
            bool korrekteEingabe = false;
            do
            {
                Console.WriteLine($"Spieler {aktuellerSpieler.Name}: bitte gib die gewünschte Zeile an (z.B. \"1\"):");
                string eingabeZeile = Console.ReadLine();
                /* todo: Fehlerprüfung fehlt*/
                int zeile = int.Parse(eingabeZeile) - 1;

                Console.WriteLine($"Spieler {aktuellerSpieler.Name}: bitte gib die gewünschte Spalte an (z.B. \"A\"):");
                string eingabeSpalte = Console.ReadLine();
                eingabeSpalte = eingabeSpalte.ToUpper();
                /* todo: Fehlerprüfung fehlt*/
                // int spalte = eingabeSpalte[0] - 'A'; // Alternative ist:
                int spalte = 0;
                if (eingabeSpalte == "B") spalte = 1;
                else if (eingabeSpalte == "C") spalte = 2;

                Console.WriteLine($"Danke, die Eingabe enstpricht den Koordinaten: {zeile}, {spalte}.");
                if (Feld.prüfe(zeile, spalte) == null)
                {
                    Spielstein temp = new Spielstein();
                    temp.Wert = aktuellerSpieler.Kennzeichner;
                    Feld.setze(temp, zeile, spalte);
                    korrekteEingabe = true;
                }
                else
                {
                    Console.WriteLine($"Das Feld \"{eingabeZeile}, {eingabeSpalte}\" ist leider schon belegt, bitte versuches es gleich noch einmal!");
                }
            }
            while (!korrekteEingabe);
        }

        public void start()
        {
            const int maxRunden = 9;

            Feld.zeichne();
            aktuellerSpieler = Spieler1;

            for (int runde = 0; runde < maxRunden; runde++) // Alternative: bool gameover = false; while (!gameover) {}
            {
                // Aktuellen Spieler anhand von Runde setzen (Spieler ändern, Variante 1)
                // if (runde % 2 == 0) aktuellerSpieler = spieler1; // % ist Modulo -> öffne Number_Systems.de.html
                // else aktuellerSpieler = spieler2;
                eingabeAufforderung();

                Feld.zeichne();

                // Sieg überprüfen -> öffne CSharp_Conditional_TicTacToe.de.html
                bool gewinner = prüfeGewinner();
                if (gewinner)
                {
                    Console.WriteLine("Spieler " + aktuellerSpieler.Name + " hat gewonnen!");
                    Console.WriteLine("Drücke Enter, um das Programm zu beenden!");
                    Console.ReadLine();
                    return;
                }
                if (aktuellerSpieler == Spieler1)
                {
                    aktuellerSpieler = Spieler2;
                }
                else
                {
                    aktuellerSpieler = Spieler1;
                }
            }

        }

        private bool prüfeGewinner()
        {
            for (int i = 0; i < 3; i++)
            {
                if ((Feld.prüfeWert(i, 0) == Feld.prüfeWert(i, 1))
                    && (Feld.prüfeWert(i, 1) == Feld.prüfeWert(i, 2))
                    && (Feld.prüfeWert(i, 0) != " ")) return true;
            }
            for (int i = 0; i < 3; i++)
            {
                if ((Feld.prüfeWert(0, i) == Feld.prüfeWert(1, i))
                    && (Feld.prüfeWert(1, i) == Feld.prüfeWert(2, i))
                    && (Feld.prüfeWert(0, i) != " ")) return true;
            }
            if ((Feld.prüfeWert(0, 0) == Feld.prüfeWert(1, 1))
                    && (Feld.prüfeWert(1, 1) == Feld.prüfeWert(2, 2))
                    && (Feld.prüfeWert(0, 0) != " ")) return true;
            if ((Feld.prüfeWert(2, 0) == Feld.prüfeWert(1, 1))
                    && (Feld.prüfeWert(1, 1) == Feld.prüfeWert(0, 2))
                    && (Feld.prüfeWert(2, 0) != " ")) return true;

            return false;
        }
    }
}
