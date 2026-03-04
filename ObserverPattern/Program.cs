using ObserverPattern.Core;

namespace ObserverPattern
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Sensor sensor = new Sensor(0);

            Display display = new Display();
            AirConditioner airConditioner = new AirConditioner();
            SecuritySystem securitySystem = new SecuritySystem();

            sensor.TemperatureChanged += display.OnTemperatureChanged;
            sensor.TemperatureChanged += airConditioner.OnTemperatureChanged;
            sensor.TemperatureChanged += securitySystem.OnTemperatureChanged;

            sensor.ChangeTemperature(20);

            while (true)
            {
                Console.Write("\n > Use UP/DOWN to change temperature. Press ESC to exit. ");

                ConsoleKeyInfo key = Console.ReadKey();

                Utils.Clear(0, 5);

                switch (key.Key)
                {
                    case ConsoleKey.UpArrow:
                        sensor.ChangeTemperature(1);
                        break;
                    case ConsoleKey.DownArrow:
                        sensor.ChangeTemperature(-1);
                        break;
                    case ConsoleKey.Escape:
                        Environment.Exit(0);
                        break;
                }
            }
        }
    }
}
