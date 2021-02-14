using Egzamin.DAL;
using Egzamin.DTOs.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Egzamin.Services
{
    public class MedicamentsService : IMedicamentsService
    {
        private MedicalDbContext _context;

        public MedicamentsService(MedicalDbContext context)
        {
            _context = context;
        }

        public GetMedicamentDataDto GetMedicamentData(int IdMedicament)
        {
            var medicamentQuery = _context.Medicaments.Where(medicament => medicament.IdMedicament == IdMedicament);
            var medicament = medicamentQuery.FirstOrDefault();

            if (medicament == null)
            {
                throw new Exception($"Medicament o id: {IdMedicament} nie istnieje w DB");
            }

            var prescriptions = _context.Prescription_Medicaments
                .Where(prescription_medicament => prescription_medicament.IdMedicament == medicament.IdMedicament)
                .Join(
                    _context.Prescriptions,
                    prescription_medicament => prescription_medicament.IdPrescription,
                    prescription => prescription.IdPrescription,
                    (prescription_medicament, prescription) => prescription
                )
                .OrderBy(prescription => prescription.DueDate)
                .ToList();

            var medicamentData = new GetMedicamentDataDto
            {
                IdMedicament = medicament.IdMedicament,
                Name = medicament.Name,
                Description = medicament.Description,
                Type = medicament.Type,
                Prescriptions = prescriptions
            };

            return medicamentData;
        }
    }
}
