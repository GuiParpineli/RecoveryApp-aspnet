using Microsoft.EntityFrameworkCore;
using RecoveryApp_ASPNET.Models;
using RecoveryApp_ASPNET.Models.PlanModel;
using RecoveryApp_ASPNET.Models.PlanModel.CaseModel;
using System.Data;

namespace RecoveryApp_ASPNET.Data
{
    public class DbInitializer
    {
        private readonly ModelBuilder _builder;

        public DbInitializer(ModelBuilder builder)
        {
            _builder = builder;
        }

        public void Seed()
        {

            _builder.Entity<Address>(a =>
            {
                a.HasData(new Address
                {
                    Id = new Guid("90d10994-3bdd-4ca2-a178-6a35fd653c59"),
                    Street = "Rua das Flores",
                    City = "Berilo",
                    State = "MG",
                    ZipCode = "35485-300",
                    Country = "Brasil",
                    Complement = ""
                });
            });


            _builder.Entity<Customer>(a =>
            {
                a.HasData(new Customer
                {
                    Id = new Guid("98474b8e-d713-401e-8aee-acb7353f97bb"),
                    Name = "Paulo",
                    LastName = "Wilson",
                    Cpf = "14512-45",
                    Phone = "18 54754-46456",
                    Gender = GenderEnum.MASCULINO,
                    AddressId = new Guid("90d10994-3bdd-4ca2-a178-6a35fd653c59")
                });
            });

            _builder.Entity<Plan>(a =>
            {
                a.HasData(new Plan
                {
                    Id = new Guid("f7e82895-0783-470a-a0d6-48b0f2be68b6"),
                    IsActive = true,
                    Code = "XJ420",
                    Value = 2000.00,
                    RecidivistCustomer = false,
                    CustomerId = new Guid("98474b8e-d713-401e-8aee-acb7353f97bb")
                });
            });

            _builder.Entity<Sinistro>(a =>
            {
                a.HasData(new Sinistro
                {
                    Id = new Guid("be1a4c3d-d34c-4f21-9dee-c4bf841787fb"),
                    Date = DateTime.Now,
                    Stage = "EM_ABERTO",
                    Value = 200.0,
                    CoverageValue = 0,
                    InitialTime = DateTime.Now,
                    SinistroType = "FURTO",
                    BoStatus = true,
                    Franchise = 2000.0,
                    FranchiseRate = 0,
                    DiscountValue = 0,
                    Payment = false
                });
            });

            _builder.Entity<PlanCase>(a =>
            {
                a.HasData(new PlanCase
                {
                    PlanId = new Guid("f7e82895-0783-470a-a0d6-48b0f2be68b6"),
                    CaseId = new Guid("be1a4c3d-d34c-4f21-9dee-c4bf841787fb")
                });
            }
            );

        }
    }
}
