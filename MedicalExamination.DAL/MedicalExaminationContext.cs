﻿using System;
using MedicalExamination.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MedicalExamination.DAL
{
    /// <summary>
    /// DataBase Context
    /// </summary>
    public sealed class MedicalExaminationContext : IdentityDbContext<ApplicationUser, ApplicationRole, Guid>
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="options"></param>
        public MedicalExaminationContext(DbContextOptions<MedicalExaminationContext> options) : base(options)
        {
            
        }

        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<DiseaseOutcomeType> DiseaseOutcomeTypes { get; set; }
        public DbSet<Worker> Workers { get; set; }
        public DbSet<ExaminationResultType> ExaminationResultTypes { get; set; }
        public DbSet<InsuranceCompanyType> InsuranceCompanyTypes { get; set; }
        public DbSet<PassportIssuePlaceType> PassportIssuePlaceTypes { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<PositionType> PositionTypes { get; set; }
        public DbSet<ProvideService> ProvideServices { get; set; }
        public DbSet<ServiceType> ServiceTypes { get; set; }
        public DbSet<ServiceResult> ServiceResults { get; set; }
        public DbSet<QuestionnaireAfter75> QuestionnaireAfter75 { get; set; }
        public DbSet<QuestionnaireTill75> QuestionnaireTill75 { get; set; }
        public DbSet<ServiceResult> ServicesResults { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            //{
            //    relationship    
            //}

            base.OnModelCreating(modelBuilder);
            
            modelBuilder.Entity<Worker>().HasKey(w => w.PersonId);
            modelBuilder.Entity<ApplicationUser>().HasOne(u => u.Worker).WithOne();
            modelBuilder.Entity<Patient>().HasOne(p => p.Person).WithOne().OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Appointment>().HasOne(p => p.Patient).WithOne().OnDelete(DeleteBehavior.Restrict);

        }
    }
}
