using HospitalSystem.Models;
using HospitalSystem.Repositories;
using Microsoft.EntityFrameworkCore;

namespace HospitalSystem.Services
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IAppointmentRepo _appointmentRepo;
        private readonly IPatientService _patientService;
        private readonly IClinicService _clinicalService;

        public AppointmentService(IAppointmentRepo appointmentRepo, IPatientService patientService, IClinicService clinicService)
        {
            _appointmentRepo = appointmentRepo;
            _patientService = patientService;
            _clinicalService = clinicService;

        }

       public IEnumerable<Appoinment> GetAppointmentsByClinc(int cid)
        {
            return _appointmentRepo.GetAppointmentsByClinc(cid);
        }

        public IEnumerable<Appoinment> GetAppointmentsByPatient(int pid)
        {
            return _appointmentRepo.GetAppointmentsByPatient(pid);
        }

        //book Appointment
        public void BookAppointment(string pname, string cname, DateTime appDate)
        {
            var patients = _patientService.GetAllPatients();
            var clinics = _clinicalService.GetAllClinic();
            int slotNum = 0;
            int ReservedSlots = 0;

            Clinic clinic = null;
            Patient patient = null;

            foreach (var p in patients)
            {
                if (p.PName == pname)
                {
                    patient = p;
                }//if
            }//foreach patient

            if (patient == null)
                throw new InvalidOperationException("Invalid paitent name.");

            foreach (var c in clinics)
            {
                if (c.specilization == cname)
                {
                    //check if patient have appointment at same time
                    clinic = c;
                }
            }//foreach clinic

            if (clinic == null)
                throw new InvalidOperationException("Invalid clinc name.");

            var appointments = GetAppointmentsByClinc(clinic.CID);

            foreach (var appointment in appointments)
            {
                if (appointment.date == appDate)
                {
                    ReservedSlots++;
                    if (appointment.PID == patient.PID)
                    throw new InvalidOperationException("Patient have appointment in this day.");
                }

            }

            slotNum = appointments.Count() + 1;

            //appointments = GetAppointmentsByPatient(patient.PID);
            //foreach(var appointment in appointments)
            //{
            //    if(appointment.SlotNumber == slotNum && appointment.date == appDate)
            //        throw new InvalidOperationException("Patient have appointment in this slot.");
            //}

            slotNum = ReservedSlots + 1;
            if (slotNum > clinic.NumberOfSlots)
                throw new InvalidOperationException("NO appointment available on this day.");

            //add new appointment.
            var newAppointment = new Appoinment
            {
                CID = clinic.CID,
                PID = patient.PID,
                SlotNumber = slotNum,
                date = appDate
            };
            _appointmentRepo.BookAppointment(newAppointment);
        }

    }
}
