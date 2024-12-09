using HospitalSystem.Models;
using HospitalSystem.Services;
using Microsoft.AspNetCore.Mvc;

namespace HospitalSystem.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class ClinicController : ControllerBase
    {
        private readonly IClinicService _clinicService;

        public ClinicController(IClinicService clinicService)
        {
            _clinicService = clinicService;
        }

        [HttpPost("AddClinic")]
        public IActionResult AddClinic(string specilization,int numberOfSlots)
        {
            try
            {
                if (specilization == null && numberOfSlots == 0)
                {
                    return BadRequest("Clinic data is null");
                }
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var clinic = new Clinic
                {
                    specilization = specilization,
                    NumberOfSlots = numberOfSlots
                };
                _clinicService.AddClinic(clinic);
                return CreatedAtAction(nameof(AddClinic), new { id = clinic.CID }, clinic);
            }
            catch (Exception ex)
            {
                ex.ToString();
                return StatusCode(500, "Error ");
            }

        }

        [HttpGet("GetAllClincs")]
        public IActionResult GetAllClinic()
        {
            try
            {
                var clinics = _clinicService.GetAllClinic();
                return Ok(clinics);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }
        }
    }
}
