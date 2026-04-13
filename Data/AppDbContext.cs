using Microsoft.EntityFrameworkCore;
using MedicalCabinetAPI.Models;

namespace MedicalCabinetAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<MedicalAssistant> MedicalAssistants { get; set; }
        public DbSet<MedicalFolder> MedicalFolders { get; set; }
        public DbSet<FamilyRelations> FamilyRelations { get; set; }
        public DbSet<DiseaseCategory> DiseaseCategories { get; set; }
        public DbSet<Disease> Diseases { get; set; }
        public DbSet<Speciality> Specialities { get; set; }
        public DbSet<Symptom> Symptoms { get; set; }
        public DbSet<Allergy> Allergies { get; set; }
        public DbSet<Consultation> Consultations { get; set; }
        public DbSet<Prescription> Prescriptions { get; set; }
        public DbSet<Insurance> Insurances { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Explicit primary keys
            modelBuilder.Entity<Allergy>().HasKey(a => a.IdAllergy);
            modelBuilder.Entity<Consultation>().HasKey(c => c.IdCons);
            modelBuilder.Entity<Disease>().HasKey(d => d.IdDisease);
            modelBuilder.Entity<DiseaseCategory>().HasKey(dc => dc.IdDC);
            modelBuilder.Entity<FamilyRelations>().HasKey(f => f.IdFamily);
            modelBuilder.Entity<Insurance>().HasKey(i => i.IdInsurance);
            modelBuilder.Entity<MedicalFolder>().HasKey(mf => mf.IdMF);
            modelBuilder.Entity<Prescription>().HasKey(p => p.IdP);
            modelBuilder.Entity<Speciality>().HasKey(s => s.IdS);
            modelBuilder.Entity<Symptom>().HasKey(s => s.IdSymptom);
            modelBuilder.Entity<User>().HasKey(u=>u.IdUser);

            // TPH inheritance - all in one Users table
            modelBuilder.Entity<User>().ToTable("Users");
            modelBuilder.Entity<Doctor>().ToTable("Users");
            modelBuilder.Entity<Patient>().ToTable("Users");
            modelBuilder.Entity<MedicalAssistant>().ToTable("Users");

            // Doctor → Consultations
            modelBuilder.Entity<Doctor>()
                .HasMany(d => d.Consultations)
                .WithOne()
                .HasForeignKey(c => c.IdDoctorCons)
                .OnDelete(DeleteBehavior.NoAction);

            // Doctor → Specialities (many-to-many)
            modelBuilder.Entity<Doctor>()
                .HasMany(d => d.Specialities)
                .WithMany();

            // Patient → MedicalFolder (one-to-one)
            modelBuilder.Entity<Patient>()
                .HasOne(p => p.MedicalFolder)
                .WithOne()
                .HasForeignKey<MedicalFolder>(mf => mf.IdPatient);

            // Patient → Consultations
            modelBuilder.Entity<Patient>()
                .HasMany(p => p.Consultations)
                .WithOne()
                .HasForeignKey(c => c.IdPatient)
                .OnDelete(DeleteBehavior.NoAction);

            // Patient → Prescriptions
            modelBuilder.Entity<Patient>()
                .HasMany(p => p.Prescriptions)
                .WithOne()
                .HasForeignKey(p => p.IdPatient);

            // Patient → FamilyRelations
            modelBuilder.Entity<Patient>()
                .HasMany(p => p.FamilyRelations)
                .WithOne()
                .HasForeignKey(f => f.IdPatient);

            // Disease → DiseaseCategory
            modelBuilder.Entity<Disease>()
                .HasOne<DiseaseCategory>()
                .WithMany()
                .HasForeignKey(d => d.IdDC);

            // Symptom → Patient
            modelBuilder.Entity<Symptom>()
                .HasOne<Patient>()
                .WithMany()
                .HasForeignKey(s => s.IdPatient);

            // Allergy → Patient
            modelBuilder.Entity<Allergy>()
                .HasOne<Patient>()
                .WithMany()
                .HasForeignKey(a => a.IdPatient);

            // Prescription → Consultation
            modelBuilder.Entity<Prescription>()
                .HasOne<Consultation>()
                .WithMany()
                .HasForeignKey(p => p.IdConsultation);

            // Insurance → Patient
            modelBuilder.Entity<Insurance>()
                .HasOne<Patient>()
                .WithMany()
                .HasForeignKey(i => i.IdPatient);
        }
    }
}