using Apteka.Models.Dto;
using Apteka.Services.IServices;
using Apteka.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Apteka.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly ILogger<PatientController> _logger;
        private readonly IPatientService _patientService;

        public PatientController(
            ILogger<PatientController> logger,
            IPatientService patientService)
        {
            _logger = logger;
            _patientService = patientService;
        }

        [HttpPost]
       public async Task<IActionResult> AddPrescriptionAsync([FromBody] int patientId)
        {
            try
            {
                _logger.LogInformation("Added new Prescription");
                await _patientService.GetById(patientId);
                return Ok();
            }
            catch (ArgumentException ex)
            {
                return BadRequest($"An error occurred: {ex.InnerException.Message}");
            }
        }
    }
}
