using HospitalSystem.Models;

namespace HospitalSystem.Services
{
    public interface IPatientService
    {
        void AddPatient(Patient patient);
        IEnumerable<Patient> GetAllPatients();
    }
}