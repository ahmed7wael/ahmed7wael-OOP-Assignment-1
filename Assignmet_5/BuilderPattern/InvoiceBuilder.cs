using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace BuilderPattern
{
    public class InvoiceBuilder
    {
        private readonly  Guid _invoiceId;
        private readonly string _customerName;
        private readonly string _customerEmail;
        private readonly string _customerPhone;

        public InvoiceBuilder(Guid invoiceId, string customerName, string customerEmail, string customerPhone)
        {
            if(string.IsNullOrWhiteSpace(customerName))
                throw new ArgumentException("Customer name cannot be null or empty.", nameof(customerName));

            if(string.IsNullOrWhiteSpace(customerEmail))
                throw new ArgumentException("Customer email cannot be null or empty.", nameof(customerEmail));
            
            if(string.IsNullOrWhiteSpace(customerPhone))
                throw new ArgumentException("Customer phone cannot be null or empty.", nameof(customerPhone));
            
            
            _invoiceId = invoiceId;
            _customerName = customerName;
            _customerEmail = customerEmail;
            _customerPhone = customerPhone;
        }

        private Address? _billingAddress;
        private Address? _shippingAddress;


        private Order _setorderpayment;




        public InvoiceBuilder setBillingAddress(Address address)
        {
            _billingAddress = address;
            return this;
        }

        public InvoiceBuilder setShippingAddress(Address address)
        {
            _shippingAddress = address;
            return this;
        }

        public InvoiceBuilder setPaymentInfo(Order order)
        {
            _setorderpayment = order;
            return this;    
        }


        public Invoice Build()
        {
            if (_billingAddress == null)
                throw new InvalidOperationException("Billing address is required to build the invoice.");

            if (_shippingAddress == null)
                throw new InvalidOperationException("Shipping address is required to build the invoice.");
            
            if (_setorderpayment == null)
                throw new InvalidOperationException("Payment info is required to build the invoice.");

            return new Invoice(
                _invoiceId, _customerName, _customerEmail, _customerPhone,
                _billingAddress.Street, _billingAddress.City, _billingAddress.State, _billingAddress.ZipCode, _billingAddress.Country,
                _shippingAddress.Street, _shippingAddress.City, _shippingAddress.State, _shippingAddress.ZipCode, _shippingAddress.Country,
                _setorderpayment.OrderDate, _setorderpayment.PaymentMethod, _setorderpayment.Currency, _setorderpayment.SubTotal, _setorderpayment.DiscountAmount, _setorderpayment.TaxAmount, _setorderpayment.TotalAmount
            );
        }
    }
}
