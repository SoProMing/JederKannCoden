using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToeOOP
{
    internal class Spielfeld
    {
        Spielstein[,] data;
        const string zeilenTrenner = "#---+---+---#";

        public Spielfeld() {
            data = new Spielstein[3, 3];
        }

        public void male()
        {
            Console.Clear();

            // Spielfeld anzeigen -> öffne Console_WriteLine_TicTacToe.de.html
            Console.WriteLine("  A   B   C");
            Console.WriteLine(zeilenTrenner);

            for (int i = 0; i < 3 /* todo: später optimieren */; i++)
            {
                Console.Write("|");
                for (int j = 0; j < 3 /* todo: später optimieren */; j++)
                {
                    string temp = (data[i, j] == null) ? " " : data[i, j].Wert;
                    Console.Write($" {temp} |");
                }
                Console.Write($" {i + 1}\n");
                Console.WriteLine(zeilenTrenner);
            }
        }

        // gibt false zurück, wenn Koordinate belegt
        public bool setze(Spielstein stein, int x, int y)
        {
            return false;
        }

        public Spielstein prüfe(int x, int y)
        {
            return null;
        }
    }
}
