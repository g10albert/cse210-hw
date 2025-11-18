using System;

class Program
{
    static void Main(string[] args)
    {
        {
            Address usaAddress = new Address("79 Front St", "Brooklyn", "NY", "USA");

            Customer usaCustomer = new Customer("Stephen Curry", usaAddress);

            Product p1 = new Product("Laptop", "laptop_001", 1200.00, 1);
            Product p2 = new Product("Mouse", "mouse_001", 10.75, 2);
            List<Product> products1 = new List<Product> { p1, p2 };

            Order order1 = new Order(products1, usaCustomer);

            Console.WriteLine(order1.GetPackingLabel());
            Console.WriteLine("\n");
            Console.WriteLine(order1.GetShippingLabel());
            Console.WriteLine("\n");
            double totalCost1 = order1.CalculateTotalCost();
            Console.WriteLine($"Final Order Total: ${totalCost1:0.00}");


            Address intAddress = new Address("99 rue de l'Aigle", "LA MADELEINE", "Nord-Pas-de-Calais", "France");

            Customer intCustomer = new Customer("Audrey R Sansouci", intAddress);

            Product p3 = new Product("Keyboard", "keyboard_001", 100.00, 2);
            Product p4 = new Product("Webcam HD", "webcam_001", 30.20, 1);
            Product p5 = new Product("USB Drive", "drive_001", 5.00, 5);
            List<Product> products2 = new List<Product> { p3, p4, p5 };

            Order order2 = new Order(products2, intCustomer);

            Console.WriteLine(order2.GetPackingLabel());
            Console.WriteLine("\n");
            Console.WriteLine(order2.GetShippingLabel());
            Console.WriteLine("\n");
            double totalCost2 = order2.CalculateTotalCost();
            Console.WriteLine($"Final Order Total: ${totalCost2:0.00}");
            Console.WriteLine("");
        }
    }
}