using RestaurantManagementSystem.Enums;

namespace RestaurantManagementSystem
{
    public class DrinkItem : BaseItem
    {
        // Fields:
        private DrinkCategory _category;
        private double _volume;
        private double _alcoholPercentage;

        // Properties:
        public DrinkCategory Category => _category;
        public double Volume => _volume;
        public double AlcoholPercentage => _alcoholPercentage;

        // Constructions:
        public DrinkItem(string title, DrinkCategory category, double volume, int calories, double alcoholPercentage, decimal price) : base(title, calories, price)
        {
            _category = category;
            _volume = volume;
            _alcoholPercentage = alcoholPercentage;
        }

        // Methods:

        public override void Print()
        {
            Console.WriteLine(
                $"{Title} (ID: {Id})\n" +
                $"-------------------------\n" +
                $"Category: {_category}\n" +
                $"Volume: {_volume} ml\n" +
                $"Calories: {Calories} cal\n" +
                $"Alcohol: {_alcoholPercentage}%\n" +
                $"Price: {Price} UAH\n" +
                $"-------------------------");
        }
    }
}