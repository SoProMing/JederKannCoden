namespace TicTacToeOOP
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Spieler spieler1 = new Spieler("Name1", "X");
            Spieler spieler2 = new Spieler("Name2", "O");

            Spielfeld feld = new Spielfeld();

            TicTacToeRegeln spiel = new TicTacToeRegeln(spieler1, spieler2, feld);
            spiel.start();
        }
    }
}
