namespace MedicalCabinetAPI.Models
{
    public class Symptom
    {
        public int IdSymptom { get; set; }
        public string? TitleEN { get; set; }
        public string? TitleFR { get; set; }
        public string? TitleAR { get; set; }
        public string? Description { get; set; }
        public string? Image { get; set; }
        public int IdCabinet { get; set; }
        public int IdPatient { get; set; }
    }
}