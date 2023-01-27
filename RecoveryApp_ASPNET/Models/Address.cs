using System.ComponentModel.DataAnnotations;

namespace RecoveryApp_ASPNET.Models
{
    public class Address
    {
        [Key]
        public Guid Id { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string Country { get; set; }
        public string? Complement { get; set; }
        public List<Customer> Customers { get; set; }
        public List<Bondsman> Bondsmans { get; set; }
    }
}
