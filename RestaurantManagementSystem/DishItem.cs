using RestaurantManagementSystem.Enums;

namespace RestaurantManagementSystem
{
    public class DishItem : BaseItem
    {
        // Fields:
        private DishCategory _category;
        private double _weight;

        // Properties:
        public DishCategory Category => _category;
        public double Weight => _weight;

        // Constructors:
        public DishItem(string title, DishCategory category, double weight, int calories, decimal price) : base(title, calories, price)
        {
            _category = category;
            _weight = weight;
        }

        // Methods:

        public override void Print()
        {
            Console.WriteLine(
                $"{Title} (ID: {Id})\n" +
                $"-------------------------\n" +
                $"Category: {_category}\n" +
                $"Weight: {_weight} g\n" +
                $"Calories: {Calories} cal\n" +
                $"Price: {Price} UAH\n" +
                $"-------------------------");
        }
    }
}