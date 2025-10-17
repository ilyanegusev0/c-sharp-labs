namespace DeliverySystem
{
    public class Scooter : Vehicle
    {
        private int batteryCapacity;
        private double batteryLevel;

        public Scooter(string brand, int year, double mileage, int batteryCapacity) : base(brand, year, mileage, 45.0)
        {
            this.batteryCapacity = batteryCapacity;
            batteryLevel = 100;
        }

        public override string GetInfo()
        {
            return $"Scooter: {brand} ({year}), Battery: {batteryLevel}% of {batteryCapacity}Ah";
        }

        public override void Move(double distance)
        {
            if (batteryLevel > 0)
            {
                if (distance > batteryLevel * 2)
                    distance = batteryLevel * 2;

                base.Move(distance);

                batteryLevel -= distance * 0.5;
                if (batteryLevel < 0)
                    batteryLevel = 0;
            }

            if(batteryLevel <= 0)
                Console.WriteLine($"The battery of scooter {brand} is dead.");
        }

        public void Charge()
        {
            batteryLevel = 100;

            Console.WriteLine($"{brand} has been fully charged.");
        }
    }
}