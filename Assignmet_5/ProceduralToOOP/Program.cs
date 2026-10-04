namespace ProceduralToOOP
{
    public class Program
    {
        static List<Customer> customers = new List<Customer>();
        static List<Product> products = new List<Product>();
        static List<Order> orders = new List<Order>();

        public static Customer FindCustomerById(int id)
        {
            foreach (var customar in customers)
            {
                if (customar.Id == id)
                    return customar;
            }
            return null;
        }
        public static Product FindProductById(int id)
        {
            foreach (var product in products)
            {
                if (product.Id == id)
                    return product;
            }
            return null;
        }
        public static Order FindOrderById(int id)
        {
            foreach (var order in orders)
            {
                if (order.Id == id)
                    return order;
            }
            return null;
        }

        public static void AddCustomer(int id, string name, string email, string city, bool isVip)
        {
            if (FindCustomerById(id) != null)
            {
                Console.WriteLine($"ERROR: customer id : {id} already exists.");
                return;
            }
            customers.Add(new Customer(id, name, email, city, isVip));
        }


        public static void PrintCustomers()
        {
            Console.WriteLine($"\n=== CUSTOMERS ({customers.Count}) ===");
            foreach (var customer in customers)
            {
                Console.WriteLine($"#Id = {customer.Id}, Name = {customer.Name}, <Email = {customer.Email}>, City = {customer.City}, vip= {(customer.IsVip ? "Yes" : "No")}\n");
            }
        }
           
        public static void AddProduct(int id, string name, decimal price, int stock)
        {
            if (FindProductById(id) != null)
            {
                Console.WriteLine($"ERROR: product id : {id} already exists.");
                return;
            }
            products.Add(new Product(id, name, price, stock));
        }
                
        public static void PrintProducts()
        {
            Console.WriteLine($"\n=== PRODUCTS ({products.Count}) ===");
            foreach (var product in products)
            {
                Console.WriteLine($"#Id = {product.Id}, Name = {product.Name}, Price = {product.Price}, Stock = {product.Stock}\n");
            }
        }
             
        public static void CreateOrder(int id, int customerId)
        {
            if (FindOrderById(id) != null)
            {
                Console.WriteLine($"ERROR: order id {id} already exists.\n");
                return;
            }
            Customer customer = FindCustomerById(customerId);
            if (customer == null)
            {
                Console.WriteLine($"ERROR: customer id {customerId} not found.\n");
                return;
            }
            orders.Add(new Order(id, customer));

        }
              
        public static void AddLineToOrder(int orderId, int productId, int quantity)
        {
            Order order = FindOrderById(orderId);
            if (order == null)
            {
                Console.WriteLine($"ERROR: order id {orderId} not found.\n");
                return;
            }

            Product product = FindProductById(productId);
            if (product == null)
            {
                Console.WriteLine($"ERROR: product id {productId} not found.\n");
                return;
            }
            order.AddLine(product, quantity);
        }
               
        public static void PrintOrder(int orderId)
        {
            Order order = FindOrderById(orderId);
            if (order == null)
            {
                Console.WriteLine($"ERROR: order id {orderId} not found.\n");
                return;
            }
            Console.WriteLine($"\n=== ORDER # {order.Id} ===\n");
            Console.WriteLine($"Date: {order.Dates:yyyy-MM-dd}");
            Console.WriteLine($"Customer Name: {order.Customer.Name}\n");
            Console.WriteLine($"(# {order.Customer.Id} )\n");
            Console.WriteLine($"Paid: {(order.IsPaid ? "yes" : "no")}");

            foreach (OrderLine line in order.OrderLines)
            {
                Console.WriteLine($"  - {line.Product.Name}  x{line.Quantity}  @{line.UnitPrice:C}  = {line.CalculateOrderTotalLine():C}");
            }

            Console.WriteLine($"TOTAL: {order.CalculateTotal():C}");
        }
        public static void PrintAllOrders()
        {
            Console.WriteLine($"\n=== ALL ORDERS ({orders.Count}) ===");
            foreach (var order in orders)
            {
                PrintOrder(order.Id);
            }
        }

        public static decimal TotalSalesPaidOnly()
        {
            decimal sum = 0.0m;
            foreach(var order in orders)
            {
                if (order.IsPaid)
                {
                    sum += order.CalculateTotal();
                }
            }
            return sum;
        }

        public static void seedSampleData()
        {
            AddCustomer(1, "Mona Ali", "mona@example.com", "Cairo", true);
            AddCustomer(2, "Omar Hassan", "omar@example.com", "Alexandria", false);
            AddCustomer(3, "Sara Nabil", "sara@example.com", "Giza", false);

            AddProduct(101, "USB Cable", 50.0m, 100);
            AddProduct(102, "Wireless Mouse", 250.0m, 40);
            AddProduct(103, "Mechanical Keyboard", 1200.0m, 15);
            AddProduct(104, "Laptop Stand", 400.0m, 25);
        }

        public static void runDemoScenario()
        {
            CreateOrder(1001, 1);
            AddLineToOrder(1001, 101, 2);
            AddLineToOrder(1001, 102, 1);
            FindOrderById(1001)?.MarkAsPaid();

            CreateOrder(1002, 2);
            AddLineToOrder(1002, 103, 1);
            AddLineToOrder(1002, 104, 1);

            CreateOrder(1003, 3);
            AddLineToOrder(1003, 101, 5);
            FindOrderById(1003)?.MarkAsPaid();
        }

        public static void RunInteractiveMenu()
        {
            while (true)
            {
                Console.WriteLine("\n=== MENU ===");
                Console.WriteLine("1. Print Customers");
                Console.WriteLine("2. Print Products");
                Console.WriteLine("3. Print All Orders");
                Console.WriteLine("4. Print Single Order");
                Console.WriteLine("5. Create New Order");
                Console.WriteLine("6. Add Item to Order");
                Console.WriteLine("7. Pay Order");
                Console.WriteLine("8. Show Total Paid Sales");
                Console.WriteLine("0. Exit");
                Console.Write("Enter choice: ");

                string choice = Console.ReadLine();
                if (choice == "0") break;

                switch (choice)
                {
                    case "1":
                        PrintCustomers();
                        break;
                    case "2":
                        PrintProducts();
                        break;
                    case "3":
                        PrintAllOrders();
                        break;
                    case "4":
                        Console.Write("Enter Order ID: ");
                        if (int.TryParse(Console.ReadLine(), out int orderId))
                            PrintOrder(orderId);
                        break;
                    case "5":
                        Console.Write("Enter New Order ID: ");
                        int newOrderId = int.Parse(Console.ReadLine());
                        Console.Write("Enter Customer ID: ");
                        int customerId = int.Parse(Console.ReadLine());
                        CreateOrder(newOrderId, customerId);
                        break;
                    case "6":
                        Console.Write("Enter Order ID: ");
                        int oId = int.Parse(Console.ReadLine());
                        Console.Write("Enter Product ID: ");
                        int pId = int.Parse(Console.ReadLine());
                        Console.Write("Enter Quantity: ");
                        int qty = int.Parse(Console.ReadLine());
                        AddLineToOrder(oId, pId, qty);
                        break;
                    case "7":
                        Console.Write("Enter Order ID to Pay: ");
                        int payOrderId = int.Parse(Console.ReadLine());
                        var orderToPay = FindOrderById(payOrderId);
                        if (orderToPay != null)
                            orderToPay.MarkAsPaid();
                        else
                            Console.WriteLine($"ERROR: order id {payOrderId} not found.");
                        break;
                    case "8":
                        Console.WriteLine($"\nTotal Paid Sales: {TotalSalesPaidOnly():C}");
                        break;
                    default:
                        Console.WriteLine("Invalid choice, try again.");
                        break;
                }
            }
        }

        public static void Main(string[] args)
        {
            seedSampleData();
            runDemoScenario();
            RunInteractiveMenu();
        }
    }
}
