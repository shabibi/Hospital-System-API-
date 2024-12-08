using HospitalSystem.Models;

namespace HospitalSystem.Services
{
    public interface IAppointmentService
    {
        void BookAppointment(string pname, string cname, DateTime appDate);
        Appoinment GetAppointmentsByClinc(int cid);
        Appoinment GetAppointmentsByPatient(int pid);
    }
}