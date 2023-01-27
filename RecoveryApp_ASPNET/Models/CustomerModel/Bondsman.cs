using RecoveryApp_ASPNET.Models.PlanModel;
using System.ComponentModel.DataAnnotations;

namespace RecoveryApp_ASPNET.Models.CustomerModel
{
    public class Bondsman
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Cpf { get; set; }
        public string Phone { get; set; }
        public GenderEnum Gender { get; set; }
        public Guid? AddressId { get; set; }
        public Address? Address { get; set; }
        public List<Plan> Plans { get; set; }
    }
}
