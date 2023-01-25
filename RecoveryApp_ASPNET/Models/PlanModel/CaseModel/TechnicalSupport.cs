using System.ComponentModel.DataAnnotations;

namespace RecoveryApp_ASPNET.Models.PlanModel.CaseModel
{
    public class TechnicalSupport : CaseRecovery
    {
        [Key]
        public override Guid Id { get; set; }
        public override DateTime Date { get; set; }
        public override string Stage { get; set; }
        public override double Value { get; set; }
        public override double CoverageValue { get; set; }
        public override string? PostCode { get; set; }
        public override string? Observation { get; set; }
        public override string? CaseType { get; set; }

        public double RepairValue { get; set; }
        public bool Status { get; set; }
    }
}
