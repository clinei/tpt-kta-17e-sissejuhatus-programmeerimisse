namespace OOPRestaurant
{
    using System.Linq;
    using System.Text;

    public class Receipt
    {
        private string _restaurantName;
        private string _restaurantAddress;
        private Tab _tab;

        public Receipt(string restaurantName, string restaurantAddress, Tab tab)
        {
            this._restaurantName = restaurantName;
            this._restaurantAddress = restaurantAddress;
            this._tab = tab;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.AppendLine(this._restaurantName);
            sb.AppendLine(this._restaurantAddress);

            sb.AppendLine("-------------------------");
            foreach (var entry in _tab.Entries)
            {
                sb.AppendLine($"Price of food item: {entry}");
            }
            sb.AppendLine("-------------------------");


            sb.AppendLine($"Subtotal: €{_tab.Entries.Sum()}");
            sb.AppendLine($"15% Gratuity: €{_tab.Entries.Sum() * 0.15}");
            sb.AppendLine($"Total: €{_tab.Entries.Sum() * 0.85}");

            return sb.ToString();
        }
    }
}