using System.ComponentModel.DataAnnotations;

namespace RecoveryApp_ASPNET.Models.PlanModel.CaseModel
{
    public class Sinistro : CaseRecovery
    {
        [Key]
        public override Guid Id { get; set; }
        public override DateTime Date { get; set; }
        public override string Stage { get;  set; }
        public override double Value { get; set; }
        public override double CoverageValue { get; set ; }
        public override string? PostCode { get; set; }
        public override string? Observation { get; set; }
        public override string? CaseType { get; set; }


        public DateTime InitialTime { get; set; }
        public string SinistroType { get; set; }
        public bool BoStatus { get; set; }
        public double Franchise { get; set; }
        public double FranchiseRate { get; set; }
        public double DiscountValue { get; set; }
        public bool Payment { get; set; }

    }
}
