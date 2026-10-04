using System;
using System.Collections.Generic;
using System.Text;

namespace ProceduralToOOP
{
    public class Product
    {
        public int Id { get; }
        public string Name { get; set; }
        public decimal Price { get; private set; }
        public int Stock { get; set; }
        public Product(int id, string name, decimal price, int stock)
        {
            Id = id;
            Name = name;
            Price = price;
            Stock = stock;
        }

        public bool ReduceStock(int quantity)
        {
            if (quantity <= 0 || quantity > Stock)
                return false;

            Stock -= quantity;
            return true;
        }
    }
}
