using Egzamin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Egzamin.DTOs.Requests
{
    public class GetMedicamentDataDto
    {
        public int IdMedicament { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }

        public IList<Prescription> Prescriptions { get; set; }
    }
}
