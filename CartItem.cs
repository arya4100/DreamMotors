namespace DreamMotors
{
    public class CartItem
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }

        public override string ToString()
        {
            return $"{Name} x {Quantity} - ${Price * Quantity:0.00}";
        }
    }
}
