using HospitalSystem.Models;
using HospitalSystem.Repositories;
using Microsoft.EntityFrameworkCore;

namespace HospitalSystem.Services
{
    public class ClinicService : IClinicService
    {
        private readonly ClinicRepo _clinicRepo;

        public ClinicService(ClinicRepo clinicRepo)
        {
            _clinicRepo = clinicRepo;
        }
        public void AddClinic(Clinic clinic)
        {
            _clinicRepo.AddClinic(clinic);
        }
        public IEnumerable<Clinic> GetAllClinic()
        {
            return _clinicRepo.GetAllClinic().ToList();
        }
    }
}
