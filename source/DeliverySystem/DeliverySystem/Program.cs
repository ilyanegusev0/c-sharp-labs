namespace DeliverySystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Scooter
            Scooter scooter = new Scooter("Xiaomi", 2025, 1000, 45);
            Console.WriteLine(scooter.GetInfo());
            Console.WriteLine($"Max speed of scooter: {scooter.GetMaxSpeed()} km/h");
            scooter.Move(1000);
            scooter.Charge();
            scooter.Move(100);

            Console.WriteLine();

            // Car
            Car car = new Car("Toyota", 2020, 15000, 4);
            Console.WriteLine(car.GetInfo());
            Console.WriteLine($"Max speed of car: {car.GetMaxSpeed()} km/h");
            car.Move(1000);
            car.Refuel(25);
            car.Move(1000);
            car.Refuel(100);
            car.Move(100);

            Console.WriteLine();

            // Van
            Van van = new Van("Ford", 2015, 45000, 2, 2000);
            Console.WriteLine(van.GetInfo());
            Console.WriteLine($"Max speed of van: {van.GetMaxSpeed()} km/h");
            van.Move(1000);
            van.Refuel(25);
            van.Move(1000);
            van.Refuel(100);
            van.Move(100);
            van.UnloadCargo();
            van.LoadCargo(10000);
            van.LoadCargo(1000);
            van.UnloadCargo();
        }
    }
}