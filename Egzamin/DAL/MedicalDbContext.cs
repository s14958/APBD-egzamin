using Egzamin.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Egzamin.DAL
{
    public class MedicalDbContext : DbContext
    {
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Prescription> Prescriptions { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Prescription_Medicament> Prescription_Medicaments { get; set; }
        public DbSet<Medicament> Medicaments { get; set; }


        public MedicalDbContext() { }

        public MedicalDbContext(DbContextOptions options) : base(options)
        {}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Prescription_Medicament>().HasKey(pm => new {
                pm.IdMedicament,
                pm.IdPrescription
            });

            Seed(modelBuilder);
        }

        private void Seed(ModelBuilder builder)
        {
            Random random = new Random();

            var d1 = new Doctor
            {
                IdDoctor = random.Next(),
                FirstName = "Adam",
                LastName = "Adamowicz",
                Email = "aadamowicz@gmail.com"
            };

            var d2 = new Doctor
            {
                IdDoctor = random.Next(),
                FirstName = "Filip",
                LastName = "Filipowicz",
                Email = "ffilipowicz@gmail.com"
            };

            var d3 = new Doctor
            {
                IdDoctor = random.Next(),
                FirstName = "Jan",
                LastName = "Janowicz",
                Email = "jjanowicz@gmail.com"
            };

            builder.Entity<Doctor>().HasData(new List<Doctor>() { d1, d2, d3 });

            var p1 = new Patient
            {
                IdPatient = random.Next(),
                FirstName = "Anna",
                LastName = "Annawska",
                BirthDate = new DateTime()
            };

            var p2 = new Patient
            {
                IdPatient = random.Next(),
                FirstName = "Jadwiga",
                LastName = "Jadwigowska",
                BirthDate = new DateTime()
            };

            var p3 = new Patient
            {
                IdPatient = random.Next(),
                FirstName = "Justyna",
                LastName = "Justynowska",
                BirthDate = new DateTime()
            };

            builder.Entity<Patient>().HasData(new List<Patient>() { p1, p2, p3 });

            var m1 = new Medicament
            {
                IdMedicament = random.Next(),
                Name = "A",
                Description = "AA",
                Type = "AAA"
            };

            var m2 = new Medicament
            {
                IdMedicament = random.Next(),
                Name = "A",
                Description = "AA",
                Type = "AAA"
            };

            var m3 = new Medicament
            {
                IdMedicament = random.Next(),
                Name = "A",
                Description = "AA",
                Type = "AAA"
            };

            builder.Entity<Medicament>().HasData(new List<Medicament>() { m1, m2, m3 });

            var prescription1 = new Prescription
            {
                IdPrescription = random.Next(),
                Date = new DateTime(),
                DueDate = new DateTime().AddDays(10),
                IdPatient = p1.IdPatient,
                IdDoctor = d1.IdDoctor
            };

            var prescription2 = new Prescription
            {
                IdPrescription = random.Next(),
                Date = new DateTime(),
                DueDate = new DateTime().AddDays(10),
                IdPatient = p2.IdPatient,
                IdDoctor = d2.IdDoctor
            };

            var prescription3 = new Prescription
            {
                IdPrescription = random.Next(),
                Date = new DateTime(),
                DueDate = new DateTime().AddDays(10),
                IdPatient = p3.IdPatient,
                IdDoctor = d3.IdDoctor
            };

            builder.Entity<Prescription>().HasData(
                new List<Prescription>() {
                    prescription1,
                    prescription2,
                    prescription3
                }
            );

            var pm1 = new Prescription_Medicament
            {
                IdMedicament = m1.IdMedicament,
                IdPrescription = prescription1.IdPrescription,
                Dose = random.Next(0, 100),
                Details = "AAA"
            };

            var pm2 = new Prescription_Medicament
            {
                IdMedicament = m2.IdMedicament,
                IdPrescription = prescription2.IdPrescription,
                Dose = random.Next(0, 100),
                Details = "AAA"
            };

            var pm3 = new Prescription_Medicament
            {
                IdMedicament = m3.IdMedicament,
                IdPrescription = prescription3.IdPrescription,
                Dose = random.Next(0, 100),
                Details = "AAA"
            };

            builder.Entity<Prescription_Medicament>().HasData(new List<Prescription_Medicament>()
            {
                pm1, pm2, pm3
            });
        }
    }
}
