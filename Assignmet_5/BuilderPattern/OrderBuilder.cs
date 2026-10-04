namespace BuilderPattern
{
    public class Order
    {
        public DateTime OrderDate { get; }
        public string PaymentMethod { get; }
        public string Currency { get; }
        public decimal SubTotal { get; }
        public decimal DiscountAmount { get; }
        public decimal TaxAmount { get; }
        public decimal TotalAmount { get; }

        public Order(DateTime orderDate, string paymentMethod, string currency, decimal subTotal, decimal discountAmount, decimal taxAmount, decimal totalAmount)
        {
            OrderDate = orderDate;
            PaymentMethod = paymentMethod;
            Currency = currency;
            SubTotal = subTotal;
            DiscountAmount = discountAmount;
            TaxAmount = taxAmount;
            TotalAmount = totalAmount;
        }
    }

    public class OrderBuilder
    {
        private DateTime _orderDate = DateTime.UtcNow;
        private string _paymentMethod = "Credit Card";
        private string _currency = "USD";
        private decimal _subTotal;
        private decimal _discountAmount;
        private decimal _taxAmount;
        private decimal _totalAmount;

        public OrderBuilder SetPaymentInfo(string paymentMehod, string currency)
        {
            _paymentMethod = paymentMehod;
            _currency = currency;
            return this;
        }

        public OrderBuilder SetPriceInfo(decimal subTotal, decimal discountAmount, decimal taxAmount, decimal totalAmount)
        {
            _subTotal = subTotal;
            _discountAmount = discountAmount;
            _taxAmount = taxAmount;
            _totalAmount = totalAmount;
            return this;
        }

        public Order Build()
        {
            return new Order(_orderDate, _paymentMethod, _currency, _subTotal, _discountAmount, _taxAmount, _totalAmount);
        }
    }
}
