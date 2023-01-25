﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RecoveryApp_ASPNET.Data;

#nullable disable

namespace RecoveryAppASPNET.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("RecoveryApp_ASPNET.Models.Address", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Complement")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ZipCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Address");

                    b.HasData(
                        new
                        {
                            Id = new Guid("90d10994-3bdd-4ca2-a178-6a35fd653c59"),
                            City = "Berilo",
                            Complement = "",
                            Country = "Brasil",
                            State = "MG",
                            Street = "Rua das Flores",
                            ZipCode = "35485-300"
                        });
                });

            modelBuilder.Entity("RecoveryApp_ASPNET.Models.Customer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("AddressId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Cpf")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.ToTable("Customers");

                    b.HasData(
                        new
                        {
                            Id = new Guid("98474b8e-d713-401e-8aee-acb7353f97bb"),
                            AddressId = new Guid("90d10994-3bdd-4ca2-a178-6a35fd653c59"),
                            Cpf = "14512-45",
                            Gender = 0,
                            LastName = "Wilson",
                            Name = "Paulo",
                            Phone = "18 54754-46456"
                        });
                });

            modelBuilder.Entity("RecoveryApp_ASPNET.Models.PlanModel.CaseModel.CaseRecovery", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CaseType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("CoverageValue")
                        .HasColumnType("float");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Observation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PostCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Stage")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Value")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("CaseRecovery");

                    b.HasDiscriminator<string>("Discriminator").HasValue("CaseRecovery");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("RecoveryApp_ASPNET.Models.PlanModel.Plan", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreateAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("CustomerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("FinalDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("RecidivistCustomer")
                        .HasColumnType("bit");

                    b.Property<double>("Value")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.ToTable("Plans");

                    b.HasData(
                        new
                        {
                            Id = new Guid("f7e82895-0783-470a-a0d6-48b0f2be68b6"),
                            Code = "XJ420",
                            CreateAt = new DateTime(2023, 1, 25, 20, 37, 5, 257, DateTimeKind.Local).AddTicks(1110),
                            CustomerId = new Guid("98474b8e-d713-401e-8aee-acb7353f97bb"),
                            IsActive = true,
                            RecidivistCustomer = false,
                            Value = 2000.0
                        });
                });

            modelBuilder.Entity("RecoveryApp_ASPNET.Models.PlanModel.PlanCase", b =>
                {
                    b.Property<Guid>("PlanId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CaseId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CaseRecoveryId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("PlanId", "CaseId");

                    b.HasIndex("CaseRecoveryId");

                    b.ToTable("PlanCases");
                });

            modelBuilder.Entity("RecoveryApp_ASPNET.Models.PlanModel.CaseModel.Missappropriation", b =>
                {
                    b.HasBaseType("RecoveryApp_ASPNET.Models.PlanModel.CaseModel.CaseRecovery");

                    b.Property<bool>("ChargeBack")
                        .HasColumnType("bit");

                    b.Property<DateTime>("ChargeBackDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("PayMethod")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("Missappropriation");
                });

            modelBuilder.Entity("RecoveryApp_ASPNET.Models.PlanModel.CaseModel.Sinistro", b =>
                {
                    b.HasBaseType("RecoveryApp_ASPNET.Models.PlanModel.CaseModel.CaseRecovery");

                    b.Property<bool>("BoStatus")
                        .HasColumnType("bit");

                    b.Property<double>("DiscountValue")
                        .HasColumnType("float");

                    b.Property<double>("Franchise")
                        .HasColumnType("float");

                    b.Property<double>("FranchiseRate")
                        .HasColumnType("float");

                    b.Property<DateTime>("InitialTime")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Payment")
                        .HasColumnType("bit");

                    b.Property<string>("SinistroType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("Sinistro");
                });

            modelBuilder.Entity("RecoveryApp_ASPNET.Models.PlanModel.CaseModel.TechnicalSupport", b =>
                {
                    b.HasBaseType("RecoveryApp_ASPNET.Models.PlanModel.CaseModel.CaseRecovery");

                    b.Property<double>("RepairValue")
                        .HasColumnType("float");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.HasDiscriminator().HasValue("TechnicalSupport");
                });

            modelBuilder.Entity("RecoveryApp_ASPNET.Models.Customer", b =>
                {
                    b.HasOne("RecoveryApp_ASPNET.Models.Address", "Address")
                        .WithMany("Customers")
                        .HasForeignKey("AddressId");

                    b.Navigation("Address");
                });

            modelBuilder.Entity("RecoveryApp_ASPNET.Models.PlanModel.Plan", b =>
                {
                    b.HasOne("RecoveryApp_ASPNET.Models.Customer", "Customer")
                        .WithMany("Plans")
                        .HasForeignKey("CustomerId");

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("RecoveryApp_ASPNET.Models.PlanModel.PlanCase", b =>
                {
                    b.HasOne("RecoveryApp_ASPNET.Models.PlanModel.CaseModel.CaseRecovery", "CaseRecovery")
                        .WithMany()
                        .HasForeignKey("CaseRecoveryId");

                    b.HasOne("RecoveryApp_ASPNET.Models.PlanModel.Plan", "Plan")
                        .WithMany("PLanCases")
                        .HasForeignKey("PlanId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CaseRecovery");

                    b.Navigation("Plan");
                });

            modelBuilder.Entity("RecoveryApp_ASPNET.Models.Address", b =>
                {
                    b.Navigation("Customers");
                });

            modelBuilder.Entity("RecoveryApp_ASPNET.Models.Customer", b =>
                {
                    b.Navigation("Plans");
                });

            modelBuilder.Entity("RecoveryApp_ASPNET.Models.PlanModel.Plan", b =>
                {
                    b.Navigation("PLanCases");
                });
#pragma warning restore 612, 618
        }
    }
}
