using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToeOOP
{
    internal class TTTSpielfeld
    {
        Spielstein[,] theGameBoard;
        const string zeilenTrenner = "#---+---+---#";

        public TTTSpielfeld() {
            theGameBoard = new Spielstein[3, 3];
        }

        public void zeichne()
        {
            Console.Clear();

            // TTTSpielfeld anzeigen -> öffne Console_WriteLine_TicTacToe.de.html
            Console.WriteLine("  A   B   C");
            Console.WriteLine(zeilenTrenner);

            for (int i = 0; i < 3 /* todo: später optimieren */; i++)
            {
                Console.Write("|");
                for (int j = 0; j < 3 /* todo: später optimieren */; j++)
                {
                    string temp = (theGameBoard[i, j] == null) ? " " : theGameBoard[i, j].Wert;
                    /* if ( theGameBoard[i, j] == null) {
                     *     temp = " ";
                     * } else {
                     *     temp = theGameBoard[i, j].Wert
                     * }
                     */
                    Console.Write($" {temp} |");
                }
                Console.Write($" {i + 1}\n");
                Console.WriteLine(zeilenTrenner);
            }
        }

        // gibt false zurück, wenn Koordinate belegt
        public void setze(Spielstein stein, int x, int y)
        {
            theGameBoard[x, y] = stein;
        }

        public Spielstein prüfe(int x, int y)
        {
            if ( theGameBoard[x, y] != null )
                return theGameBoard[x, y];
            return null;
        }

        public string prüfeWert(int x, int y)
        {
            Spielstein temp = prüfe(x, y);
            return (temp == null) ? " " : temp.Wert;
        }
    }
}
