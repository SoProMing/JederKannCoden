namespace AutosDieserWelt
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            // Auto meinErstesAuto = new Auto("rot", 3, 4); Geht nicht mehr, da abstract
            EAuto meinErstesEAuto = new EAuto( 150, 5, 5 );

            meinErstesEAuto.laden(10);

            Console.WriteLine($"Farbe meines E-Autos: {meinErstesEAuto.Farbe}");

            Console.WriteLine($"Weltweite Anzahl JEMALS hergestellter Autos: {Auto.SummeAllerAutos}!");

            meinErstesEAuto.fahren(100);
            Console.WriteLine($"Kilometerstand meines Wagens: {meinErstesEAuto.Kilometerstand} km.");
        }
    }
}
