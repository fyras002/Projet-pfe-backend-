namespace MedicalCabinetAPI.Models
{
    public class Insurance
    {
        public int IdInsurance { get; set; }
        public string? Title { get; set; }
        public string? Type { get; set; }
        public string? Company { get; set; }
        public string? PhoneCompany { get; set; }
        public string? EmailCompany { get; set; }
        public string? AddressCompany { get; set; }
        public string? Details { get; set; }
        public int Active { get; set; }
        public int IdPatient { get; set; }
        public int IdCabinet { get; set; }
    }
}