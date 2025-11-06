namespace SmartHomeSystem
{
    public class MotionSensor : Device
    {
        public override void TurnOn()
        {
            if (!IsOn)
            {
                IsOn = true;
                Console.WriteLine($"{Name} активовано.");
            }
        }

        public override void TurnOff()
        {
            if (IsOn)
            {
                IsOn = false;
                Console.WriteLine($"{Name} деактивовано.");
            }
        }
    }
}
