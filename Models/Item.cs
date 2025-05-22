namespace InventoryManagementSystem.Models
{
    public abstract class Item
    {
        private static int _counter = 0;
        public static int TotalItems => _counter;

        public int Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }

        protected Item(string name, int quantity, double price)
        {
            Id = ++_counter;
            Name = name;
            Quantity = quantity;
            Price = price;
        }

        public abstract void DisplayInfo();
    }

    public class Electronics : Item
    {
        public int WarrantyMonths { get; set; }

        public Electronics(string name, int quantity, double price, int warranty)
            : base(name, quantity, price)
        {
            WarrantyMonths = warranty;
        }

        public override void DisplayInfo()
        {
            Console.WriteLine($"[Electronics] {Name} (ID: {Id}) - Qty: {Quantity}, Price: {Price}, Warranty: {WarrantyMonths} months");
        }
    }

    public class Food : Item
    {
        public DateTime ExpiryDate { get; set; }

        public Food(string name, int quantity, double price, DateTime expiry)
            : base(name, quantity, price)
        {
            ExpiryDate = expiry;
        }

        public override void DisplayInfo()
        {
            Console.WriteLine($"[Food] {Name} (ID: {Id}) - Qty: {Quantity}, Price: {Price}, Expires: {ExpiryDate.ToShortDateString()}");
        }
    }
}
