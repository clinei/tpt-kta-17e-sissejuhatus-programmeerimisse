using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05_Parse_Input_Multiply_Divide
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Mina olen kalkulaatori programm.");
            Console.WriteLine("Ütle mulle kaks numbrit ja ma ütlen Sulle nende korrutise ja jagatise");
            Console.WriteLine();

            Console.Write("Esimene number: ");
            string input1 = Console.ReadLine();

            Console.Write("Teine number: ");
            string input2 = Console.ReadLine();

            Console.WriteLine();

            int number1 = int.Parse(input1);
            int number2 = int.Parse(input2);

            Console.WriteLine("Korrutades " + number1 + " ja " + number2 + "on tulemuseks: " + (number1 * number2));
            Console.WriteLine($"Jagades {number1} ja {number2} on tulemuseks: {number1 / number2}");

            Console.WriteLine();
            Console.WriteLine("Press any key to continue");

            Console.ReadLine();
        }
    }
}
