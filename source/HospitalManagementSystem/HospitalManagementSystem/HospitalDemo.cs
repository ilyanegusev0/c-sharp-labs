namespace HospitalManagementSystem
{
    public class HospitalDemo
    {
        public void Run()
        {
            Console.WriteLine("=== СИСТЕМА УПРАВЛІННЯ ЛІКАРНЕЮ ===");

            Hospital hospital = new Hospital();

            // Додавання лікарів
            Console.WriteLine("\n--- ДОДАВАННЯ ЛІКАРІВ ---");

            Doctor doctor1 = new Doctor(1, "Іван", "Терапевт");
            Doctor doctor2 = new Doctor(2, "Володимир", "Кардіолог");
            hospital.AddDoctor(doctor1);
            hospital.AddDoctor(doctor2);

            // Реєстрація пацієнтів
            Console.WriteLine("\n--- РЕЄСТРАЦІЯ ПАЦІЄНТІВ ---");

            Patient patient1 = new Patient(1, "Андрій", 19);
            Patient patient2 = new Patient(2, "Сергій", 27);
            Patient patient3 = new Patient(3, "Максим", 35);
            hospital.RegisterPatient(patient1);
            hospital.RegisterPatient(patient2);
            hospital.RegisterPatient(patient3);

            // Створення палат
            Console.WriteLine("\n--- СТВОРЕННЯ ПАЛАТ ---");

            hospital.CreateRoom(new HospitalRoom(101, 4));
            hospital.CreateRoom(new HospitalRoom(102, 8));

            // Госпіталізація
            Console.WriteLine("\n--- ГОСПІТАЛІЗАЦІЯ ---");

            hospital.HospitalizePatient(1, 101);
            hospital.HospitalizePatient(2, 102);
            hospital.HospitalizePatient(3, 102);

            // Медичні записи
            Console.WriteLine("\n--- МЕДИЧНІ ЗАПИСИ ---");

            hospital.AddMedicalRecord(new MedicalRecord(patient1, doctor1, new DateTime(2025, 10, 6, 12, 35, 45), "ГРВІ"));
            hospital.AddMedicalRecord(new MedicalRecord(patient2, doctor2, new DateTime(2025, 9, 29, 18, 15, 30), "Бронхіт"));
            hospital.AddMedicalRecord(new MedicalRecord(patient3, doctor2, new DateTime(2025, 9, 15, 2, 25, 5), "Серцева недостатність"));

            // Історія пацієнта
            Console.WriteLine("\n--- ІСТОРІЯ ПАЦІЄНТА ---");

            List<MedicalRecord> history = hospital.GetPatientHistory(1);
            foreach (MedicalRecord record in history)
            {
                Console.WriteLine($"  Дата: {record.Date}");
                Console.WriteLine($"  Лікар: {record.Doctor.Name}");
                Console.WriteLine($"  Опис: {record.Description}\n");
            }

            // Статистика
            Console.WriteLine(hospital.GetStatistics());
        }
    }
}
