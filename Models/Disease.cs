namespace MedicalCabinetAPI.Models
{
    public class Disease
    {
        public int IdDisease { get; set; }
        public string? TitleEN { get; set; }
        public string? TitleFR { get; set; }
        public string? TitleAR { get; set; }
        public int IdMedicineSpeciality { get; set; }
        public string? IdTreatmentType { get; set; }
        public string? MedicationList { get; set; }
        public string? SymptomList { get; set; }
        public string? Files { get; set; }
        public int Active { get; set; }

        // Foreign key
        public int IdDC { get; set; }
    }
}