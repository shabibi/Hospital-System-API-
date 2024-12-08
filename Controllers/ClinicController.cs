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


        [HttpPost]
        public IActionResult AddClinic(ClinicDTO clinicDTO)
        {
            try
            {
                if (clinicDTO == null)
                {
                    return BadRequest("Clinic data is null");
                }
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var clinic = new Clinic
                {
                    specilization = clinicDTO.Specilization,
                    NumberOfSlots = clinicDTO.NumberOfSlots,
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
        public IActionResult GetAllPatients()
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
