namespace MedicalCabinetAPI.Models
{
    public class FamilyRelations
    {
        public int IdFamily { get; set; }
        public int IdPatient { get; set; }
        public int IdPatient2 { get; set; }
        public int IsWife { get; set; }
        public int IsHusband { get; set; }
        public int IsFather { get; set; }
        public int IsMother { get; set; }
        public int IsSun { get; set; }
        public int IsSister { get; set; }
        public int IsCousin { get; set; }
    }
}