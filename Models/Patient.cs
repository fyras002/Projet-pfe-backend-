namespace MedicalCabinetAPI.Models
{
    public class Patient : User
    {
        public int IdPatient { get; set; }
        public int PatientNumber { get; set; }
        public int IdCabinet { get; set; }
        public string? Details { get; set; }
        public string? DateInscription { get; set; }
        public string? InsuranceNumber { get; set; }
        public string? InsuranceFinDate { get; set; }
        public string? InsuranceCopie { get; set; }
        public string? IllnessCardNumber { get; set; }
        public string? IllnessFinDate { get; set; }
        public string? IllnessCardCopie { get; set; }

        // Navigation properties
        public MedicalFolder? MedicalFolder { get; set; }
        public List<Consultation> Consultations { get; set; } = new List<Consultation>();
        public List<Prescription> Prescriptions { get; set; } = new List<Prescription>();
        public List<FamilyRelations> FamilyRelations { get; set; } = new List<FamilyRelations>();
    }
}