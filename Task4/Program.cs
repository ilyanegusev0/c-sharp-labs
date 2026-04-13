using System.Text.Json;
using System.Text.Json.Serialization;

namespace Task4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const string OUTPUT_FILE = "orders.json";

            var options = new JsonSerializerOptions()
            {
                WriteIndented = true,
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                Converters = { new JsonStringEnumConverter() }
            };

            List<Order> orders = new List<Order>();

            Order order1 = new Order();
            Order order2 = new Order();
            Order order3 = new Order();

            order2.ChangeStatus(OrderStatus.Processing);
            order3.ChangeStatus(OrderStatus.Completed);

            orders.AddRange(order1, order2, order3);

            string json;

            if (!File.Exists(OUTPUT_FILE))
            {
                json = JsonSerializer.Serialize(orders, options);
                File.WriteAllText(OUTPUT_FILE, json);
            }

            json = File.ReadAllText(OUTPUT_FILE);
            List<Order> deserializerOrders = JsonSerializer.Deserialize<List<Order>>(json, options) ?? new List<Order>();

            Console.WriteLine($"ORDERS ({deserializerOrders.Count}):");
            foreach (var order in deserializerOrders)
                Console.WriteLine($"- Order #{order.Id} | STATUS: {order.Status}");
        }
    }
}
