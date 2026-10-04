namespace ProceduralToOOP
{
    public class OrderLine
    {

        public Product Product { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public OrderLine(Product product, int quantity)
        {
            Product = product;
            Quantity = quantity;
            UnitPrice = product.Price;
        }

        public decimal CalculateOrderTotalLine()
        {
            return UnitPrice * Quantity;
        }
    }
}
