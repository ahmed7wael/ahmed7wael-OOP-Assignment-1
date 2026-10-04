using System;
using System.Collections.Generic;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ProceduralToOOP
{
    public class Order
    {
        public int Id {get; }
        public Customer Customer { get; set; }
        public DateTime Dates { get; set; }
        public bool IsPaid { get; set; }
        public List<OrderLine> OrderLines { get; set; }

        public Order(int id, Customer customer)
        {
            Id = id;
            Customer = customer;
            Dates = DateTime.Now;
            IsPaid = false;
            OrderLines = new List<OrderLine>();
        }

        public bool AddLine(Product product , int quantity)
        {
            if (IsPaid)
            {
                Console.WriteLine("ERROR: cannot change a paid order.");
                return false;
            }
            if (!product.ReduceStock(quantity))
            {
                Console.WriteLine($"ERROR: not enough stock for product #{product.Id}.");
                return false;
            }
            OrderLines.Add(new OrderLine(product, quantity));
            return true;
        }

        public decimal CalculateTotal()
        {
            decimal total = 0.0m;
            foreach (var order in OrderLines)
            {
                total += order.CalculateOrderTotalLine();
            }
            if (Customer.IsVip)
            {
                total = total * 0.90m;
            }

            return total;
        }
        public  void MarkAsPaid()
        {
            if (OrderLines.Count == 0)
            {
                Console.WriteLine("ERROR: cannot pay an empty order.");
                return;
            }
            IsPaid = true;
            return;
        }
    }    
}
