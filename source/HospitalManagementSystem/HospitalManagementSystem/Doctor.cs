namespace HospitalManagementSystem
{
    public class Doctor
    {
        public int Id;
        public string Name;
        public string Specialization;

        public Doctor(int id, string name, string specialization)
        {
            Id = id;
            Name = name;
            Specialization = specialization;
        }
    }
}
