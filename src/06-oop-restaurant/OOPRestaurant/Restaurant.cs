namespace OOPRestaurant
{
    using System;

    public class Restaurant
    {
        private string _name;
        private string _address;

        public Restaurant(string name, string address)
        {
            _name = name;
            _address = address;
        }

        public Receipt GetReceipt(Tab tab)
        {
            return new Receipt(_name, _address, tab);
        }
    }
}