namespace SmartHomeSystem
{
    public class Light : Device, IEnergyConsumer
    {
        public string DeviceName => Name;
        public int PowerConsumption => 60;

        public override void TurnOn()
        {
            if (!IsOn)
            {
                IsOn = true;
                Console.WriteLine($"{Name} засвітилася.");
            }
        }

        public override void TurnOff()
        {
            if (IsOn)
            {
                IsOn = false;
                Console.WriteLine($"{Name} вимкнена.");
            }
        }

        public double GetEnergyUsage(int hours)
        {
            if (IsOn)
                return PowerConsumption * hours / 1000.0;
            else
                return 0;
        }
    }
}