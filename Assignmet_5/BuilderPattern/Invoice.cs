namespace BuilderPattern
{
    public class Invoice
    {
        /// 1. Customer Info
        public Guid InvoiceId { get; }
        public string CustomerName { get; }
        public string CustomerEmail { get; }
        public string CustomerPhone { get; }

        // 2. Billing Address
        public string? BillingStreet { get; }
        public string? BillingCity { get; }
        public string? BillingState { get; }
        public string? BillingZipCode { get; }
        public string? BillingCountry { get; }

        // 3. Shipping Address
        public string? ShippingStreet { get; }
        public string? ShippingCity { get; }
        public string? ShippingState { get; }
        public string? ShippingZipCode { get; }
        public string? ShippingCountry { get; }

        // 4. Order & Payment Info
        public DateTime OrderDate { get; }
        public string PaymentMethod { get; }
        public string Currency { get; }
        public decimal SubTotal { get; }
        public decimal DiscountAmount { get; }
        public decimal TaxAmount { get; }
        public decimal TotalAmount { get; }

        public Invoice(
            Guid invoiceId, string customerName, string customerEmail, string customerPhone,
            string? billingStreet, string? billingCity, string? billingState, string? billingZipCode, string? billingCountry,
            string? shippingStreet, string? shippingCity, string? shippingState, string? shippingZipCode, string? shippingCountry,
            DateTime orderDate, string paymentMethod, string currency, decimal subTotal, decimal discountAmount, decimal taxAmount, decimal totalAmount)
        {
            InvoiceId = invoiceId;
            CustomerName = customerName;
            CustomerEmail = customerEmail;
            CustomerPhone = customerPhone;

            BillingStreet = billingStreet;
            BillingCity = billingCity;
            BillingState = billingState;
            BillingZipCode = billingZipCode;
            BillingCountry = billingCountry;

            ShippingStreet = shippingStreet;
            ShippingCity = shippingCity;
            ShippingState = shippingState;
            ShippingZipCode = shippingZipCode;
            ShippingCountry = shippingCountry;

            OrderDate = orderDate;
            PaymentMethod = paymentMethod;
            Currency = currency;
            SubTotal = subTotal;
            DiscountAmount = discountAmount;
            TaxAmount = taxAmount;
            TotalAmount = totalAmount;
        }

    }
}
