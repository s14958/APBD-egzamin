using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Egzamin.Models
{
    public class Prescription_Medicament
    {
        [Key]
        [ForeignKey("Medicament")]
        public int IdMedicament { get; set; }
        [Key]
        [ForeignKey("Prescription")]
        public int IdPrescription { get; set; }
        public int? Dose { get; set; }
        [Required]
        public string Details { get; set; }

        [Required]
        public Prescription prescription { get; set; }
        [Required]
        public Medicament medicament { get; set; }
    }
}
