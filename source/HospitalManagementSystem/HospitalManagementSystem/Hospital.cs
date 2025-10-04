namespace HospitalManagementSystem
{
    public class Hospital
    {
        public List<Doctor> Doctors { get; private set; }
        public List<Patient> Patients { get; private set; }
        public List<HospitalRoom> Rooms { get; private set; }
        public List<MedicalRecord> Records { get; private set; }

        public Hospital()
        {
            Doctors = new List<Doctor>();
            Patients = new List<Patient>();
            Rooms = new List<HospitalRoom>();
            Records = new List<MedicalRecord>();
        }

        public void AddDoctor(Doctor doctor)
        {
            if (!Doctors.Contains(doctor))
            {
                Doctors.Add(doctor);
                Console.WriteLine($"Лікар {doctor.Name} доданий до системи.");
            }
        }

        public void RegisterPatient(Patient patient)
        {
            if (!Patients.Contains(patient))
            {
                Patients.Add(patient);
                Console.WriteLine($"Пацієнт {patient.Name} зареєстрований у системі.");
            }
        }

        public void CreateRoom(HospitalRoom room)
        {
            if (!Rooms.Contains(room))
            {
                Rooms.Add(room);
                Console.WriteLine($"Палата #{room.RoomNumber} додана до системи (місткість: {room.Capacity}).");
            }
        }

        public void HospitalizePatient(int patientId, int roomNumber)
        {
            Patient patient = Patients.FirstOrDefault(p => p.Id == patientId);
            HospitalRoom room = Rooms.FirstOrDefault(r => r.RoomNumber == roomNumber);

            if (patient == null)
            {
                Console.WriteLine($"Пацієнта з ID #{patientId} не знайдено.");
                return;
            }

            if (room == null)
            {
                Console.WriteLine($"Палату #{roomNumber} не знайдено.");
                return;
            }

            room.AddPatient(patient);
        }

        public void AddMedicalRecord(MedicalRecord record)
        {
            if (!Records.Contains(record))
            {
                Records.Add(record);
                Console.WriteLine($"Медичний запис створено: {record.Patient.Name} -> {record.Doctor.Name}.");
            }
        }

        public List<MedicalRecord>? GetPatientHistory(int patientId)
        {
            return Records.FindAll(r => r.Patient.Id == patientId);
        }

        public string GetStatistics()
        {
            int totalPatientsInRooms = 0;
            foreach (HospitalRoom room in Rooms)
                totalPatientsInRooms += room.Patients.Count;

            string statistics = "=== СТАТИСТИКА ЛІКАРНІ ===\n" +
                 $"Кількість лікарів: {Doctors.Count}\n" +
                 $"Кількість зареєстрованих пацієнтів: {Patients.Count}\n" +
                 $"Кількість палат: {Rooms.Count}\n" +
                 $"Кількість пацієнтів у палатах: {totalPatientsInRooms}\n" +
                 $"Кількість медичних записів: {Records.Count}";

            return statistics;
        }
    }
}