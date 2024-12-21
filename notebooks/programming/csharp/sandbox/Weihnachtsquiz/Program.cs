using System;

namespace OOPQuiz
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Willkommen zum Quiz! Lösen Sie alle Aufgaben, um die geheime Nachricht zu entschlüsseln.\n");

            // Starten des Quiz
            Quiz quiz = new Quiz();
            quiz.Start();
        }
    }

    abstract class QuizBase
    {
        protected string encryptedMessage = "Îúçàí¨ßíáàæéëàüíæ¨ýæì¨ïýüíæ¨Úýüûëà©";
        protected char xorKey = '\x88';

        // Abstrakte Methode, die von den abgeleiteten Klassen implementiert werden muss
        public abstract void Start();

        // Methode zur XOR-Entschlüsselung
        protected string DecryptMessage(string encrypted, char key)
        {
            char[] decrypted = new char[encrypted.Length];
            for (int i = 0; i < encrypted.Length; i++)
            {
                decrypted[i] = (char)(encrypted[i] ^ key);
            }
            return new string(decrypted);
        }
    }

    class Quiz : QuizBase
    {
        public override void Start()
        {
            if (Question1() && Question2() && Question3())
            {
                Console.WriteLine("\nGratulation! Sie haben alle Aufgaben gelöst. Die entschlüsselte Nachricht lautet:");
                Console.WriteLine(DecryptMessage(encryptedMessage, xorKey));
            }
            else
            {
                Console.WriteLine("\nSie haben nicht alle Aufgaben gelöst. Versuchen Sie es erneut!");
            }
        }

        private bool Question1()
        {
            Console.WriteLine("Aufgabe 1: Was ist das Ergebnis von 3 + 5?");
            Console.Write("Antwort: ");
            string input = Console.ReadLine();
            return input == "8";
        }

        private bool Question2()
        {
            Console.WriteLine("Aufgabe 2: Schreiben Sie die Methode `AddNumbers` so, dass sie zwei Zahlen addiert und das Ergebnis zurückgibt.");
            Console.WriteLine("Hinweis: Die Methode ist in der Klasse `Helper` definiert.");

            // Simulation: Methode ist korrekt implementiert
            Helper helper = new Helper();
            return helper.AddNumbers(3, 7) == 10;
        }

        private bool Question3()
        {
            Console.WriteLine("Aufgabe 3: Schreiben Sie die Methode `GetGreeting` so, dass sie den Text 'Hallo, [Name]!' zurückgibt.");
            Console.WriteLine("Hinweis: Die Methode ist in der Klasse `Helper` definiert.");

            // Simulation: Methode ist korrekt implementiert
            Helper helper = new Helper();
            return helper.GetGreeting("Welt") == "Hallo, Welt!";
        }
    }

    class Helper
    {
        // Methode 1: Leere Methode, die implementiert werden muss
        public int AddNumbers(int a, int b)
        {
            // Implementieren Sie diese Methode
            return 0; // Platzhalter
        }

        // Methode 2: Leere Methode, die implementiert werden muss
        public string GetGreeting(string name)
        {
            // Implementieren Sie diese Methode
            return string.Empty; // Platzhalter
        }
    }
}
