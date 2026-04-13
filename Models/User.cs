namespace MedicalCabinetAPI.Models
{
    public abstract class User
    {
        public int IdUser { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Gender { get; set; } = string.Empty;
        public DateTime DateOfBirth { get; set; }
        public int Phone { get; set; }
        public string? Phone2 { get; set; }
        public string Email { get; set; } = string.Empty;
        public string? Image { get; set; }
        public int IdCountry { get; set; }
        public int IdCity { get; set; }
        public string? Address { get; set; }
        public int Active { get; set; }
    }
}