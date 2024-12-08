using HospitalSystem.Services;
using Microsoft.AspNetCore.Mvc;

namespace HospitalSystem.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class AppointmentController : ControllerBase
    {
        private readonly IAppointmentService _appointmentService;

        public AppointmentController(IAppointmentService appointmentService)
        {
            _appointmentService = appointmentService;
        }

        [HttpGet("GetAllAppointmentByPatientId")]
        public IActionResult GetAppointmentsByPatient( int pid)
        {
            try
            {
                var appointments = _appointmentService.GetAppointmentsByPatient(pid);
                return Ok(appointments);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }
        }
        [HttpGet("GetAllAppointmentByClinicId")]
        public IActionResult GetAppointmentsByClinc(int cid)
        {
            try
            {
                var appointment = _appointmentService.GetAppointmentsByClinc(cid);
                return Ok(appointment);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }
        }

        [HttpPost("BookAppintment")]
        public IActionResult BookAppointment(string patientName, string ClinicName, DateTime Date)
        {
            try
            {
                _appointmentService.BookAppointment(patientName, ClinicName, Date);
                return Created();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
}
