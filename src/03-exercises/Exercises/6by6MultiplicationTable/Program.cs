namespace _6by6MultiplicationTable
{
    using System;

    class Program
    {
        static void Main(string[] args)
        {
            // print out 6by6 multiplication table using two nested for loops


            for (int i = 0; i <= 6; i++)
            {
                Console.Write(i + "\t");

                for (int j = 1; j <= 6; j++)
                {
                    if (i > 0)
                        Console.Write(i * j + "\t");

                    else
                        Console.Write(j + "\t");
                }
                Console.Write("\n");
            }


            Console.ReadLine();
        }
    }
}
