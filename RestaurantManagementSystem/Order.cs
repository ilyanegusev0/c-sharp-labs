using RestaurantManagementSystem.Enums;
using RestaurantManagementSystem.Interfaces;

namespace RestaurantManagementSystem
{
    public class Order : IPrintable
    {
        // Fields:

        private static int _index = 1;

        private int _id;
        private DateTime _date;
        private OrderStatus _status;
        private int _tableNumber;
        private Dictionary<BaseItem, int> _items;

        // Properties:

        public int Id => _id;
        public DateTime Date => _date;
        public OrderStatus Status => _status;
        public int TableNumber => _tableNumber;
        public Dictionary<BaseItem, int> Items => _items;
        public decimal Price => GetTotalPrice();

        // Constructors:

        public Order(int tableNumber)
        {

            _id = _index++;
            _date = DateTime.Now;
            _status = OrderStatus.New;
            _tableNumber = tableNumber;
            _items = new Dictionary<BaseItem, int>();
        }

        //Methods:

        public void AddItem(BaseItem item, int count)
        {
            if (count < 1)
                return;

            if (_items.ContainsKey(item))
                _items[item] += count;
            else
                _items.Add(item, count);
        }
        public void RemoveItem(BaseItem item, int count)
        {
            if (!_items.ContainsKey(item))
                return;

            if (_items[item] < count)
                return;

            _items[item] -= count;

            if (_items[item] == 0)
                _items.Remove(item);
        }
        public decimal GetTotalPrice()
        {
            return _items.Sum(i => i.Key.Price * i.Value);
        }
        public void ChangeStatus(OrderStatus status)
        {
            if (status != _status)
                _status = status;
        }

        public void Print()
        {
            Console.WriteLine(ToString());
        }

        public override string ToString()
        {
            string info = "";
            info +=
                $"Order #{_id}:\n" +
                $"-------------------------\n" +
                $"Date: {_date}\n" +
                $"Status: {_status}\n" +
                $"Table: {_tableNumber}\n" +
                $"Items ({_items.Sum(i => i.Value)}):\n";

            foreach (var item in _items)
            {
                info += $"- {item.Key.Title} x{item.Value} ({item.Value * item.Key.Price} UAH)\n";
            }

            info +=
                $"Total price: {GetTotalPrice()} UAH\n" +
                "-------------------------";

            return info;
        }
    }
}