using Apteka.Models.Dto;
using Apteka.Services;
using Apteka.Services.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Apteka.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrescriptionController : ControllerBase
    {
        private readonly ILogger<PrescriptionController> _logger;
        private readonly IPrescriptionService _prescriptionService;

        public PrescriptionController(
            ILogger<PrescriptionController> logger,
            PrescriptionService prescriptionService)
        {
            _logger = logger;
            _prescriptionService = prescriptionService;
        }

        [HttpPost]
        public async Task<IActionResult> AddPrescriptionAsync([FromBody] AddPrescriptionDto request)
        {
            try
            {
                _logger.LogInformation("Added new Prescription");
                await _prescriptionService.MakeNewPrescriptionAsync(request);
                return Ok();
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}
