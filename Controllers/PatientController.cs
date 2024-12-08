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

        [HttpPost]
        public IActionResult AddPatient(PatientDTO patientDTO)
        {
            try
            {
                if (patientDTO == null)
                {
                    return BadRequest("Patient data is null");
                }
                if(!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var patient = new Patient
                {
                    PName = patientDTO.PName,
                    age = patientDTO.Age,
                    gender = patientDTO.Gender
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
