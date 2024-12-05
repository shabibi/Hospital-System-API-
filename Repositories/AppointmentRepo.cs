using HospitalSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace HospitalSystem.Repositories
{
    public class AppointmentRepo : IAppointmentRepo
    {
        private readonly ApplicationDbContext _context;

        public AppointmentRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        //view appoinment by clinic id
        public Appoinment GetAppointmentsByClinci(int cid)
        {
            return _context.Appoinments.FirstOrDefault(a => a.CID == cid);
        }

        //view appoinment by patient id 
        public Appoinment GetAppointmentsByPatient(int pid)
        {
            return _context.Appoinments.FirstOrDefault(a => a.PID == pid);
        }
    }
}
