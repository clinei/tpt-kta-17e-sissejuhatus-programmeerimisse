namespace Hangman
{
    using System;

    public class Program
    {
        public static void Main(string[] args)
        {
            /*
             * 1. Kirjuta pseudokood või eeldatav programmi output

                2. Arvuti suudab välja valida ühe sõna

                3. Suudab välja kuvada õige arvu "_" märke iga tähe asemel

                4. Kui kasutaja arvab ära õige tähe, siis see asendatakse õige _ kohapeal

                    4.1 Hoitakse meeles õiget sõna
                    4.2 Hoitakse meeles kõiki kasutaja         poolt sisestatud tähti
                    4.3 iga tähe printimise korral         otsustada kas täht või _ (if/else         kas on arvatud või mitte)

                5. Kui sõna on ära arvatud siis on võit! 
             */


            Console.WriteLine("Arvuti on valinud ühe sõna, arva see tähthaaval ära vähem kui 5 eksimusega");

            Console.WriteLine();
            Console.WriteLine("_ _ _ _ _"); // ILVES
            Console.WriteLine("> A");

            Console.WriteLine();
            Console.WriteLine("_ _ _ _ _"); // ILVES
            Console.WriteLine("> L");

            Console.WriteLine();
            Console.WriteLine("_ L _ _ _"); // ILVES
            Console.WriteLine("> S");

            Console.WriteLine();
            Console.WriteLine("_ L _ _ S"); // ILVES
            Console.WriteLine("> ");
        }
    }
}
