namespace MedicalCabinetAPI.Models
{
    public class MedicalFolder
    {
        public int IdMF { get; set; }
        public int IdPatient { get; set; }
        public int IdPatientNumber { get; set; }
        public string? BloodType { get; set; }
        public string? Height { get; set; }
        public string? Weight { get; set; }
        public string? DateOfBirth { get; set; }
        public string? IsMarried { get; set; }
        public string? WhenMarried { get; set; }
        public int HowManyChildren { get; set; }
        public int HighBloodPressure { get; set; }
        public int Diabete { get; set; }
        public int HighCholesterol { get; set; }
        public int BleedingDisorder { get; set; }
        public int SurgeryBefore { get; set; }
        public string? Allergies { get; set; }
        public string? Observation { get; set; }
        public string? Files { get; set; }
        public int IdCabinet { get; set; }
    }
}