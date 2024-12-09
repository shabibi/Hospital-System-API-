using HospitalSystem.Models;

namespace HospitalSystem.Repositories
{
    public interface IPatientRepo
    {
        void AddPatient(Patient patient);
        IEnumerable<Patient> GetAllPatients();
    }
}