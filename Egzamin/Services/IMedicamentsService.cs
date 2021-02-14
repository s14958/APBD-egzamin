using Egzamin.DTOs.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Egzamin.Services
{
    public interface IMedicamentsService
    {
        public GetMedicamentDataDto GetMedicamentData(int IdMedicament);
    }
}
