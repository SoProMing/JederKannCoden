namespace TicTacToeOOP
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Spieler spieler1 = new Spieler("Alice", "X");
            Spieler spieler2 = new Spieler("Bob", "O");

            TTTSpielfeld feld = new TTTSpielfeld();

            TicTacToeRegeln spiel = new TicTacToeRegeln(spieler1, spieler2, feld);
            spiel.start();
        }
    }
}
