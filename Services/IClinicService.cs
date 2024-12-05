using HospitalSystem.Models;

namespace HospitalSystem.Services
{
    public interface IClinicService
    {
        void AddClinic(Clinic clinic);
        IEnumerable<Clinic> GetAllClinic();
    }
}