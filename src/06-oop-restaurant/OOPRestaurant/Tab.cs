using System;
using System.Collections.Generic;

namespace OOPRestaurant
{
    public class Tab
    {
        public IList<double> Entries { get; private set; } = new List<double>();

        public void Add(double price)
        {
            Entries.Add(price);
        }
    }
}