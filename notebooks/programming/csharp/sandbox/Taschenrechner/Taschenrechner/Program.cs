namespace Taschenrechner
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            Console.WriteLine($"Summe von 5 und 10 ist: {addiere(5, 10)}");
        }

        public static int addiere(int a, int b)
        {
            return a + b;
        }
    }
}
