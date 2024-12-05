﻿using HospitalSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace HospitalSystem
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Clinic> Clinic { get; set; }
        public DbSet<Appoinment> Appoinments { get; set; }
    }
}