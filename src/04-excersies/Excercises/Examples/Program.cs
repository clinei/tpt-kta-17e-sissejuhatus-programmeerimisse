using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examples
{
    class Program
    {
        static void Main(string[] args)
        {
            int input = GetUserInput();
            Console.WriteLine($"Hello {input}!");
            

            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
        }

        static int GetUserInput()
        {
            bool success = true;
            int value = 0;

            while (success)
            {
                string input = Console.ReadLine();
                success = !int.TryParse(input, out value);
            }

            return value;
        }

        static void PrintGreeting(string a1, int a2)
        {
            Console.WriteLine("Hello world!");
            Console.WriteLine($"A1 {a1}");
            Console.WriteLine($"A2 {a2}");
        }

        static void DoSomething()
        {
            Console.WriteLine("Hello world!");
        }
    }
}
