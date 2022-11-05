using OrderSystem.Entities;
using OrderSystem.Entities.Enum;
using System.Diagnostics.Metrics;
using System.Globalization;

namespace OrderSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine();
            Console.WriteLine("--------------------- Order System ---------------------");
            Console.WriteLine();

            //Entrada de dados do cliente 
            Console.WriteLine(" ## Enter client data ## ");
            Console.WriteLine();
            Console.Write("Name: ");
            string ClientName = Console.ReadLine();
            Console.Write("Email: ");
            string Email = Console.ReadLine();
            Console.Write("Birth date (DD/MM/YYYY): ");
            DateTime BirthDate = DateTime.Parse(Console.ReadLine());
            Console.WriteLine();

            //Entradada de dados do pedido
            Console.WriteLine(" ## Enter order data ## ");
            Console.WriteLine();
            Console.Write("Status: ");
            OrderStatus Status = Enum.Parse<OrderStatus>(Console.ReadLine());
            Console.WriteLine();

            //Construtores sobrecarregados
            Client client = new Client(ClientName, Email, BirthDate);
            Order order = new Order(DateTime.Now, Status, client);

            //Quantidade de pedidos
            Console.Write("How many items to this order? ");
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine();

            //Entrada de dados dos itens do pedido
            for (int i = 1; i <= n; i++)
            {
                Console.WriteLine();
                Console.WriteLine($"Enter #{i} item data:");
                Console.Write("Product name: ");
                string productName = Console.ReadLine();
                Console.Write("Product price: ");
                double price = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                Product product = new Product(productName, price);

                Console.Write("Quantity: ");
                int quantity = int.Parse(Console.ReadLine());

                OrderItem orderItem = new OrderItem(quantity, price, product);

                order.AddItem(orderItem);
            }

            //Saída de dados
            Console.WriteLine();
            Console.WriteLine("## ORDER SUMMARY ##");
            Console.WriteLine(order);
        }
    }
}