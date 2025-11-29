using System.ComponentModel.Design;

namespace Coding_Dojo_CSV
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
        /*
        list.Add("Name;Strasse;Ort;Alter");
        list.Add("Peter Pan;Am Hang 5;12345 Einsam;42");
        1. Name;Strasse;Ort;Alter ->
        2. "Name", "Strasse", "Ort", "Alter" (Und merken uns 4, numberOfCols)
        3. 0, 0, 0, 0 (maxWidth) ->
        4. 4, 7, 3, 5 ->
        5. 9, 9, 12, 5 (!)
         * */
        public static IEnumerable<string> Tabelliere(IEnumerable<string> csv_zeilen)
        {
            var stringOutput = new List<string>();
            int numberOfCols = 0;

            int[]? maxWidth = null;
            List<string[]> cellContents = new List<string[]>();

            // für jede Zeile
            foreach (var csv in csv_zeilen)
            {
                string[] col = csv.Split(';');
                int length = col.GetLength(0);
               
                if (maxWidth == null) {
                    maxWidth = new int[length];
                }

                string[] contents = new string[length];
                // Suche nach der größten Breite pro Spalte
                for(int i = 0; i < col.Count(); i ++)
                {   
                    contents[i] = col[i];
                    if (col[i].Count() > maxWidth[i])
                    {
                        maxWidth[i] = col[i].Count();
                    }
                }
                cellContents.Add(contents);
            }

            // maxWidth 9, 9, 12, 5
            // { [ "Name", "Adresse", "Ort", "Alter" ], ["Peter Pan", ... ] }

            bool addedSeparator = false;
            foreach(var lineAsArray in cellContents)
            {
                string flatLine = "";
                for(int i=0; i < lineAsArray.Count(); i++ )
                {
                    var cell = lineAsArray[i];
                    int missingWhiteSpaces = maxWidth[i] - cell.Length;
                    string spaces = "";
                    for (int j=0;j<missingWhiteSpaces;j++)
                    {
                        spaces += " ";
                    }
                    //          Name< 3 x space>|
                    flatLine += cell + spaces + "|";
                }
                stringOutput.Add(flatLine);
                flatLine = "";
                if (!addedSeparator) 
                {
                    addedSeparator = true;
                    for (int i = 0; i < lineAsArray.Count(); i++)
                    {
                        int neededMinusses = maxWidth[i];
                        string minuses = "";
                        for (int j = 0; j < neededMinusses; j++)
                        {
                            minuses += "-";
                        }
                        //          Name< 3 x space>|
                        flatLine += minuses + "+";
                    }
                    stringOutput.Add(flatLine);
                    flatLine = "";
                }
            }

            return stringOutput;
        }
    }
}
