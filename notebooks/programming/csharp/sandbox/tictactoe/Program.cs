namespace tictactoe;

class Program
{
    static string aktuellerSpieler = "";
    const string zeilenTrenner = "#---+---+---#";
    // Spielfeld initialisieren -> öffne CSharp_Loops_TicTacToe.de.html in Projektmappenelementen (Rechtsklick in Browser anzeigen)
    static string[,] spielfeld = {
                                { " ", " ", " " },
                                { " ", " ", " " },
                                { " ", " ", " " }
                              };

    static void spielfeldZeichnen()
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
                Console.Write($" {spielfeld[i, j]} |");
            }
            Console.Write($" {i + 1}\n");
            Console.WriteLine(zeilenTrenner);
        }
        /***************************************************************/

    }

    static void eingabeAufforderung()
    {
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
    }

    static void Main(string[] args)
    {
        const int maxRunden = 9;

        // Spielablauf  -> öffne CSharp_Loops_TicTacToe.de.html
        string spieler1 = "X";
        string spieler2 = "O";
        aktuellerSpieler = spieler1;

        spielfeldZeichnen();

        for (int runde = 0; runde < maxRunden; runde++) // Alternative: bool gameover = false; while (!gameover) {}
        {
            // Aktuellen Spieler anhand von Runde setzen (Spieler ändern, Variante 1)
            // if (runde % 2 == 0) aktuellerSpieler = spieler1; // % ist Modulo -> öffne Number_Systems.de.html
            // else aktuellerSpieler = spieler2;
            eingabeAufforderung();

            spielfeldZeichnen();

            // Sieg überprüfen -> öffne CSharp_Conditional_TicTacToe.de.html
            // Checke Zeilen

            bool gewinner = prüfeGewinner();
            if (gewinner)
            {
                Console.WriteLine("Spieler " + aktuellerSpieler + " hat gewonnen!");
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

    static bool prüfeGewinner2()
    {
        int[,,] winCombinations = {
            {{ 0, 0 }, { 0, 1 }, { 0, 2 }}, // row 1
            {{ 1, 0 }, { 1, 1 }, { 1, 2 }}, // row 2
            {{ 2, 0 }, { 2, 1 }, { 2, 2 }}, // row 3
            {{ 0, 0 }, { 1, 0 }, { 2, 0 }}, // column a
            {{ 0, 1 }, { 1, 1 }, { 2, 1 }}, // column b
            {{ 0, 2 }, { 1, 2 }, { 2, 2 }}, // column c
            {{ 0, 0 }, { 1, 1 }, { 2, 2 }}, // diagonal 1a > 3c
            {{ 2, 0 }, { 1, 1 }, { 0, 2 }}  // diagonal 1c > 3a
        };

        for (int i = 0; i < 8; i++)
        {
            if ((spielfeld[winCombinations[i,0,0], winCombinations[i, 0, 1]] == spielfeld[winCombinations[i, 1, 0], winCombinations[i, 1, 1]])
                && (spielfeld[winCombinations[i, 1, 0], winCombinations[i, 1, 1]] == spielfeld[winCombinations[i, 2, 0], winCombinations[i, 2, 1]])
                && (spielfeld[winCombinations[i, 0, 0], winCombinations[i, 0, 1]] != " ")) return true;
        }

        return false;
    }

    static bool prüfeGewinner()
    {
        for (int i = 0; i < 3; i++)
        {
            if ((spielfeld[i, 0] == spielfeld[i, 1])
                && (spielfeld[i, 1] == spielfeld[i, 2])
                && (spielfeld[i, 0] != " ")) return true;
        }
        for (int i = 0; i < 3; i++)
        {
            if ((spielfeld[0, i] == spielfeld[1, i])
                && (spielfeld[1, i] == spielfeld[2, i])
                && (spielfeld[0, i] != " ")) return true;
        }
        if ((spielfeld[0, 0] == spielfeld[1, 1])
                && (spielfeld[1, 1] == spielfeld[2, 2])
                && (spielfeld[0, 0] != " ")) return true;
        if ((spielfeld[2, 0] == spielfeld[1, 1])
                && (spielfeld[1, 1] == spielfeld[0, 2])
                && (spielfeld[2, 0] != " ")) return true;

        return false;
    }
}
