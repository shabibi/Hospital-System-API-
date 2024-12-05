using HospitalSystem.Models;
using HospitalSystem.Repositories;
using Microsoft.EntityFrameworkCore;

namespace HospitalSystem.Services
{
    public class PatientService : IPatientService
    {
        private readonly IPatientRepo _patientRepo;
        public PatientService(IPatientRepo patientRepo)
        {
            _patientRepo = patientRepo;
        }

        public void AddPatient(Patient patient)
        {
            _patientRepo.AddPatient(patient);
        }
        public IEnumerable<Patient> GetAllPatients()
        {
            return _patientRepo.GetAllPatients().ToList();
        }
    }
}
