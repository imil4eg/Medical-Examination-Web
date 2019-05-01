﻿// <auto-generated />
using System;
using MedicalExamination.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace MedicalExaminationWeb.Migrations
{
    [DbContext(typeof(MedicalExaminationContext))]
    [Migration("20190324195159_AddedServiceResultEntity")]
    partial class AddedServiceResultEntity
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.8-servicing-32085")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MedicalExamination.Entities.ApplicationRole", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("MedicalExamination.Entities.ApplicationUser", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("Password")
                        .IsRequired();

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(256);

                    b.Property<int>("WorkerId");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.HasIndex("WorkerId")
                        .IsUnique();

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("MedicalExamination.Entities.Appointment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("DiseaseOutcomeId");

                    b.Property<DateTime>("EndDate");

                    b.Property<Guid>("ExaminationResultId");

                    b.Property<int>("PatientId");

                    b.Property<int>("WorkerId");

                    b.HasKey("Id");

                    b.HasIndex("DiseaseOutcomeId");

                    b.HasIndex("ExaminationResultId");

                    b.HasIndex("PatientId")
                        .IsUnique();

                    b.HasIndex("WorkerId");

                    b.ToTable("Appointments");
                });

            modelBuilder.Entity("MedicalExamination.Entities.DiseaseOutcomeType", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("DiseaseOutcomeTypes");
                });

            modelBuilder.Entity("MedicalExamination.Entities.ExaminationResultType", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("ExaminationResultTypes");
                });

            modelBuilder.Entity("MedicalExamination.Entities.InsuranceCompanyType", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("InsuranceCompanyTypes");
                });

            modelBuilder.Entity("MedicalExamination.Entities.PassportIssuePlaceType", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("PassportIssuePlaceTypes");
                });

            modelBuilder.Entity("MedicalExamination.Entities.Patient", b =>
                {
                    b.Property<int>("PersonId");

                    b.Property<Guid>("InsuranceCompanyId");

                    b.Property<string>("InsuranceNumber")
                        .IsRequired();

                    b.HasKey("PersonId");

                    b.HasIndex("InsuranceCompanyId");

                    b.ToTable("Patients");
                });

            modelBuilder.Entity("MedicalExamination.Entities.Person", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("BirthDate");

                    b.Property<string>("FirstName")
                        .IsRequired();

                    b.Property<int>("Gender");

                    b.Property<string>("INN");

                    b.Property<string>("LastName")
                        .IsRequired();

                    b.Property<string>("MiddleName");

                    b.Property<DateTime>("PassportIssueDate");

                    b.Property<Guid>("PassportIssuePlaceId");

                    b.Property<string>("PassportNumber");

                    b.Property<string>("PassportSeries");

                    b.Property<string>("SNILS");

                    b.HasKey("Id");

                    b.HasIndex("PassportIssuePlaceId");

                    b.ToTable("Persons");
                });

            modelBuilder.Entity("MedicalExamination.Entities.Position", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("PositionId");

                    b.Property<int>("WorkerId");

                    b.HasKey("Id");

                    b.HasIndex("PositionId");

                    b.HasIndex("WorkerId");

                    b.ToTable("Positions");
                });

            modelBuilder.Entity("MedicalExamination.Entities.PositionType", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("PositionTypes");
                });

            modelBuilder.Entity("MedicalExamination.Entities.ProvideService", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("PositionId");

                    b.Property<Guid>("ServiceId");

                    b.HasKey("Id");

                    b.HasIndex("PositionId");

                    b.HasIndex("ServiceId");

                    b.ToTable("ProvideServices");
                });

            modelBuilder.Entity("MedicalExamination.Entities.QuestionnaireAfter75", b =>
                {
                    b.Property<Guid>("AppointmentId");

                    b.Property<bool>("QuestionEight");

                    b.Property<bool>("QuestionEighteen");

                    b.Property<bool>("QuestionEleven");

                    b.Property<bool>("QuestionFifteen");

                    b.Property<bool>("QuestionFive");

                    b.Property<bool>("QuestionFour");

                    b.Property<bool>("QuestionFourteen");

                    b.Property<bool>("QuestionNine");

                    b.Property<bool>("QuestionNineteen");

                    b.Property<bool>("QuestionOneFive");

                    b.Property<bool>("QuestionOneFour");

                    b.Property<bool>("QuestionOneFourOne");

                    b.Property<bool>("QuestionOneOne");

                    b.Property<bool>("QuestionOneOneOne");

                    b.Property<bool>("QuestionOneSeven");

                    b.Property<bool>("QuestionOneSix");

                    b.Property<bool>("QuestionOneThree");

                    b.Property<string>("QuestionOneThreeOne");

                    b.Property<bool>("QuestionOneTwo");

                    b.Property<bool>("QuestionOneTwoOne");

                    b.Property<bool>("QuestionSeven");

                    b.Property<bool>("QuestionSeventeen");

                    b.Property<bool>("QuestionSix");

                    b.Property<bool>("QuestionSixteen");

                    b.Property<bool>("QuestionTen");

                    b.Property<bool>("QuestionThirteen");

                    b.Property<bool>("QuestionThree");

                    b.Property<bool>("QuestionTwelve");

                    b.Property<bool>("QuestionTwenty");

                    b.Property<bool>("QuestionTwentyFour");

                    b.Property<bool>("QuestionTwentyOne");

                    b.Property<bool>("QuestionTwentyThree");

                    b.Property<bool>("QuestionTwentyTwo");

                    b.Property<bool>("QuestionTwo");

                    b.HasKey("AppointmentId");

                    b.ToTable("QuestionnaireAfter75");
                });

            modelBuilder.Entity("MedicalExamination.Entities.QuestionnaireTill75", b =>
                {
                    b.Property<Guid>("AppointmentId");

                    b.Property<bool>("QuestionEight");

                    b.Property<bool>("QuestionEighteen");

                    b.Property<bool>("QuestionEleven");

                    b.Property<bool>("QuestionFifteen");

                    b.Property<bool>("QuestionFive");

                    b.Property<bool>("QuestionFour");

                    b.Property<bool>("QuestionFourteen");

                    b.Property<bool>("QuestionNine");

                    b.Property<bool>("QuestionNineteen");

                    b.Property<bool>("QuestionOneEight");

                    b.Property<bool>("QuestionOneFive");

                    b.Property<bool>("QuestionOneFour");

                    b.Property<bool>("QuestionOneNine");

                    b.Property<string>("QuestionOneNineOne");

                    b.Property<bool>("QuestionOneOne");

                    b.Property<bool>("QuestionOneOneOne");

                    b.Property<bool>("QuestionOneSeven");

                    b.Property<bool>("QuestionOneSix");

                    b.Property<bool>("QuestionOneSixOne");

                    b.Property<bool>("QuestionOneTen");

                    b.Property<bool>("QuestionOneTenOne");

                    b.Property<bool>("QuestionOneThree");

                    b.Property<bool>("QuestionOneTwo");

                    b.Property<int>("QuestionSeven");

                    b.Property<bool>("QuestionSeventeen");

                    b.Property<bool>("QuestionSix");

                    b.Property<bool>("QuestionSixteen");

                    b.Property<bool>("QuestionTen");

                    b.Property<bool>("QuestionThirteen");

                    b.Property<bool>("QuestionThree");

                    b.Property<bool>("QuestionTwelve");

                    b.Property<int>("QuestionTwenty");

                    b.Property<int>("QuestionTwentyFive");

                    b.Property<bool>("QuestionTwentyFour");

                    b.Property<bool>("QuestionTwentyOne");

                    b.Property<int>("QuestionTwentySeven");

                    b.Property<int>("QuestionTwentySix");

                    b.Property<bool>("QuestionTwentyThree");

                    b.Property<bool>("QuestionTwentyTwo");

                    b.Property<bool>("QuestionTwo");

                    b.HasKey("AppointmentId");

                    b.ToTable("QuestionnaireTill75");
                });

            modelBuilder.Entity("MedicalExamination.Entities.ServiceResult", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("AppointmentId");

                    b.Property<string>("Description");

                    b.Property<string>("Result");

                    b.Property<Guid>("ServiceTypeId");

                    b.Property<string>("TubeNumber");

                    b.HasKey("Id");

                    b.HasIndex("AppointmentId");

                    b.HasIndex("ServiceTypeId");

                    b.ToTable("ServiceResult");
                });

            modelBuilder.Entity("MedicalExamination.Entities.ServiceType", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("ServiceTypes");
                });

            modelBuilder.Entity("MedicalExamination.Entities.Worker", b =>
                {
                    b.Property<int>("PersonId");

                    b.HasKey("PersonId");

                    b.ToTable("Workers");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<Guid>("RoleId");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<Guid>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<Guid>("UserId");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId");

                    b.Property<Guid>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("MedicalExamination.Entities.ApplicationUser", b =>
                {
                    b.HasOne("MedicalExamination.Entities.Worker", "Worker")
                        .WithOne()
                        .HasForeignKey("MedicalExamination.Entities.ApplicationUser", "WorkerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MedicalExamination.Entities.Appointment", b =>
                {
                    b.HasOne("MedicalExamination.Entities.DiseaseOutcomeType", "Outcome")
                        .WithMany()
                        .HasForeignKey("DiseaseOutcomeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MedicalExamination.Entities.ExaminationResultType", "ExaminationResult")
                        .WithMany()
                        .HasForeignKey("ExaminationResultId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MedicalExamination.Entities.Patient", "Patient")
                        .WithOne()
                        .HasForeignKey("MedicalExamination.Entities.Appointment", "PatientId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("MedicalExamination.Entities.Worker", "Worker")
                        .WithMany()
                        .HasForeignKey("WorkerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MedicalExamination.Entities.Patient", b =>
                {
                    b.HasOne("MedicalExamination.Entities.InsuranceCompanyType", "InsuranceCompany")
                        .WithMany()
                        .HasForeignKey("InsuranceCompanyId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MedicalExamination.Entities.Person", "Person")
                        .WithOne()
                        .HasForeignKey("MedicalExamination.Entities.Patient", "PersonId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("MedicalExamination.Entities.Person", b =>
                {
                    b.HasOne("MedicalExamination.Entities.PassportIssuePlaceType", "PassportIssuePlace")
                        .WithMany()
                        .HasForeignKey("PassportIssuePlaceId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MedicalExamination.Entities.Position", b =>
                {
                    b.HasOne("MedicalExamination.Entities.PositionType", "PositionType")
                        .WithMany()
                        .HasForeignKey("PositionId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MedicalExamination.Entities.Worker", "Worker")
                        .WithMany()
                        .HasForeignKey("WorkerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MedicalExamination.Entities.ProvideService", b =>
                {
                    b.HasOne("MedicalExamination.Entities.PositionType", "Position")
                        .WithMany()
                        .HasForeignKey("PositionId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MedicalExamination.Entities.ServiceType", "Service")
                        .WithMany()
                        .HasForeignKey("ServiceId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MedicalExamination.Entities.QuestionnaireAfter75", b =>
                {
                    b.HasOne("MedicalExamination.Entities.Appointment", "Appointment")
                        .WithMany()
                        .HasForeignKey("AppointmentId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MedicalExamination.Entities.QuestionnaireTill75", b =>
                {
                    b.HasOne("MedicalExamination.Entities.Appointment", "Appointment")
                        .WithMany()
                        .HasForeignKey("AppointmentId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MedicalExamination.Entities.ServiceResult", b =>
                {
                    b.HasOne("MedicalExamination.Entities.Appointment", "Appointment")
                        .WithMany()
                        .HasForeignKey("AppointmentId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MedicalExamination.Entities.ServiceType", "ServiceType")
                        .WithMany()
                        .HasForeignKey("ServiceTypeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MedicalExamination.Entities.Worker", b =>
                {
                    b.HasOne("MedicalExamination.Entities.Person", "Person")
                        .WithMany()
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.HasOne("MedicalExamination.Entities.ApplicationRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.HasOne("MedicalExamination.Entities.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.HasOne("MedicalExamination.Entities.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.HasOne("MedicalExamination.Entities.ApplicationRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MedicalExamination.Entities.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.HasOne("MedicalExamination.Entities.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}