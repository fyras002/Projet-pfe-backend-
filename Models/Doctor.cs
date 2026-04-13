namespace MedicalCabinetAPI.Models
{
    public class Doctor : User
    {
        public int IdDoctor { get; set; }
        public int IdCabinet { get; set; }
        public string? LicenseNumber { get; set; }
        public DateTime HireDate { get; set; }
        public List<Speciality> Specialities { get; set; } = new List<Speciality>();
        public List<Consultation> Consultations { get; set; } = new List<Consultation>();
    }
}