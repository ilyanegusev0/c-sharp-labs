using RestaurantManagementSystem.Enums;
using Utils;

namespace RestaurantManagementSystem
{
    public class Restaurant
    {
        // SINGLETON:
        private static Restaurant _instance = new Restaurant();
        public static Restaurant Instance => _instance;

        // FIELDS:
        private List<Table> _tables;
        private List<Order> _orders;
        private List<BaseItem> _items;

        // PROPERTIES:
        public List<Table> Tables => _tables;
        public List<Order> Orders => _orders;
        public List<BaseItem> Items => _items;

        // CONSTRUCTORS:
        public Restaurant()
        {
            _tables = new List<Table>();
            _orders = new List<Order>();
            _items = new List<BaseItem>();
        }

        // METHODS:

        // Tables:
        public void AddTable(Table table)
        {
            if (table != null)
                if (!_tables.Contains(table))
                    _tables.Add(table);
        }
        public void RemoveTable(Table table)
        {
            if (_tables.Contains(table))
                _tables.Remove(table);
        }
        public Table? SearchTableByNumber(int number)
        {
            return _tables.FirstOrDefault(i => i.Number == number);
        }
        public void ShowAllTables()
        {
            ConsoleEx.WriteLine($"# TABLES ({_tables.Count} items):\n", ConsoleColor.Yellow);
            foreach (var table in _tables)
            {
                table.Print();
                Console.WriteLine();
            }
        }

        // Orders:
        public void AddOrder(Order order)
        {
            if (!_orders.Contains(order))
                _orders.Add(order);
        }
        public void RemoveOrder(Order order)
        {
            if (_orders.Contains(order))
                _orders.Remove(order);
        }
        public Order? SearchOrderById(int id)
        {
            return _orders.FirstOrDefault(o => o.Id == id);
        }
        public void ShowAllOrders()
        {
            ConsoleEx.WriteLine($"# ORDERS ({_orders.Count} items):\n", ConsoleColor.Yellow);

            ShowNewOrders();
            ShowActiveOrders();
            ShowFinishedOrders();
        }
        public void ShowNewOrders()
        {
            ConsoleEx.WriteLine($"# NEW ORDERS ({_orders.Count(o => o.Status == OrderStatus.New)} items):\n", ConsoleColor.Yellow);

            foreach (var order in _orders.Where(o => o.Status == OrderStatus.New))
            {
                order.Print();
                Console.WriteLine();
            }
        }
        public void ShowActiveOrders()
        {
            ConsoleEx.WriteLine($"# ACTIVE ORDERS ({_orders.Count(o => o.Status == OrderStatus.InProgress)} items):\n", ConsoleColor.Yellow);

            foreach (var order in _orders.Where(o => o.Status == OrderStatus.InProgress))
            {
                order.Print();
                Console.WriteLine();
            }
        }
        public void ShowFinishedOrders()
        {
            ConsoleEx.WriteLine($"# FINISHED ORDERS ({_orders.Count(o => o.Status == OrderStatus.Ready)} items):\n", ConsoleColor.Yellow);

            foreach (var order in _orders.Where(o => o.Status == OrderStatus.Ready))
            {
                order.Print();
                Console.WriteLine();
            }
        }

        // Items:
        public void AddItem(BaseItem item)
        {
            if (item != null)
                if (!_items.Contains(item))
                    _items.Add(item);
        }
        public void RemoveItem(BaseItem item)
        {
            if (_items.Contains(item))
                _items.Remove(item);
        }
        public BaseItem? SearchItemById(int id)
        {
            return _items.FirstOrDefault(i => i.Id == id);
        }
        public BaseItem? SearchItemByTitle(string title)
        {
            return _items.FirstOrDefault(i => i.Title == title);
        }
        public void ShowAllItems()
        {
            ConsoleEx.WriteLine($"# MENU ({_items.Count} items):\n", ConsoleColor.Yellow);

            ShowDishes();
            ShowDrinks();
        }
        public void ShowDishes()
        {
            ConsoleEx.WriteLine($"# DISHES ({_items.Count(i => i is DishItem)} items):\n", ConsoleColor.Yellow);
            foreach (var dish in _items.Where(i => i is DishItem))
            {
                dish.Print();
                Console.WriteLine();
            }
        }
        public void ShowDrinks()
        {
            ConsoleEx.WriteLine($"# DRINKS ({_items.Count(i => i is DrinkItem)} items):\n", ConsoleColor.Yellow);
            foreach (var drink in _items.Where(i => i is DrinkItem))
            {
                drink.Print();
                Console.WriteLine();
            }
        }
    }
}
