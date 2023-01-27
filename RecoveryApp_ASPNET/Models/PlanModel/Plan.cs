using System.ComponentModel.DataAnnotations;
using RecoveryApp_ASPNET.Models.CustomerModel;

namespace RecoveryApp_ASPNET.Models.PlanModel
{
    public class Plan
    {

        public Guid Id { get; set; }
        public bool IsActive { get; set; }
        public string Code { get; set; }
        public double Value { get; set; }
        public DateTime CreateAt { get; set; } = DateTime.Now;
        public DateTime? FinalDate { get; set; }
        public bool RecidivistCustomer { get; set; }
        public IList<PlanCase>? PLanCases { get; set; }
        public Guid? CustomerId { get; set; }
        public Customer? Customer { get; set; }
        public Guid? BondsmanId { get; set; }
        public Bondsman? Bondsman { get; set; }
    }
}
