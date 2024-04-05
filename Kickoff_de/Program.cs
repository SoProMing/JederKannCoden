// Code passend zum Video https://youtu.be/kx0V9AgG8Cs?si=lDm0lwI1fupqX2JH

using System;
					
public class Program
{
	// Funktion mit    Funktionsname            Parameter
	//                 v                        v
	public static void schreibeEinenText(string text)
	{ // <-- Funktionskörper Anfang
		Console.WriteLine("Dies hier ist unser Text: " + text);
	} // <-- Funktionskörper Ende
	
	public static void Main()
	{
		// Funktionsaufruf der oben stehenden Funktion
		// |               Parameter
		// v               v
		schreibeEinenText("Hallo Welt!");
	}
}