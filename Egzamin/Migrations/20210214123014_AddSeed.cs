using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Egzamin.Migrations
{
    public partial class AddSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Doctors",
                columns: new[] { "IdDoctor", "Email", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 194343274, "aadamowicz@gmail.com", "Adam", "Adamowicz" },
                    { 765069155, "ffilipowicz@gmail.com", "Filip", "Filipowicz" },
                    { 1823315558, "jjanowicz@gmail.com", "Jan", "Janowicz" }
                });

            migrationBuilder.InsertData(
                table: "Medicaments",
                columns: new[] { "IdMedicament", "Description", "Name", "Type" },
                values: new object[,]
                {
                    { 70238570, "AA", "A", "AAA" },
                    { 287846971, "AA", "A", "AAA" },
                    { 1403662933, "AA", "A", "AAA" }
                });

            migrationBuilder.InsertData(
                table: "Patients",
                columns: new[] { "IdPatient", "BirthDate", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 126507981, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Anna", "Annawska" },
                    { 1514420107, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jadwiga", "Jadwigowska" },
                    { 1047822992, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Justyna", "Justynowska" }
                });

            migrationBuilder.InsertData(
                table: "Prescriptions",
                columns: new[] { "IdPrescription", "Date", "DueDate", "IdDoctor", "IdPatient" },
                values: new object[,]
                {
                    { 794029451, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 194343274, 126507981 },
                    { 1053208964, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 765069155, 1514420107 },
                    { 360633305, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 1823315558, 1047822992 }
                });

            migrationBuilder.InsertData(
                table: "Prescription_Medicaments",
                columns: new[] { "IdMedicament", "IdPrescription", "Details", "Dose" },
                values: new object[] { 70238570, 794029451, "AAA", 98 });

            migrationBuilder.InsertData(
                table: "Prescription_Medicaments",
                columns: new[] { "IdMedicament", "IdPrescription", "Details", "Dose" },
                values: new object[] { 287846971, 1053208964, "AAA", 72 });

            migrationBuilder.InsertData(
                table: "Prescription_Medicaments",
                columns: new[] { "IdMedicament", "IdPrescription", "Details", "Dose" },
                values: new object[] { 1403662933, 360633305, "AAA", 84 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "IdDoctor",
                keyValue: 194343274);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "IdDoctor",
                keyValue: 765069155);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "IdDoctor",
                keyValue: 1823315558);

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "IdPatient",
                keyValue: 126507981);

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "IdPatient",
                keyValue: 1047822992);

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "IdPatient",
                keyValue: 1514420107);

            migrationBuilder.DeleteData(
                table: "Prescription_Medicaments",
                keyColumns: new[] { "IdMedicament", "IdPrescription" },
                keyValues: new object[] { 70238570, 794029451 });

            migrationBuilder.DeleteData(
                table: "Prescription_Medicaments",
                keyColumns: new[] { "IdMedicament", "IdPrescription" },
                keyValues: new object[] { 287846971, 1053208964 });

            migrationBuilder.DeleteData(
                table: "Prescription_Medicaments",
                keyColumns: new[] { "IdMedicament", "IdPrescription" },
                keyValues: new object[] { 1403662933, 360633305 });

            migrationBuilder.DeleteData(
                table: "Medicaments",
                keyColumn: "IdMedicament",
                keyValue: 70238570);

            migrationBuilder.DeleteData(
                table: "Medicaments",
                keyColumn: "IdMedicament",
                keyValue: 287846971);

            migrationBuilder.DeleteData(
                table: "Medicaments",
                keyColumn: "IdMedicament",
                keyValue: 1403662933);

            migrationBuilder.DeleteData(
                table: "Prescriptions",
                keyColumn: "IdPrescription",
                keyValue: 360633305);

            migrationBuilder.DeleteData(
                table: "Prescriptions",
                keyColumn: "IdPrescription",
                keyValue: 794029451);

            migrationBuilder.DeleteData(
                table: "Prescriptions",
                keyColumn: "IdPrescription",
                keyValue: 1053208964);
        }
    }
}
