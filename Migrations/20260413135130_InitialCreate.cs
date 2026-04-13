using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MedicalCabinetAPI.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DiseaseCategories",
                columns: table => new
                {
                    IdDC = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TitleDCEN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TitleDCFR = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TitleDCAR = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DescDC = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiseaseCategories", x => x.IdDC);
                });

            migrationBuilder.CreateTable(
                name: "Specialities",
                columns: table => new
                {
                    IdS = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TitleEN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TitleFR = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TitleAR = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Specialities", x => x.IdS);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    IdUser = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Phone = table.Column<int>(type: "int", nullable: false),
                    Phone2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdCountry = table.Column<int>(type: "int", nullable: false),
                    IdCity = table.Column<int>(type: "int", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Active = table.Column<int>(type: "int", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(21)", maxLength: 21, nullable: false),
                    IdDoctor = table.Column<int>(type: "int", nullable: true),
                    Doctor_IdCabinet = table.Column<int>(type: "int", nullable: true),
                    LicenseNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Doctor_HireDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IdAssistant = table.Column<int>(type: "int", nullable: true),
                    MedicalAssistant_IdCabinet = table.Column<int>(type: "int", nullable: true),
                    Specialization = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HireDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IdPatient = table.Column<int>(type: "int", nullable: true),
                    PatientNumber = table.Column<int>(type: "int", nullable: true),
                    IdCabinet = table.Column<int>(type: "int", nullable: true),
                    Details = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateInscription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InsuranceNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InsuranceFinDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InsuranceCopie = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IllnessCardNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IllnessFinDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IllnessCardCopie = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.IdUser);
                });

            migrationBuilder.CreateTable(
                name: "Diseases",
                columns: table => new
                {
                    IdDisease = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TitleEN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TitleFR = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TitleAR = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdMedicineSpeciality = table.Column<int>(type: "int", nullable: false),
                    IdTreatmentType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MedicationList = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SymptomList = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Files = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Active = table.Column<int>(type: "int", nullable: false),
                    IdDC = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Diseases", x => x.IdDisease);
                    table.ForeignKey(
                        name: "FK_Diseases_DiseaseCategories_IdDC",
                        column: x => x.IdDC,
                        principalTable: "DiseaseCategories",
                        principalColumn: "IdDC",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Allergies",
                columns: table => new
                {
                    IdAllergy = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TitleEN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TitleFR = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TitleAR = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdCabinet = table.Column<int>(type: "int", nullable: false),
                    IdPatient = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Allergies", x => x.IdAllergy);
                    table.ForeignKey(
                        name: "FK_Allergies_Users_IdPatient",
                        column: x => x.IdPatient,
                        principalTable: "Users",
                        principalColumn: "IdUser",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Consultations",
                columns: table => new
                {
                    IdCons = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HeartMesure = table.Column<float>(type: "real", nullable: false),
                    OxygeneMesure = table.Column<int>(type: "int", nullable: false),
                    BloodMesure = table.Column<float>(type: "real", nullable: false),
                    Observation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SizeMesure = table.Column<float>(type: "real", nullable: false),
                    HeightMesure = table.Column<int>(type: "int", nullable: false),
                    IdInsurancePatient = table.Column<int>(type: "int", nullable: false),
                    IdDoctorCons = table.Column<int>(type: "int", nullable: false),
                    Payed = table.Column<int>(type: "int", nullable: false),
                    Details = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FilesConsultation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdCabinet = table.Column<int>(type: "int", nullable: false),
                    IdPatient = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Consultations", x => x.IdCons);
                    table.ForeignKey(
                        name: "FK_Consultations_Users_IdDoctorCons",
                        column: x => x.IdDoctorCons,
                        principalTable: "Users",
                        principalColumn: "IdUser");
                    table.ForeignKey(
                        name: "FK_Consultations_Users_IdPatient",
                        column: x => x.IdPatient,
                        principalTable: "Users",
                        principalColumn: "IdUser");
                });

            migrationBuilder.CreateTable(
                name: "DoctorSpeciality",
                columns: table => new
                {
                    DoctorIdUser = table.Column<int>(type: "int", nullable: false),
                    SpecialitiesIdS = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DoctorSpeciality", x => new { x.DoctorIdUser, x.SpecialitiesIdS });
                    table.ForeignKey(
                        name: "FK_DoctorSpeciality_Specialities_SpecialitiesIdS",
                        column: x => x.SpecialitiesIdS,
                        principalTable: "Specialities",
                        principalColumn: "IdS",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DoctorSpeciality_Users_DoctorIdUser",
                        column: x => x.DoctorIdUser,
                        principalTable: "Users",
                        principalColumn: "IdUser",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FamilyRelations",
                columns: table => new
                {
                    IdFamily = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdPatient = table.Column<int>(type: "int", nullable: false),
                    IdPatient2 = table.Column<int>(type: "int", nullable: false),
                    IsWife = table.Column<int>(type: "int", nullable: false),
                    IsHusband = table.Column<int>(type: "int", nullable: false),
                    IsFather = table.Column<int>(type: "int", nullable: false),
                    IsMother = table.Column<int>(type: "int", nullable: false),
                    IsSun = table.Column<int>(type: "int", nullable: false),
                    IsSister = table.Column<int>(type: "int", nullable: false),
                    IsCousin = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FamilyRelations", x => x.IdFamily);
                    table.ForeignKey(
                        name: "FK_FamilyRelations_Users_IdPatient",
                        column: x => x.IdPatient,
                        principalTable: "Users",
                        principalColumn: "IdUser",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Insurances",
                columns: table => new
                {
                    IdInsurance = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Company = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneCompany = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailCompany = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AddressCompany = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Details = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Active = table.Column<int>(type: "int", nullable: false),
                    IdPatient = table.Column<int>(type: "int", nullable: false),
                    IdCabinet = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Insurances", x => x.IdInsurance);
                    table.ForeignKey(
                        name: "FK_Insurances_Users_IdPatient",
                        column: x => x.IdPatient,
                        principalTable: "Users",
                        principalColumn: "IdUser",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MedicalFolders",
                columns: table => new
                {
                    IdMF = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdPatient = table.Column<int>(type: "int", nullable: false),
                    IdPatientNumber = table.Column<int>(type: "int", nullable: false),
                    BloodType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Height = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Weight = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOfBirth = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsMarried = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WhenMarried = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HowManyChildren = table.Column<int>(type: "int", nullable: false),
                    HighBloodPressure = table.Column<int>(type: "int", nullable: false),
                    Diabete = table.Column<int>(type: "int", nullable: false),
                    HighCholesterol = table.Column<int>(type: "int", nullable: false),
                    BleedingDisorder = table.Column<int>(type: "int", nullable: false),
                    SurgeryBefore = table.Column<int>(type: "int", nullable: false),
                    Allergies = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Observation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Files = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdCabinet = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicalFolders", x => x.IdMF);
                    table.ForeignKey(
                        name: "FK_MedicalFolders_Users_IdPatient",
                        column: x => x.IdPatient,
                        principalTable: "Users",
                        principalColumn: "IdUser",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Symptoms",
                columns: table => new
                {
                    IdSymptom = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TitleEN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TitleFR = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TitleAR = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdCabinet = table.Column<int>(type: "int", nullable: false),
                    IdPatient = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Symptoms", x => x.IdSymptom);
                    table.ForeignKey(
                        name: "FK_Symptoms_Users_IdPatient",
                        column: x => x.IdPatient,
                        principalTable: "Users",
                        principalColumn: "IdUser",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Prescriptions",
                columns: table => new
                {
                    IdP = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdCabinet = table.Column<int>(type: "int", nullable: false),
                    IdPatient = table.Column<int>(type: "int", nullable: false),
                    IdConsultation = table.Column<int>(type: "int", nullable: false),
                    PrescriptionText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MedicationsTitleDaysPerDays = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prescriptions", x => x.IdP);
                    table.ForeignKey(
                        name: "FK_Prescriptions_Consultations_IdConsultation",
                        column: x => x.IdConsultation,
                        principalTable: "Consultations",
                        principalColumn: "IdCons",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Prescriptions_Users_IdPatient",
                        column: x => x.IdPatient,
                        principalTable: "Users",
                        principalColumn: "IdUser",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Allergies_IdPatient",
                table: "Allergies",
                column: "IdPatient");

            migrationBuilder.CreateIndex(
                name: "IX_Consultations_IdDoctorCons",
                table: "Consultations",
                column: "IdDoctorCons");

            migrationBuilder.CreateIndex(
                name: "IX_Consultations_IdPatient",
                table: "Consultations",
                column: "IdPatient");

            migrationBuilder.CreateIndex(
                name: "IX_Diseases_IdDC",
                table: "Diseases",
                column: "IdDC");

            migrationBuilder.CreateIndex(
                name: "IX_DoctorSpeciality_SpecialitiesIdS",
                table: "DoctorSpeciality",
                column: "SpecialitiesIdS");

            migrationBuilder.CreateIndex(
                name: "IX_FamilyRelations_IdPatient",
                table: "FamilyRelations",
                column: "IdPatient");

            migrationBuilder.CreateIndex(
                name: "IX_Insurances_IdPatient",
                table: "Insurances",
                column: "IdPatient");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalFolders_IdPatient",
                table: "MedicalFolders",
                column: "IdPatient",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Prescriptions_IdConsultation",
                table: "Prescriptions",
                column: "IdConsultation");

            migrationBuilder.CreateIndex(
                name: "IX_Prescriptions_IdPatient",
                table: "Prescriptions",
                column: "IdPatient");

            migrationBuilder.CreateIndex(
                name: "IX_Symptoms_IdPatient",
                table: "Symptoms",
                column: "IdPatient");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Allergies");

            migrationBuilder.DropTable(
                name: "Diseases");

            migrationBuilder.DropTable(
                name: "DoctorSpeciality");

            migrationBuilder.DropTable(
                name: "FamilyRelations");

            migrationBuilder.DropTable(
                name: "Insurances");

            migrationBuilder.DropTable(
                name: "MedicalFolders");

            migrationBuilder.DropTable(
                name: "Prescriptions");

            migrationBuilder.DropTable(
                name: "Symptoms");

            migrationBuilder.DropTable(
                name: "DiseaseCategories");

            migrationBuilder.DropTable(
                name: "Specialities");

            migrationBuilder.DropTable(
                name: "Consultations");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
