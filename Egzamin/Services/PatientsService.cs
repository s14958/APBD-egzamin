using Egzamin.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Egzamin.Services
{
    public class PatientsService : IPatientsService
    {
        private MedicalDbContext _context;

        public PatientsService(MedicalDbContext context)
        {
            _context = context;
        }

        public void DeletePatient(int IdPatient)
        {
            var patient = _context.Patients.Where(patient => patient.IdPatient == IdPatient).FirstOrDefault();

            if (patient == null)
            {
                throw new Exception($"Pacjent o id: {IdPatient} nie istnieje");
            }

            var patientPrescriptions = _context.Prescriptions.Where(prescription => prescription.IdPatient == patient.IdPatient);

            var prescriptionMedicaments = _context.Prescription_Medicaments.Join(
                patientPrescriptions,
                prescriptionMedicament => prescriptionMedicament.IdPrescription,
                prescription => prescription.IdPrescription,
                (prescriptionMedicaments, prescriptions) => prescriptionMedicaments
            );

            _context.Prescription_Medicaments.RemoveRange(prescriptionMedicaments);
            _context.Prescriptions.RemoveRange(patientPrescriptions);
            _context.Patients.Remove(patient);

            _context.SaveChanges();
        }
    }
}
