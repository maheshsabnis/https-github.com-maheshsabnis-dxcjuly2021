﻿// <auto-generated />
using CS_EF_Code_First.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CS_EF_Code_First.Migrations
{
    [DbContext(typeof(DxcCompanyDbContext))]
    [Migration("20210722065309_TablePerHierarchyMigration")]
    partial class TablePerHierarchyMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("CS_EF_Code_First.Models.Department", b =>
                {
                    b.Property<int>("DeptRowId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("Capacity")
                        .HasColumnType("int");

                    b.Property<string>("DeptName")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("DeptNo")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("DeptRowId");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("CS_EF_Code_First.Models.Doctor", b =>
                {
                    b.Property<int>("DoctorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("DoctorName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DoctorId");

                    b.ToTable("Doctors");
                });

            modelBuilder.Entity("CS_EF_Code_First.Models.Employee", b =>
                {
                    b.Property<int>("EmpRowId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("DeptRowId")
                        .HasColumnType("int");

                    b.Property<string>("EmpName")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("EmpNo")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("Salary")
                        .HasColumnType("int");

                    b.HasKey("EmpRowId");

                    b.HasIndex("DeptRowId");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("CS_EF_Code_First.Models.Patient", b =>
                {
                    b.Property<int>("PatientId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("PatientName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PatientId");

                    b.ToTable("Patients");
                });

            modelBuilder.Entity("CS_EF_Code_First.Models.ProductionUnit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ReleaseYear")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("ProductionUnit");

                    b.HasDiscriminator<string>("Discriminator").HasValue("ProductionUnit");
                });

            modelBuilder.Entity("DoctorPatient", b =>
                {
                    b.Property<int>("DoctorsDoctorId")
                        .HasColumnType("int");

                    b.Property<int>("PatientsPatientId")
                        .HasColumnType("int");

                    b.HasKey("DoctorsDoctorId", "PatientsPatientId");

                    b.HasIndex("PatientsPatientId");

                    b.ToTable("DoctorsPatients");
                });

            modelBuilder.Entity("CS_EF_Code_First.Models.Movies", b =>
                {
                    b.HasBaseType("CS_EF_Code_First.Models.ProductionUnit");

                    b.Property<string>("Category")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Collection")
                        .HasColumnType("int");

                    b.Property<int>("Duration")
                        .HasColumnType("int");

                    b.HasDiscriminator().HasValue("Movies");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Dr.No",
                            ReleaseYear = 1963,
                            Category = "Spy",
                            Collection = 300000,
                            Duration = 120
                        },
                        new
                        {
                            Id = 2,
                            Name = "Golmal",
                            ReleaseYear = 1976,
                            Category = "Comedy",
                            Collection = 60000,
                            Duration = 180
                        });
                });

            modelBuilder.Entity("CS_EF_Code_First.Models.WebSeries", b =>
                {
                    b.HasBaseType("CS_EF_Code_First.Models.ProductionUnit");

                    b.Property<int>("EpisodsPerSeason")
                        .HasColumnType("int");

                    b.Property<int>("NoOfSeasons")
                        .HasColumnType("int");

                    b.HasDiscriminator().HasValue("WebSeries");

                    b.HasData(
                        new
                        {
                            Id = 3,
                            Name = "Ramayan",
                            ReleaseYear = 1986,
                            EpisodsPerSeason = 70,
                            NoOfSeasons = 2
                        },
                        new
                        {
                            Id = 4,
                            Name = "CID",
                            ReleaseYear = 1998,
                            EpisodsPerSeason = 70,
                            NoOfSeasons = 50
                        });
                });

            modelBuilder.Entity("CS_EF_Code_First.Models.Employee", b =>
                {
                    b.HasOne("CS_EF_Code_First.Models.Department", "Department")
                        .WithMany("Employees")
                        .HasForeignKey("DeptRowId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");
                });

            modelBuilder.Entity("DoctorPatient", b =>
                {
                    b.HasOne("CS_EF_Code_First.Models.Doctor", null)
                        .WithMany()
                        .HasForeignKey("DoctorsDoctorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CS_EF_Code_First.Models.Patient", null)
                        .WithMany()
                        .HasForeignKey("PatientsPatientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CS_EF_Code_First.Models.Department", b =>
                {
                    b.Navigation("Employees");
                });
#pragma warning restore 612, 618
        }
    }
}
