namespace tictactoe;

class Program
{
    static void Main(string[] args)
    {
        const int maxRunden = 9;
        const string zeilenTrenner = "#---+---+---#";

        // Spielfeld initialisieren -> öffne CSharp_Loops_TicTacToe.de.html in Projektmappenelementen (Rechtsklick in Browser anzeigen)
        string[,] spielfeld = {
                                { " ", " ", " " },
                                { " ", " ", " " },
                                { " ", " ", " " }
                              };

        // Spielablauf  -> öffne CSharp_Loops_TicTacToe.de.html
        string spieler1 = "X";
        string spieler2 = "O";
        string aktuellerSpieler = spieler1;

        for (int runde = 0; runde < maxRunden; runde++) // Alternative: bool gameover = false; while (!gameover) {}
        {
            // Aktuellen Spieler anhand von Runde setzen (Spieler ändern, Variante 1)
            // if (runde % 2 == 0) aktuellerSpieler = spieler1; // % ist Modulo -> öffne Number_Systems.de.html
            // else aktuellerSpieler = spieler2;

            // Console.Clear();

            // Spielfeld anzeigen -> öffne Console_WriteLine_TicTacToe.de.html
            Console.WriteLine("  A   B   C");
            Console.WriteLine(zeilenTrenner);

            for (int i = 0; i < 3 /* todo: später optimieren */; i++)
            {
                Console.Write("|");
                for (int j = 0; j < 3 /* todo: später optimieren */; j++)
                {
                    Console.Write($" {spielfeld[i, j]} |");
                }
                Console.Write($" {i + 1}\n");
                Console.WriteLine(zeilenTrenner);
            }
            /***************************************************************/

            // Spielerzug -> öffne Console_ReadLine_Basics.de.html todo: Eingabe als Koordinate z.B. a1
            bool korrekteEingabe = false;
            do
            {
                Console.WriteLine($"Spieler {aktuellerSpieler}: bitte gib die gewünschte Zeile an (z.B. \"1\"):");
                string eingabeZeile = Console.ReadLine();
                /* todo: Fehlerprüfung fehlt*/
                int zeile = int.Parse(eingabeZeile) - 1;

                Console.WriteLine($"Spieler {aktuellerSpieler}: bitte gib die gewünschte Spalte an (z.B. \"A\"):");
                string eingabeSpalte = Console.ReadLine();
                eingabeSpalte = eingabeSpalte.ToUpper();
                /* todo: Fehlerprüfung fehlt*/
                // int spalte = eingabeSpalte[0] - 'A'; // Alternative ist:
                int spalte = 0;
                if (eingabeSpalte == "B") spalte = 1;
                else if (eingabeSpalte == "C") spalte = 2;

                Console.WriteLine($"Danke, die Eingabe enstpricht den Koordinaten: {zeile}, {spalte}.");
                if (spielfeld[zeile, spalte] == " ")
                {
                    spielfeld[zeile, spalte] = aktuellerSpieler;
                    korrekteEingabe = true;
                }
                else
                {
                    Console.WriteLine($"Das Feld \"{eingabeZeile}, {eingabeSpalte}\" ist leider schon belegt, bitte versuches es gleich noch einmal!");
                }
            }
            while (!korrekteEingabe);

            // Sieg überprüfen -> öffne CSharp_Conditional_TicTacToe.de.html
            bool gewinner = false;
            // Checke Zeilen

            for (int i = 0; i < 3; i++)
            {
                if ((spielfeld[i, 0] == spielfeld[i, 1])
                    && (spielfeld[i, 1] == spielfeld[i, 2])
                    && (spielfeld[i, 0] != " ")) gewinner = true;
            }
            if (gewinner)
            {
                Console.WriteLine("Spieler " + aktuellerSpieler + "hat gewonnen!");
                Console.WriteLine("Drücke Enter, um das Programm zu beenden!");
                Console.ReadLine();
                return;
            }
            

            // Unentschieden überprüfen -> öffne CSharp_Conditional_TicTacToe.de.html

            // Spieler wechseln -> öffne CSharp_Other_Operators_Basics.de.html (Spieler ändern, Variante 2)
            if (aktuellerSpieler == spieler1) aktuellerSpieler = spieler2;
            else aktuellerSpieler = spieler1;
        }
    }
}
