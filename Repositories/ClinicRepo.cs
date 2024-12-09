using HospitalSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace HospitalSystem.Repositories
{
    public class ClinicRepo : IClinicRepo
    {
        private readonly ApplicationDbContext _context;
        public ClinicRepo(ApplicationDbContext context)
        {
            _context = context;
        }


        //Add clinic
        public void AddClinic(Clinic clinic)
        {
            _context.Clinic.Add(clinic);
            _context.SaveChanges();
        }

        //view all clinics
        public IEnumerable<Clinic> GetAllClinic()
        {
            return _context.Clinic.Include(c => c.Appoinments).ToList();
        }
    }
}
