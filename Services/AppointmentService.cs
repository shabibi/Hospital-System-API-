using HospitalSystem.Models;
using HospitalSystem.Repositories;
using Microsoft.EntityFrameworkCore;

namespace HospitalSystem.Services
{
    public class AppointmentService : IAppointmentService
    {
        private readonly AppointmentRepo _appointmentRepo;
        private readonly PatientService _patientService;
        private readonly ClinicService _clinicalService;

        public AppointmentService(AppointmentRepo appointmentRepo, PatientService patientService, ClinicService clinicService)
        {
            _appointmentRepo = appointmentRepo;
            _patientService = patientService;
            _clinicalService = clinicService;

        }

        public Appoinment GetAppointmentsByClinc(int cid)
        {
            return _appointmentRepo.GetAppointmentsByClinc(cid);
        }

        public Appoinment GetAppointmentsByPatient(int pid)
        {
            return _appointmentRepo.GetAppointmentsByPatient(pid);
        }

        //book Appointment
        public void BookAppointment(string pname, string cname, DateTime appDate)
        {
            var patients = _patientService.GetAllPatients();
            var clinics = _clinicalService.GetAllClinic();
            int slotNum = 0;
            Appoinment appintment = null;
            Appoinment Patient_appoinment = null;
            Clinic clinic = null;
            Patient patient = null;

            foreach (var p in patients)
            {
                if (p.PName == pname)
                {
                    Patient_appoinment = GetAppointmentsByPatient(p.PID);
                    patient = p;
                }//if
            }//foreach patient

            if (patient == null)
                throw new InvalidOperationException("Invalid paitent name.");

            foreach (var c in clinics)
            {
                if (c.specilization == cname)
                {
                    appintment = GetAppointmentsByClinc(c.CID);

                    //check if patient have appointment at same time
                    if (appintment != null && Patient_appoinment != null)
                    {
                        if (appintment == Patient_appoinment && appintment.date == appDate)
                            throw new InvalidOperationException("Patient have appointment in this day.");
                    }
                    clinic = c;
                    if (clinic.NumberOfSlots > appintment.SlotNumber)
                        slotNum = appintment.SlotNumber + 1;
                    else
                        throw new InvalidOperationException("No available appointment in this day.");

                }
            }//foreach clinic

            if (clinic == null)
                throw new InvalidOperationException("Invalid clinc name.");

            //add new appointment.
            var newAppointment = new Appoinment
            {
                CID = clinic.CID,
                PID = patient.PID,
                SlotNumber = slotNum,
                date = appDate
            };

        }

    }
}
