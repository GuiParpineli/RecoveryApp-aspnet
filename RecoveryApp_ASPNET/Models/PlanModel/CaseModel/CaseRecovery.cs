using System.ComponentModel.DataAnnotations;

namespace RecoveryApp_ASPNET.Models.PlanModel.CaseModel
{
    public abstract class CaseRecovery
    {
        [Key]
        public abstract Guid Id { get; set; }
        public abstract DateTime Date { get; set; }
        public abstract string Stage { get; set; }
        public abstract double Value { get; set; }
        public abstract double CoverageValue { get; set; }
        public abstract string? PostCode { get; set; }
        public abstract string? Observation { get; set; }
        public abstract string? CaseType { get; set; }

    }
}
