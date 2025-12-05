using RestaurantManagementSystem.Interfaces;

namespace RestaurantManagementSystem
{
    public abstract class BaseItem : IPrintable
    {
        // Fields:

        private static int _index = 1;

        private int _id;
        private string _title;
        private int _calories;
        private decimal _price;

        // Properties:

        public int Id => _id;
        public string Title => _title;
        public int Calories => _calories;
        public decimal Price => _price;

        // Constructors:

        public BaseItem(string title, int calories, decimal price)
        {
            _id = _index++;
            _title = title;
            _calories = calories;
            _price = price;
        }

        // Methods:

        public abstract void Print();
    }
}