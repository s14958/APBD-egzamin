using Egzamin.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Egzamin.Controllers
{
    [ApiController]
    [Route("/api/patients")]
    public class PatientsController : Controller
    {
        IPatientsService _patientsService;

        public PatientsController(IPatientsService patientsService) {
            _patientsService = patientsService;
        }

        [HttpDelete("{id}")]
        public IActionResult DeletePatient(int id)
        {
            try
            {
                _patientsService.DeletePatient(id);
                return Ok($"Patient with id: {id} deleted");
            } catch (Exception e)
            {
                return BadRequest($"Błąd: {e.Message}");
            }
            
        }
    }
}
