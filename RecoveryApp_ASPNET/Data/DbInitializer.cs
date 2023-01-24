using Microsoft.EntityFrameworkCore;
using RecoveryApp_ASPNET.Models;

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

        }
    }
}
