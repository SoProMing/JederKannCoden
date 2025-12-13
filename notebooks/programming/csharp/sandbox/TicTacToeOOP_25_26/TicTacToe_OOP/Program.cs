namespace TicTacToe_OOP
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World, wir spielen TicTacToe!");
            var unserSpielfeld = new Spielfeld(3, 3);
            unserSpielfeld.Zeichnen();
        }
    }
}
