using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Hei! Kaks numbrit");

            Console.Write("Palun sisesta number");
            string input = Console.ReadLine();

            int sisestatudNumber = int.Parse(input);

            int number = 5;

            Console.WriteLine(number + input);

            Console.ReadLine();
            // prindi välja "Sina ütled"
            // küsi kasutaja sisend ja salvesta nii, et saan seda kasutada
            // prindi välja "Mina ütlen"...

            // oota kasutaja sisendit, et programm kinni ei läheks
        }
    }
}
