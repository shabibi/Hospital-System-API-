using HospitalSystem.Models;

namespace HospitalSystem.Services
{
    public interface IAppointmentService
    {
        void BookAppointment(string pname, string cname, DateTime appDate);
        IEnumerable<Appoinment> GetAppointmentsByClinc(int cid);
        IEnumerable<Appoinment> GetAppointmentsByPatient(int pid);
    }
}