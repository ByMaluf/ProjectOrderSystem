using OrderSystem.Entities.Enum;
using OrderSystem.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace OrderSystem.Entities
{
    internal class Order
    {
        public DateTime Moment { get; set; }
        public OrderStatus Status { get; set; }

        //Representa uma composição de objetos que é uma associação entres duas classes diferentes
        public Client Client { get; set; }

        //Representa uma composição de objetos que é uma associação entres duas classes diferentes
        public List<OrderItem> Items { get; set; } = new List<OrderItem>();

        public Order(DateTime moment, OrderStatus status, Client client)
        {
            Moment = moment;
            Status = status;
            Client = client;
        }

        public void AddItem(OrderItem item)
        {
            Items.Add(item);
        }

        public void RemoveItem(OrderItem item)
        {
            Items.Remove(item);
        }
        public double Total()
        {
            double sum = 0.0;
            foreach (OrderItem item in Items)
            {
                sum += item.SubTotal();
            }
            return sum;          
        }

        public override string ToString()
        {            
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("Order Moment: " + Moment.ToString("dd/MM/yyyy HH:mm:ss"));
            sb.AppendLine("Order Moment: " + Status);
            sb.AppendLine("Order Moment: " + Client);
            sb.AppendLine("Order Items: ");

            foreach (OrderItem item in Items)
            {
                sb.AppendLine(item.ToString());
            }

            sb.AppendLine("Total Values:");

            sb.AppendLine("Total price: $" + Total().ToString("F2", CultureInfo.InvariantCulture));

            return sb.ToString();

        }
    }
}
