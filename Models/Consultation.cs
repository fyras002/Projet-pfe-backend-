namespace MedicalCabinetAPI.Models
{
    public class Consultation
    {
        public int IdCons { get; set; }
        public float HeartMesure { get; set; }
        public int OxygeneMesure { get; set; }
        public float BloodMesure { get; set; }
        public string? Observation { get; set; }
        public float SizeMesure { get; set; }
        public int HeightMesure { get; set; }
        public int IdInsurancePatient { get; set; }
        public int IdDoctorCons { get; set; }
        public int Payed { get; set; }
        public string? Details { get; set; }
        public DateTime DateTime { get; set; }
        public string? FilesConsultation { get; set; }
        public int IdCabinet { get; set; }
        public int IdPatient { get; set; }
    }
}