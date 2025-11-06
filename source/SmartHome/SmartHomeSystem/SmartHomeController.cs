namespace SmartHomeSystem
{
    public class SmartHomeController
    {
        private List<ISwitchable> switchableDevices = new List<ISwitchable>();
        private List<IEnergyConsumer> energyDevices = new List<IEnergyConsumer>();

        public void AddDevice(ISwitchable device)
        {
            if (!switchableDevices.Contains(device))
                switchableDevices.Add(device);
        }

        public void AddEnergyDevice(IEnergyConsumer device)
        {
            if (!energyDevices.Contains(device))
                energyDevices.Add(device);
        }

        public void TurnAllOn()
        {
            foreach (var device in switchableDevices)
                device?.TurnOn();
        }

        public void TurnAllOff()
        {
            foreach (var device in switchableDevices)
                device?.TurnOff();
        }

        public void ShowEnergyReport(int hours)
        {
            Console.WriteLine($"Звіт про споживання енергії за {hours} год:");

            double energyTotal = 0;

            foreach (var device in energyDevices)
            {
                energyTotal += device.GetEnergyUsage(hours);
                Console.WriteLine($"{device.DeviceName}: {device.GetEnergyUsage(hours):F2} кВт·год (потужність: {device.PowerConsumption} Вт)");
            }

            Console.WriteLine(
                $"Загальне споживання: {energyTotal:F2} кВт·год\n" +
                $"Вартість (~4 грн/кВт·год): {energyTotal * 4:F2} грн");
        }
    }
}
