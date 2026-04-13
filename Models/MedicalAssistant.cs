namespace MedicalCabinetAPI.Models
{
    public class MedicalAssistant : User
    {
        public int IdAssistant { get; set; }
        public int IdCabinet { get; set; }
        public string? Specialization { get; set; }
        public DateTime HireDate { get; set; }
    }
}