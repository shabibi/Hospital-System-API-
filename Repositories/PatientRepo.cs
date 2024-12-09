using HospitalSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace HospitalSystem.Repositories
{
    public class PatientRepo : IPatientRepo
    {
        private readonly ApplicationDbContext _context;

        public PatientRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        //Add patirnt 
        public void AddPatient(Patient patient)
        {
            _context.Patients.Add(patient);
            _context.SaveChanges();
        }

        //Get All Patients
        public IEnumerable<Patient> GetAllPatients()
        {
            return _context.Patients.Include(p => p.Appoinments).ToList();
        }
    }
}
