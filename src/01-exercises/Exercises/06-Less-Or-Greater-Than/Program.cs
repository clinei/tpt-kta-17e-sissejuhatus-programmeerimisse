using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06_Less_Or_Greater_Than
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Palun sisesta number [1-100] ning ma ütlen, kas see on suurem või väiksem");
            Console.WriteLine();

            Console.Write("Sinu number: ");
            string input = Console.ReadLine();

            //teen stringi int'iks
            int number = int.Parse(input);

            // arvuti valib numbri
            int magicNumber = 33;

            if (magicNumber > number)
            {
                Console.WriteLine("Sinu number on väiksem");
            }

            if (magicNumber < number)
            {
                Console.WriteLine("Sinu number on suurem");
            }

            Console.WriteLine("Press any key to continue");
            Console.ReadLine();
        }
    }
}
