using Egzamin.DTOs.Requests;
using Egzamin.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Egzamin.Controllers
{
    [ApiController]
    [Route("/api/medicaments")]
    public class MedicamentsController : Controller
    {
        IMedicamentsService _medicamentsService;

        public MedicamentsController(IMedicamentsService medicamentsService)
        {
            _medicamentsService = medicamentsService;
        }

        [HttpGet("{id}")]
        public IActionResult Index(int id)
        {
            GetMedicamentDataDto medicamentData;

            try
            {
                medicamentData = _medicamentsService.GetMedicamentData(id);
                return Ok(_medicamentsService.GetMedicamentData(id));
            } catch(Exception e)
            {
                return BadRequest($"Błąd: {e.Message}");
            }

            
        }
    }
}
