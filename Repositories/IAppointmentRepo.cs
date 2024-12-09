using HospitalSystem.Models;

namespace HospitalSystem.Repositories
{
    public interface IAppointmentRepo
    {
        IEnumerable<Appoinment> GetAppointmentsByClinc(int cid);
        IEnumerable<Appoinment> GetAppointmentsByPatient(int pid);
        void BookAppointment(Appoinment appoinment);
    }
}