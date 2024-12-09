using HospitalSystem.Models;
using HospitalSystem.Services;
using Microsoft.AspNetCore.Mvc;

namespace HospitalSystem.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class PatientController : ControllerBase
    {
        private readonly IPatientService _patientService;

        public PatientController(IPatientService patientService)
        {
            _patientService = patientService;
        }
        [HttpPost("AddPatient")]
      
        public IActionResult AddPatient(string patientName, int Age, Gender gender)
        {
            try
            {
                if (patientName == null)
                {
                    return BadRequest("Patient data is null");
                }
                if(!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var patient = new Patient
                {
                    PName = patientName,
                    age = Age,
                    gender = gender
                };
                _patientService.AddPatient(patient);
                return CreatedAtAction(nameof(AddPatient), new { id = patient.PID }, patient);
            }
            catch (Exception ex) { ex.ToString(); 
                return StatusCode(500,"Error ");
            }

        }

        [HttpGet("GetAllPatients")]
        public IActionResult GetAllPatients()
        {
            try
            {
                var patients = _patientService.GetAllPatients();
                return Ok(patients);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }
        }

    }
}
