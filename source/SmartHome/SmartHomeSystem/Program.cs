namespace SmartHomeSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SmartHomeController smartHomeController = new SmartHomeController();

            List<Device> devices = new List<Device>
            {
                new Light() {Name = "Лампа у вітальні"},
                new Light() {Name = "Лампа у гаражі"},
                new AirConditioner() { Name = "Кондиціонер у спальні"},
                new CoffeeMachine() {Name = "Кавомашина на кухні"},
                new MotionSensor() { Name = "Датчик руху у коридорі"},
            };

            foreach (var device in devices)
            {
                if (device is ISwitchable)
                    smartHomeController.AddDevice(device);

                IEnergyConsumer? energyDevice = device as IEnergyConsumer;

                if (energyDevice != null)
                    smartHomeController.AddEnergyDevice(energyDevice);
            }

            smartHomeController.TurnAllOn();

            foreach (var device in devices)
                device.PrintStatus();

            smartHomeController.ShowEnergyReport(5);

            smartHomeController.TurnAllOff();

            foreach (var device in devices)
                device.PrintStatus();
        }
    }
}