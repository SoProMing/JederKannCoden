namespace CodingDojo_CSV_Test
{
    public class CSV_Test
    {
        [Fact]
        public void Linie()
        {
            var Linie = new List<string>();
            Linie.Add("Name     |Strasse  |Ort         |Alter|");
            Linie.Add("---------+---------+------------+-----+");
            Linie.Add("Peter Pan|Am Hang 5|12345 Einsam|42   |");
            var list = new List<string>();
            list.Add("Name;Strasse;Ort;Alter");
            list.Add("Peter Pan;Am Hang 5;12345 Einsam;42");
            Assert.Equal(Linie, Coding_Dojo_CSV.Program.Tabelliere(list));

        }

        [Fact]
        public void Aufruf_erfolgreich()
        {
            IEnumerable<string> list = new List<string>();
            Assert.Equal(new List<string>(), Coding_Dojo_CSV.Program.Tabelliere(list));
        }
        [Fact]
        /* "a" ->
         * "a|"
         * "-+"
         */
        public void inputcheck()
        {
            var list = new List<string>();
            var input = new List<string>();
            input.Add("a");
            list.Add("a|");
            list.Add("-+");
            Assert.Equal(list, Coding_Dojo_CSV.Program.Tabelliere(input));

        }
        [Fact]
        public void String_CSV()
        {
            var list = new List<string>();
            var a = new List<string>();
            a.Add("Name|Strasse|");
            a.Add("----+-------+");
            list.Add("Name;Strasse");
            Assert.Equal(a, Coding_Dojo_CSV.Program.Tabelliere(list));
        }

        /*
Name;Strasse;Ort;Alter
Peter Pan;Am Hang 5;12345 Einsam;42


Name     |Strasse  |Ort         |Alter|
---------+---------+------------+-----+
Peter Pan|Am Hang 5|12345 Einsam|42   |
        */

        /*
        [Fact]
        public void String_CSVfullstring()
        {
            var list = new List<string>();
            var a = new List<string>();
            a.Add("Name|Strasse|Ort|Alter");
            a.Add("Peter Pan|Am Hang 5|12345 Einsam|42");
            list.Add("Name;Strasse;Ort;Alter");
            list.Add("Peter Pan;Am Hang 5;12345 Einsam;42");
            Assert.Equal(a, Coding_Dojo_CSV.Program.Tabelliere(list));
        }
        */
        
    }
}