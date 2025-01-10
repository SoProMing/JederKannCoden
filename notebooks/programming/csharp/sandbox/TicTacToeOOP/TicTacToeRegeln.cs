using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToeOOP
{
    internal class TicTacToeRegeln
    {
        Spieler Spieler1 { get; set; }
        Spieler Spieler2 { get; set; }
        Spielfeld Feld { get; set; }

        public TicTacToeRegeln( Spieler Spieler1, Spieler Spieler2, Spielfeld Feld)
        {
            this.Spieler2 = Spieler2;
            this.Feld = Feld;  
            this.Spieler1 = Spieler1;
        }

        public void start()
        {
            const int maxRunden = 9;

            Feld.male();

            for (int runde = 0; runde < maxRunden; runde++) // Alternative: bool gameover = false; while (!gameover) {}
            {
                // Aktuellen Spieler anhand von Runde setzen (Spieler ändern, Variante 1)
                // if (runde % 2 == 0) aktuellerSpieler = spieler1; // % ist Modulo -> öffne Number_Systems.de.html
                // else aktuellerSpieler = spieler2;
//                eingabeAufforderung();

//                spielfeldZeichnen();

                // Sieg überprüfen -> öffne CSharp_Conditional_TicTacToe.de.html
                // Checke Zeilen

//                bool gewinner = prüfeGewinner();
/*                if (gewinner)
                {
                    Console.WriteLine("Spieler " + aktuellerSpieler + " hat gewonnen!");
                    Console.WriteLine("Drücke Enter, um das Programm zu beenden!");
                    Console.ReadLine();
                    return;
                }
*/
            }

        }
    }
}
