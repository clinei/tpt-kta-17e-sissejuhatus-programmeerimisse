﻿namespace OOPRestauran.t
{
    using System;
    using System.Collections.Generic;

    using OOPRestaurant;

    public class Program
    {
        public static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Restaurant restaurant = new Restaurant("Taco Palenque", "1200 Main ST.");

            Tab tab = new Tab();

            tab.Add(7.99);
            tab.Add(6.55);
            tab.Add(2.345);

            Receipt receipt = restaurant.GetReceipt(tab);

            Console.Write(receipt);

            Console.WriteLine();
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
        }
    }
}
