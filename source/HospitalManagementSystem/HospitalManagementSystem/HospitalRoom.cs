namespace HospitalManagementSystem
{
    public class HospitalRoom
    {
        public int RoomNumber { get; private set; }
        public int Capacity { get; private set; }
        public List<Patient> Patients { get; private set; }

        public HospitalRoom(int roomNumber, int capacity)
        {
            RoomNumber = roomNumber;
            Capacity = capacity;
            Patients = new List<Patient>();
        }

        public void AddPatient(Patient patient)
        {
            if (Patients.Count < Capacity)
            {
                if (!Patients.Contains(patient))
                {
                    Patients.Add(patient);
                    Console.WriteLine($"Пацієнт {patient.Name} доданий до палати #{RoomNumber}.");
                }
                else
                {
                    Console.WriteLine($"Пацієнт {patient.Name} вже зареєстрований у палаті #{RoomNumber}.");
                }
            }
            else
            {
                Console.WriteLine($"Палата #{RoomNumber} переповнена.");
            }
        }
    }
}
