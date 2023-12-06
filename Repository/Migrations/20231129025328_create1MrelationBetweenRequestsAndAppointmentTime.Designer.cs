﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Repository;

#nullable disable

namespace Repository.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20231129025328_create1MrelationBetweenRequestsAndAppointmentTime")]
    partial class create1MrelationBetweenRequestsAndAppointmentTime
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Core.Domain.Appointment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("DoctorId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DoctorId");

                    b.ToTable("Appointments");
                });

            modelBuilder.Entity("Core.Domain.AppointmentDay", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AppointmentId")
                        .HasColumnType("int");

                    b.Property<int>("DayOfWeek")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AppointmentId");

                    b.ToTable("AppointmentDayOfWeek");
                });

            modelBuilder.Entity("Core.Domain.AppointmentTime", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AppointmentDayId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Time")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("AppointmentDayId");

                    b.ToTable("AppointmentTimes");
                });

            modelBuilder.Entity("Core.Domain.DiscountCodeCoupon", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("DiscountType")
                        .HasColumnType("int");

                    b.Property<bool>("IsActivated")
                        .HasColumnType("bit");

                    b.Property<int>("Value")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("DiscountCodeCoupons");
                });

            modelBuilder.Entity("Core.Domain.Doctor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("PersonId")
                        .HasColumnType("int");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.Property<int>("SpecializationId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PersonId");

                    b.HasIndex("SpecializationId");

                    b.ToTable("Doctors");
                });

            modelBuilder.Entity("Core.Domain.Patient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("PersonId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PersonId");

                    b.ToTable("Patients");
                });

            modelBuilder.Entity("Core.Domain.Person", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Persons");
                });

            modelBuilder.Entity("Core.Domain.Request", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AppointmentTimeId")
                        .HasColumnType("int");

                    b.Property<int>("DiscountCodeCouponId")
                        .HasColumnType("int");

                    b.Property<int>("DoctorId")
                        .HasColumnType("int");

                    b.Property<int>("PatientId")
                        .HasColumnType("int");

                    b.Property<int>("RequestState")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AppointmentTimeId");

                    b.HasIndex("DiscountCodeCouponId");

                    b.HasIndex("DoctorId");

                    b.HasIndex("PatientId");

                    b.ToTable("Requests");
                });

            modelBuilder.Entity("Core.Domain.Specialization", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Specializations");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Psychiatry(Mental, Emotional or Behavioral Disorders)"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Dentistry(Teeth)"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Pediatrics and New Born(Child)"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Orthopedics(Bones)"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Genecology and Infertility"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Ear, Nose and Throat"
                        },
                        new
                        {
                            Id = 7,
                            Name = "Andrology and Male Infertility"
                        },
                        new
                        {
                            Id = 8,
                            Name = "Allergy and Immunology(Sensitivity and Immunity)"
                        },
                        new
                        {
                            Id = 9,
                            Name = "Cardiology and Vascular Disease(Heart)"
                        },
                        new
                        {
                            Id = 10,
                            Name = "Audiology"
                        },
                        new
                        {
                            Id = 11,
                            Name = "Cardiology and Thoracic Surgery(Heart & Chest)"
                        },
                        new
                        {
                            Id = 12,
                            Name = "Chest and Respiratory"
                        },
                        new
                        {
                            Id = 13,
                            Name = "Dietitian and Nutrition"
                        },
                        new
                        {
                            Id = 14,
                            Name = "Diagnostic Radiology(Scan Centers)"
                        },
                        new
                        {
                            Id = 15,
                            Name = "Diabetes and Endocrinology"
                        });
                });

            modelBuilder.Entity("Core.Domain.Appointment", b =>
                {
                    b.HasOne("Core.Domain.Doctor", "Doctor")
                        .WithMany("Appointments")
                        .HasForeignKey("DoctorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Doctor");
                });

            modelBuilder.Entity("Core.Domain.AppointmentDay", b =>
                {
                    b.HasOne("Core.Domain.Appointment", "Appointment")
                        .WithMany("AppointmentsDayOfWeek")
                        .HasForeignKey("AppointmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Appointment");
                });

            modelBuilder.Entity("Core.Domain.AppointmentTime", b =>
                {
                    b.HasOne("Core.Domain.AppointmentDay", "AppointmentDay")
                        .WithMany("Time")
                        .HasForeignKey("AppointmentDayId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AppointmentDay");
                });

            modelBuilder.Entity("Core.Domain.Doctor", b =>
                {
                    b.HasOne("Core.Domain.Person", "Person")
                        .WithMany()
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Domain.Specialization", "Specialization")
                        .WithMany("Doctors")
                        .HasForeignKey("SpecializationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Person");

                    b.Navigation("Specialization");
                });

            modelBuilder.Entity("Core.Domain.Patient", b =>
                {
                    b.HasOne("Core.Domain.Person", "Person")
                        .WithMany()
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Person");
                });

            modelBuilder.Entity("Core.Domain.Request", b =>
                {
                    b.HasOne("Core.Domain.AppointmentTime", "AppointmentTime")
                        .WithMany()
                        .HasForeignKey("AppointmentTimeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Domain.DiscountCodeCoupon", "DiscountCodeCoupon")
                        .WithMany("Requests")
                        .HasForeignKey("DiscountCodeCouponId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Domain.Doctor", "Doctor")
                        .WithMany("Requests")
                        .HasForeignKey("DoctorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Domain.Patient", "Patient")
                        .WithMany("Requests")
                        .HasForeignKey("PatientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AppointmentTime");

                    b.Navigation("DiscountCodeCoupon");

                    b.Navigation("Doctor");

                    b.Navigation("Patient");
                });

            modelBuilder.Entity("Core.Domain.Appointment", b =>
                {
                    b.Navigation("AppointmentsDayOfWeek");
                });

            modelBuilder.Entity("Core.Domain.AppointmentDay", b =>
                {
                    b.Navigation("Time");
                });

            modelBuilder.Entity("Core.Domain.DiscountCodeCoupon", b =>
                {
                    b.Navigation("Requests");
                });

            modelBuilder.Entity("Core.Domain.Doctor", b =>
                {
                    b.Navigation("Appointments");

                    b.Navigation("Requests");
                });

            modelBuilder.Entity("Core.Domain.Patient", b =>
                {
                    b.Navigation("Requests");
                });

            modelBuilder.Entity("Core.Domain.Specialization", b =>
                {
                    b.Navigation("Doctors");
                });
#pragma warning restore 612, 618
        }
    }
}
