using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradedAssignment
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("See on allahindluse arvutamise programm, sisesta summa:");
            Console.Write("> ");

            string input = Console.ReadLine();

            Console.WriteLine($"Summa: {input}€");

            Console.WriteLine("Tavaklient:");

            int amount = int.Parse(input);
            int percent = 0;

            if (amount >= 50 && amount < 250)
                percent = 10;
                
            if (amount >= 250 && amount < 350)
                percent = 20;

            if (amount >= 350)
                percent = 30;

            Console.WriteLine($"Allahindlus: {percent}% ");

            var finalAmount = amount - ((double)amount / 100 * percent);
            
            Console.WriteLine($"Tasuda: {finalAmount}€");


            Console.WriteLine("Püsiklient:");
            Console.WriteLine("Allahindlus:");
            Console.WriteLine("Tasuda:");

            Console.ReadLine();
            //See on allahindluse arvutamise programm, sisesta summa:
            //    > 50€

            //Summa: 50"

            //Tavaklient:
            //Allahindlus: 10 %
            //    Tasuda: 45€

            //Püsiklient:
            //Allahindlus: 20 %
            //    Tasuda: 40€
        }
    }
}
