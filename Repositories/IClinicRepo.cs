using HospitalSystem.Models;

namespace HospitalSystem.Repositories
{
    public interface IClinicRepo
    {
        void AddClinic(Clinic clinic);
        IEnumerable<Clinic> GetAllClinic();
    }
}