using System;

namespace BuilderPattern
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Before Refactoring
            //var invoice = new InvoiceBuilder(Guid.NewGuid(), "Wael", "wael@example.com", "01000000000")
            //    .setBillingAddress("123 Main St", "Cairo", "EG", "11511", "Egypt")
            //    .setShippingAddress("456 Sea St", "Alexandria", "EG", "21500", "Egypt")
            //    .setPaymentInfo("Credit Card", "USD")
            //    .setPriceInfo(1000m, 100m, 140m, 1040m)
            //    .Build();


            //Console.WriteLine("========== INVOICE ==========");

            //Console.WriteLine($"Invoice ID: {invoice.InvoiceId}");
            //Console.WriteLine($"Customer Name: {invoice.CustomerName}");
            //Console.WriteLine($"Customer Email: {invoice.CustomerEmail}");
            //Console.WriteLine($"Phone: {invoice.CustomerPhone}");

            //Console.WriteLine("\n--- Billing Address ---");
            //Console.WriteLine($"Street: {invoice.BillingStreet}");
            //Console.WriteLine($"City: {invoice.BillingCity}");
            //Console.WriteLine($"State: {invoice.BillingState}");
            //Console.WriteLine($"Zip Code: {invoice.BillingZipCode}");
            //Console.WriteLine($"Country: {invoice.BillingCountry}");

            //Console.WriteLine("\n--- Shipping Address ---");
            //Console.WriteLine($"Street: {invoice.ShippingStreet}");
            //Console.WriteLine($"City: {invoice.ShippingCity}");
            //Console.WriteLine($"State: {invoice.ShippingState}");
            //Console.WriteLine($"Zip Code: {invoice.ShippingZipCode}");
            //Console.WriteLine($"Country: {invoice.ShippingCountry}");

            //Console.WriteLine("\n--- Payment Info ---");
            //Console.WriteLine($"Payment Method: {invoice.PaymentMethod}");
            //Console.WriteLine($"Currency: {invoice.Currency}");

            //Console.WriteLine("\n--- Price Info ---");
            //Console.WriteLine($"Subtotal: {invoice.SubTotal}");
            //Console.WriteLine($"Discount: {invoice.DiscountAmount}");
            //Console.WriteLine($"Tax: {invoice.TaxAmount}");
            //Console.WriteLine($"Total: {invoice.TotalAmount}");

            //Console.WriteLine("==============================");

            //After Refactoring
            var billingAddress = new AddressBuilder()
                .SetStreet("123 Main St")
                .SetCity("Cairo")
                .SetState("EG")
                .SetZipCode("11511")
                .SetCountry("Egypt")
                .Build();

            var shippingAddress = new AddressBuilder()
                .SetStreet("456 Sea St")
                .SetCity("Alexandria")
                .SetState("EG")
                .SetZipCode("21500")
                .SetCountry("Egypt")
                .Build();

            var paymentInfo = new OrderBuilder()
                .SetPaymentInfo("Credit Card", "USD")
                .SetPriceInfo(1000m, 100m, 140m, 1040m)
                .Build();

            var invoice = new InvoiceBuilder(Guid.NewGuid(), "Wael", "wael@example.com", "01000000000")
                .setBillingAddress(billingAddress)
                .setShippingAddress(shippingAddress)
                .setPaymentInfo(paymentInfo)
                .Build();

            Console.WriteLine("==================================================");
            Console.WriteLine("             INVOICE DETAILS                      ");
            Console.WriteLine("==================================================");

            // 1. Customer Info
            Console.WriteLine($"Invoice ID    : {invoice.InvoiceId}");
            Console.WriteLine($"Customer Name : {invoice.CustomerName}");
            Console.WriteLine($"Email         : {invoice.CustomerEmail}");
            Console.WriteLine($"Phone         : {invoice.CustomerPhone}");

            // 2. Billing Address
            Console.WriteLine("\n--- Billing Address ---");
            Console.WriteLine($"Street  : {invoice.BillingStreet}");
            Console.WriteLine($"City    : {invoice.BillingCity}");
            Console.WriteLine($"State   : {invoice.BillingState}");
            Console.WriteLine($"Zip Code: {invoice.BillingZipCode}");
            Console.WriteLine($"Country : {invoice.BillingCountry}");

            // 3. Shipping Address
            Console.WriteLine("\n--- Shipping Address ---");
            Console.WriteLine($"Street  : {invoice.ShippingStreet}");
            Console.WriteLine($"City    : {invoice.ShippingCity}");
            Console.WriteLine($"State   : {invoice.ShippingState}");
            Console.WriteLine($"Zip Code: {invoice.ShippingZipCode}");
            Console.WriteLine($"Country : {invoice.ShippingCountry}");

            // 4. Order & Payment Info
            Console.WriteLine("\n--- Order & Payment Info ---");
            Console.WriteLine($"Order Date    : {invoice.OrderDate:yyyy-MM-dd HH:mm:ss}");
            Console.WriteLine($"Payment Method: {invoice.PaymentMethod}");
            Console.WriteLine($"Currency      : {invoice.Currency}");
            Console.WriteLine($"SubTotal      : {invoice.SubTotal:C}");
            Console.WriteLine($"Discount      : {invoice.DiscountAmount:C}");
            Console.WriteLine($"Tax           : {invoice.TaxAmount:C}");
            Console.WriteLine($"Total Amount  : {invoice.TotalAmount:C}");

            Console.WriteLine("==================================================");
        }
    }
}
