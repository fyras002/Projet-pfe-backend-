namespace MedicalCabinetAPI.Models
{
    public class Prescription
    {
        public int IdP { get; set; }
        public int IdCabinet { get; set; }
        public int IdPatient { get; set; }
        public int IdConsultation { get; set; }
        public string? PrescriptionText { get; set; }
        public string? MedicationsTitleDaysPerDays { get; set; }
    }
}