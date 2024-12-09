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
        public IEnumerable<Appoinment> GetAppointmentsByClinc(int cid)
        {
            return _context.Appoinments.Where(a => a.CID == cid).ToList();
        }

        //view appoinment by patient id 
        public IEnumerable<Appoinment> GetAppointmentsByPatient(int pid)
        {
            return _context.Appoinments.Where(a => a.PID == pid).ToList();
        }
        public void BookAppointment(Appoinment appoinment)
        {
            _context.Add(appoinment);
            _context.SaveChanges();
        }
    }
}
